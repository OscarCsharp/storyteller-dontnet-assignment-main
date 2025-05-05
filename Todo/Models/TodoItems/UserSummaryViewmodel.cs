namespace Todo.Models.TodoItems
{
    public class UserSummaryViewmodel
    {
        public string UserName { get; }
        public string Email { get; }

        /// <summary>
        /// Creates a new user summary view model
        /// </summary>
        /// <param name="userName">The username of the user</param>
        /// <param name="email">The email address of the user</param>
        public UserSummaryViewmodel(string userName, string email)
        {
            UserName = userName;
            Email = email;
        }
    }
}