using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollCase.Model
{
    public class PollPostViewModel
    {
        public string poll_description { get; set; }
        public List<string> options { get; set; }
    }

    public class PollPostResultViewModel
    {
        public int poll_id { get; set; }
    }
}
