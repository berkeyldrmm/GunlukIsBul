using AutoMapper;
using DTOLayer.DTOs;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunlukIsBul.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Ilan, IlanEkleDTO>().ReverseMap();
            CreateMap<Ilan, IlanGetirDTO>().ReverseMap();
            CreateMap<IlanGuncelleDTO, Ilan>()
                .ForMember(ilan => ilan.IlanBaslik, dto => dto.MapFrom(dto => dto.IlanBaslikGuncelle))
                .ForMember(ilan => ilan.IlanAciklama, dto => dto.MapFrom(dto => dto.IlanAciklamaGuncelle))
                .ForMember(ilan => ilan.Ucret, dto => dto.MapFrom(dto => dto.UcretGuncelle))
                .ForMember(ilan => ilan.IlanKategori, dto => dto.MapFrom(dto => dto.IlanKategoriGuncelle))
                .ForMember(ilan => ilan.BaslangicSaati, dto => dto.MapFrom(dto => dto.BaslangicSaatiGuncelle))
                .ForMember(ilan => ilan.BitisSaati, dto => dto.MapFrom(dto => dto.BitisSaatiGuncelle))
                .ForMember(ilan => ilan.CalismaSaati, dto => dto.MapFrom(dto => dto.CalismaSaatiGuncelle))
                .ForMember(ilan => ilan.Cinsiyet, dto => dto.MapFrom(dto => dto.CinsiyetGuncelle))
                .ForMember(ilan => ilan.IsDevamlilik, dto => dto.MapFrom(dto => dto.IsDevamlilikGuncelle))
                .ForMember(ilan => ilan.Tarih, dto => dto.MapFrom(dto => dto.TarihGuncelle))
                .ForMember(ilan => ilan.Konum, dto => dto.MapFrom(dto => dto.KonumGuncelle))
                .ReverseMap();
        }
    }
}
