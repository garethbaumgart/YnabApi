using Xunit;

namespace Ynab.Api.Tests
{
    public class UriBuilderTests
    {
        private const string FakeBaseUri = "FakeBaseUri";
        private const string FakeBudgetId = "FakeBudgetId";
        private IUriBuilder _defaultUriBuilder;
        public IUriBuilder DefaultUriBuilder
        {
            get
            {
                if(_defaultUriBuilder == null)
                    _defaultUriBuilder = new Builders.UriBuilder(FakeBaseUri);
                return _defaultUriBuilder;
            }
        }

        [Fact]
        public void BuildGetAccountsUri()
        {
            //Arrange
            var expectedUri = $"{FakeBaseUri}/budgets/{FakeBudgetId}/accounts";
            var uriBuilder = DefaultUriBuilder;
            
            //Act
            var actualUri = DefaultUriBuilder.BuildGetAccountsUri(FakeBudgetId);

            //Assert
            Assert.Equal(expectedUri, actualUri);
        }

        [Fact]
        public void BuildGetTransactionsByAccountUri()
        {
            //Arrange
            var fakeAccountId = "FakeAccountId";
            var expectedUri = $"{FakeBaseUri}budgets/{FakeBudgetId}/accounts/{fakeAccountId}/transactions";

            //Act
            var actualUri = DefaultUriBuilder.BuildGetTransactionsByAccount(FakeBudgetId,fakeAccountId);

            //Asssert
            Assert.Equal(expectedUri, actualUri);
        }

        [Fact]
        public void BuildUploadTransactionsUri()
        {
            //Arrange
            var expectedUri = $"{FakeBaseUri}budgets/{FakeBudgetId}/transactions";

            //Act
            var actualUri = DefaultUriBuilder.BuildUploadTransactions(FakeBudgetId);

            //Assert
            Assert.Equal(expectedUri, actualUri);
        }
    }
}
