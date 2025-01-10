using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs
{
    public class IlanGetirDTO
    {
        public string IlanBaslik { get; set; }
        public string IlanAciklama { get; set; }
        public int Ucret { get; set; }
        public TimeSpan BaslangicSaati { get; set; }
        public TimeSpan BitisSaati { get; set; }
        public string CalismaSaati { get; set; }
        public string IlanKategori { get; set; }
        public string Konum { get; set; }
        public string Cinsiyet { get; set; }
        public string IsDevamlilik { get; set; }
        public DateTime Tarih { get; set; }
        public DateTime EklemeTarihi { get; set; }
    }
}
