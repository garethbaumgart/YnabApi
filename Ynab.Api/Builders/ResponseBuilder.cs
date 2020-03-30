using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Ynab.Api.Models;

namespace Ynab.Api.Builders
{
    public class ResponseBuilder
    {
        public static async Task<ApiResponse<T>> BuildResponse<T>(HttpResponseMessage rawResult)
        {
            var result = rawResult.Content == null ? new ApiResponse<T>() : await JsonSerializer.DeserializeAsync<ApiResponse<T>>(await rawResult.Content.ReadAsStreamAsync());
            result.StatusCode = rawResult.StatusCode;
            result.ReasonPhrase = rawResult.ReasonPhrase;
            result.IsSuccess = rawResult.IsSuccessStatusCode;
            return result;
        }
    }
}