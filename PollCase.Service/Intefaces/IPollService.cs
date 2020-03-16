using Microsoft.AspNetCore.Mvc;
using PollCase.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PollCase.Service.Intefaces
{
    public interface IPollService
    {
        Task<ActionResult<PollGetResultViewModel>> PollGetAsync(int id);
        Task<PollStatsReturnViewModel> PollGetStatsAsync(int id);
        Task<PollPostResultViewModel> CreatePollAsync([FromBody]PollPostViewModel model);
        Task<ActionResult<string>> VotePollAsync(int id, [FromBody]PollVotePostViewModel vote);
    }
}
