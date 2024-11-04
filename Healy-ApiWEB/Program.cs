using Healy_ApiWEB.Repository.Implementations;
using Healy_ApiWEB.Repository;
using Healy_ApiWEB.Services.Implementations;
using Healy_ApiWEB.Services;
using Microsoft.EntityFrameworkCore;
using Healy_ApiWEB.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using IdentityModel.Client;
using Microsoft.ML;
using System.IO;
using Healy_ApiWEB.Models;
using Microsoft.ML.Trainers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));

builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<IProfissionalRepository, ProfissionalRepository>();
builder.Services.AddScoped<IExameRepository, ExameRepository>();

builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<IProfissionalService, ProfissionalService>();
builder.Services.AddScoped<IExameService, ExameService>();

builder.Services.AddHttpClient();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.Authority = $"https://{builder.Configuration["Auth0:dev-b42rnz5hakwo5p2s.us.auth0.com"]}/";
    options.Audience = builder.Configuration["Auth0:healy-auth"];
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "HealyWebAPI", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

void TreinarModeloRecomendacao()
{
    var mlContext = new MLContext();

    IDataView trainingData = mlContext.Data.LoadFromTextFile<ProfissionalRecomendacao>("historico_profissionais.csv", separatorChar: ',', hasHeader: true);

    var options = new MatrixFactorizationTrainer.Options
    {
        MatrixColumnIndexColumnName = nameof(ProfissionalRecomendacao.ProfissionalId),
        MatrixRowIndexColumnName = nameof(ProfissionalRecomendacao.PacienteId), 
        LabelColumnName = nameof(ProfissionalRecomendacao.Label), 
        NumberOfIterations = 20,
        ApproximationRank = 100
    };

    var pipeline = mlContext.Recommendation().Trainers.MatrixFactorization(options);

        var model = pipeline.Fit(trainingData);

    mlContext.Model.Save(model, trainingData.Schema, "modeloRecomendacaoProfissionais.zip");
}

if (!File.Exists("historico_profissionais.csv"))
{
    using (var stream = File.Create("historico_profissionais.csv"))
    {
        using (var writer = new StreamWriter(stream))
        {

            writer.WriteLine("PacienteId,ProfissionalId,Label");

            writer.WriteLine("1,1,5");
            writer.WriteLine("1,2,4");
            writer.WriteLine("2,1,3");
        }
    }
}

if (!File.Exists("modeloRecomendacaoProfissionais.zip"))
{
    TreinarModeloRecomendacao();
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HealyWebAPI v1"));
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
