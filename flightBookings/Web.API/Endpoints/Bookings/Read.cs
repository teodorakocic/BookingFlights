using Application.Bookings.GetBooking;
using Carter;
using Domain.Purchasers;
using MediatR;

namespace Web.API.Endpoints.Bookings;

public class Read : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("bookings/{id:guid}", async (Guid id, ISender sender) =>
        {
            try
            {
                return Results.Ok(await sender.Send(new GetBookingQuery(id)));
            }
            catch (Exception e)
            {
                return Results.NotFound(e.Message);
            }
        });

        app.MapGet("bookings/purchaser/{id:guid}", async (Guid id, ISender sender) =>
        {
            try
            {
                return Results.Ok(await sender.Send(new GetAllBookings(new PurchaserId(id))));
            }
            catch (Exception e)
            {
                return Results.NotFound(e.Message);
            }
        });
    }
}
