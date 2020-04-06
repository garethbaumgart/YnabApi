using System.Collections.Generic;
using System.Threading.Tasks;
using Ynab.Api.Models;

namespace Ynab.Api
{
    public interface IRestClient
    {
        Task<ApiResponse<AccountData>> GetAccounts(string budgetId);
        Task<ApiResponse<TransactionData>> GetTransactions(string budgetId, string accountId);
        Task<ApiResponse<TransactionData>> UploadTransactions(string budgetId, IEnumerable<Transaction> transactions);
    }
}