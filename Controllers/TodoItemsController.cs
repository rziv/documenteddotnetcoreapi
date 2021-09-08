using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


// For more information on generating swagger with swashbuckle go to https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-5.0&tabs=visual-studio

namespace DocumentedAPIExample.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private static readonly List<TodoItem> todos = new List<TodoItem>
        {
           new TodoItem{ID = 1, Completed = true, Text="Read a new book"},
           new TodoItem{ID = 2, Completed = true, Text="Exercise"},
        };


        /// <summary>
        /// Get the complete todo list
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> Get()
        {
            return Ok(todos);
        }

        /// <summary>
        /// Get a specific TodoItem.
        /// </summary>
        /// <param name="id">The identifier of the requested Todo Item</param>        
        [HttpGet("{id}")]
        public ActionResult<TodoItem> GetById(int id)
        {
            return Ok(todos.Find(todo => todo.ID == id));
        }

        /// <summary>
        /// Creates a TodoItem.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 100,
        ///        "text": "a task that has to be done",
        ///        "completed": false
        ///     }
        ///
        /// </remarks>
        /// <param name="todoItem"></param>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If there is already an item with the same id</response>      
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]        
        public ActionResult<TodoItem> Post([FromBody] TodoItem todoItem)
        {
            if(todos.Exists(item=>item.ID==todoItem.ID)) {
                return BadRequest();
            }
            todos.Add(todoItem);   
            
            return Ok(todoItem);
            
        }
        
    }
}
