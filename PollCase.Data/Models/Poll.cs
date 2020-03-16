using System;
using System.Collections.Generic;
using System.Text;

namespace PollCase.Data.Models
{
    public class Poll
    {
        public int poll_id { get; set; }
        public string poll_description { get; set; }
        public int poll_views { get; set; }

        public IList<Options> Options { get; set; } = new List<Options>();
    }
}
