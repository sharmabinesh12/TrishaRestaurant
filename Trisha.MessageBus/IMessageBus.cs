using System;
using System.Threading.Tasks;

namespace Trisha.MessageBus
{
    public interface IMessageBus
    {
        Task PublishMessage(BaseMessage message, string topicName);
    }
}
