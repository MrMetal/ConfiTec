using System.Threading.Tasks;
using DemoConfiTec.Data.UoW;
using DemoConfiTec.Domain.Interfaces;
using DemoConfiTec.Domain.Models;
using DemoConfiTec.Domain.Notifications;
using FluentValidation;
using FluentValidation.Results;

namespace DemoConfiTec.Business.Services
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;
        private readonly IUnitOfWork _uoW;

        protected BaseService(INotificador notificador, IUnitOfWork uoW)
        {
            _notificador = notificador;
            _uoW = uoW;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notificar(validator);

            return false;
        }

        public virtual Task<bool> Commit()
        {
            return _uoW.Commit();
        }
        
    }
}