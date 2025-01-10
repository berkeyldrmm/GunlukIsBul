using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs
{
    public class FilterDTO
    {
        public FilterDTO()
        {
            this.KategoriFilter = new List<string>();
            UcretFilter = 0;
            CinsiyetFilter = "İkisi de";
        }

        public List<string> KategoriFilter { get; set; }
        public int UcretFilter { get; set; }
        public string CinsiyetFilter { get; set; }
    }
}
