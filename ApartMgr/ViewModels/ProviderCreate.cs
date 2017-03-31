using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApartMgr.ViewModels
{
    public class ProviderCreate
    {
        [Required, StringLength(256, MinimumLength =5)]
        public string ProviderName { get; set; }
    }
}
