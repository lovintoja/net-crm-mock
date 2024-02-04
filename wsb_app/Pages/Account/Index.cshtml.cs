using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using wsb_app.Data;
using wsb_app.Persistance.Models.Customers;

namespace wsb_app.Pages.Account
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly CrmDbContext _context;

        public IdentityUser CurrentUser { get; set; }
        public List<Customer> Customers { get; set; }

        public IndexModel(UserManager<IdentityUser> userManager, CrmDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            CurrentUser = await _userManager.GetUserAsync(User);
            if (CurrentUser == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            Customers = await _context.Customers.ToListAsync();

            return Page();
        }
    }
}
