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
            var expectedData = new Fixture().Create<AccountData>();
            var expected = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonSerializer.Serialize(new ApiResponse<AccountData>{ Data = expectedData })),
                ReasonPhrase = "TestReasonPhrase"
            };

            //Act
            var actual = await ResponseBuilder.BuildResponse<AccountData>(expected);
            
            //Assert
            Assert.Equal(expectedData, actual.Data);
            Assert.Equal(expected.StatusCode, actual.StatusCode);
            Assert.Equal(expected.ReasonPhrase, actual.ReasonPhrase);
            Assert.Equal(expected.IsSuccessStatusCode, actual.IsSuccess);
        }
    }
}