using DTOLayer.DTOs;
using FluentValidation;

namespace GunlukIsBul.Validations
{
    public class IlanGuncelleValidation : AbstractValidator<IlanGuncelleDTO>
    {
        public IlanGuncelleValidation()
        {
            RuleFor(i => i.IlanBaslikGuncelle).NotEmpty().WithMessage("Başlık alanı boş olamaz.");
            RuleFor(i => i.IlanAciklamaGuncelle).NotEmpty().WithMessage("Açıklama alanı boş olamaz.")
                .MaximumLength(500).WithMessage("Açıklama alanı çok uzunç.");
            RuleFor(i => i.YeniKategoriGuncelle).NotEmpty().When(i => i.IlanKategoriGuncelle == "-1").WithMessage("Kategori seçin ya da bir kategori girin.")
            .Must((model, yenikategori) => string.IsNullOrEmpty(yenikategori) || model.IlanKategoriGuncelle == "-1")
            .WithMessage("Hem kategori seçip hem yeni kategori girmemelisiniz.");
            RuleFor(i => i.CalismaSaatiGuncelle).NotEmpty().WithMessage("Çalışma saati alanı boş olamaz.")
                .Must(CalismaSaati => int.TryParse(CalismaSaati, out var number) && number > 0)
                .WithMessage("Çalışma saati 0'dan küçük olamaz.");
            RuleFor(i => i.CinsiyetGuncelle).NotEmpty().WithMessage("Cinsiyet alanı boş olamaz.");
            RuleFor(i => i.KonumGuncelle).NotEmpty().WithMessage("Konum alanı boş olamaz.");
            RuleFor(i => i.UcretGuncelle).NotEmpty().WithMessage("Ücret alanı boş olamaz.");
            RuleFor(i => i.IsDevamlilikGuncelle).NotEmpty().WithMessage("Lütfen bir iş devamlılık şekli seçiniz.");
            RuleFor(i => i.TarihGuncelle).NotEmpty().When(i => i.IsDevamlilikGuncelle != null ? i.IsDevamlilikGuncelle.ToLower() == "tarih" : false).WithMessage("Tarih alanı boş olamaz.")
                .Must(value => value.Date >= DateTime.Today)
                .WithMessage("Tarih bugünden daha erken bir tarih olamaz.");
        }
    }
}
