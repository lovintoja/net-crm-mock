using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wsb_app.Data;
using wsb_app.Persistance.Models.Customers;

namespace wsb_app.Pages.Customers;
public class AddCustomerModel : PageModel
{
    private readonly CrmDbContext _context;

    public AddCustomerModel(CrmDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Customer Customer { get; set; }

    public IActionResult OnGet()
    {
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Customers.Add(Customer);
        await _context.SaveChangesAsync();

        return RedirectToPage("./ManageCustomers");
    }
}