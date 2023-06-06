using Application.Data;
using Domain.Purchasers;
using MediatR;

namespace Application.Purchasers.Update;

internal sealed class UpdatePurchaserCommandQueryHandler : IRequestHandler<UpdatePurchaserCommand>
{

    private readonly IRepository<Purchaser> _purchaserRepository;

    public UpdatePurchaserCommandQueryHandler(IRepository<Purchaser> purchaserRepository)
    {
        _purchaserRepository = purchaserRepository;
    }

    public async Task Handle(UpdatePurchaserCommand request, CancellationToken cancellationToken)
    {
        var purchaser = await _purchaserRepository.GetByIdAsync(request.PurchaserId.Value);
     
        if (purchaser is null)
        {
            throw new ArgumentNullException(nameof(purchaser));
        } 

        purchaser.Update(
            request.FirstName,
            request.LastName);

        _purchaserRepository.Update(purchaser);

        await _purchaserRepository.SaveChangesAsync();
    }
}
