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
    public class IlanService : ServiceRepository<Ilan>, IIlanService
    {
        public IlanService(GunlukIsBulContext context) : base(context)
        {
        }

        public override IEnumerable<Ilan> GetAll()
        {
            return _contextEntity.Where(ilan => ilan.Tarih >= DateTime.Today || ilan.IsDevamlilik== "HerGun").ToList();
        }
    }
}
