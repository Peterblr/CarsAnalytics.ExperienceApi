using APIResponseWrapper;
using CarsAnalytics.ExperienceApi.Dto;
using CarsAnalytics.ExperienceApi.Providers;
using FluentValidation;

namespace CarsAnalytics.ExperienceApi.Services
{
    public class TerritoryService(ITerritoriesProvider provider, IValidator<TerritoryDto> validator) : ITerritoryService
    {
        public async Task<ApiResponse<IEnumerable<TerritoryDto>>> GetAsync(string countryCode, CancellationToken ct = default)
        {
            var items = await provider.GetByCountryAsync(countryCode, ct);

            foreach (var item in items)
            {
                var result = validator.Validate(item);
                if (!result.IsValid) throw new ValidationException(result.Errors);
            }
            return ApiResponse<IEnumerable<TerritoryDto>>.CreateSuccessResponse([.. items
                .OrderBy(t => t.Name, StringComparer.OrdinalIgnoreCase)
                .ThenBy(t => t.Code, StringComparer.OrdinalIgnoreCase)]);
        }
    }
}
