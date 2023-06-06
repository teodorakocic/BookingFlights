using Application.Purchasers.Create;
using Application.Purchasers.Read;
using Application.Purchasers.Update;
using Carter;
using Domain.Purchasers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Endpoints.Purchasers;

public class Purchasers : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
       app.MapPost("purchasers", async (CreatePurchaserCommand command, ISender sender) =>
        {
            await sender.Send(command);

            return Results.Ok();
        });

        app.MapGet("purchasers/{id:guid}", async (Guid id, ISender sender) =>
        {
            try
            {
                return Results.Ok(await sender.Send(new ReadPurchaserQuery(new PurchaserId(id))));
            }
            catch (Exception e)
            {
                return Results.NotFound(e.Message);
            }
        });

        app.MapPut("purchasers/{id:guid}", async (Guid id, [FromBody] UpdatePurchaserRequest request, ISender sender) =>
        {
            var command = new UpdatePurchaserCommand(
                new PurchaserId(id),
                request.FirstName,
                request.LastName);

            await sender.Send(command);

            return Results.NoContent();
        });
    }
}
