using Microsoft.AspNetCore.Identity;

namespace api.Models;

/// <summary>
/// Application identity
/// </summary>
public class ApplicationUser : IdentityUser
{
    /// <summary>
    /// Gets or sets full name of application user
    /// </summary>
    public string FullName { get; set; } = string.Empty;
}
