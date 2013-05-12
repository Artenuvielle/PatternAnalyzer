project by René Martin
Univerity of applied sciences, Leipzig
2013

This is a project which shall solve the given task for the 5th Coding Contest: DNA Sequencing.
It was developed and tested using Microsoft Visual Studio 2012 with .NET-Framework 4.5 (for details on the developers machine look at the bottom of the file).

This solution includes 3 C#-projects with the following namespaces:
	DNAPattern.Base         libary for data management and pattern scan logic (for detailed information about subnamespaces and included classes look below)
	DNAPattern.GUI          actual executable project which implements a graphical interface to use DNAPattern.Base
	DNAPattern.Test         unit tests for DNAPattern.Base

To find evidence that this whole solution works see \DNAPatter.Test\evidence.jpeg or build it and set the DNAPattern.GUI as StartUp project or run it manually.
Then click on FILE->Open and select the file located in \DNAPattern.Test\DNATest.txt. The given DNA sequence for this task is saved in this file.
On the left side you can see the input sequence and on the left side is a tab control which holds all the answers to the given questions.

Detailed information about the projects:
	DNAPattern.Base
		DNASequence     Class which implements methods to handle a DNA strand and work with it (like calling regular expressions or loading from textfiles)
		DNAScan         Abstract class which every scan class should implement
		DNAScanResult   Abstract class which every scan result class should implement
		DNAPattern.Base.Scan
			Scan1           Class to solve the first given task
			Scan2           Class to solve the second given task
			Scan3           Class to solve the third given task
			Scan4           Class to solve the fourth given task
			Scan5           Class to solve the fifth given task
			Scan6           Class to solve the sixth given task
			Scan7           Class to solve the seventh given task
		DNAPatterm.Base.ScanResults
			TextResult              Class to handle the result of a task which can be answered with a text
			AbsoluteNumberResult	Class to handle the result of a task which can be answered by a list of strings with integer values (e.g. for shares)
			DNASequenceResult       Class to handle the result of a task which can be answered with another DNA strand

Notes on the achitechture:
The task was to come up with a solution which could be production-quality code and easily expandable.
You might be concerned that the code has nearly no comments in it but this was intended and i will explain that.
First of all the DNAPattern.Test Project is only for testing. Therefore many comments in this project are unnessecary.
Secondly the DNAPattern.GUI Project. This one is only very roughly refactored and has nearly no comments because it shall only show how the DNAPattern.Base classes shall be used.
That project should only provide the requested runnable file. In addition it shows that the solution is very simple adeptable for different projects.
And finally: DNAPattern.Base
This is the core libary.
It implements mainly a class (DNASequence) which can handle all of the asked requests and many more.
It also has abstract classes which define how future scans and result types for new scans have to be implemented. This is a kind of a factory model which is implemented there.
But also this project has only a few comments. This is because I often had the issue that comments were outdated.
If many persons work on one project and they all have access to one method which had a comment to desribe what it does, it happens wuite easily that someone might change the function without changing the comment.
This is why I decided to make the function and variable names my comments. Each one of them may be very long but describes exactlic what is done in this function / with this variable. Not more and not less.

Some final thoughts about the implementation of the pattern serch:
I decided to use instantiated RegEx calls. I tried it with a self written deterministic mashine but the regex would be faster.
The reason why I instantiated it is here: http://www.dotnetperls.com/regex-performance. I did not choose the compiled method because it would mean less expandablity.

machine datails for deveolping machine:
	cpu: 4x3.2 GHz
	ram: 16 GB
	graphic card: NVidia GeForce 660 GTX 2GB
	os: Windows 8