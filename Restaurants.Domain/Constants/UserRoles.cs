

namespace Restaurants.Domain.Constants
{
    public static class UserRoles
    {
        public const string User = "User";
        public const string Owner = "Owner";
        public const string Admin = "Admin";
    }
}
//we put it in domain cuz it related to our business log and application other wise put it in infrastructure