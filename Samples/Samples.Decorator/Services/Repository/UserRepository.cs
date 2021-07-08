using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Samples.Shared.Interfaces;
using Samples.Shared.Models;
namespace Samples.Decorator.Services.Repository
{
    /*
     * This class contains the actual implementation of on fetching the users from the API.
     * NOTE:
     * _httpClient.SendAsync(request).ConfigureAwait(false) -> Here we have set the ConfiguredAwait flag to false.
     *                                                         This would avoid forcing the callback to be invoked on the original Thread context.
     * Ref: https://devblogs.microsoft.com/dotnet/configureawait-faq/
     */
    public class UserRepository : IUserRepository
    {
        private readonly HttpClient _httpClient;
        
        private const string JsonPlaceHolderApiUrl = "https://jsonplaceholder.typicode.com/users";
        
        public UserRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async ValueTask<IEnumerable<User>> GetUsers()
        {
            var users = new List<User>();
            var request = new HttpRequestMessage(HttpMethod.Get, JsonPlaceHolderApiUrl);
            var response = await _httpClient.SendAsync(request).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                return users;
            }
                
            var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            users = JsonSerializer.Deserialize<List<User>>(responseString);
            return users;
        }
    }
}
