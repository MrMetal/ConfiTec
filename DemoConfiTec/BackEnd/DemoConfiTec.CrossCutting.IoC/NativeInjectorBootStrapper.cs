using DemoConfiTec.Business.Services;
using DemoConfiTec.Data.Context;
using DemoConfiTec.Data.Mapping;
using DemoConfiTec.Data.Repository;
using DemoConfiTec.Data.UoW;
using DemoConfiTec.Domain.Interfaces;
using DemoConfiTec.Domain.Interfaces.Repository;
using DemoConfiTec.Domain.Interfaces.Services;
using DemoConfiTec.Domain.Notifications;
using Microsoft.Extensions.DependencyInjection;

namespace DemoConfiTec.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection service)
        {
            //Injeção de dependencia nativa do net core 5

            #region CONFIG
            service.AddScoped<DemoDbContext>();
            service.AddScoped<INotificador, Notificador>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            #region REPOSITORIES
            service.AddScoped<IUsuarioRepository, UsuarioRepository>();
            #endregion

            #region SERVICES
            service.AddScoped<IUsuarioService, UsuarioService>();
            
            #endregion
        }
    }
}