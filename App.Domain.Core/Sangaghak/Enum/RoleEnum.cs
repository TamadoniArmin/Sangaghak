using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.Sangaghak.Enum
{
    public enum RoleEnum
    {
        [Display(Name = "ادمین")]
        Admin = 1,

        [Display(Name = "مشتری")]
        Customer = 2,

        [Display(Name = "کارشناس")]
        Expert = 3
    }
}
