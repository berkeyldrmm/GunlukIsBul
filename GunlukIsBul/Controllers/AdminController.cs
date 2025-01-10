using AutoMapper;
using DataAccessLayer.Abstract;
using DTOLayer.DTOs;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System;
using FluentValidation.Results;

namespace GunlukIsBul.Controllers
{
    public class AdminController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IIlanService _ilanService;
        private readonly IKategoriService _kategoriService;
        private readonly IValidator<IlanEkleDTO> _validatorIlanEkleDTO;
        private readonly IValidator<IlanGuncelleDTO> _validatorIlanGuncelleDTO;
        public AdminController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IMapper mapper, IIlanService ilanService, IValidator<IlanEkleDTO> validatorIlanEkleDTO, IKategoriService kategoriService, IValidator<IlanGuncelleDTO> validatorIlanGuncelleDTO)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
            _ilanService = ilanService;
            _validatorIlanEkleDTO = validatorIlanEkleDTO;
            _kategoriService = kategoriService;
            _validatorIlanGuncelleDTO = validatorIlanGuncelleDTO;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (loginDTO.Username != null && loginDTO.Password != null)
            {
                var user = await _userManager.FindByNameAsync(loginDTO.Username);
                if (user == null)
                {
                    ViewBag.error = "Kullanıcı adı veya şifre hatalı";
                    return View();
                }

                var result2 = await _signInManager.PasswordSignInAsync(user, loginDTO.Password, true, true);
                if (result2.Succeeded)
                {
                    ViewBag.nameSurname = user.UserName;
                    return RedirectToAction("Index", "Admin");
                }

                ViewBag.error = "Kullanıcı adı veya şifre hatalı";
                return View();
            }

            ViewBag.error = "Kullanıcı adı veya şifre boş olamaz.";
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        //[HttpPost]
        //public async Task<IActionResult> SignUp(LoginDTO signUpDTO)
        //{
        //    var user = new IdentityUser { UserName = signUpDTO.Username };
        //    var result = await _userManager.CreateAsync(user, signUpDTO.Password);
        //    if (result.Succeeded)
        //    {
        //        return RedirectToAction("Index", "Login");
        //    }
        //    return View();
        //}

        public IActionResult IlanGetir(int id)
        {
            Ilan ilan = _ilanService.Get(id);
            IlanGetirDTO ilanGetirDTO = _mapper.Map<IlanGetirDTO>(ilan);
            return Ok(ilanGetirDTO);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IlanEkle([FromForm]IlanEkleDTO ilanEkleDTO)
        {
            Wrapper.Response response = new Wrapper.Response();

            FluentValidation.Results.ValidationResult validationResult = await _validatorIlanEkleDTO.ValidateAsync(ilanEkleDTO);
            if (validationResult.IsValid)
            {
                Ilan ilan = _mapper.Map<Ilan>(ilanEkleDTO);

                if(ilanEkleDTO.IlanKategori == "-1")
                {
                    ilan.IlanKategori = ilanEkleDTO.YeniKategori;

                    bool kategoriAddResult = await _kategoriService.Add(new IsKategori { KategoriIsim=ilan.IlanKategori });
                    if (!kategoriAddResult)
                    {
                        response.Success = false;
                        response.Message = "İlan kaydedilirken yeni kategori eklenme kısmında bir hata oluştu.";
                        response.Time = 2000;
                        return Ok(response);
                    }
                }
                ilan.EklemeTarihi = DateTime.Now;
                ilan.GuncellemeTarihi = DateTime.Now;

                bool result = await _ilanService.Add(ilan);
                int result2 = await _ilanService.SaveChanges();

                if (result && result2 > 0)
                {
                    response.Success = true;
                    response.Message = "İlan başarıyla kaydedildi.";
                    response.Time = 2000;
                }
                else
                {
                    response.Success = false;
                    response.Message = "İlan kaydedilirken bir hata oluştu.";
                    response.Time = 2000;
                }
            }
            else
            {
                response.Success = false;
                IEnumerable<string> allErrors = validationResult.Errors.Select(x => x.ErrorMessage);
                string message = "<ul>";
                foreach (var error in allErrors)
                {
                    message += "<li>" + error + "</li>";
                }
                message += "</ul>";
                response.Message = message;
                response.Time = 10000;
            }

            return Ok(response);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> IlanSil(int id)
        {
            Wrapper.Response response = new Wrapper.Response();
            _ilanService.Delete(id);
            int result = await _ilanService.SaveChanges();
            if (result > 0)
            {
                response.Success = true;
                response.Message = "İlan başarıyla silindi.";
                response.Time = 2000;
            }
            else
            {
                response.Success = false;
                response.Message = "İlan silinirken bir hata oluştu.";
                response.Time = 2000;
            }
            return Ok(response);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IlanGuncelle(IlanGuncelleDTO ilanGuncelleDTO)
        {
            Wrapper.Response response = new Wrapper.Response();

            FluentValidation.Results.ValidationResult validationResult = await _validatorIlanGuncelleDTO.ValidateAsync(ilanGuncelleDTO);
            if (validationResult.IsValid)
            {
                Ilan ilan = _mapper.Map<Ilan>(ilanGuncelleDTO);

                if (ilanGuncelleDTO.IlanKategoriGuncelle == "-1")
                {
                    ilan.IlanKategori = ilanGuncelleDTO.YeniKategoriGuncelle;

                    bool kategoriAddResult = await _kategoriService.Add(new IsKategori { KategoriIsim = ilan.IlanKategori });
                    if (!kategoriAddResult)
                    {
                        response.Success = false;
                        response.Message = "İlan güncellenirken yeni kategori eklenme kısmında bir hata oluştu.";
                        response.Time = 2000;
                        return Ok(response);
                    }
                }

                ilan.GuncellemeTarihi = DateTime.Now;

                bool result = _ilanService.Update(ilan);
                int result2 = await _ilanService.SaveChanges();

                if (result && result2 > 0)
                {
                    response.Success = true;
                    response.Message = "İlan başarıyla güncellendi.";
                    response.Time = 2000;
                }
                else
                {
                    response.Success = false;
                    response.Message = "İlan güncellenirken bir hata oluştu.";
                    response.Time = 2000;
                }
            }
            else
            {
                response.Success = false;
                IEnumerable<string> allErrors = validationResult.Errors.Select(x => x.ErrorMessage);
                string message = "<ul>";
                foreach (var error in allErrors)
                {
                    message += "<li>" + error + "</li>";
                }
                message += "</ul>";
                response.Message = message;
                response.Time = 10000;
            }

            return Ok(response);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> KategoriSil(int id)
        {
            Wrapper.Response response = new Wrapper.Response();

            _kategoriService.Delete(id);
            int result = await _kategoriService.SaveChanges();
            if (result > 0)
            {
                response.Success = true;
                response.Message = "Kategori başarıyla silindi.";
                response.Time = 2000;
            }
            else
            {
                response.Success = false;
                response.Message = "Kategori silinirken bir hata oluştu.";
                response.Time = 2000;
            }

            return Ok(response);
        }
    }
}
