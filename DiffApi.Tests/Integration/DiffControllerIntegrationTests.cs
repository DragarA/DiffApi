using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Castle.Components.DictionaryAdapter.Xml;
using DiffApi.Models;

namespace DiffApi.Tests.Integration
{
    public class DiffControllerIntegrationTests
    {
        [Fact]
        public async Task Put_ShoudReturn400()
        {
            var application = new DiffApiWebApplilcationFactory();
            var client = application.CreateClient();

            var requestBody = new DiffRequestModel
            {
                Data = null
            };
            
            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            var response = await client.PutAsync("/v1/diff/1/left", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        
        [Fact]
        public async Task PutLeft_ShoudReturn201()
        {
            var application = new DiffApiWebApplilcationFactory();
            var client = application.CreateClient();

            var requestBody = new DiffRequestModel
            {
                Data = "AAAAAA=="
            };
            
            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            var response = await client.PutAsync("/v1/diff/1/left", content);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
        
        [Fact]
        public async Task PutRight_ShoudReturn201()
        {
            var application = new DiffApiWebApplilcationFactory();
            var client = application.CreateClient();

            var requestBody = new DiffRequestModel
            {
                Data = "AAAAAA=="
            };
            
            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            var response = await client.PutAsync("/v1/diff/1/left", content);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
        
        [Fact]
        public async Task Get_ShouldReturn404()
        {
            var application = new DiffApiWebApplilcationFactory();
            var client = application.CreateClient();
            
            var response = await client.GetAsync("/v1/diff/1");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        
        [Fact]
        public async Task Get_ShouldReturn200Equals()
        {
            var application = new DiffApiWebApplilcationFactory();
            var client = application.CreateClient();
            
            var requestBody = new DiffRequestModel
            {
                Data = "AAAAAA=="
            };
            
            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            await client.PutAsync("/v1/diff/1/left", content);
            await client.PutAsync("/v1/diff/1/right", content);
            
            var response = await client.GetAsync("/v1/diff/1");

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadFromJsonAsync<DiffResponseModel>();

            Assert.Equal("Equals", responseBody.DiffResultType);
            Assert.Null(responseBody.Diffs);
        }
    }
}