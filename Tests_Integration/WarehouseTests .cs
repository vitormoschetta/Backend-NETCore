using System;
using System.Net.Http;
using System.Threading.Tasks;
using api;
using Newtonsoft.Json;
using Xunit;

namespace Tests_Integration
{
    public class WarehouseTests : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public WarehouseTests(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        [Fact]
        public async Task TestGetProductsAsync()
        {
            // Arrange
            var request = "/api/product";

            // Act
            var response = await Client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestGetProductItemAsync()
        {
            // Arrange
            var request = "/api/product/1";

            // Act
            var response = await Client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestPostProductItemAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/api/product",
                Body = new
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Product Teste",
                    Price = 1.99m,                   
                }
            };

            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestPutProductItemAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/api/Product/1",
                Body = new
                {
                    Id = "1",
                    Name = "Agenda 2021",
                    Price = 16.99m,
                }
            };

            // Act
            var response = await Client.PutAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            // Assert
            response.EnsureSuccessStatusCode();
        }

        // [Fact]
        // public async Task TestDeleteProductItemAsync()
        // {
        //     // Arrange

        //     var postRequest = new
        //     {
        //         Url = "/api/Product/1",
        //         Body = new
        //         {
        //             Id = "1",
        //         }
        //     };

        //     // Act
        //     var postResponse = await Client.PostAsync(postRequest.Url, ContentHelper.GetStringContent(postRequest.Body));
        //     var jsonFromPostResponse = await postResponse.Content.ReadAsStringAsync();

        //     var singleResponse = JsonConvert.DeserializeObject<SingleResponse<StockItem>>(jsonFromPostResponse);

        //     var deleteResponse = await Client.DeleteAsync(string.Format("/api/v1/Warehouse/StockItem/{0}", singleResponse.Model.StockItemID));

        //     // Assert
        //     postResponse.EnsureSuccessStatusCode();

        //     Assert.False(singleResponse.DidError);

        //     deleteResponse.EnsureSuccessStatusCode();
        // }
    }
}