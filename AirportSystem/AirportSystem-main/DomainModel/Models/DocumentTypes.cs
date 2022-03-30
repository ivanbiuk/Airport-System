using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public enum DocumentTypes
    {
        [Description("ID Card")] IdCard = 1,
        Passport
    }
}
