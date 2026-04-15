namespace Fina.Api.Common.Api;

public static class AppExtension
{
    public static void ConfigureDevEnviorment(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        //app.MapSwagger().RequireAuthorization();
    }
}