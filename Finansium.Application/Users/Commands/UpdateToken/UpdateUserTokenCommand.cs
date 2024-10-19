using Finansium.Application.Users.Commands.Login;

namespace Finansium.Application.Users.Commands.UpdateToken;

public sealed record UpdateUserTokenCommand : ICommand<TokenResponse>;
