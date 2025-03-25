using Business.Interfaces.Notificador;
using Business.Models;
using FluentValidation;
using FluentValidation.Results;

namespace Business.Services;

public abstract class BaseService
{
    private readonly INotificador _notificador;

    protected BaseService(INotificador notificador)
    {
        _notificador = notificador;
    }

    protected bool ExecuteValidacao<TV, TM>(TV validacao, TM model)
        where TV : AbstractValidator<TM>
        where TM : BaseModel
    {
        var validator = validacao.Validate(model);

        if (validator.IsValid) return true;

        Notificar(validator);

        return false;
    }

    protected void Notificar(string mensagem)
    {
        _notificador.Handle(new Notificacoes.Notificacao(mensagem));
    }

    protected void Notificar(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
        {
            Notificar(error.ErrorMessage);
        }
    }
}
