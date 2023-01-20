using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private readonly string CosmosDbConnectionString = "AccountEndpoint=https://cloudlab.documents.azure.com:443/;AccountKey=I8erJBDzkthqZEbswA2B68oyOQdVieWNRie5uOaHxwC1iHOdLPkjExS8TdhvfOEeWBGKjTIRSasHACDbYq1oqQ==;";
        private readonly string CosmosDbName = "todo-db";
        private readonly string CosmosDbContainerName = "todo-container";
        private readonly CosmosClient _client;
        private readonly Container _container;

        public ToDoItemsController()
        {
            _client = new CosmosClient(CosmosDbConnectionString);
            _container = _client.GetContainer(CosmosDbName, CosmosDbContainerName);
        }

        // GET: api/ToDoItem
        [HttpGet]
        public IEnumerable<ToDoItem> Get()
        {
            var items = _container.GetItemLinqQueryable<ToDoItem>().ToFeedIterator();
            var result = new List<ToDoItem>();
            while (items.HasMoreResults)
            {
                result.AddRange(items.ReadNextAsync().Result);
            }
            return result;
        }

        // POST: api/ToDoItem
        [HttpPost]
        public async Task Post([FromBody] ToDoItem value)
        {
            await _container.CreateItemAsync(value);
        }

        // PUT: api/ToDoItem/5
        [HttpPut("{id}")]
        public async Task Put(Guid id, [FromBody] ToDoItem value)
        {
            await _container.UpsertItemAsync(value);
        }

        // DELETE: api/ToDoItem/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
           await  _container.DeleteItemAsync<ToDoItem>(id.ToString(), new PartitionKey(id.ToString()));
        }
    }
}
