﻿using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Ynab.Api.Builders;
using Ynab.Api.Models;

namespace Ynab.Api
{
    public class RestClient : IRestClient
    {
        private readonly string _apiToken;
        private readonly HttpClient _httpClient;
        private readonly IUriBuilder _uriBuilder;
        public RestClient(HttpClient httpClient,
            IUriBuilder uriBuilder, 
            string apiToken)
        {
            _httpClient = httpClient;
            _uriBuilder = uriBuilder;
            _apiToken = apiToken;
            SetupHttpClient();
        }

        private void SetupHttpClient()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken);
        }

        private HttpContent BuildHttpContent(TransactionData transactionData)
        {
            return new StringContent(JsonSerializer.Serialize(transactionData));
        }
        
        public async Task<ApiResponse<AccountData>> GetAccounts(string budgetId)
        {
            var rawResult = await _httpClient.GetAsync(_uriBuilder.BuildGetAccountsUri(budgetId));
            ApiResponse<AccountData> result = await ResponseBuilder.BuildResponse<AccountData>(rawResult);
            return result;
        }

        public async Task<ApiResponse<TransactionData>> GetTransactions(string budgetId, string accountId)
        {
            var rawResult = await _httpClient.GetAsync(_uriBuilder.BuildGetTransactionsByAccount(budgetId, accountId));
            ApiResponse<TransactionData> result = await ResponseBuilder.BuildResponse<TransactionData>(rawResult);
            return result;
        }

        public async Task<ApiResponse<TransactionData>> UploadTransactions(string budgetId, IEnumerable<Transaction> transactions)
        {
            var transactionData = new TransactionData { Transactions = transactions };
            var rawResult = await _httpClient.PostAsync(_uriBuilder.BuildUploadTransactions(budgetId), BuildHttpContent(transactionData));
            ApiResponse<TransactionData> result = await ResponseBuilder.BuildResponse<TransactionData>(rawResult);
            return result;
        }
    }
}
