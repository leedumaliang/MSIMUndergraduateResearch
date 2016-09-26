#include <iostream>
#include "Simulation.h"
#include "Sink.h"

using namespace std;

Sink::Sink(string name)
{
	_name = name;
}

void Sink::Arrive(Entity *en)
{
	cout << GetCurrentSimTime() << ", Sink " << _name << ", Arrive, Entity " << en->GetID() << endl;
}
