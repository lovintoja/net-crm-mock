using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wsb_app.Data;
using wsb_app.Persistance.Models.Customers;

namespace CRM_mock.Pages.Customers
{
    public class AddContactModel : PageModel
    {
        private readonly CrmDbContext _context;


        public AddContactModel(CrmDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        private int OwningCustomerId { get; set; }
        public async Task<IActionResult> OnGetAsync(int customerId)
        {
            OwningCustomerId = customerId;
            return Page();
        }

        [BindProperty]
        public Contact Model { get; set; }

        public async Task<IActionResult> OnPostAsync(int customerId)
        {
            var customer = _context.Customers.Where(x => x.CustomerId == customerId).Single();

            Model.Customer = customer;
            Model.CustomerId = customerId;
            await _context.Contacts.AddAsync(Model);

            customer.Contacts.Add(Model);
            _context.Customers.Update(customer);

            await _context.SaveChangesAsync();

            return RedirectToPage("./ManageCustomers");
        }
    }
}
