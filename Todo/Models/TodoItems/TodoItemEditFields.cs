﻿using Todo.Data.Entities;
using Todo.Migrations;

namespace Todo.Models.TodoItems
{
    public class TodoItemEditFields
    {
        public string TodoListId { get; set; }
        public string Title { get; set; }
        public string TodoListTitle { get; set; }
        public string TodoItemId { get; set; }
        public bool IsDone { get; set; }
        public string ResponsiblePartyId { get; set; }
        public Importance Importance { get; set; }
        public int Rank { get; set; }
        public TodoItemEditFields() { }

        public TodoItemEditFields(string todoListId, string todoListTitle, string todoItemId, string title, bool isDone, string responsiblePartyId, Importance importance,int rank)
        {
            TodoListId = todoListId;
            TodoListTitle = todoListTitle;
            TodoItemId = todoItemId;
            Title = title;
            IsDone = isDone;
            ResponsiblePartyId = responsiblePartyId;
            Importance = importance;
            Rank = rank;
        }
    }
}