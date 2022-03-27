using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPSPrzebiegi.Models
{
    public class ResultApi<T>
    {
        public int ErrorCode { get; set; }
        public string ErrorDescription { get; set; }
        public int Status { get; set; }
        public ResultContent<T> Result { get; set; }

    }

    public class ResultContent<T>
    {
        public Token Token { get; set; }

        public T[] Result { get; set; }

        public StatusInfo[] Statuses { get; set; }


    }
}
