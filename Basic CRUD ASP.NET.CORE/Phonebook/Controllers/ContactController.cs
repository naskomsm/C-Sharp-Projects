using Microsoft.AspNetCore.Mvc;
using Phonebook.Data;
using Phonebook.Data.Models;

namespace Phonebook.Controllers
{
    public class ContactController : Controller
    {
        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            if (DataAccess.Contacts.Contains(contact))
            {
                TempData["Error"] = "This contact is already in the list.";
            }
            else
            {
                DataAccess.Contacts.Add(contact);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}