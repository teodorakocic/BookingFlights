using Application.Data;
using Domain.Purchasers;
using MediatR;

namespace Application.Purchasers.Create;

internal class CreateFlightControlCommandQueryHandler : IRequestHandler<CreatePurchaserCommand>
{

    private readonly IRepository<Purchaser> _purchaserRepository;

    public CreateFlightControlCommandQueryHandler(IRepository<Purchaser> purchaserRepository)
    {
        _purchaserRepository = purchaserRepository;
    }

    public async Task Handle(CreatePurchaserCommand request, CancellationToken cancellationToken)
    {
        var purchaser = new Purchaser(
            new PurchaserId(Guid.NewGuid()),
            request.Email,
            request.FirstName,
            request.LastName);

        _purchaserRepository.Insert(purchaser);

        await _purchaserRepository.SaveChangesAsync();
    }
}
