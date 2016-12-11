using System;
using VirtualQNet.Messages;
using VirtualQNet.Results;

namespace VirtualQNet
{
    internal abstract class EntityHandler
    {
        public EntityHandler(ApiClient apiClient)
        {
            _ApiClient = apiClient;
        }

        protected ApiClient _ApiClient { get; }

        protected SingleApiMessage<T> CreateMessage<T, U>(string type, U attributes, long? id = null) where T: ApiMessage<U>
        {
            T data = Activator.CreateInstance(typeof(T)) as T;
            data.Id = id;
            data.Type = type;
            data.Attributes = attributes;

            return new SingleApiMessage<T> { Data = data };
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
