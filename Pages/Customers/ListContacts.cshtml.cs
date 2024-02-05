using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using wsb_app.Data;
using wsb_app.Persistance.Models.Customers;

namespace CRM_mock.Pages.Customers
{
    public class ListContactsModel : PageModel
    {
        private readonly CrmDbContext _context;

        public ListContactsModel(CrmDbContext context)
        {
            _context = context;
        }

        public List<Contact> Contacts { get; set; }

        public void OnGet(int customerId)
        {
            var customer = _context.Customers.Where(x => x.CustomerId == customerId)
                .Include(x => x.Contacts)
                .Single();
            Contacts = customer.Contacts.ToList();
        }

        public async Task<IActionResult> OnPostDeleteContactAsync(int contactId)
        {
            var contact = await _context.Contacts.FindAsync(contactId);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage(new { customerId = contact?.CustomerId });
        }
    }
}
