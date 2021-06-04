using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CStore.Models
{
    public class Admin
    {
        public virtual int Id { get; set; }

        [Required(ErrorMessage = "Вы не ввели логин")]
        public virtual string Login { get; set; }

        [Required(ErrorMessage = "Вы не ввели пароль")]
        public virtual string Password { get; set; }

        [NotMapped]
        [Compare("Password", ErrorMessage = "Неверно введен повторный пароль")]
        public string ConfirmPassword { get; set; }
    }
}
