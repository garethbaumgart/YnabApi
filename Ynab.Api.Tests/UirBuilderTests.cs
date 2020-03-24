using Xunit;
using Ynab.Api.Interfaces;

namespace Ynab.Api.Tests
{
    public class UriBuilderTests
    {
        private const string BaseUri = "FakeBaseUri";
        public IUriBuilder DefaultUriBuilder
        {
            get{return new Builders.UriBuilder(BaseUri);}
        }

        [Fact]
        public void BuildGetAccountsUri()
        {
            //Arrange
            var budgetId = "FakeBudgetId";
            var expectedUri = $"{BaseUri}/budgets/{budgetId}/accounts";
            var uriBuilder = DefaultUriBuilder;
            
            //Act
            var actualUri = DefaultUriBuilder.BuildGetAccountsUri(budgetId);

            //Assert
            Assert.Equal(expectedUri, actualUri);
        }
    }
}
