Imports VirtualQNet
Imports VirtualQNet.Lines

Module SampleApp
    Private Const apiKey As String = ""
    Private Const apiBaseAddress As String = "http://staging-api.virtualq.io"

    Sub Main()
        Console.WriteLine("Starting asynchronous call")
        AsyunchronousCallSample()
        Console.WriteLine("Starting synchronous call")
        SynchronousCallSample()
    End Sub

    Private Sub SynchronousCallSample()
        Dim config As New VirtualQClientConfiguration()
        config.ApiBaseAddress = apiBaseAddress

        Using client As New VirtualQ(apiKey, config)
            Dim params As New ListLinesParameters
            params.CallCenterId = 1
            ' Note the ussage of the Result property, this will perform a syncrhonous call to the method
            Dim result = client.Lines.ListLines(params).Result
            If (result.RequestWasSuccessful) Then
                Dim firstLine = result.Value.FirstOrDefault()
                Console.WriteLine($"Call from {NameOf(SynchronousCallSample)} complete: {firstLine}")
            Else
                Console.WriteLine($"Error from {NameOf(SynchronousCallSample)}: {result.Error.Description}")
            End If
        End Using
    End Sub

    Private Async Sub AsyunchronousCallSample()
        Dim config As New VirtualQClientConfiguration()
        config.ApiBaseAddress = apiBaseAddress

        Using client As New VirtualQ(apiKey, config)
            Dim params As New ListLinesParameters
            params.CallCenterId = 1
            ' Note the ussage of the Async and Await keywords, this will perform an asyncrhonous call to the method
            ' The main thread will not be blocked
            Dim result = Await client.Lines.ListLines(params)
            If (result.RequestWasSuccessful) Then
                Dim firstLine = result.Value.FirstOrDefault()
                Console.WriteLine($"Call from {NameOf(AsyunchronousCallSample)} complete: {firstLine}")
            Else
                Console.WriteLine($"Error from {NameOf(AsyunchronousCallSample)}: {result.Error.Description}")
            End If
        End Using
    End Sub

End Module
