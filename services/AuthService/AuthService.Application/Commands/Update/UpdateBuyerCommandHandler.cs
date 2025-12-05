using AuthService.Application.Dtos;
using AuthService.Application.Interfaces;
using AuthService.Domain.Entities;
using AutoMapper;
using MediatR;
using Unifrik.Common.Shared.Exceptions;
using Unifrik.Infrastructure.Shared.User;


namespace AuthService.Application.Commands.Update
{
    public class UpdateBuyerCommandHandler : IRequestHandler<UpdateBuyerDto, BuyerResponseDto>
    {
        private readonly IUserRepository _repository;
        private readonly IUserServices _userServices;
        private readonly IMapper _mapper;
        private readonly ICurrentUser _currentUser;

        public UpdateBuyerCommandHandler(IUserRepository repository, IUserServices userServices,
            IMapper mapper, ICurrentUser currentUser)
        {
            _repository = repository;
            _userServices = userServices;
            _mapper = mapper;
            _currentUser = currentUser;
            
        }
        public async Task<BuyerResponseDto> Handle(UpdateBuyerDto request, CancellationToken cancellationToken)
        {
            var exists = await _repository.Exists(_currentUser.Email);
            if (!exists)
                throw new EntityNotFoundException("Email not found");
            var user = new User();
            user.Email = _currentUser.Email;
            user = _mapper.Map(request, user);
           
            var updatedUser = await _userServices.UpdateUser(_currentUser.Email, user);
            return _mapper.Map<BuyerResponseDto>(updatedUser);
        }
    }
}
