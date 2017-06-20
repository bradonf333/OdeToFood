using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace OdeToFood.Entities
{
    /// <summary>
    /// Generic user.
    /// This is not needed unless you specify custom properties.
    /// For now we are only usingh the properties provided by IdentityUser, but if any properties
    /// are needed that are not in this class, then can be set up here.
    /// </summary>
    public class User : IdentityUser
    {

    }
}
