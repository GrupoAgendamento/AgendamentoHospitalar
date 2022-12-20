using Microsoft.EntityFrameworkCore;
using ProjetoAgendamentoHospitalar.Database;
using ProjetoAgendamentoHospitalar.Persistence;
using ProjetoAgendamentoHospitalar.Persistence.Interfaces;
using ProjetoAgendamentoHospitalar.Service;
using ProjetoAgendamentoHospitalar.Service.Interfaces;

namespace ProjetoAgendamentoHospitalar
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddCors();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<ApplicationDbContext>(
                    options => options.UseSqlServer(
                        builder.Configuration.GetConnectionString("Projeto")  
                ));
            builder.Services.AddScoped<IBeneficiarioService, BeneficiarioService>();
            builder.Services.AddScoped<IBeneficiarioPersist, BeneficiarioPersistence>();
            builder.Services.AddScoped<IGeralPersist, GeralPersistence>();

            builder.Services.AddScoped<IEspecialidadeService, EspecialidadeService>();
            builder.Services.AddScoped<IEspecialidadePersist, EspecialidadePersistence>();

            builder.Services.AddScoped<IHospitalService, HospitalService>();
            builder.Services.AddScoped<IHospitalPersist, HospitalPersistence>();
            builder.Services.AddScoped<IGeralPersist, GeralPersistence>();

            builder.Services.AddScoped<IAgendamentoService, AgendamentoService>();
            builder.Services.AddScoped<IAgendamentoPersist, AgendamentoPersistence>();
            builder.Services.AddScoped<IGeralPersist, GeralPersistence>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();


            app.UseAuthorization();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.MapControllers();

            app.Run();
        }
    }
}