using System;
using System.Collections.Generic;
using System.Linq;
using PortfolioWebsite.Models;

namespace PortfolioWebsite.Services
{
    public class BlogService
    {
        private List<BlogPost> blogPosts = new List<BlogPost>
        {
            new BlogPost { Id = 1, Title = "Welcome to My Blog", Content = "Here, I share insights about my journey, projects, and programming tips...", CreatedDate = DateTime.Now.AddDays(-5) },
            new BlogPost { Id = 2, Title = "Building My First Blazor Project", Content = "I share my experiences building a Blazor portfolio app, the challenges I faced, and the solutions I found...", CreatedDate = DateTime.Now.AddDays(-10) },
            new BlogPost { Id = 3, Title = "Introduction to C# and .NET Core", Content = "Here’s a beginner-friendly guide to getting started with C# and .NET Core...", CreatedDate = DateTime.Now.AddDays(-15) }
        };

        public List<BlogPost> GetAllPosts()
        {
            return blogPosts;
        }

        public BlogPost GetPostById(int id)
        {
            return blogPosts.FirstOrDefault(post => post.Id == id);
        }

        public void AddPost(BlogPost newPost)
        {
            newPost.Id = blogPosts.Any() ? blogPosts.Max(post => post.Id) + 1 : 1;
            blogPosts.Add(newPost);
        }

        public void UpdatePost(BlogPost updatedPost)
        {
            var existingPost = GetPostById(updatedPost.Id);
            if (existingPost != null)
            {
                existingPost.Title = updatedPost.Title;
                existingPost.Content = updatedPost.Content;
                existingPost.CreatedDate = updatedPost.CreatedDate;
            }
        }

        public void DeletePost(int id)
        {
            var post = GetPostById(id);
            if (post != null)
            {
                blogPosts.Remove(post);
            }
        }
    }
}
