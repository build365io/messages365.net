using AutoMapper;
using CliWrap;
using CliWrap.Buffered;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using PostService.Data;

namespace PostService.Controllers
{
    [ApiController]
    [Route("api/cli")]
    public class CliController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public CliController(DataContext context, IMapper mapper,
            IPublishEndpoint publishEndpoint)
        {
            _context = context;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet]
        public async Task<ActionResult> GetUserInfo(string name)
        {
            var results = await Cli.Wrap(targetFilePath: "powershell")
                .WithWorkingDirectory(@"C:\Users\messa\OneDrive\Desktop\messages365.net\src\PostService")
                .WithArguments(new[] { $@"C:\Users\messa\OneDrive\Desktop\messages365.net\src\PostService\cli.ps1 -name {name}" })
                .ExecuteBufferedAsync();

            return Ok(results.StandardOutput);
        }

        

    }
}