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
        public async Task SendGridEmailSenderSendEmailAsyncShouldWork()
        {
            var sender = new SendGridClient(this.Configuration["SendGrid:ApiKey"]);

            var fromAddress = new EmailAddress("gosho", "gosho123@gmail.com");
            var toAddress = new EmailAddress("nagoshkopriqtelq@gmail.bg");
            var message = MailHelper.CreateSingleEmail(fromAddress, toAddress, "zaglavie", null, "tainabrat");

            var result = await sender.SendEmailAsync(message);
            Assert.Equal("200", result.StatusCode.ToString());
        }
    }
}
