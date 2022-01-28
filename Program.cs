using hello_asp_localization.Installers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InstallMvc();
builder.Services.InstallSwagger();

var app = builder.Build();

app.InstallRequestPipeline();
app.Run();
