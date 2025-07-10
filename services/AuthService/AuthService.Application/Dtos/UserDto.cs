namespace AuthService.Application.Dtos
{
    public class UserDto
    {
        public string Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string? LanguagePreference { get; set; }
    }
}