using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace wsb_app.Pages.Account
{
    [Authorize]
    public class AdminForDebugModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AdminForDebugModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGet()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var result = await _userManager.AddToRoleAsync(currentUser, "Admin");

            if (result.Succeeded)
            {
                return RedirectToPage("./Details");
            }

            return RedirectToPage("/Index");
        }
    }
}
