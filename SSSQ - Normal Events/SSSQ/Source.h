#pragma once

#include <string>
#include "Distribution.h"
#include "Simulation.h"
#include "SSSQ.h"

class Source : public SimObj
{
public:
	Source(std::string name, SSSQ *sssq, Distribution *interarrivalTime);
	Source(std::string name, SSSQ *sssq, Distribution *interarrivalTime, int numGen);
private:
	class NextEntityEvent;
	SSSQ *_sssq;
	Distribution *_interarrivalTime;
	void NextEntity();
	std::string _name;
	int _numGen;
};