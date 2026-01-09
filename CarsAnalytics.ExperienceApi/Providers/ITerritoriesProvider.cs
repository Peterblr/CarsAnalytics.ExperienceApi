using CarsAnalytics.ExperienceApi.Dto;

namespace CarsAnalytics.ExperienceApi.Providers;

public interface ITerritoriesProvider
{
    Task<IEnumerable<TerritoryDto>> GetByCountryAsync(string countryCode, CancellationToken ct = default);
}
