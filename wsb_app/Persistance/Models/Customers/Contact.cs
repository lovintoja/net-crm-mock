using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace wsb_app.Persistance.Models.Customers;

public class Contact
{
    [Key]
    public int ContactId { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    // Foreign key
    public int CustomerId { get; set; }

    // Navigation property for Customer
    [ForeignKey("CustomerId")]
    public Customer Customer { get; set; }
}
