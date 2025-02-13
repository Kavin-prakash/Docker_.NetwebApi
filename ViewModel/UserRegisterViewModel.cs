using System.ComponentModel.DataAnnotations;

namespace AzuerSqApi.Model
{
    public class UserRegisterViewModel
    {
        [Required]
        public string? UserName { get; set; }
        [Required]

        public string? UserEmail { get; set; }

        [Required]
        public string? UserPassword { get; set; }

    }
}
