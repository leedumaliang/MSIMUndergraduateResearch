// TestViz.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <string>
#include <fstream>

using namespace std;


int main()
{
	ofstream output;
	output.open("testvizoutput.txt");

	string input;
	while (input != "999")
	{
		getline(cin, input);
		output << "Viz: " << input << endl;
	}
	output << "END";
    return 0;
}

