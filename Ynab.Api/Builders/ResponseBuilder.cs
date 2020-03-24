using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Ynab.Api.Models;

namespace Ynab.Api.Builders
{
    public class ResponseBuilder
    {
        public static async Task<ApiResponse<T>> BuildResponse<T>(HttpResponseMessage rawResult)
        {
            var result = rawResult.Content == null ? new ApiResponse<T>() : JsonConvert.DeserializeObject<ApiResponse<T>>(await rawResult.Content?.ReadAsStringAsync());
            result.StatusCode = rawResult.StatusCode;
            result.ReasonPhrase = rawResult.ReasonPhrase;
            result.IsSuccess = rawResult.IsSuccessStatusCode;
            return result;
        }
    }
}