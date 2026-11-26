namespace CleanArchitecture.API.Requests
{
    public class CreateBlogRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }
    }
}
