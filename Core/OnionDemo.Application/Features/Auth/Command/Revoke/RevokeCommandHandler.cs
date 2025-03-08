using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using OnionDemo.Application.Bases;
using OnionDemo.Application.Features.Auth.Rules;
using OnionDemo.Application.Interfaces.AutoMapper;
using OnionDemo.Application.Interfaces.UnitOfWorks;
using OnionDemo.Domain.Entities;

namespace OnionDemo.Application.Features.Auth.Command.Revoke;

public class RevokeCommandHandler : BaseHandler, IRequestHandler<RevokeCommandRequest, Unit>
{
    private readonly UserManager<User> _userManager;
    private readonly AuthRules _authRules;

    public RevokeCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, AuthRules authRules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        _userManager = userManager;
        _authRules = authRules;
    }

    public async Task<Unit> Handle(RevokeCommandRequest request, CancellationToken cancellationToken)
    {
        User user = await _userManager.FindByEmailAsync(request.Email);
        await _authRules.EmailAddressShouldBeValid(user);

        user.RefreshToken = null;
        await _userManager.UpdateAsync(user);

        return Unit.Value;
    }
}