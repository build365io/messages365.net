using Contracts;
using MassTransit;
using MongoDB.Entities;

namespace SearchService.Consumers
{
    public class PostDeletedConsumer : IConsumer<PostDeleted>
    {
        public async Task Consume(ConsumeContext<PostDeleted> context)
        {
            Console.WriteLine("--> Consuming PostDeleted: " + context.Message.Id);

            var result = await DB.DeleteAsync<Item>(context.Message.Id);

            if (!result.IsAcknowledged) 
                throw new MessageException(typeof(PostDeleted), "Problem deleting post");
        }
    }

}