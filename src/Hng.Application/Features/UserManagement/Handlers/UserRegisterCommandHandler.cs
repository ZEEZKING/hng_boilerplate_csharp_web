

using AutoMapper;
using Hng.Application.Features.UserManagement.Commands;
using Hng.Application.Features.UserManagement.Dtos;
using Hng.Domain.Entities;
using Hng.Infrastructure.Repository.Interface;
using Hng.Infrastructure.Services.Interfaces;
using MediatR;

namespace Hng.Application.Features.UserManagement.Handlers
{
    public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommand, AuthResponseDto>
    {
        private readonly IRepository<User> _userRepo;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;
        private readonly ITokenService _tokenService;

        public UserRegisterCommandHandler(IRepository<User> userRepo,IMapper mapper, IPasswordService passwordService, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _mapper = mapper;
            _passwordService = passwordService;
            _userRepo = userRepo;
            
        }
        public async Task<AuthResponseDto> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {
            var userExists = await _userRepo.GetBySpec(u => u.Email == request.RegisterRequest.Email);
            if(userExists is not null)
                return null;
            User user= _mapper.Map<User>(request.RegisterRequest);
            (user.PasswordSalt,user.Password)=_passwordService.GeneratePasswordSaltAndHash(request.RegisterRequest.Password);
            await _userRepo.AddAsync(user);
            await _userRepo.SaveChanges();

            var response= new AuthResponseDto{
                Message="Success",
                Data=_mapper.Map<UserDto>(user),
                AccessToken=_tokenService.GenerateJwt(user)
            };
            return response;

        }
    }
}