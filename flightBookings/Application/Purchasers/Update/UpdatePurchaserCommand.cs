using Domain.Purchasers;
using MediatR;

namespace Application.Purchasers.Update;

public record UpdatePurchaserCommand(
    PurchaserId PurchaserId,
    string FirstName,
    string LastName) : IRequest;

public record UpdatePurchaserRequest(
    string FirstName,
    string LastName);
