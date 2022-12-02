using System.CodeDom;

namespace DatabaseFirst_Initial.Models
{
    internal class ProductCategory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ProductCategory(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }

        public ProductCategory(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}