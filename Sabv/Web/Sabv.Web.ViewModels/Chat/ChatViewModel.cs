namespace Sabv.Web.ViewModels.Chat
{
    using System.Collections.Generic;

    using Sabv.Data.Models;

    public class ChatViewModel
    {
        public ApplicationUser User { get; set; }

        public IEnumerable<Message> Messages { get; set; }
    }
}
