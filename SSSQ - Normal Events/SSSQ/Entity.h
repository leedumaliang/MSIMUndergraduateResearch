#pragma once

class Entity
{
public:
	Entity();
	int GetID();
private:
	int _id;
	static int _nextID;
};
