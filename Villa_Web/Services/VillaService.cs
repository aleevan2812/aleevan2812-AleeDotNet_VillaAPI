using Villa_Utility;
using Villa_Web.Models;
using Villa_Web.Models.Dto;
using Villa_Web.Services.IServices;

namespace Villa_Web.Services;

public class VillaService : BaseService, IVillaService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly string villaUrl;

    public VillaService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
    {
        _clientFactory = clientFactory;
        villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");
        // "ServiceUrls:VillaAPI" is in appsettings.json
    }

    public Task<T> CreateAsync<T>(VillaCreateDTO dto)
    {
        return SendAsync<T>(new APIRequest
        {
            ApiType = SD.ApiType.POST,
            Data = dto,
            Url = villaUrl + "/api/villaAPI"
            // "/api/villaAPI" is in VillaAPIController
        });
    }

    public Task<T> DeleteAsync<T>(int id)
    {
        return SendAsync<T>(new APIRequest
        {
            ApiType = SD.ApiType.DELETE,
            Url = villaUrl + "/api/villaAPI/" + id
        });
    }

    public Task<T> GetAllAsync<T>()
    {
        return SendAsync<T>(new APIRequest
        {
            ApiType = SD.ApiType.GET,
            Url = villaUrl + "/api/villaAPI"
        });
    }

    public Task<T> GetAsync<T>(int id)
    {
        return SendAsync<T>(new APIRequest
        {
            ApiType = SD.ApiType.GET,
            Url = villaUrl + "/api/villaAPI/" + id
        });
    }

    public Task<T> UpdateAsync<T>(VillaUpdateDTO dto)
    {
        return SendAsync<T>(new APIRequest
        {
            ApiType = SD.ApiType.PUT,
            Data = dto,
            Url = villaUrl + "/api/villaAPI/" + dto.Id
        });
    }
}