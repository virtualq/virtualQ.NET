# virutalq.NET
.NET Client for the virtualQ API

You can download the code and add the VirtualQNet project to your solution. Add a reference it by project.

## Usage

Create a virtualQ client by instanciating a VirtualQ class as follows:

```cs
        var apiKey = "XXXXXXXX"; // Assign your API Key
        using (IVirtualQ client = new VirtualQ(apiKey))
        {
            // Rest of the code ...
        }
```

Or you can provide additional information to set up proxy or time out configuration using the `VirtualQClientConfiguration` class as folows:

```cs
        VirtualQClientConfiguration configuration = new VirtualQClientConfiguration
        {
            ApiBaseAddress = "https://xxxxxxxxxxx.xxx" // Overrides the default API base Url
            Timeout = TimeSpan.FromMilliseconds(1500), // Sets Timeout to 1.5 seconds
            ProxyConfiguration = new WebProxy() // Sets proxy configuration using a WebProxy class
        };        
        var apiKey = "XXXXXXXX"; // Assign your API Key
        using (IVirtualQ client = new VirtualQ(apiKey, configuration))
        {
            // Rest of the code ...
        }
```

All properties in `VirtualQClientConfiguration` class are optional.

For more information:
[TimeSpan](https://msdn.microsoft.com/en-us/library/system.timespan(v=vs.110).aspx),
[WebProxy](https://msdn.microsoft.com/en-us/library/system.net.webproxy(v=vs.110).aspx)

VirtualQ class inherits from IDisposable. If the VirtualQ client is not instantiated inside of a `using` block, the Dispose method must be called in order to release managed resources when the client is no longer used.

```cs
        client.Dispose();
```

IVirtualQ is the interface of the VirtualQ class and defines several properties that represents a handler that matches an end point in the API:

```cs
        ILinesHandler Lines { get; }
        ILineGroupsHandler LineGroups { get; }
        ICallerHandler Callers { get; }
```

All methods in the handler interfaces are asynchronous. Here are a couple of samples on how to use them.

### ILinesHandler

`ILinesHandler` interface defines functionality that affects Lines API end point.

```cs
        Task<Result<bool>> IsVirtualQActive(long lineId);
```

Returns true if a line that matches the `lineId` parameter is active, otherwise  returns false.

```cs
        bool isVirtualQActive;
        long lineId = 3;

        var result = async client.Lines.IsVirtualQActive(lineId);

        if(result.RequestWasSuccessful) 
        {
            // You can collect the value returned by the API
            isVirtualQActive = result.Value;
        }
        else
        {
            // Something went wrong, verify the error object assigned to the Error property
            YourCustomErrorHandling(result.Error);
        }
```

### ILineGroupsHandler

`ILineGroupsHandler` interface defines functionality that affects Line Groups API end point.

```cs
        Task<Result> UpdateLineGroup(long lineGroupId, UpdateLineGroupParameters attributes);
```

Updates a Line Group that matches `lineGroupId` parameter with the information supplied in the `attributes` parameter. This method doesn't return an value from the API.

```cs
        long lineGroupIdToUpdate = 185;
        UpdateLineGroupParameters attributes = new UpdateLineGroupParameters
        {
            ServiceEwt = 300,
            ServiceCallersCount = 2,
            ServiceAverageTalkTime = 35,
            ServiceAgentsCount = 3,
            ServiceAgentList = new string[] { "A", "B", "C" }
        };

        Result result = async client.LineGroups.UpdateLineGroup(lineGroupIdToUpdate, attributes);

        if(!result.RequestWasSuccessful)
        {
            // Something went wrong, verify the error object assigned to the Error property
            YourCustomErrorHandling(result.Error);
        }
```


## Build Instructions

1. Open the solution in Visual Studio 2015.
2. Select **"Release"** in Solution Configurations dropdown.
3. Build with `Ctrl` + `Shift` + `B`.

The assemblies will be located under `VirtualQNet\bin\Release`.

## Running integration tests

1. Open the VirtualQNet.Tests project in Visual Studio 2015.
2. Open the App.config file and paste your API Key in the value attribute of the ApiKey option.
3. Open the Test Explorer tab.
4. Double click on a test name to show the test's code. You can modify any parameters there.
5. To run the test, right click on a test name in the Test Explorer tab and select Run Selected Tests.
6. If a test pass, watch you dashboard to see its effects.

**Important**: Some tests need to be executed in order to pass.