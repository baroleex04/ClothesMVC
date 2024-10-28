using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClothesMVC.Models
{
    public class ClothesTypeViewModel
    {
        public List<Clothes>? Clothes { get; set; } // list of clothes
        public SelectList? Types { get; set; } // list of types
        public string? ClothesType { get; set; } // selected type
        public string? searchString { get; set; } // text user enter in search box
    }
}
