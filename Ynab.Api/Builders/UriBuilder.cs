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

        public string BuildGetTransactionsByAccount(string budgetId, string accountId)
        {
            return $"{_baseUri}budgets/{budgetId}/accounts/{accountId}/transactions";
        }

        public string BuildUploadTransactions(string budgetId)
        {
            return $"{_baseUri}budgets/{budgetId}/transactions";
        }
    }
}