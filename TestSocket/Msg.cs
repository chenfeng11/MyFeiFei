using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSocket
{
    public class Msg
    {
        public string MsgId { get; set; }
        public List<Data> Data { get; set; }
    }

    public class Data 
    {
        public string GigaInferno { get; set; }

        public int level { get; set; }
    }
}
