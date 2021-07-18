using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using RestService.Common;
using RestService.DTO;
using Services;
using static RestService.Properties.Settings;

namespace RestService
{
    public class ApiRestService: IAuthService, IClientService, IProductService, IAccountService
    {
        private Connector Connector { get; set; }

        public ApiRestService()
        {
            Connector = new Connector(Default.API_URL);
        }

        #region Public Methods
        public async Task<Client> Login(int clientId, int password)
        {
            var filters = new Dictionary<string, string>() {
                { "id", clientId.ToString() },
                { "pass", password.ToString() }
            };

            List<ClientDTO> clients = await GetClientList(filters);

            return clients.FirstOrDefault();
        }

        public async Task<Client> GetClient(int clientId)
        {
            var filters = new Dictionary<string, string>() {
                { "id", clientId.ToString() }
            };

            List<ClientDTO> clients = await GetClientList(filters);

            return clients.FirstOrDefault();
        }

        public async Task<List<Product>> GetProducts(int pClientId)
        {
            var filters = new Dictionary<string, string>() {
                { "id", pClientId.ToString() }
            };

            List<ClientProductsDTO> list = await GetClientProductsList(filters);
            ClientProductsDTO clientProducts = list.FirstOrDefault();

            if (clientProducts != null)
            {
                return clientProducts.Products.ConvertAll(item => (Product)item);
            }

            else
            {
                return new List<Product>();
            }
        }

        public async Task<AccountBalance> GetAccountBalance(int clientId)
        {
            var filters = new Dictionary<string, string>() {
                { "id", clientId.ToString() }
            };

            List<AccountBalanceDTO> list = await GetAccountBalanceList(filters);

            return list.FirstOrDefault();
        }

        public async Task<List<AccountMovement>> GetAccountMovements(int clientId)
        {
            var filters = new Dictionary<string, string>() {
                { "id", clientId.ToString() }
            };

            List<ClientAccountMovementsDTO> list = await GetClientAccountMovementsList(filters);
            ClientAccountMovementsDTO clientAccountMovements = list.FirstOrDefault();

            if (clientAccountMovements != null)
            {
                return clientAccountMovements.Movements.ConvertAll(item => (AccountMovement)item);
            }

            else {
                return new List<AccountMovement>();
            }
        }

        public async Task<ProductReset> ResetProduct(string productNumber)
        {
            var filters = new Dictionary<string, string>() {
                { "number", productNumber.ToString() }
            };

            List<ProductResetDTO> list = await GetProductResetList(filters);

            return list.FirstOrDefault();
        }
        #endregion

        #region Private Methods
        private async Task<List<ClientDTO>> GetClientList(Dictionary<string, string> filters)
        {
            Request request = new Request
            {
                Method = Method.GET,
                Path = Default.GET_CLIENTS_PATH,
                Params = filters
            };

            JsonResponse<List<ClientDTO>> response = await Connector.SendAsync<JsonResponse<List<ClientDTO>>>(request);

            return response.Entity;
        }

        private async Task<List<ClientProductsDTO>> GetClientProductsList(Dictionary<string, string> filters)
        {
            Request request = new Request
            {
                Method = Method.GET,
                Path = Default.GET_PRODUCTS_PATH,
                Params = filters
            };

            JsonResponse<List<ClientProductsDTO>> response = await Connector.SendAsync<JsonResponse<List<ClientProductsDTO>>>(request);

            return response.Entity;
        }

        private async Task<List<AccountBalanceDTO>> GetAccountBalanceList(Dictionary<string, string> filters)
        {
            Request request = new Request
            {
                Method = Method.GET,
                Path = Default.GET_ACCOUNT_BALANCE_PATH,
                Params = filters
            };

            JsonResponse<List<AccountBalanceDTO>> response = await Connector.SendAsync<JsonResponse<List<AccountBalanceDTO>>>(request);
            return response.Entity;
        }

        private async Task<List<ClientAccountMovementsDTO>> GetClientAccountMovementsList(Dictionary<string, string> filters)
        {
            Request request = new Request
            {
                Method = Method.GET,
                Path = Default.GET_ACCOUNT_MOVEMENTS_PATH,
                Params = filters
            };

            JsonResponse<List<ClientAccountMovementsDTO>> response = await Connector.SendAsync<JsonResponse<List<ClientAccountMovementsDTO>>>(request);

            return response.Entity;
        }

        private async Task<List<ProductResetDTO>> GetProductResetList(Dictionary<string, string> filters)
        {
            Request request = new Request
            {
                Method = Method.GET,
                Path = Default.GET_PRODUCT_RESET_PATH,
                Params = filters
            };

            JsonResponse<List<ProductResetDTO>> response = await Connector.SendAsync<JsonResponse<List<ProductResetDTO>>>(request);

            return response.Entity;
        }
        #endregion
    }
}