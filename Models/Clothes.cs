using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothesMVC.Models
{
    public enum ClothingType
    {
        Top,
        Bottom,
        Outerware,
        Shoes,
        Accessories
    }
    public class Clothes
    {
        public int Id { get; set; }
        [Required]
        public ClothingType? Type { get; set; }
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
        [Range(1000,10000000)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public int Price { get; set; }
    }
}
