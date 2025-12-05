using AuthService.Application.Dtos;
using AuthService.Application.Interfaces;
using AuthService.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unifrik.Common.Shared.Exceptions;
using Unifrik.Infrastructure.Shared.Storage;
using Unifrik.Infrastructure.Shared.User;

namespace AuthService.Application.Commands.Update
{
    public class UpdateAgentCommandHandler : IRequestHandler<UpdateLogisticsAgentDto, LogisticsResponseDto>
    {
        private readonly IUserRepository _repository;
        private readonly IUserServices _userServices;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly ICurrentUser _currentUser;
        public UpdateAgentCommandHandler(IUserRepository repository, IUserServices userServices,
            IMapper mapper, IFileService fileService, ICurrentUser currentUser)
        {
            _repository = repository;
            _userServices = userServices;
            _mapper = mapper;
            _fileService = fileService;
            _currentUser = currentUser;
        }
        public async Task<LogisticsResponseDto> Handle(UpdateLogisticsAgentDto request, CancellationToken cancellationToken)
        {
            var exists = await _repository.Exists(_currentUser.Email);
            if (!exists)
                throw new EntityNotFoundException("Email not found");
            var user = new User();

            user.Email = _currentUser.Email;
            _mapper.Map(request, user);
            
            if (request.LogisticsLogoFile != null)
            {
                user.LogisticsLogoFileName = $"{Guid.NewGuid()}{Path.GetExtension(request.LogisticsLogoFile.FileName)}";
                await _fileService.UploadAsync(request.LogisticsLogoFile.OpenReadStream(), user.LogisticsLogoFileName, request.LogisticsLogoFile.ContentType);
            }
            var updatedUser = await _userServices.UpdateUser(_currentUser.Email, user);
            return _mapper.Map<LogisticsResponseDto>(updatedUser);
        }
    }
}
