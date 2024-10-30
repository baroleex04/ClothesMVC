using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothesMVC.Models
{
    public class Clothes
    {
        public int Id { get; set; }
        [StringLength(10, MinimumLength = 2)]
        [Required]
        public string? Type { get; set; }
        [StringLength(20, MinimumLength = 2)]
        [Required]
        public string Name { get; set; }
        public string? Size { get; set; }
        public string? Brand { get; set; }
        [Range(0,10)]
        public int? Condition { get; set; }
        [DataType(DataType.Upload)]
        public string? Image { get; set; }
        [Display(Name="Date Buy")]
        [DataType(DataType.Date)]
        public DateTime DateBuy { get; set; }
        [Range(1,1000)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10,0)")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal Price { get; set; }
    }
}
