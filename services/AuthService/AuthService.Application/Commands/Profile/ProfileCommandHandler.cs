using AuthService.Application.Dtos;
using AuthService.Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unifrik.Domain.Shared.Enums;

namespace AuthService.Application.Commands.Profile
{
    public class ProfileCommandHandler : IRequestHandler<ProfileCommand, object>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public ProfileCommandHandler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<object> Handle(ProfileCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByEmail(request.email);
            object account = user!.UserType == UserTypeEnum.Buyer ? _mapper.Map<BuyerResponseDto>(user) :
               user.UserType == UserTypeEnum.Seller ? _mapper.Map<SellerResponseDto>(user) :
                _mapper.Map<LogisticsResponseDto>(user);
            return account;
        }
    }
}
