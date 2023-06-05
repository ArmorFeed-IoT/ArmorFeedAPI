using ArmorFeedApi.Geolocation.Domain.Model;

namespace ArmorFeedApi.Geolocation.Domain.Repositories
{
    public interface ILocationDataRepository
    {
        Task AddAsync(LocationData locationData);
    }
}
