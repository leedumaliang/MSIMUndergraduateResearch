#include "FileIO.h"

FileIO* FileIO::_instance = nullptr;

FileIO::FileIO()
{
	file.open("VisualizationFile.txt");
	file.close();

	// connect to existing named pipe
	hPipe = CreateFile(TEXT("\\\\.\\pipe\\Pipe"),
					   GENERIC_READ | GENERIC_WRITE,
					   0,
					   NULL,
					   OPEN_EXISTING,
					   0,
					   NULL);


}

FileIO::~FileIO()
{
	CloseHandle(hPipe);
}

void FileIO::OutputScheduleEvent(std::string eventName, double time)
{
	file.open("VisualizationFile.txt", std::ofstream::app);
	file << "Scheduled " << eventName << " at " << time << std::endl;
	file.close();

	// write to pipe
	if (hPipe != INVALID_HANDLE_VALUE)
	{
		DWORD dwRead;
		DWORD dwWritten;
		char buffer[256];
//		int len = sprintf_s(buffer, "Scheduled %s at %f\n", eventName.c_str(), time);
		int len = sprintf_s(buffer, "%d %s %f\n", 0, eventName.c_str(), time);

		WriteFile(hPipe,
				  buffer,
				  len,
				  &dwWritten,
				  NULL);

		while (ReadFile(hPipe, buffer, sizeof(buffer) - 1, &dwRead, NULL) != FALSE)
		{
			// wait for response
			buffer[dwRead] = '\0';
			printf("%s", buffer);
			break;
		}
	}
	else
	{
		std::cerr << "Invalid Handle to Visualizer. Cannot write to pipe." << std::endl;
	}

	std::cout << "Event scheduled\n";
}

void FileIO::OutputExecuteEvent(std::string eventName, double time)
{
	file.open("VisualizationFile.txt", std::ofstream::app);
	file << "Execute " << eventName << " at " << time << std::endl;
	file.close();

	// write to pipe
	if (hPipe != INVALID_HANDLE_VALUE)
	{
		DWORD dwRead;
		DWORD dwWritten;
		char buffer[256];
//		int len = sprintf_s(buffer, "Execute %s at %f\n", eventName.c_str(), time);
		int len = sprintf_s(buffer, "%d %s %f\n", 1, eventName.c_str(), time);

		WriteFile(hPipe,
				  buffer,
				  len,
				  &dwWritten,
				  NULL);

		while (ReadFile(hPipe, buffer, sizeof(buffer) - 1, &dwRead, NULL) != FALSE)
		{
			// wait for response
			buffer[dwRead] = '\0';
			printf("%s", buffer);
			break;
		}
	}
	else
	{
		std::cerr << "Invalid Handle to Visualizer. Cannot write to pipe." << std::endl;
	}

	std::cout << "Event executed\n";
}

FileIO * FileIO::Instance()
{
	if (_instance == nullptr)
	{
		_instance = new FileIO();
	}
	return _instance;
}