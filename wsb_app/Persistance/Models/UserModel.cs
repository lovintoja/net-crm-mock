using wsb_app.Persistance.Models;

namespace AppPersistance.Models;
public class UserModel : LoginInputModel
{
    public string Email { get; set; }
}
