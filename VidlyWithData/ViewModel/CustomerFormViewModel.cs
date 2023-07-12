using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyWithData.Models;

namespace VidlyWithData.ViewModel
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MemebershipTypes { get; set; }
        public Customer Customer { get; set; }

    }
}