using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Domain.Enitites
{
    public class Comment
    {
        public int Id { get; private set; }
        public int BlogId { get; private set; }
        public string Author {  get; private set; }
        public string content { get; set; } = string.Empty;
        private Comment()
        {
        }

        public Comment(string content,string author)
        {
            if (string.IsNullOrWhiteSpace(author))
                throw new ArgumentException("Author is required");

            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Content is required");
            if (content.Length > 50)
                throw new ArgumentException("Comment too long");
            Author = author;
            content = content;
        }
        public void UpdateContent(string content)
        {
            this.content = content;
        }

    }
}
