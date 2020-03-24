using Ynab.Api.Interfaces;

namespace Ynab.Api.Builders
{
    public class UriBuilder : IUriBuilder
    {
        private readonly string _baseUri;
        public UriBuilder(string baseUri = "https://api.youneedabudget.com/v1/")
        {
            _baseUri = baseUri;
        }
        
        public string BuildGetAccountsUri(string budgetId)
        {
            return $"{_baseUri}/budgets/{budgetId}/accounts";
        }
    }
}