#pragma once

#include <string>
#include "Simulation.h"
#include "Distribution.h"
#include "FIFO.h"
#include "Sink.h"

class SSSQ : public SimObj
{
public:
	SSSQ( std::string name, Sink *sink, Distribution *serviceTime);
	/*
		SSSQ
			Parameters:
				Sink*			sink			sink where entities leaving the sssq go
				Distribution*	serviceTime		distribution defining the service time for entities served by the server
			Return value:
				none
			Behavior:
				Constructor.  Saves the destination sink and service time distribution.
	*/

	void ScheduleArrivalIn(Time deltaT, Entity *en);
	void ScheduleArrivalAt(Time time, Entity *en);
	/*
		ScheduleArrival{In,At}
			Parameters:
				Time			{deltaT,time}	{delay before arrival, time of arrival}
				Entity*			en				arriving entity
			Return value:
				none
			Behavior:
				Entities are schedule to arrive.  At the scheduled time, the method Arrive is called and the entity is
				added to the queue.
	*/

private:
	enum ServerState { busy, idle };
	ServerState _state;
	FIFO<Entity> *_queue;
	Sink *_sink;
	Distribution *_serviceTime;
	bool _serverReserved;
	std::string _name;
	class ArriveEvent;
	class ServeEvent;
	class DepartEvent;
	void Arrive(Entity *en);
	void Serve();
	void Depart(Entity *en);
};
