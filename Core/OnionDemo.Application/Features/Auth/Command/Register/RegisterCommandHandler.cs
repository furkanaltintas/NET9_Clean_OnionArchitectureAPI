using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using OnionDemo.Application.Bases;
using OnionDemo.Application.Features.Auth.Rules;
using OnionDemo.Application.Interfaces.AutoMapper;
using OnionDemo.Application.Interfaces.UnitOfWorks;
using OnionDemo.Domain.Entities;

namespace OnionDemo.Application.Features.Auth.Command.Register;

public class RegisterCommandHandler : BaseHandler, IRequestHandler<RegisterCommandRequest, Unit>
{
    private readonly AuthRules _authRules;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;


    public RegisterCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, AuthRules authRules, UserManager<User> userManager, RoleManager<Role> roleManager) : base(mapper, unitOfWork, httpContextAccessor)
    {
        _authRules = authRules;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
    {
        await _authRules.UserShouldNotBeExist(await _userManager.FindByEmailAsync(request.Email));

        var user = _mapper.Map<User, RegisterCommandRequest>(request);
        user.UserName = request.Email;
        user.SecurityStamp = Guid.NewGuid().ToString();

        IdentityResult result = await _userManager.CreateAsync(user, request.Password);

        if(result.Succeeded)
        {
            if(!await _roleManager.RoleExistsAsync("user"))
                await _roleManager.CreateAsync(new Role { Name = "user" });

            await _userManager.AddToRoleAsync(user, "user");
        }

        return Unit.Value;
    }
}