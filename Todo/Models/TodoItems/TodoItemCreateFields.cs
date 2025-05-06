using Todo.Data.Entities;

namespace Todo.Models.TodoItems
{
    public class TodoItemCreateFields
    {
        public string TodoListId { get; set; }
        public string Title { get; set; }
        public string TodoListTitle { get; set; }
        public string ResponsiblePartyId { get; set; }
        public Importance Importance { get; set; } = Importance.Medium;

        public TodoItemCreateFields() { }

        public TodoItemCreateFields(string todoListId, string todoListTitle, string responsiblePartyId)
        {
            TodoListId = todoListId;
            TodoListTitle = todoListTitle;
            ResponsiblePartyId = responsiblePartyId;
        }
    }
}