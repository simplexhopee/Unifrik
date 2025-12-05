using AuthService.Application.Dtos;
using AuthService.Application.Interfaces;
using AuthService.Domain.Entities;
using AutoMapper;
using MediatR;
using Unifrik.Common.Shared.Exceptions;
using Unifrik.Infrastructure.Shared.Storage;

namespace AuthService.Application.Commands.Register
{
    public class RegisterAgentCommandHandler : IRequestHandler<RegisterLogisticsAgentDto, LogisticsResponseDto>
    {
        private readonly IUserRepository _repository;
        private readonly IUserServices _userServices;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        public RegisterAgentCommandHandler(IUserRepository repository, IUserServices userServices,
            IMapper mapper, IFileService fileService)
        {
            _repository = repository;
            _userServices = userServices;
            _mapper = mapper;
            _fileService = fileService;
        }
        public async Task<LogisticsResponseDto> Handle(RegisterLogisticsAgentDto request, CancellationToken cancellationToken)
        {
            var exists = await _repository.Exists(request.Email);
            if (exists)
                throw new EntityConflictException("Email already exists");
            var user = new User();
           
           
            _mapper.Map<User>(request);
            if (request.LogisticsLogoFile != null)
            {
                user.LogisticsLogoFileName = $"{Guid.NewGuid()}{Path.GetExtension(request.LogisticsLogoFile.FileName)}";
                await _fileService.UploadAsync(request.LogisticsLogoFile.OpenReadStream(), user.LogisticsLogoFileName, request.LogisticsLogoFile.ContentType);
            }
            var createdUser =  await _userServices.NewUser(user, request.Password);
            return _mapper.Map<LogisticsResponseDto>(createdUser);
        }
    }
}
