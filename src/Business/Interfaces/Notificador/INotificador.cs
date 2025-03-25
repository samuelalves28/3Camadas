using Business.Notificacoes;

namespace Business.Interfaces.Notificador;

public interface INotificador
{
    bool TemNotificacao();
    List<Notificacao> ObterNotificacoes();
    void Handle(Notificacao notificacao);
}
