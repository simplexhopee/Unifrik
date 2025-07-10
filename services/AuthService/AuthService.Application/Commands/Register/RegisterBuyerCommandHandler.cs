using AuthService.Application.Dtos;
using AuthService.Application.Interfaces;
using AuthService.Domain.Entities;
using AutoMapper;
using MediatR;
using Unifrik.Common.Shared.Exceptions;

namespace AuthService.Application.Commands.Register
{
    public class RegisterAgentCommandHandler : IRequestHandler<RegisterLogisticsAgentDto, LogisticsResponseDto>
    {
        private readonly IUserRepository _repository;
        private readonly IUserServices _userServices;
        private readonly IMapper _mapper;
        public RegisterAgentCommandHandler(IUserRepository repository, IUserServices userServices,
            IMapper mapper)
        {
            _repository = repository;
            _userServices = userServices;
            _mapper = mapper;
        }
        public async Task<LogisticsResponseDto> Handle(RegisterLogisticsAgentDto request, CancellationToken cancellationToken)
        {
            var exists = await _repository.Exists(request.Email);
            if (exists)
                throw new EntityConflictException("Email already exists");
            var user = _mapper.Map<User>(request);
            var createdUser =  await _userServices.NewUser(user, request.Password);
            return _mapper.Map<LogisticsResponseDto>(createdUser);
        }
    }
}
