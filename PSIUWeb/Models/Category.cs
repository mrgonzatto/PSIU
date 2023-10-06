using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSIUWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        
        public int? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public Category? Parent { get; set; }

        public List<ContentCategory> ContentCategories { get; set; }

    }
}
