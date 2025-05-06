using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Todo.Data.Entities
{
    public class TodoList
    {
        public string TodoListId { get; set; }
        public string Title { get; set; }
        public IdentityUser Owner { get; set; }

        public ICollection<TodoItem> Items { get; set; } = new List<TodoItem>();

        protected TodoList() { }

        public TodoList(IdentityUser owner, string title)
        {
            TodoListId = new Guid().ToString();
            Owner = owner;
            Title = title;
        }
    }
}