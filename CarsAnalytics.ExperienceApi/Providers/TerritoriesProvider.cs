using CarsAnalytics.ExperienceApi.Dto;

namespace CarsAnalytics.ExperienceApi.Providers;

public class TerritoriesProvider(HttpClient http) : ITerritoriesProvider
{
    private sealed class Envelope<T>
    {
        public T? Data { get; set; }
    }

    public async Task<IEnumerable<TerritoryDto>> GetByCountryAsync(string countryCode, CancellationToken ct = default)
    {
        var url = $"/api/Territories/{countryCode}"; 
        var envelope = await http.GetFromJsonAsync<Envelope<List<TerritoryDto>>>(url, cancellationToken: ct); 
        return envelope?.Data ?? [];
    }
}
