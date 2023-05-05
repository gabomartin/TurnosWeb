using TurnosWeb.Services.Abstractions;

namespace TurnosWeb.Api.Mappings
{
	public static class BarberMapping
	{
		public static void MapBarberEndpoints(this WebApplication app)
		{
			app.MapGet("/Barber/", (IBarberDomainService contextService) =>
			{
				return contextService.GetBarbers();
			})
			.WithName("GetBarbers")
			.WithOpenApi();
		}
	}
}
