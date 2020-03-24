using System.Threading.Tasks;
using Ynab.Api.Models;

namespace Ynab.Api.Interfaces
{
    public interface IRestClient
    {
        Task<ApiResponse<AccountData>> GetAccounts(string budgetId);
    }
}