using Business.Models;

namespace Business.Interfaces.Repositories;

public interface IProdutoRepository : IBaseRepository<Produto>
{
    Task<IEnumerable<Produto>> ObterProdutosFornecedores(Guid fonecedorId);
    Task<IEnumerable<Produto>> ObterProdutosPorFornecedores();
    Task<Produto> ObterProdutoFornecedor(Guid id);
}
