namespace Ynab.Api
{
    public interface IUriBuilder
    {
        string BuildGetAccountsUri(string budgetId);   
        string BuildGetTransactionsByAccount(string budgetId, string accountId);
        string BuildUploadTransactions(string budgetId);
    }
}