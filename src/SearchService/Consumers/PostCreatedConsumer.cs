using AutoMapper;
using Contracts;
using MassTransit;
using MongoDB.Entities;

namespace SearchService.Consumers
{
    public class PostCreatedConsumer : IConsumer<PostCreated>
    {
        private readonly IMapper _mapper;

        public PostCreatedConsumer(IMapper mapper)
        {
            _mapper = mapper;
        }
        
        public async Task Consume(ConsumeContext<PostCreated> context)
        {
            Console.WriteLine("--> Consuming post created: " + context.Message.Id);

            var item = _mapper.Map<Item>(context.Message);

            await item.SaveAsync();
        }
    }
}