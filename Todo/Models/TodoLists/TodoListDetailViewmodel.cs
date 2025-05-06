using System.Collections.Generic;
using System.Linq;
using Todo.Data.Entities;
using Todo.Models.TodoItems;

namespace Todo.Models.TodoLists
{
    public class TodoListDetailViewmodel
    {
        public string TodoListId { get; }
        public string Title { get; }
        public ICollection<TodoItemSummaryViewmodel> Items { get; }

        /// <summary>
        /// Creates a new todo list detail view model
        /// </summary>
        /// <param name="items">Collection of items in this list</param>
        /// <param name="todoListId">The ID of the todo list</param>
        /// <param name="title">The title of the todo list</param>
        public TodoListDetailViewmodel(string todoListId, string title, ICollection<TodoItemSummaryViewmodel> items)
        {
            var sortedItems = items.OrderBy(t => t.Importance).ToList();
            Items = sortedItems;
            TodoListId = todoListId;
            Title = title;
        }
    }
}