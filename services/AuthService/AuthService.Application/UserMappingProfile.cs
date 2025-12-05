using AuthService.Application.Dtos;
using AuthService.Domain.Entities;
using AutoMapper;
using Unifrik.Domain.Shared.Enums;


namespace AuthService.Application
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<RegisterBuyerDto, User>()
                .ForMember(dest => dest.UserType, opt => opt.MapFrom(_ => UserTypeEnum.Buyer))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            CreateMap<RegisterSellerDto, User>()
                .ForMember(dest => dest.UserType, opt => opt.MapFrom(_ => UserTypeEnum.Seller))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));


            CreateMap<UpdateSellerDto, User>()
               .ForMember(dest => dest.UserType, opt => opt.MapFrom(_ => UserTypeEnum.Seller))
               .ForMember(dest => dest.UserName, opt => opt.Ignore())
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FirstName))
               .ForMember(dest => dest.Email, opt => opt.Ignore());


            CreateMap<UpdateBuyerDto, User>()
               .ForMember(dest => dest.UserType, opt => opt.MapFrom(_ => UserTypeEnum.Buyer))
               .ForMember(dest => dest.UserName, opt => opt.Ignore())
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FirstName))
               .ForMember(dest => dest.Email, opt => opt.Ignore());

            CreateMap<UpdateLogisticsAgentDto, User>()
               .ForMember(dest => dest.UserType, opt => opt.MapFrom(_ => UserTypeEnum.LogisticsAgent))
               .ForMember(dest => dest.UserName, opt => opt.Ignore())
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FirstName))
               .ForMember(dest => dest.Email, opt => opt.Ignore());



            CreateMap<RegisterLogisticsAgentDto, User>()
                .ForMember(dest => dest.UserType, opt => opt.MapFrom(_ => UserTypeEnum.LogisticsAgent))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
            CreateMap<User, BuyerResponseDto>();
            CreateMap<User, SellerResponseDto>();
            CreateMap<User, LogisticsResponseDto>();
        }
    }

}
