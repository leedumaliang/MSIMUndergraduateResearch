#include <iostream>
#include "Source.h"

using namespace std;

class Source::NextEntityEvent : public Event
{
public:
	NextEntityEvent(Source *source)
	{ 
		_source = source; 
		name = "NextEntity";
	};
	void Execute()
	{
		FileIO::Instance()->OutputExecuteEvent(name, GetCurrentSimTime());
		_source->NextEntity();
	};
	std::string GetName()
	{
		return name;
	}
private:
	Source *_source;
	std::string name;
};

Source::Source(string name, SSSQ *sssq, Distribution *interarrivalTime)
{
	_sssq = sssq;
	_interarrivalTime = interarrivalTime;
	ScheduleEventIn(0.0, new NextEntityEvent(this));
	_name = name;
	_numGen = -1;
}

Source::Source(string name, SSSQ *sssq, Distribution *interarrivalTime, int numGen)
{
	_sssq = sssq;
	_interarrivalTime = interarrivalTime;
	ScheduleEventIn(0.0, new NextEntityEvent(this));
	_name = name;
	_numGen = numGen;
}

void Source::NextEntity()
{
	if ((_numGen == -1) || (_numGen > 0)) {
		if (_numGen > 0) _numGen--;
		Entity *en = new Entity;
		cout << GetCurrentSimTime() << ", " << _name << ", NextEntity, Entity " << en->GetID() << endl;
		_sssq->ScheduleArrivalIn(0,en);
		ScheduleEventIn(_interarrivalTime->GetRV(), new NextEntityEvent(this));
	}
}
