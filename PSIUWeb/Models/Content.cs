using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSIUWeb.Models
{
    public class Content
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Resume { get; set; }
        public string HtmlContent { get; set; }

        public int PsicoId { get; set; }
        [ForeignKey("PsicoId")]
        public Psico Psico { get; set; }

        public List<ContentCategory> ContentCategories { get; set; }

    }
}
