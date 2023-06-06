using Application.Bookings.AddTicket;
using Application.Bookings.Create;
using Application.Bookings.RemoveTicket;
using Carter;
using Domain.Bookings;
using Domain.FlightControl;
using MediatR;

namespace Web.API.Endpoints.Bookings
{
    public class Create : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("bookings", async (Guid purchaserId, Guid flightControlId, string currency, decimal amount, string seatNumber, ISender sender) =>
            {
                var command = new CreateBookingCommand(purchaserId, flightControlId, currency, amount, seatNumber);

                await sender.Send(command);

                return Results.Ok();
            });

            app.MapPost("booking/add-ticket", async (Guid bookingId, Guid flightControlId, string currency, decimal amount, string seatNumber, ISender sender) =>
            {
                var command = new AddTicketToBooking(new BookingId(bookingId), new FlightControlId(flightControlId), currency, amount, seatNumber);

                await sender.Send(command);

                return Results.Ok();
            });

            app.MapDelete("bookings/{id}/tickets/{ticketId}", async (Guid id, Guid ticketId, ISender sender) =>
            {
                var command = new RemoveTicket(new BookingId(id), new TicketId(ticketId));

                await sender.Send(command);

                return Results.Ok();
            });
        }
    }
}
