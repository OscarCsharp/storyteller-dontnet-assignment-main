using Todo.Models.TodoItems;

namespace Todo.Models.TodoLists
{
    public class TodoListSummaryViewmodel
    {
        public string TodoListId { get; }
        public string Title { get; }
        public int NumberOfNotDoneItems { get; }
        public UserSummaryViewmodel Owner { get; }

        /// <summary>
        /// Creates a new todo list summary view model
        /// </summary>
        /// <param name="todoListId">The ID of the todo list</param>
        /// <param name="title">The title of the todo list</param>
        /// <param name="numberOfNotDoneItems">Count of incomplete items in this list</param>
        /// <param name="owner">The user who owns this list</param>
        public TodoListSummaryViewmodel(string todoListId, string title, int numberOfNotDoneItems, UserSummaryViewmodel owner)
        {
            TodoListId = todoListId;
            Title = title;
            NumberOfNotDoneItems = numberOfNotDoneItems;
            Owner = owner;
        }
    }
}