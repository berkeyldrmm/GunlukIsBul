using DTOLayer.DTOs;
using EntityLayer.Entities;

namespace GunlukIsBul.Models
{
    public class AnaSayfaViewModel
    {
        public IEnumerable<Ilan> Ilanlar { get; set; }
        public FilterDTO Filtreler { get; set; }
    }
}
