using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GunlukIsBul.ViewComponents
{
    public class IlanlariGetirComponent : ViewComponent
    {
        private readonly IIlanService _ilanService;

        public IlanlariGetirComponent(IIlanService ilanService)
        {
            _ilanService = ilanService;
        }

        public IViewComponentResult Invoke()
        {
            IEnumerable<Ilan> ilanlar = _ilanService.GetAll();
            return View(ilanlar);
        }
    }
}
