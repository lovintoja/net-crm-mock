using System.ComponentModel.DataAnnotations;

namespace wsb_app.Persistance.Models.Customers;

public class Customer
{
    [Key]
    public int CustomerId { get; set; }

    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public ICollection<Contact> Contacts { get; set; }

    public Customer()
    {
        Contacts = new List<Contact>();
    }
}

