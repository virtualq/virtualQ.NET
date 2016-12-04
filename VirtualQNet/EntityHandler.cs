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

        protected ErrorResult CreateErrorResult(CallResult callResult)
        {
            return new ErrorResult(
                callResult.ErrorStatus,
                callResult.ErrorCode,
                callResult.ErrorTitle,
                callResult.ErrorDescription);
        }
    }
}
