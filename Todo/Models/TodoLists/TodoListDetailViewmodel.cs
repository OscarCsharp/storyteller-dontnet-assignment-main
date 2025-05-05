using System.Collections.Generic;
using Todo.Models.TodoItems;

namespace Todo.Models.TodoLists
{
    public class TodoListDetailViewmodel
    {
        public int TodoListId { get; }
        public string Title { get; }
        public ICollection<TodoItemSummaryViewmodel> Items { get; }

        /// <summary>
        /// Creates a new todo list detail view model
        /// </summary>
        /// <param name="items">Collection of items in this list</param>
        /// <param name="todoListId">The ID of the todo list</param>
        /// <param name="title">The title of the todo list</param>
        public TodoListDetailViewmodel(int todoListId, string title, ICollection<TodoItemSummaryViewmodel> items)
        {
            Items = items;
            TodoListId = todoListId;
            Title = title;
        }
    }
}