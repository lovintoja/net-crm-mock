using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using wsb_app.Persistance.Models.Account;

namespace wsb_app.Pages.Account
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public EditModel(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public IdentityUser UserModel { get; set; } = default!;
        [BindProperty]
        public string NewPassword { get; set; }
        [BindProperty]
        public string CurrentPassword { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var currentUser = await _userManager.GetUserAsync(User);
            if (!_userManager.IsInRoleAsync(currentUser, "Admin").Result && id != currentUser.Id)
            {
                return Forbid();
            }

            var userModel =  _userManager.FindByIdAsync(id).Result;

            if (userModel == null)
            {
                return NotFound();
            }

            UserModel = userModel;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var currentUser = await _userManager.GetUserAsync(User);
                if (!_userManager.IsInRoleAsync(currentUser, "Admin").Result && UserModel.Id != currentUser.Id)
                {
                    return Forbid();
                }

                await _userManager.UpdateAsync(UserModel);
                await _userManager.ChangePasswordAsync(UserModel, CurrentPassword, NewPassword);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserModelExists(UserModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UserModelExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
