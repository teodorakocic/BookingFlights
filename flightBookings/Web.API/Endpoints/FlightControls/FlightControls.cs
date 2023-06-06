using Application.FlightControls.Create;
using Application.FlightControls.Delete;
using Application.FlightControls.Read;
using Carter;
using Domain.FlightControl;
using MediatR;

namespace Web.API.Endpoints.FlightControls;

public class FlightControls : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("flights", async (CreateFlightControlCommand command, ISender sender) =>
        {
            await sender.Send(command);

            return Results.Ok();
        });

        app.MapGet("flights/{id:guid}", async (Guid id, ISender sender) =>
        {
            try
            {
                return Results.Ok(await sender.Send(new ReadFlightControlQuery(new FlightControlId(id))));
            }
            catch (Exception e)
            {
                return Results.NotFound(e.Message);
            }
        });

        app.MapDelete("flights/{id:guid}", async (Guid id, ISender sender) =>
       {
           try
           {
               await sender.Send(new DeleteFlightControlCommand(new FlightControlId(id)));

               return Results.NoContent();
           }
           catch (Exception e)
           {
               return Results.NotFound(e.Message);
           }
       });
    }
}
