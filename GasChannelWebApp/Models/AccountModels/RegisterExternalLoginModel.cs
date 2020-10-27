using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace GasChannelWebApp.Models.AccountModels
{
    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }
}