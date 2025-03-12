using Business.Models;
using FluentValidation;

namespace Business.Services;

public abstract class BaseService
{
    protected bool ExecuteValidacao<TV, TM>(TV validacao, TM model)
        where TV : AbstractValidator<TM>
        where TM : BaseModel
    {
        var validator = validacao.Validate(model);
        
        if (validator.IsValid) return true;


        // lancemento de notificacoes

        return false;
    }
}
