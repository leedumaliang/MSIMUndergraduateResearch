#pragma once

#include <string>
#include "Entity.h"

class Sink
{
public:
	Sink(std::string name);
	void Arrive(Entity *en);
private:
	std::string _name;
};