using Todo.Data.Entities;

namespace Todo.Models.TodoItems
{
    public class TodoItemSummaryViewmodel
    {
        public string TodoItemId { get; }
        public string Title { get; }
        public UserSummaryViewmodel ResponsibleParty { get; }
        public bool IsDone { get; }
        public Importance Importance { get; }

        /// <summary>
        /// Creates a new todo item summary view model
        /// </summary>
        /// <param name="todoItemId">The ID of the todo item</param>
        /// <param name="title">The title of the todo item</param>
        /// <param name="isDone">Whether the item is marked as done</param>
        /// <param name="responsibleParty">The user responsible for this item</param>
        /// <param name="importance">The importance level of this item</param>
        public TodoItemSummaryViewmodel(string todoItemId, string title, bool isDone, UserSummaryViewmodel responsibleParty, Importance importance)
        {
            TodoItemId = todoItemId;
            Title = title;
            IsDone = isDone;
            ResponsibleParty = responsibleParty;
            Importance = importance;
        }
    }
}