using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PollCase.Model;
using PollCase.Service.Intefaces;

namespace PollCase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollController : ControllerBase
    {
        private readonly IPollService _pollService;

        public PollController(IPollService pollService)
        {
            _pollService = pollService;
        }

        // GET: api/Poll
        [HttpGet]
        public string Get()
        {
            return "";
        }

        // GET: api/Poll/:id
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<PollGetResultViewModel>> Get(int id)
        {
            var result = await _pollService.PollGetAsync(id);

            if (result == null)
                return NotFound();

            return result;
        }

        // GET: api/Poll/:id/stats
        [HttpGet("{id}/stats")]
        public async Task<PollStatsReturnViewModel> GetStats(int id) => await _pollService.PollGetStatsAsync(id);

        // POST: api/Poll
        [HttpPost]
        public async Task<PollPostResultViewModel> Post([FromBody]PollPostViewModel model) => await _pollService.CreatePollAsync(model);

        // POST: api/Poll/:id/vote
        [HttpPost("{id}/vote")]
        public async Task<ActionResult<string>> Post(int id, [FromBody]PollVotePostViewModel vote)
        {
            var result = await _pollService.VotePollAsync(id, vote);

            if (result == null)
                return NotFound();

            return result;
        }
    }
}
