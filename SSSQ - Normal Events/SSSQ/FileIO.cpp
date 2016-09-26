#include "FileIO.h"

FileIO* FileIO::_instance = nullptr;

FileIO::FileIO()
{
	file.open("VisualizationFile.txt");
	file.close();
}

void FileIO::OutputScheduleEvent(std::string eventName, double time)
{
	file.open("VisualizationFile.txt", std::ofstream::app);
	file << "Scheduled " << eventName << " at " << time << std::endl;
	file.close();
}

void FileIO::OutputExecuteEvent(std::string eventName, double time)
{
	file.open("VisualizationFile.txt", std::ofstream::app);
	file << "Execute " << eventName << " at " << time << std::endl;
	file.close();
}

FileIO * FileIO::Instance()
{
	if (_instance == nullptr)
	{
		_instance = new FileIO();
	}
	return _instance;
}