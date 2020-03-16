using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PollCase.Data.Contexts;
using PollCase.Data.Models;
using PollCase.Model;
using PollCase.Service.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollCase.Service
{
    public class PollService : IPollService
    {
        private readonly PollCaseDbContext _dataContext;

        public PollService(PollCaseDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<PollPostResultViewModel> CreatePollAsync([FromBody]PollPostViewModel model)
        {
            var poll = new Poll
            {
                poll_description = model.poll_description,
                Options = model.options.Select(x =>
                new Options
                {
                    option_description = x
                }).ToList()
            };

            _dataContext.Add(poll);
            await _dataContext.SaveChangesAsync();

            return new PollPostResultViewModel { poll_id = poll.poll_id };
        }

        public async Task<PollStatsReturnViewModel> PollGetStatsAsync(int id)
        {
            var poll = await _dataContext.Polls
                .Include(x => x.Options)
                .SingleOrDefaultAsync(x => x.poll_id == id);

            return new PollStatsReturnViewModel
            {
                views = poll.poll_views,
                votes = poll.Options.Select(x =>
                new OptiosStatsReturnViewModel
                {
                    option_id = x.option_id,
                    qty = x.option_votes
                }).ToList()
            };
        }

        public async Task<ActionResult<PollGetResultViewModel>> PollGetAsync(int id)
        {
            var poll = await _dataContext.Polls
                .Include(x => x.Options)
                .SingleOrDefaultAsync(x => x.poll_id == id);

            if (poll == null)
                return null;

            poll.poll_views++;

            _dataContext.Update(poll);
            await _dataContext.SaveChangesAsync();

            return new PollGetResultViewModel
            {
                poll_id = poll.poll_id,
                poll_description = poll.poll_description,
                options = poll.Options.Select(x =>
                new OptionsGetResultViewModel
                {
                    option_id = x.option_id,
                    option_description = x.option_description
                }).ToList()
            };
        }

        public async Task<ActionResult<string>> VotePollAsync(int id, [FromBody]PollVotePostViewModel vote)
        {
            var poll = await _dataContext.Polls
                .Include(x => x.Options)
                .SingleOrDefaultAsync(x => x.poll_id == id && x.Options.Count(y => y.option_id == vote.option_id) == 1);

            if (poll == null)
                return null;

            poll.Options.First(x => x.option_id == vote.option_id).option_votes += 1;

            _dataContext.Update(poll);
            await _dataContext.SaveChangesAsync();

            return "Registered Vote!";
        }
    }
}
