using DotNetEnv;

var builder = Run();

WebApplication Run()
{

    Env.Load(); // loads .env from the app root

    var builder = WebApplication.CreateBuilder(args);

    
    builder.Services.AddControllersWithViews();

    // Register MongoDBContext so controllers can receive it via DI
    builder.Services.AddSingleton<FlowBoard_Project_Management_System_MVC.Data.MongoDBContext>();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Auth}/{action=Login}/{id?}");

    app.Run();

    return app;
}
