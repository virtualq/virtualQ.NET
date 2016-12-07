# virutalq.NET
.NET Client for the virtualQ API

Add the VirtualQNet project to your solution. Add a reference to it by project.

Alternatively you can download the [the distribution package](https://github.com/virtualq/virtualQ.NET/tree/master/Distribution) and import the DLL into your project.

### General Requirements
- Compatible with .NET version 4.5
- Compile as DLL file

### Getting Started

- Create an account at the [virtualQ dashboard](https://dashboard.virtualq.io)
- Create a _Call Center_
- Create a _Line Group_
- Create a _Service Line_
- Find your _API Key_ on the dashboard. Click on your Email on top right.

> Note: _Line Groups_ can have several _Lines_ with the same properties like _EWT_ or _Number of Agents_. Instead of updating each line, you update the line group instead. In the simplest case, 1 _Line Group_ has 1 _Line_.

<br>

### Build Instructions

1. Open the solution in Visual Studio 2015.
2. Select **"Release"** in Solution Configurations dropdown.
3. Build with `Ctrl` + `Shift` + `B`.

The assemblies will be located under `VirtualQNet\bin\Release`.

<br>

### Running integration tests

1. Open the VirtualQNet.Tests project in Visual Studio 2015.
2. Open the App.config file and paste your API Key in the value attribute of the ApiKey option.
3. Open the Test Explorer tab.
4. Double click on a test name to show the test's code. You can modify any parameters there.
5. To run the test, right click on a test name in the Test Explorer tab and select Run Selected Tests.
6. If a test pass, watch you dashboard to see its effects.

> **Important**: Some tests need to be executed in order to pass.
