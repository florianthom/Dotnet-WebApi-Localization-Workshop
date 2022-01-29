using hello_asp_localization.Installers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InstallMvc();
builder.Services.InstallSwagger();
builder.Services.InstallLocalization();

var app = builder.Build();

app.InstallRequestPipeline();
app.Run();
