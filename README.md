# ServiceWrapper
A template for wrapping a console application in a windows service.

TODO: Forgot to add the appconfig entries for the logger

TODO: Write nice guide for people.

## Summary

* The code for the console app lives in a class library, the wrapper is just a wrapper for that code
* When you run in debug it runs as a console app
* In release configuration it produces a service and must be installed, will use the logger to keep you in the loop
