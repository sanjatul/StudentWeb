using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace StudentWeb.Models
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Gender { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        public int ClassId { get; set; }
        [DisplayName("Class")]
        [ForeignKey("ClassId")]
        [ValidateNever]
        public Class Class { get; set; }
        [DisplayName("Created Date")]
        public DateTime? CreatedDate { get; set; }
        [DisplayName("Modification Date")]
        public DateTime? ModificationDate { get; set; }
    }
}
