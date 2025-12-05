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
    public class UpdateSellerCommandHandler : IRequestHandler<UpdateSellerDto, SellerResponseDto>
    {
        private readonly IUserRepository _repository;
        private readonly IUserServices _userServices;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly ICurrentUser _currentUser;
        public UpdateSellerCommandHandler(IUserRepository repository, IUserServices userServices,
            IMapper mapper, IFileService fileService, ICurrentUser currentUser)
        {
            _repository = repository;
            _userServices = userServices;
            _mapper = mapper;
            _fileService = fileService;
            _currentUser = currentUser;
        }
        public async Task<SellerResponseDto> Handle(UpdateSellerDto request, CancellationToken cancellationToken)
        {
            var exists = await _repository.Exists(_currentUser.Email);
            if (!exists)
                throw new EntityNotFoundException("Email not found");
            var user = new User();

            user.Email = _currentUser.Email;
            _mapper.Map(request, user);
           
            if (request.BusinessLogoFile != null)
            {
                user.BusinessLogoFileName = $"{Guid.NewGuid()}{Path.GetExtension(request.BusinessLogoFile.FileName)}";
                await _fileService.UploadAsync(request.BusinessLogoFile.OpenReadStream(), user.BusinessLogoFileName, request.BusinessLogoFile.ContentType);
            }
            var updatedUser = await _userServices.UpdateUser(_currentUser.Email, user);
            return _mapper.Map<SellerResponseDto>(updatedUser);
        }
    }
}
