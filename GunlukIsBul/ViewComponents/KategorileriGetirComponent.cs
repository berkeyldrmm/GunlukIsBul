using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GunlukIsBul.ViewComponents
{
    public class KategorileriGetirComponent : ViewComponent
    {
        private readonly IKategoriService _kategoriService;

        public KategorileriGetirComponent(IKategoriService kategoriService)
        {
            _kategoriService = kategoriService;
        }

        public IViewComponentResult Invoke(bool forFilter)
        {
            IEnumerable<IsKategori> kategoriler = _kategoriService.GetAll();
            if (forFilter)
            {
                ViewBag.kategoriler = kategoriler;
                return View("ForFilterKategori");
            }
            return View(kategoriler);
        }
    }
}
