using System.ComponentModel.DataAnnotations;

namespace GasChannelWebCore.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указано имя пользователя")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
