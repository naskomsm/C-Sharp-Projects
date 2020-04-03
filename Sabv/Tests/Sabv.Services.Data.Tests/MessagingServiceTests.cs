namespace Sabv.Services.Data.Tests
{
    using System;
    using System.IO;
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
        public async Task SendGridClientSendEmailAsyncShouldWork()
        {
            var sender = new SendGridClient(this.Configuration["SendGrid:ApiKey"]);

            var fromAddress = new EmailAddress("gosho1234@abv.bg", "goshko");
            var toAddress = new EmailAddress("nagoshkopriqtelq@gmail.com");
            var message = MailHelper.CreateSingleEmail(fromAddress, toAddress, "zaglavie", null, "tainabrat");

            var result = await sender.SendEmailAsync(message);
            Assert.Equal("Accepted", result.StatusCode.ToString());
        }

        [Fact]
        public async Task SendEmailClientAsyncShouldWork()
        {
            var sender = new SendEmailClient(this.Configuration["SendGrid:ApiKey"]);

            using var consoleText = new StringWriter();
            Console.SetOut(consoleText);
            await sender.SendEmailAsync("goshko1234@abv.bg", "goshko", "nagoshkopriqtelq@gmal.com", "zaglavie", "tainbrat");
            Assert.Equal("Accepted", consoleText.ToString().Trim());
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async Task SendEmailClientAsyncShouldThrowException(string data)
        {
            var sender = new SendEmailClient(this.Configuration["SendGrid:ApiKey"]);
            await Assert.ThrowsAsync<ArgumentException>(() => sender.SendEmailAsync("goshko1234@abv.bg", "goshko", "nagoshkopriqtelq@gmal.com", data, data));
        }

        [Theory]
        [InlineData("Content")]
        [InlineData("FileName")]
        [InlineData("MimeType")]
        public void EmailAttachmentShouldHaveProperties(string propertyName)
        {
            var property = typeof(EmailAttachment).GetProperty(propertyName);
            Assert.NotNull(property);
        }

        [Fact]
        public void EmailAttachmentPropertiesSettersShouldWork()
        {
            var model = new EmailAttachment();
            model.Content = new byte[123];
            model.FileName = "test";
            model.MimeType = "random";

            Assert.Equal(new byte[123], model.Content);
            Assert.Equal("test", model.FileName);
            Assert.Equal("random", model.MimeType);
        }
    }
}
