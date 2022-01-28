namespace Dotnet.DTOS
{
    public record createUserDTO
    {

        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? email { get; set; }
        public string? contactNumber { get; set; }
        public string? password { get; set; }
    }
};

