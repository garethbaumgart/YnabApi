using AutoFixture;
using Moq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Ynab.Api.Models;

namespace Ynab.Api.Tests
{
    public class RestClientTests
    {
        private readonly Fixture _fixture = new Fixture();
        private readonly Mock<IUriBuilder> _mockUriBuilder = new Mock<IUriBuilder>();
        private const string _fakeUrl = "https://fakeurl.com/fake";

        [Fact]
        public async Task GetAcounts_AccountDataRetrieved_ReturnOkWithAccount()
        {
            // Arrange
            var expectedAccountData = _fixture.Create<AccountData>();

            var mockHandler = new MockHttpMessageHandler<AccountData>(expectedAccountData, HttpStatusCode.OK);

            var httpClient = new HttpClient(mockHandler);

            _mockUriBuilder
                .Setup(b => b.BuildGetAccountsUri(It.IsAny<string>()))
                .Returns(_fakeUrl);

            var client = new RestClient(httpClient, _mockUriBuilder.Object, "");

            // Act
            var result = await client.GetAccounts("");

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(expectedAccountData, result.Data);
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async Task GetTransactions_TransactionData_ReturnOkWithTransactionData()
        {
            // Arrange
            var expectedTransactionData = _fixture.Create<TransactionData>();

            var mockHandler = new MockHttpMessageHandler<TransactionData>(expectedTransactionData, HttpStatusCode.OK);

            var httpClient = new HttpClient(mockHandler);

            _mockUriBuilder
                .Setup(b => b.BuildGetTransactionsByAccount(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(_fakeUrl);
            
            var client = new RestClient(httpClient, _mockUriBuilder.Object, "");

            // Act
            var result = await client.GetTransactions("", "");

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(expectedTransactionData, result.Data);
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async Task UploadTransactions_TransactionUploaded_ReturnCreatedWithTransactionData()
        {
            // Arrange
            var expectedTransactionData = _fixture.Create<TransactionData>();

            var mockHandler = new MockHttpMessageHandler<TransactionData>(expectedTransactionData, HttpStatusCode.Created);

            var httpClient = new HttpClient(mockHandler);

            _mockUriBuilder
                .Setup(b => b.BuildUploadTransactions(It.IsAny<string>()))
                .Returns(_fakeUrl);
            
            var client = new RestClient(httpClient, _mockUriBuilder.Object, "");

            var requestTransactions = _fixture.CreateMany<Transaction>();

            // Act
            var result = await client.UploadTransactions("", requestTransactions);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(expectedTransactionData, result.Data);
            Assert.Equal(HttpStatusCode.Created, result.StatusCode);
            Assert.Equal(requestTransactions, mockHandler.GetRequestContent<TransactionData>().Transactions);
        }
    }

    public class MockHttpMessageHandler<T> : HttpMessageHandler
    {
        private readonly string _response;
        private readonly HttpStatusCode _statusCode;

        private string _requestContent;

        public MockHttpMessageHandler(T response, HttpStatusCode statusCode)
        {
            var apiResponse = new ApiResponse<T> { Data = response };
            _response = JsonSerializer.Serialize(apiResponse);
            _statusCode = statusCode;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (request.Content != null) // Could be a GET-request without a body
            {
                _requestContent = await request.Content.ReadAsStringAsync();
            }

            return new HttpResponseMessage
            {
                StatusCode = _statusCode,
                Content = new StringContent(_response)
            };
        }

        public TRequest GetRequestContent<TRequest>() =>
            JsonSerializer.Deserialize<TRequest>(_requestContent);
        
    }
}