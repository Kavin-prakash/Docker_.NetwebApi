using System.ComponentModel.DataAnnotations;

namespace AzuerSqApi.Model
{
    public class UserRegisterViewModel
    {
        public string? UserName { get; set; }

        public string? UserEmail { get; set; }


        public string? UserPassword { get; set; }

    }
}
