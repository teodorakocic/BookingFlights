using MediatR;

namespace Application.Purchasers.Create;

public record CreatePurchaserCommand(
    string Email,
    string FirstName,
    string LastName) : IRequest;
