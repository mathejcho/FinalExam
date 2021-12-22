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
    public class ClientProfile:Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientModelBase>().ReverseMap();
            CreateMap<Client, ClientExtended>()
                .ReverseMap();
            CreateMap<ClientCreatedModel, Client>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.Ignore())
                .ForMember(dest => dest.PhoneNumber, opt => opt.Ignore())
                .ForMember(dest => dest.Email, opt => opt.Ignore())
                .ForMember(dest => dest.ClientTypeId, opt => opt.Ignore());
            CreateMap<ClientUbdateModel, Client>()
                 .ForMember(dest => dest.Name, opt => opt.Ignore())
                .ForMember(dest => dest.PhoneNumber, opt => opt.Ignore())
                .ForMember(dest => dest.Email, opt => opt.Ignore());
        }
    }
}
