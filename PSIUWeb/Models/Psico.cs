using System.ComponentModel.DataAnnotations;

namespace PSIUWeb.Models
{
    public class Psico<T>
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string CRP { get; set; }
        public bool IsAvailable { get; set; }

        public T Aguinaldo { get; set; }
    }
}
