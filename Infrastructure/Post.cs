namespace ProjectBank.Infrastructure
{
    public class Post
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        public string Content { get; set; }

        public Supervisor Author { get; set; }

        public ICollection<Tag> Tags { get; set; } = null!;

        public Post(string title, string content, Supervisor author, ICollection<Tag> tags)
        {
            Title = title;
            Content = content;
            Author = author;
            Tags = tags;
        }
    }
}
