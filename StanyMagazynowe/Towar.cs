using System.ComponentModel.DataAnnotations;

namespace StanyMagazynowe
{
    public class Towar
    {
        [Key]
        public int IDTowar { get; set; }
        public string Nazwa { get; set; }
        public string Jednostka { get; set; }
    }
}