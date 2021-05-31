using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Web.Framework.Models;

namespace RahivBXSlider.Models
{
    public record PublicInfoModel : BaseNopModel
    {
        public bool UseSandbox { get; set; }
        public string Message { get; set; }
    }
}
