namespace Sabv.Services.Data.Tests
{
    using System.Threading.Tasks;

    using Sabv.Services.Messaging;
    using SendGrid;
    using SendGrid.Helpers.Mail;
    using Xunit;

    public class MessagingServiceTests : BaseClass
    {
        [Fact]
        public void NullMessageSenderSendEmailAsyncShouldReturnTaskCompleted()
        {
            var sender = new NullMessageSender();
            var result = sender.SendEmailAsync("from", "fromName", "to", "subject", "content");
            Assert.Equal(Task.CompletedTask, result);
        }

        [Fact]
        public async Task SendEmailClientSendEmailAsyncShouldWork()
        {
            var sender = new SendGridClient(this.Configuration["SendGrid:ApiKey"]);

            var fromAddress = new EmailAddress("gosho1234@abv.bg", "goshko");
            var toAddress = new EmailAddress("nagoshkopriqtelq@gmail.com");
            var message = MailHelper.CreateSingleEmail(fromAddress, toAddress, "zaglavie", null, "tainabrat");

            var result = await sender.SendEmailAsync(message);
            Assert.Equal("Accepted", result.StatusCode.ToString());
        }
    }
}
