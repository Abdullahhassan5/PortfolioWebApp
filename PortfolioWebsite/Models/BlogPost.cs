using System;

namespace PortfolioWebsite.Models
{
    public class BlogPost
    {
        public int Id { get; set; }  // Unique identifier
        public string Title { get; set; }  // Blog post title
        public string Content { get; set; }  // Blog post content
        public DateTime CreatedDate { get; set; } = DateTime.Now;  // Date created
    }
}
