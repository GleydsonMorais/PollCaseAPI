using System;
using System.Collections.Generic;
using System.Text;

namespace PollCase.Model
{
    public class PollStatsReturnViewModel
    {
        public int views { get; set; }

        public IList<OptiosStatsReturnViewModel> votes = new List<OptiosStatsReturnViewModel>();
    }

    public class OptiosStatsReturnViewModel
    {
        public int option_id { get; set; }
        public int qty { get; set; }
    }
}
