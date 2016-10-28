namespace NutsAndBrackets.Avi
{
    using System.Linq;
    using Models;
    using RestSharp;

    public class PoolsController : IPoolsController
    {
        private IRestClient restClient;
        
        public PoolsController(IRestClient restClient)
        {
            this.restClient = restClient;
        }

        public Pool GetByName(string name)
        {
            IRestRequest request = new RestRequest("pool-inventory", Method.GET);
            request.AddQueryParameter("name", name);

            var response = restClient.Execute<PoolInventory>(request);

            if (response != null)
            {
                if (response.ErrorException != null)
                    throw response.ErrorException;

                if (response.Data != null && response.Data.results != null && response.Data.results.Any())
                    return this.GetByUuid(response.Data.results.Single().uuid);
            }

            return null;
        }

        public Pool GetByUuid(string uuid)
        {
            IRestRequest request = new RestRequest("pool/{uuid}", Method.GET);
            request.AddUrlSegment("uuid", uuid);

            var response = restClient.Execute<Pool>(request);

            if (response.ErrorException != null)
                throw response.ErrorException;

            return response.Data;
        }

        public Pool Update(Pool pool)
        {
            IRestRequest request = new RestRequest("pool/{uuid}", Method.PUT);
            request.AddUrlSegment("uuid", pool.uuid);
            request.AddJsonBody(pool);

            var response = restClient.Execute<Pool>(request);

            if (response.ErrorException != null)
                throw response.ErrorException;

            return response.Data;
        }
    }
}