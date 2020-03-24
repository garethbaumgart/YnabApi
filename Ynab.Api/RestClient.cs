using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Ynab.Api.Builders;
using Ynab.Api.Interfaces;
using Ynab.Api.Models;

namespace Ynab.Api
{
    public class RestClient : IRestClient
    {
        private readonly string _apiToken;
        private readonly DefaultContractResolver _contractResolver;
        private readonly HttpClient _httpClient;
        private readonly IUriBuilder _uriBuilder;
        public RestClient(HttpClient httpClient,
            IUriBuilder uriBuilder, 
            string apiToken)
        {
            _httpClient = httpClient;
            _apiToken = apiToken;
            _contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            SetupHttpClient();
        }

        private void SetupHttpClient()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken);
        }
        
        public async Task<ApiResponse<AccountData>> GetAccounts(string budgetId)
        {
            var rawResult = await _httpClient.GetAsync(_uriBuilder.BuildGetAccountsUri(budgetId));
            ApiResponse<AccountData> result = await ResponseBuilder.BuildResponse<AccountData>(rawResult);
            return result;
        }
    }
}
