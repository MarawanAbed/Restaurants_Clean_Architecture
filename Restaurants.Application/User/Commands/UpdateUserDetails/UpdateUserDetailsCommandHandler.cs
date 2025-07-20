//using MediatR;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.Extensions.Logging;
//using Restaurants.Application.User;
//using Restaurants.Domain.Entities;
//using Restaurants.Domain.Exceptions;

//namespace Restaurants.Application.Users.Commands.UpdateUserDetails;

//public class UpdateUserDetailsCommandHandler(ILogger<UpdateUserDetailsCommandHandler> logger,
//    UserContext userContext,
//    IUserStore<UserDomain> userStore) : IRequestHandler<UpdateUserDetailsCommand>
//{
//    public async Task Handle(UpdateUserDetailsCommand request, CancellationToken cancellationToken)
//    {
//        var user = userContext.GetCurrentUser();

//        logger.LogInformation("Updating user: {UserId}, with {@Request}", user!.Id, request);

//        var dbUser = await userStore.FindByIdAsync(user!.Id, cancellationToken);

//        if (dbUser == null)
//        {
//            throw new NotFoundExceptions(nameof(User), user!.Id);
//        }
//        //dbUser.Nationality = request.Nationality;
//        //dbUser.DateOfBirth = request.DateOfBirth;

//        await userStore.UpdateAsync(dbUser, cancellationToken);
//    }
//}
