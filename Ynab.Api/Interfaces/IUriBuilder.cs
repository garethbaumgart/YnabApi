namespace Ynab.Api.Interfaces
{
    public interface IUriBuilder
    {
        string BuildGetAccountsUri(string budgetId);   
    }
}