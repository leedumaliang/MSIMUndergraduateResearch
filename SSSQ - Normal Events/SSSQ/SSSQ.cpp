#include <iostream>
#include "SSSQ.h"

using namespace std;

SSSQ::SSSQ(string name, Sink *sink, Distribution *serviceTime)
{
	_queue = new FIFO<Entity>(name);
	_state = idle;
	_sink = sink;
	_serviceTime = serviceTime;
	_serverReserved = false;
	_name = name;
}

class SSSQ::ArriveEvent : public Event
{
public:
	ArriveEvent(SSSQ *sssq, Entity *en)
	{
		_sssq = sssq;
		_en = en;
		name = "Arrive";
	}

	void Execute()
	{
		FileIO::Instance()->OutputExecuteEvent(name, GetCurrentSimTime());
		_sssq->Arrive(_en);
	}

	std::string GetName()
	{
		return name;
	}
private:
	SSSQ *_sssq;
	Entity *_en;
	std::string name;
};

void SSSQ::ScheduleArrivalAt(Time time, Entity *en)
{
	ScheduleEventAt(time, new ArriveEvent(this, en));
}

void SSSQ::ScheduleArrivalIn(Time deltaT, Entity *en)
{
	ScheduleEventIn(deltaT, new ArriveEvent(this, en));
}

class SSSQ::ServeEvent : public Event
{
public:
	ServeEvent(SSSQ *sssq)
	{
		_sssq = sssq;
		name = "Serve";
	}

	void Execute()
	{
		FileIO::Instance()->OutputExecuteEvent(name, GetCurrentSimTime());
		_sssq->Serve();
	}
	std::string GetName()
	{
		return name;
	}
private:
	SSSQ *_sssq;
	std::string name;
};

void SSSQ::Arrive(Entity *en)
{
	cout << GetCurrentSimTime() << ", SSSQ " << _name << ", Arrive, Entity " << en->GetID() << endl;
	_queue->AddEntity(en);
	if ((_state == idle) && (!_serverReserved)) {
		ScheduleEventIn(0, new ServeEvent(this));
		_serverReserved = true;
	}
}

class SSSQ::DepartEvent : public Event
{
public:
	DepartEvent(SSSQ *sssq, Entity *en)
	{
		_sssq = sssq;
		_en = en;
		name = "Depart";
	}

	void Execute()
	{
		FileIO::Instance()->OutputExecuteEvent(name, GetCurrentSimTime());
		_sssq->Depart(_en);
	}

	std::string GetName()
	{
		return name;
	}
private:
	SSSQ *_sssq;
	Entity *_en;
	std::string name;
};

/*
	SSSQ::Serve
		Parameters:
			none
		Return value:
			none
		Behavior:
			This method is called when an entity starts being served.  It schedules the entities departure.
*/
void SSSQ::Serve()
{
	Entity *en = _queue->GetEntity();
	cout << GetCurrentSimTime() << ", SSSQ " << _name << ", Serve, Entity " << en->GetID() << endl;
	_state = busy;
	_serverReserved = false;
	ScheduleEventIn(_serviceTime->GetRV(), new DepartEvent(this, en));
}

/*
	SSSQ::Depart
		Parameters:
			Entity*			en				entity starting to be served
		Return value:
			none
		Behavior:
			This method is called when an entity departs the SSSQ.  It sends the entity to the destination sink.
*/
void SSSQ::Depart(Entity *en)
{
	cout << GetCurrentSimTime() << ", SSSQ " << _name << ", Depart, Entity " << en->GetID() << endl;
	_sink->Arrive(en);
	_state = idle;
	if (!(_queue->IsEmpty()) && (!_serverReserved)) {
		ScheduleEventIn(0, new ServeEvent(this));
		_serverReserved = true;
	}
}
