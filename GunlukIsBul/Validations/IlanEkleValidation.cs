using DTOLayer.DTOs;
using FluentValidation;

namespace GunlukIsBul.Validations
{
    public class IlanEkleValidation : AbstractValidator<IlanEkleDTO>
    {
        public IlanEkleValidation()
        {
            RuleFor(i => i.IlanBaslik).NotEmpty().WithMessage("Başlık alanı boş olamaz.");
            RuleFor(i => i.IlanAciklama).NotEmpty().WithMessage("Açıklama alanı boş olamaz.")
                .MaximumLength(500).WithMessage("Açıklama alanı çok uzunç.");
            RuleFor(i => i.YeniKategori).NotEmpty().When(i=>i.IlanKategori=="-1").WithMessage("Kategori seçin ya da bir kategori girin.")
            .Must((model, yenikategori) => string.IsNullOrEmpty(yenikategori) || model.IlanKategori == "-1")
            .WithMessage("Hem kategori seçip hem yeni kategori girmemelisiniz.");
            RuleFor(i => i.CalismaSaati).NotEmpty().WithMessage("Çalışma saati alanı boş olamaz.")
                .Must(CalismaSaati => int.TryParse(CalismaSaati, out var number) && number > 0)
                .WithMessage("Çalışma saati 0'dan küçük olamaz.");
            RuleFor(i => i.Cinsiyet).NotEmpty().WithMessage("Cinsiyet alanı boş olamaz.");
            RuleFor(i => i.Konum).NotEmpty().WithMessage("Konum alanı boş olamaz.");
            RuleFor(i => i.Ucret).NotEmpty().WithMessage("Ücret alanı boş olamaz.");
            RuleFor(i => i.IsDevamlilik).NotEmpty().WithMessage("Lütfen bir iş devamlılık şekli seçiniz.");
            RuleFor(i => i.Tarih).NotEmpty().When(i => i.IsDevamlilik != null ? i.IsDevamlilik.ToLower() == "tarih" : false).WithMessage("Tarih alanı boş olamaz.");
            RuleFor(i => i.Tarih).NotEmpty().Must(value => value.Date >= DateTime.Today).When(i => i.IsDevamlilik != null ? i.IsDevamlilik.ToLower() == "tarih" : false)
                .WithMessage("Tarih bugünden daha erken bir tarih olamaz.");
        }
    }
}
