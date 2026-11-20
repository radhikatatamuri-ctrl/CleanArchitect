using CleanArchitecture.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Enitites
{
    public class Blog
    {
        public int Id { get; set; }
        // public string Name { get; set; }
        public BlogName Name { get; private set; }
        private Blog()
        {
            // Required by EF Core
        }

        public Blog(
            BlogName name,
            string description,
            string author,
            string imageUrl)
        {
            Name = name;
            Description = description;
            Author = author;
            ImageUrl = imageUrl;
        }
    public void Update(
    BlogName name,
    string description,
    string author,
    string imageUrl)
        {
            Name = name;
            Description = description;
            Author = author;
            ImageUrl = imageUrl;
        }

        public string Description { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }

        //comments
        private readonly List<Comment> _comments = new();

        public IReadOnlyCollection<Comment> Comments
            => _comments.AsReadOnly();

        public void AddComment(string content,string author)
        {
            if (string.IsNullOrWhiteSpace(author))
                throw new ArgumentException("Author is required");

            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Content is required");
            if (content.Length > 50)
                throw new ArgumentException("Comment too long");
            _comments.Add(
                new Comment(content,author));
        }

        public void RemoveComment(int commentId)
        {
            var comment = _comments.FirstOrDefault(c => c.Id == commentId);

            if (comment != null)
            {
                _comments.Remove(comment);
            }
        }

        public void UpdateComment(int commentId, string content)
        {
            var comment = _comments.FirstOrDefault(c => c.Id == commentId);

            if (comment == null)
                return;

            comment.UpdateContent(content);
        }
    }
}
