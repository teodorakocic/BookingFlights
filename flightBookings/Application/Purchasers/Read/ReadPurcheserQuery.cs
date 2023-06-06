using Domain.Purchasers;
using MediatR;

namespace Application.Purchasers.Read;

public record ReadPurchaserQuery(PurchaserId PurchaserId) : IRequest<PurchaserResponse>;

public record PurchaserResponse(
    Guid Id,
    string Email,
    string FirstName,
    string LastName);
