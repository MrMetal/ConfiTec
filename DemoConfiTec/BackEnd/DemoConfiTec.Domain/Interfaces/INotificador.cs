using System.Collections.Generic;
using DemoConfiTec.Domain.Notifications;

namespace DemoConfiTec.Domain.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}