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
using Unifrik.Domain.Shared.Enums;
using Unifrik.Infrastructure.Shared.User;

namespace AuthService.Application.Commands.Kyc
{
    public class UpdateBuyerAndSellerKycCommandHandler : IRequestHandler<BuyerAndSellerKycDto, string>
    {
        private readonly IUserRepository _repository;
        private readonly IUserServices _userServices;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly ICurrentUser _currentUser;
        public UpdateBuyerAndSellerKycCommandHandler(IUserRepository repository, IUserServices userServices,
            IMapper mapper, IFileService fileService, ICurrentUser currentUser)
        {
            _repository = repository;
            _userServices = userServices;
            _mapper = mapper;
            _fileService = fileService;
            _currentUser = currentUser;
        }
        public async Task<string> Handle(BuyerAndSellerKycDto request, CancellationToken cancellationToken)
        {
            var exists = await _repository.Exists(_currentUser.Email);
            if (!exists)
                throw new EntityNotFoundException("Email not found");
            var user = new User();
            user.GovernmentIdPath = $"{Guid.NewGuid()}{Path.GetExtension(request.GovernmentIdPath.FileName)}";
            await _fileService.UploadAsync(request.GovernmentIdPath.OpenReadStream(), user.GovernmentIdPath, request.GovernmentIdPath.ContentType);
            user.PassportPhotoPath = $"{Guid.NewGuid()}{Path.GetExtension(request.PassportPhotoPath.FileName)}";
            await _fileService.UploadAsync(request.PassportPhotoPath.OpenReadStream(), user.PassportPhotoPath, request.PassportPhotoPath.ContentType);
            _mapper.Map(request, user);
            user.Email = _currentUser.Email;
            user.KycStatus = KycStatus.UnderReview;
            user.KycSubmittedAt = DateTime.UtcNow;
            await _userServices.UpdateUser(_currentUser.Email, user);
            return "KYC submiitted for review";
        }
    }
}
