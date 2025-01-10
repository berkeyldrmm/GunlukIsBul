using DataAccessLayer.Abstract;
using DTOLayer.DTOs;
using EntityLayer.Entities;
using GunlukIsBul.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace GunlukIsBul.Controllers
{
    public class HomeController : Controller
    {
        private readonly IIlanService _ilanService;

        public HomeController(IIlanService ilanService)
        {
            _ilanService = ilanService;
        }

        public IActionResult Index()
        {
            IEnumerable<Ilan> ilanlar = _ilanService.GetAll();

            return View(ilanlar);
        }

        public IActionResult FiltreliGetir(FilterDTO filterDTO)
        {
            List<Expression<Func<Ilan, bool>>> filtreler = new List<Expression<Func<Ilan, bool>>>();
            if (filterDTO.KategoriFilter.Count() > 0)
            {
                filtreler.Add(i => filterDTO.KategoriFilter.Contains(i.IlanKategori));
            }
            if (filterDTO.UcretFilter != 0)
            {
                filtreler.Add(i => i.Ucret >= filterDTO.UcretFilter);
            }
            if (filterDTO.CinsiyetFilter != "İkisi de")
            {
                filtreler.Add(i => i.Cinsiyet == "İkisi de" || i.Cinsiyet == filterDTO.CinsiyetFilter);
            }
            IEnumerable<Ilan> ilanlar = _ilanService.GetByFilter(filtreler).Where(ilan => ilan.Tarih >= DateTime.Today || ilan.IsDevamlilik.ToLower() != "tarih").ToList();

            return Ok(ilanlar);
        }
    }
}
