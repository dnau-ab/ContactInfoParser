# Contact Info Parser

Parses input and creates contacts with Name, Phone Number, and Email if they are found

## Getting Started

### Prerequisites

Visual Studio with C# support

### Installing

##### On Windows

Building with Visual Studio:

```
Clone the repo and open the solution (.sln) file
Press "Start" and the application will build
Locate the executable file in the "ContactInfoParser\ContactInfoParser\bin\Debug" directory
```

## How To Use

### Running the Application

Locate the executable file in the "ContactInfoParser\ContactInfoParser\bin\Debug" directory and run the following commands in a command window

The files in the "Tests" directory will be run when no files are given as arguments when the program is executed.

##### Without file given as argument (using bash):
```
$ ./ContactInfoParser.exe
Looking for contacts in '../../Tests\ContactInfoEx1.txt'
Looking for contacts in '../../Tests\ContactInfoEx2.txt'
Looking for contacts in '../../Tests\ContactInfoEx3.txt'

Name: John Doe
Phone: 4105551234
Email: john.doe@entegrasystems.com

Name: Jane Doe
Phone: 4105551234
Email: Jane.doe@acmetech.com

Name: Bob Smith
Phone: 17035551259
Email: bsmith@abctech.com
```

##### With a file given as an argument (using bash):
```
$ ./ContactInfoParser.exe ../../Tests/ContactInfoEx1.txt

Name: John Doe
Phone: 4105551234
Email: john.doe@entegrasystems.com
```

## How it Works

1. A file is opened and all of its contents are read
2. Each line of the file contents is checked against several regular expressions (Name, Phone, Email)
	1. Once a phone number or email is found for a contact, it is not looked for again.
	2. Problems arise when looking for names in the business card information which includes the following:
	 	```
       Bob Smith
       Software Engineer
       Decision & Security Technologies
       ABC Technologies
       123 North 11th Street
       Suite 229
       Arlington, VA 22209
       Tel: +1 (703) 555-1259
       Fax: +1 (703) 555-1200
       bsmith@abctech.com
	 	```
        Lines such as "Software Engineer" and "ABC Technologies" match the regular expression for names but should not be recognized as one.
        
        Therefore, when a potential name is found, the first and last name are checked against a set of first and last names read in and initialized (only once!) when a BusinessCardParser is constructed.
        
        1. If the first name is in the first name set: +1 points
        2. If the last name is in the last name set: +2 points
        
    	The name with the highest score is selected