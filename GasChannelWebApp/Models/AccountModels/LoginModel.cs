using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace GasChannelWebApp.Models.AccountModels
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        
        [Display(Name = "Не выходить из системы")]
        public bool RememberUser { get; set; }

    }
}