using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPSPrzebiegi.Models
{
    public class Token
    {
        public string SessionId { get; set; }

        public string[] UserRights { get; set; }

        public string[] Clients { get; set; }

        public string[] Modules { get; set; }
    }
}
