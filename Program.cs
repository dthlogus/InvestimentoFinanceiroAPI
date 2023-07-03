using API_Financeira.Service;
using FirebaseAdmin;
using Google.Cloud.Firestore;

var builder = WebApplication.CreateBuilder(args);
FirestoreDb db = FirestoreDb.Create("investimentoFinanceiro");
Console.WriteLine("Created Cloud Firestore client with project ID: {0}", "investimentoFinanceiro");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<StockService>();
builder.Services.AddScoped<UsuarioService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
