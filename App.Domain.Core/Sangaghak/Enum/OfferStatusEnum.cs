using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.Sangaghak.Enum
{
    public enum OfferStatusEnum
    {
        [Display(Name = "در حال برسی")]
        Pending = 1,

        [Display(Name = "تایید شده")]
        Accepted = 2,

        [Display(Name = "رد شده")]
        Rejected = 3
    }
}
