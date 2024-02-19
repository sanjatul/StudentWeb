using System.ComponentModel.DataAnnotations;

namespace StudentWeb.Models
{
    public class Class
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}
