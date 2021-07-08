using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Samples.Shared.Interfaces;
using Samples.Shared.Models;
namespace Samples.Decorator.Services.Repository
{
    /*
     * This class is the wrapper around the original class.
     * This wrapper class adds additional functionality of in-memory caching dynamically without changing the existing class.
     * This wrapper calls intercepts the calls -> adds the caching mechanism -> forwards the call to the original class.
     * Benefits we have achieved:
     *  a) We have achieved the separation of concerns where-in the actual class is doing the network calls and the wrapper is adding behaviour without changing the original implementation.
     *  b) The class is now open for extension but closed for modification.
     *  c) In future, if we plan to introduce Redis caching instead of the In-Memory Caching, then it is easy to implement following the same pattern.
     */
    public class UserRepositoryCachingServiceDecorator : IUserRepository
    {

        private readonly IMemoryCache _cache;
        private readonly IUserRepository _innerUserRepository;

        public UserRepositoryCachingServiceDecorator(IUserRepository innerUserRepository, IMemoryCache cache)
        {
            _innerUserRepository = innerUserRepository;
            _cache = cache;
        }

        public async ValueTask<IEnumerable<User>> GetUsers()
        {
            const string cacheKey = "Users";
            if (_cache.TryGetValue<IEnumerable<User>>(cacheKey, out var listOfUsers))
                return listOfUsers;
            // if the cache is empty, go fetch the list from the API
            var newListOfUsers = await _innerUserRepository.GetUsers().ConfigureAwait(false);
            if (newListOfUsers == null) return newListOfUsers;
            // populate the cache with the fetched data
            _cache.Set(cacheKey, newListOfUsers, TimeSpan.FromSeconds(30));
            return newListOfUsers;

        }
    }
}
