using Trisha.Services.Email.Messages;

namespace Trisha.Services.Email.Repository
{
    public interface IEmailRepository
    {
        Task SendAndLogEmail(UpdatePaymentResultMessage message);

    }
}
