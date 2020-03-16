using Microsoft.AspNetCore.Mvc;
using PollCase.API.Controllers;
using PollCase.Model;
using PollCase.Service.Intefaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PollCase.Test
{
    class Program
    {
        private readonly IPollService _pollService;

        public Program(IPollService pollService)
        {
            _pollService = pollService;
        }

        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var teste = await TestPollPost();
        }

        public static async Task<PollPostResultViewModel> TestPollPost()
        {
            var pollController = new PollController(_pollService);

            var pollPost = new PollPostViewModel
            {
                poll_description = "This is the question",
                options = new List<string> { "First Option", "Second Option", "Third Option" }
            };

            var result = await pollController.Post(pollPost);

            return result;
        }
    }
}
