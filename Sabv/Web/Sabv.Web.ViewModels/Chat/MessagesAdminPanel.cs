namespace Sabv.Web.ViewModels.Chat
{
    using System.Collections.Generic;

    using Sabv.Data.Models;

    public class MessagesAdminPanel
    {
        public IEnumerable<Message> Messages { get; set; }
    }
}
