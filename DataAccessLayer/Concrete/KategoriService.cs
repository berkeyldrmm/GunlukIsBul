using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class KategoriService : ServiceRepository<IsKategori>, IKategoriService
    {
        public KategoriService(GunlukIsBulContext context) : base(context)
        {
        }
    }
}
