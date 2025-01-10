using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs
{
    public class IlanGuncelleDTO
    {
        public int Id { get; set; }
        public string IlanBaslikGuncelle { get; set; }
        public string IlanAciklamaGuncelle { get; set; }
        public int UcretGuncelle { get; set; }
        public TimeSpan BaslangicSaatiGuncelle { get; set; }
        public TimeSpan BitisSaatiGuncelle { get; set; }
        public string CalismaSaatiGuncelle { get; set; }
        public string YeniKategoriGuncelle { get; set; }
        public string IlanKategoriGuncelle { get; set; }
        public string KonumGuncelle { get; set; }
        public string CinsiyetGuncelle { get; set; }
        public string IsDevamlilikGuncelle { get; set; }
        public DateTime TarihGuncelle { get; set; }
        public DateTime EklemeTarihi { get; set; }
    }
}
