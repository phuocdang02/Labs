using System.ComponentModel.DataAnnotations;

namespace api.Models;

/// <summary>
/// Represents a register model
/// </summary>
public class RegisterModel
{
    /// <summary>
    /// Gets or sets the full name of application user
    /// </summary>
    [Required]
    public string FullName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the email of application user
    /// </summary>
    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the password of application user
    /// </summary>
    [Required]
    public string Password { get; set; } = string.Empty;
}

/// <summary>
/// Represents a login model
/// </summary>
public class LoginModel
{
    /// <summary>
    /// Gets or sets the email of application user
    /// </summary>
    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the password of application user
    /// </summary>
    [Required]
    public string Password { get; set; } = string.Empty;
}