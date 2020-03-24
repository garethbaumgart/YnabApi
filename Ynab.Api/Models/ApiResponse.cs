using System.Net;
using Newtonsoft.Json;

namespace Ynab.Api.Models
{
    public class ApiResponse<T>
    {
        [JsonProperty("data")]
        public T Data;
        [JsonProperty("error")]
        public Error Error;
        public bool IsSuccess;
        public  HttpStatusCode StatusCode;
        public string ReasonPhrase;
    }
}