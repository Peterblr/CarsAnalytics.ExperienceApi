using APIResponseWrapper;
using CarsAnalytics.ExperienceApi.Dto;

namespace CarsAnalytics.ExperienceApi.Services;

public interface ITerritoryService
{
    Task<ApiResponse<IEnumerable<TerritoryDto>>> GetAsync(string countryCode, CancellationToken ct = default);
}
