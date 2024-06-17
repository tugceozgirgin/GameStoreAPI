using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

public static class DataExtensions
{
    public static async Task MigrateDbAsync(this WebApplication app)
    {
        //we can us eto request the service container of asp.net core to give us an 
        //instance of some of the services that have been registered in the application.
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        await dbContext.Database.MigrateAsync(); //EXECUTE MIGRATION ON STARTUP


    }

}
