#pragma once
#include <iostream>
#include <fstream>
#include <string>

class FileIO
{
public:
	FileIO();
	static FileIO *Instance();
	void OutputScheduleEvent(std::string eventName, double time);
	void OutputExecuteEvent(std::string eventName, double time);
private:
	static FileIO *_instance;
	std::ofstream file;
};
