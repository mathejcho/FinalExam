using AutoMapper;
using Bank.Data.Entities;
using Bank.Models.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressModelBase>().ReverseMap();
            CreateMap<Address, AddressExtended>()
                .ReverseMap();
            CreateMap<AddressCreatedModel, Address>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Street, opt => opt.Ignore())
                .ForMember(dest => dest.City, opt => opt.Ignore())
                .ForMember(dest => dest.Country, opt => opt.Ignore());
            CreateMap<AddressUpdateModel, Address>()
                 .ForMember(dest => dest.Street, opt => opt.Ignore())
                .ForMember(dest => dest.City, opt => opt.Ignore())
                .ForMember(dest => dest.Country, opt => opt.Ignore());
        }
    }
}
