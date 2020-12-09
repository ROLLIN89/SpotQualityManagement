using AutoMapper;
using Idealista.Domain;
using Idealista.Domain.Queries.Advertisements.Responses;
using System;
using System.Linq;

namespace coding_test_ranking.Controllers
{
    public class AdvertisementProfile : Profile
    {
        public AdvertisementProfile()
        {
            CreateMap<Advertisement, AdvertisementResponse>()
                .ForMember(dest => dest.HouseSize, map => map.MapFrom((s,d) => s.HouseSize ?? 0))
                .ForMember(dest => dest.GardenSize, opt => opt.MapFrom((s, d) => s.GardenSize ?? 0))
                .ForMember(dest => dest.PictureUrls, opt => opt.MapFrom(x => x.Pictures.Select(p => p.Url)));

            CreateMap<Advertisement, QualityAdvertisementResponse>()
                .ForMember(dest => dest.HouseSize, map => map.MapFrom((s, d) => s.HouseSize ?? 0))
                .ForMember(dest => dest.GardenSize, opt => opt.MapFrom((s, d) => s.GardenSize ?? 0))
                .ForMember(dest => dest.IrrelevantSince, opt => opt.MapFrom((s, d) => s.IrrelevantSince ?? DateTime.MinValue))
                .ForMember(dest => dest.PictureUrls, opt => opt.MapFrom(x => x.Pictures.Select(p => p.Url)));

        }
    }
}
