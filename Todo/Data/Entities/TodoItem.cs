using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Todo.Data.Entities {
    public class TodoItem
    {
        [Key]
        public string TodoItemId { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }
        public string ResponsiblePartyId { get; set; }
        public IdentityUser ResponsibleParty { get; set; }
        public bool IsDone { get; set; }
        public Importance Importance { get; set; }

        public string TodoListId { get; set; }
        public TodoList TodoList { get; set; }

        protected TodoItem() { }

        public TodoItem(string todoListId, string responsiblePartyId, string title, Importance importance)
        {
            TodoListId = todoListId;
            ResponsiblePartyId = responsiblePartyId;
            Title = title;
            Importance = importance;
        }
    }
}