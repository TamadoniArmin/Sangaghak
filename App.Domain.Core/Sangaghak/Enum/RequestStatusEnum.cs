using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Sangaghak.Enum
{
    public enum RequestStatusEnum
    {
        WatingForExpertsOffers=1,
        WatingForCustomerComfimation,
        OfferAccepted,
        JobDone,
        WatingForPay,
        Complited
    }
}
