#include <iostream>
#include "Source.h"
#include "SSSQ.h"
#include "Sink.h"

using namespace std;

void main()
{
	cout << "Normal Events\n";
	Sink sink1("Sink1");
	SSSQ sssq1("SSSQ1", &sink1, new Triangular(1, 3, 5));
	Source source1A("Source1A", &sssq1, new Triangular(2, 3, 4), 15);
	Source source1B("Source1B", &sssq1, new Triangular(1, 2, 3), 10);
	Sink sink2("Sink2");
	SSSQ sssq2("SSSQ2", &sink2, new Triangular(1, 3, 5));
	Source source2A("Source2B", &sssq2, new Triangular(1, 3, 5), 10);
	Source source2B("Source2B", &sssq2, new Triangular(1, 2, 3), 15);
	Sink sink3("Sink3");
	SSSQ sssq3("SSSQ3", &sink3, new Triangular(1, 3, 5));
	Source source3A("Source3A", &sssq3, new Triangular(2, 3, 4), 5);
	Source source3B("Source3B", &sssq3, new Triangular(0, 2, 4), 10);

	RunSimulation();

	cout << "<enter> to terminate: ";
	cin.get();
}
