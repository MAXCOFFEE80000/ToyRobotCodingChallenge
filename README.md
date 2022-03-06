[ENVIRONMENT]
This solution is a C# Console Application (.NET Framework) written in Visual Studio 2019.
.NET Framework version 4.7.2.
The application can be launched in the bin/Debug or the bin/Release folder.

[TESTS]
The tests cases are written using Unit Test.
The Unit Tests are in the Unit Test Project named ToyRobotTests.
The Unit Tests can be run through Tests -> Run All Tests.

[INPUT]
The input is received through the Console Application.
A few notes about the input: 
The commands are case-insensitive to make the application easier to use.
For the Place Command, I did not include the comma as part of the separator for the arguments.
	For example: PLACE 1 1 North is a valid command, while PLACE 1, 1, is invalid.
Spaces before or after the commands are invalid.
Spaces in between arguments makes the command invalid; place   1    1 north is invalid.