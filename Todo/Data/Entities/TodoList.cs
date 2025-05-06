using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Todo.Data.Entities
{
    public class TodoList
    {
        [Key]
        public string TodoListId { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }
        public IdentityUser Owner { get; set; }

        public ICollection<TodoItem> Items { get; set; } = new List<TodoItem>();

        protected TodoList() { }

        public TodoList(IdentityUser owner, string title)
        {
            Owner = owner;
            Title = title;
        }
    }
}