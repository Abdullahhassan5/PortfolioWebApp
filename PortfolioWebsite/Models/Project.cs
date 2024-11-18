namespace PortfolioWebsite.Models
{
    public class Project
    {
        public int Id { get; set; }  // Unique identifier
        public string Title { get; set; }  // Project title
        public string Description { get; set; }  // Brief description of the project
        public string TechnologiesUsed { get; set; }  // Technologies used in the project
        public string KeyFeatures { get; set; }  // Key features of the project
        public string Role { get; set; }  // Your role in the project
    }
}
