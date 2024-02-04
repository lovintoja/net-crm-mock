using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using wsb_app.Data;
using wsb_app.Persistance.Models.Customers;

namespace wsb_app.Pages.Customers;
public class ManageCustomersModel : PageModel
{
    private readonly CrmDbContext _context;

    [BindProperty]
    public Customer Customer { get; set; }

    public IList<Customer> Customers { get; set; }

    public ManageCustomersModel(CrmDbContext context)
    {
        _context = context;
    }

    public async Task OnGetAsync()
    {
        Customers = await _context.Customers.ToListAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Customer).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CustomerExists(Customer.CustomerId))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        var customer = await _context.Customers.FindAsync(id);

        if (customer != null)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage();
    }

    private bool CustomerExists(int id)
    {
        return _context.Customers.Any(e => e.CustomerId == id);
    }
}