using System.Collections.Generic;
using System.Net;
using CommonLibrary.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace FunctionsBackEnd;

public static class ToDoFunction
{
    [Function("GetTodos")]
    public static List<ToDoItem> GetTodos(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "todos")] HttpRequestData req)
    {
        return new List<ToDoItem>
        {
            new()
            {
                Id = new Guid(),
                DateCreated = new DateTime(2000, 12, 28),
                Description = "Test",
                IsComplete = false 
            }
        };
    }
}