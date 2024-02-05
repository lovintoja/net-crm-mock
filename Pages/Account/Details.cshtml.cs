using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace wsb_app.Pages.Account
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<IdentityUser> Users { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            Users = await _context.Users.ToListAsync();
            return Page();
        }
    }
}
