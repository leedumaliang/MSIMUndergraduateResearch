#pragma once
#include <iostream>
#include <fstream>
#include <string>

// added headers for pipe
#include <Windows.h>
#include <stdio.h>
#include <conio.h>

class FileIO
{
public:	
	static FileIO *Instance();
	void OutputScheduleEvent(std::string eventName, double time);
	void OutputExecuteEvent(std::string eventName, double time);
private:
	FileIO();
	~FileIO();
	static FileIO *_instance;
	std::ofstream file;
	HANDLE hPipe;
};
