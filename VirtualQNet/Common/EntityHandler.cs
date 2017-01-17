using System;
using System.Collections.Generic;
using System.Linq;
using VirtualQNet.Common.Messages;
using VirtualQNet.Common.CallResults;
using VirtualQNet.Results;

namespace VirtualQNet.Common
{
    internal abstract class EntityHandler
    {
        public EntityHandler(ApiClient apiClient)
        {
            _ApiClient = apiClient;
        }

        protected ApiClient _ApiClient { get; }

        private U CreateApiMessage<T, U>(string type, T attributes, long? id = null) where U : ApiMessage<T>
        {
            var data = Activator.CreateInstance(typeof(U)) as U;
            data.Id = id;
            data.Type = type;
            data.Attributes = attributes;
            return data;
        }

        protected SingleApiMessage<U> CreateSingleMessage<T, U>(string type, T attributes, long? id = null) where U: ApiMessage<T>
        {
            var data = CreateApiMessage<T, U>(type, attributes, id);

            return new SingleApiMessage<U> { Data = data };
        }

        protected ArrayApiMessage<U> CreateArrayMessage<T, U>(IEnumerable<U> messages) where U: ApiMessage<T>
        {
            var data = messages.Select(m => CreateApiMessage<T, U>(m.Type, m.Attributes, m.Id));

            return new ArrayApiMessage<U> { Data = data };
        }

        protected ErrorResult CreateErrorResult(CallResult callResult)
        {
            if (callResult.Error == null) return new ErrorResult(0, null, null, null, null);

            return new ErrorResult(
                callResult.Error.Status,
                callResult.Error.Code,
                callResult.Error.Title,
                callResult.Error.Description,
                new ErrorSource(callResult.Error.Source?.Pointer));
        }
    }
}
