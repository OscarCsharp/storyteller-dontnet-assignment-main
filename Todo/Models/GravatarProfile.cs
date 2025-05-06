namespace Todo.Models
{
    public class GravatarProfile
    {
        public Entry[] entry { get; set; }

        public class Entry
        {
            public string DisplayName { get; set; }
            public string EmailAddress { get; set; }
        }

    }
}
