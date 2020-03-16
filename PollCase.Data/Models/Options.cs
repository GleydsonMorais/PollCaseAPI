using System;
using System.Collections.Generic;
using System.Text;

namespace PollCase.Data.Models
{
    public class Options
    {
        public int option_id { get; set; }
        public string option_description { get; set; }
        public int option_votes { get; set; }
        public int poll_id { get; set; }

        public Poll Poll { get; set; }
    }
}
