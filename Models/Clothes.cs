using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothesMVC.Models
{
    public class Clothes
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public string Name { get; set; }
        public string? Size { get; set; }
        public string? Brand { get; set; }
        public byte[]? Image { get; set; }
        [Display(Name="Date Buy")]
        [DataType(DataType.Date)]
        public DateTime DateBuy { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
    }
}
