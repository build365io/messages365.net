using AutoMapper;
using AutoMapper.QueryableExtensions;
using Contracts;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostService.Data;
using PostService.DTOs;
using PostService.Entities;

namespace PostService.Controllers
{
    [ApiController]
    [Route("api/messages")]
    public class MessagesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public MessagesController(DataContext context, IMapper mapper,
            IPublishEndpoint publishEndpoint)
        {
            _context = context;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet]
        public async Task<ActionResult<List<MessageDto>>> GetAllMessages(string date)
        {
            var query = _context.Messages.OrderBy(x => x.CreatedAt).AsQueryable();

            if (!string.IsNullOrEmpty(date))
            {
                query = query.Where(x => x.CreatedAt.CompareTo(DateTime.Parse(date).ToUniversalTime()) > 0);
            }

            return await query.ProjectTo<MessageDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MessageDto>> GetMessageById(Guid id)
        {
            var message = await _context.Messages
                .FirstOrDefaultAsync(x => x.Id == id);
            
            if (message == null) return NotFound();

            return _mapper.Map<MessageDto>(message);
        }
        
        // [Authorize]
        [HttpPost]
        public async Task<ActionResult<MessageDto>> CreateMessage(CreateMessageDto messageDto)
        {
            var message = _mapper.Map<Message>(messageDto);
            
            message.Author = User.Identity.Name;

            _context.Messages.Add(message);

            var newMessage = _mapper.Map<MessageDto>(message);

            await _publishEndpoint.Publish(_mapper.Map<MessageCreated>(newMessage));

            var result = await _context.SaveChangesAsync() > 0;

            if (!result) return BadRequest("Could not save changes to the DB");

            return CreatedAtAction(nameof(GetMessageById), 
                new {message.Id}, newMessage);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMessage(Guid id)
        {
            var message = await _context.Messages.FindAsync(id);

            if (message == null) return NotFound();

            _context.Messages.Remove(message);

            await _publishEndpoint.Publish<MessageDeleted>(new { Id = message.Id.ToString() });

            var result = await _context.SaveChangesAsync() > 0;

            if (!result) return BadRequest("Could not update DB");

            return Ok();
        }
    }
}