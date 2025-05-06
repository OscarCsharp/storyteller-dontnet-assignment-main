using System.Security.Claims;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo.Data;
using Todo.Data.Entities;
using Todo.EntityModelMappers.TodoItems;
using Todo.Models.TodoItems;
using Todo.Services;
using Microsoft.AspNetCore.Identity;

namespace Todo.Controllers
{
    [Authorize]
    public class TodoItemController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public TodoItemController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Create(string todoListId)
        {
            var todoList = dbContext.SingleTodoList(todoListId);
            var fields = TodoItemCreateFieldsFactory.Create(todoList, User.Id());
            return View(fields);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TodoItemCreateFields fields)
        {
            if (!ModelState.IsValid) { return View(fields); }

            var item = new TodoItem(fields.TodoListId, fields.ResponsiblePartyId, fields.Title, fields.Importance);

            await dbContext.AddAsync(item);
            await dbContext.SaveChangesAsync();

            return RedirectToListDetail(fields.TodoListId);
        }

        [HttpGet]
        public IActionResult Edit(string todoItemId)
        {
            var todoItem = dbContext.SingleTodoItem(todoItemId);
            var fields = TodoItemEditFieldsFactory.Create(todoItem);
            return View(fields);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TodoItemEditFields fields)
        {
            if (!ModelState.IsValid) { return View(fields); }

            var todoItem = dbContext.SingleTodoItem(fields.TodoItemId);

            TodoItemEditFieldsFactory.Update(fields, todoItem);

            dbContext.Update(todoItem);
            await dbContext.SaveChangesAsync();

            return RedirectToListDetail(todoItem.TodoListId);
        }

        [HttpPost]
        [Route("api/todoitem/add")]
        public async Task<IActionResult> AddTodoItem([FromBody] AddTodoItemRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Title) || string.IsNullOrWhiteSpace(request.TodoListId))
                return BadRequest("Error : Invalid input");

            var todoList = await dbContext.TodoLists
                .Include(t => t.Items)
                .FirstOrDefaultAsync(t => t.TodoListId == request.TodoListId);

            if (todoList == null)
                return NotFound("Error : Todo list not found");

            var item = new TodoItem(request.TodoListId, User.FindFirstValue(ClaimTypes.NameIdentifier),request.Title,request.Importance,request.Rank);
            todoList.Items.Add(item);
            await dbContext.SaveChangesAsync();
            return Ok(new { item.TodoItemId, item.Title });
        }

        public class AddTodoItemRequest
        {
            public string TodoListId { get; set; }
            public string Title { get; set; }
            public Importance Importance { get; set; }
            public int Rank { get; set; }
        }


        private RedirectToActionResult RedirectToListDetail(string fieldsTodoListId)
        {
            return RedirectToAction("Detail", "TodoList", new {todoListId = fieldsTodoListId});
        }
    }
}