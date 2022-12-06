using System.CodeDom;

namespace DatabaseFirst_Initial.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ProductCategory()
        {

        }

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

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString() {
            return $"Id: {Id}\tTitle: {Title}\tDescription: {Description}";
        }
    }
}