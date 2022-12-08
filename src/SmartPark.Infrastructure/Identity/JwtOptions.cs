namespace SmartPark.Infrastructure.Identity;
public class JwtOptions
{
    public required string Key { get; set; } = string.Empty;
    public required string Issuer { get; set; } = string.Empty;
    public required int ExpiryMinutes { get; set; } = 1;
}