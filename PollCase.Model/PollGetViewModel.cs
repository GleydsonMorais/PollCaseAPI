using System;
using System.Collections.Generic;
using System.Text;

namespace PollCase.Model
{
    public class PollGetResultViewModel
    {
        public int poll_id { get; set; }
        public string poll_description { get; set; }

        public IList<OptionsGetResultViewModel> options = new List<OptionsGetResultViewModel>();
    }

    public class OptionsGetResultViewModel
    {
        public int option_id { get; set; }
        public string option_description { get; set; }
    }
}
