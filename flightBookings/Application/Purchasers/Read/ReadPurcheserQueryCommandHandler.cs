using Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Purchasers.Read;

internal sealed class ReadPurchaserQueryCommandHandler : IRequestHandler<ReadPurchaserQuery, PurchaserResponse>
{
    private readonly IApplicationDbContext _context;

    public ReadPurchaserQueryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PurchaserResponse> Handle(ReadPurchaserQuery request, CancellationToken cancellationToken)
    {
        var purchaser = await _context
            .Purchasers
            .Where(p => p.Id == request.PurchaserId)
            .Select(p => new PurchaserResponse(
                p.Id.Value,
                p.Email,
                p.FirstName,
                p.LastName))
            .FirstOrDefaultAsync(cancellationToken);

        if(purchaser is null)
        {
            throw new Exception("Purchaser with given id is not found!");
        }

        return purchaser;
    }
}
