namespace Domain.Purchasers;

public class Purchaser
{
    public PurchaserId Id { get; private set; }

    public string Email { get; private set; } = string.Empty;

    public string FirstName { get; private set; } = string.Empty;

    public string LastName { get; private set; } = string.Empty;
    
    private Purchaser()
    {

    }

    public Purchaser(PurchaserId id, string email, string firstName, string lastName)
    {
        Id = id;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
    }

    public Purchaser(Guid id, string email, string firstName, string lastName)
    {
        Id = new PurchaserId(id);
        Email = email;
        FirstName = firstName;
        LastName = lastName;
    }

    public void Update(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}
