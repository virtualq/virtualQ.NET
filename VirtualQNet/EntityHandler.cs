namespace VirtualQNet
{
    internal abstract class EntityHandler
    {
        public EntityHandler(ApiClient apiClient)
        {
            _ApiClient = apiClient;
        }

        protected ApiClient _ApiClient { get; }
    }
}
