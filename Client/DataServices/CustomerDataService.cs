using LabEntity.Shared;
using System.Text.Json;

namespace BlazorDemoPart2.Client.DataServices
{
    public class CustomerDataService : ICustomerDataService
    {
        private readonly HttpClient? _httpClient;

        public CustomerDataService(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }

        public Task<Customer> AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers(bool refreshRequired = false)
        {
            var list = await JsonSerializer.DeserializeAsync<IEnumerable<Customer>>
                    (await _httpClient.GetStreamAsync($"api/customers"), 
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return list;
        }

        public async Task<Customer> GetCustomerDetails(int customerId)
        {
            return await JsonSerializer.DeserializeAsync<Customer>
                (await _httpClient.GetStreamAsync($"api/customers/{customerId}"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public Task UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
