using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AutoFixture;
using Xunit;
using Ynab.Api.Builders;
using Ynab.Api.Models;

namespace Ynab.Api.Tests
{
    public class ResponseBuilderTests
    {
        [Fact]
        public async Task BuildResponse_WithNullContent_ReturnsResultWithNullData()
        {
            //Arrange
            var rawResult = new HttpResponseMessage(HttpStatusCode.OK);
            rawResult.Content = null;
            rawResult.ReasonPhrase = "TestReasonPhrase";

            //Act
            var actualResponse = await ResponseBuilder.BuildResponse<AccountData>(rawResult);
            
            //Assert
            Assert.Null(actualResponse.Data);
            Assert.Equal(actualResponse.ReasonPhrase, rawResult.ReasonPhrase);
            Assert.Equal(actualResponse.IsSuccess, rawResult.IsSuccessStatusCode);
            Assert.Equal(actualResponse.StatusCode, rawResult.StatusCode);
        }

        [Fact]
        public async Task BuildResponse_WithValidContent_ReturnsResultWithValidData()
        {
            //Arrange
            var rawResult = new HttpResponseMessage(HttpStatusCode.OK);
            var expected = new Fixture().Build<ApiResponse<AccountData>>().Create();
            rawResult.Content = new StringContent(JsonSerializer.Serialize(expected));
            rawResult.ReasonPhrase = "TestReasonPhrase";

            //Act
            var actual = await ResponseBuilder.BuildResponse<AccountData>(rawResult);
            
            //Assert
            //Todo - Fix commented assert
            //Assert.True(expected.Data.Equals(actual.Data));
            Assert.Equal(actual.Data.Accounts.Count(), expected.Data.Accounts.Count());
            Assert.Equal(actual.ReasonPhrase, rawResult.ReasonPhrase);
            Assert.Equal(actual.IsSuccess, rawResult.IsSuccessStatusCode);
            Assert.Equal(actual.StatusCode, rawResult.StatusCode);
        }
    }
}