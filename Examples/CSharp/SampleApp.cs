using System;
using System.Linq;
using VirtualQNet;
using VirtualQNet.Lines;

namespace VirtualQNetCSharpSample
{
    class SampleApp
    {
        private const string API_KEY = "";
        private const string API_BASE_ADDRESS = "http://staging-api.virtualq.io";

        static void Main(string[] args)
        {
            Console.WriteLine("Starting asynchronous call");
            AsyunchronousCallSample();
            Console.WriteLine("Starting synchronous call");
            SynchronousCallSample();
        }

        private static void SynchronousCallSample()
        {
            var config = new VirtualQClientConfiguration
            {
                ApiBaseAddress = API_BASE_ADDRESS
            };

            using(var client = new VirtualQ(API_KEY, config))
            {
                var _params = new ListLinesParameters
                {
                    CallCenterId = 1
                };
                // Note the ussage of the Result property, this will perform a syncrhonous call to the method
                var result = client.Lines.ListLines(_params).Result;
                if (result.RequestWasSuccessful)
                {
                    var firstLine = result.Value.FirstOrDefault();
                    Console.WriteLine($"Call from {nameof(SynchronousCallSample)} complete: {firstLine}");
                }
                else
                {
                    Console.WriteLine($"Error from {nameof(SynchronousCallSample)}: {result.Error.Description}");
                }
            }
        }

        private static async void AsyunchronousCallSample()
        {
            var config = new VirtualQClientConfiguration
            {
                ApiBaseAddress = API_BASE_ADDRESS
            };

            using (var client = new VirtualQ(API_KEY, config))
            {
                var _params = new ListLinesParameters
                {
                    CallCenterId = 1
                };
                // Note the ussage of the async and await keywords, this will perform an asyncrhonous call to the method
                // The main thread will not be blocked
                var result = await client.Lines.ListLines(_params);
                if (result.RequestWasSuccessful)
                {
                    var firstLine = result.Value.FirstOrDefault();
                    Console.WriteLine($"Call from {nameof(SynchronousCallSample)} complete: {firstLine}");
                }
                else
                {
                    Console.WriteLine($"Error from {nameof(SynchronousCallSample)}: {result.Error.Description}");
                }
            }
        }
    }
}
