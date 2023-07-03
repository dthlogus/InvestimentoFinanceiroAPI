using API_Financeira.Config;
using API_Financeira.Service;
using Google.Cloud.Firestore;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var firebaseJson = JsonSerializer.Serialize(new FirebaseSettings());

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<StockService>();
builder.Services.AddSingleton(_ => new FirestoreProvider(
         new FirestoreDbBuilder
         {
             ProjectId = FirebaseSettings.ProjectId,
             JsonCredentials = firebaseJson // <-- service account json file
         }.Build()
));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
