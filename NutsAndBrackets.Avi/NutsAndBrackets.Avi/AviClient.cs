namespace NutsAndBrackets.Avi
{
    using System;
    using System.Linq;
    using RestSharp;
    using RestSharp.Authenticators;

    public class AviClient : IAviClient
    {
        private IPoolsController poolsController;
        private IRestClient restClient;

        public AviClient(IRestClient restClient) : this(new PoolsController(restClient))
        {
            this.restClient = restClient;
        }

        public AviClient(IPoolsController poolsController)
        {
            this.poolsController = poolsController;
        }

        public void AuthenticateAs(string username, string password)
        {
            restClient.Authenticator = new HttpBasicAuthenticator(username, password);
        }

        public void SetTenant(string name)
        {
            if (restClient.DefaultParameters != null)
            {
                restClient.RemoveDefaultParameter("X-Avi-Tenant");
            }
            restClient.AddDefaultHeader("X-Avi-Tenant", name);
        }

        public IPoolsController Pools
        {
            get
            {
                return poolsController;
            }
        }

        public IVirtualServicesController VirtualServices
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}