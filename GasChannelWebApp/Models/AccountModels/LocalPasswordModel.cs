using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace GasChannelWebApp.Models.AccountModels
{
    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Текущий пароль")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Длина {0} должна быть не менее {2} симоволов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Новый пароль")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтвердите новый пароль")]
        [Compare("NewPassword", ErrorMessage = "Новый пароль и пароль подтверждения не совпадают.")]
        public string ConfirmPassword { get; set; }
    }
}