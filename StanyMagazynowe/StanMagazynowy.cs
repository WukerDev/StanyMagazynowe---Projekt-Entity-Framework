using System.ComponentModel.DataAnnotations;

namespace StanyMagazynowe
{
    public class StanMagazynowy
    {
        [Key]
        public int IDStanu { get; set; }
        public int Ilosc { get; set; }
        public int FKID_Towar { get; set; }
    }
}