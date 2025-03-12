using Business.Models;
using System.Linq.Expressions;

namespace Business.Interfaces.Repositories;

public interface IBaseRepository<TModel> : IDisposable where TModel : BaseModel
{
    Task Adicionar(TModel model);
    Task Atualizar(TModel model);
    Task<TModel> ObterPorId(Guid id);
    Task<IEnumerable<TModel>> ObterTodos();
    Task Remover(Guid id);
    Task<IEnumerable<TModel>> Buscar(Expression<Func<TModel, bool>> predicate);
    Task<int> SaveChanges();
}
