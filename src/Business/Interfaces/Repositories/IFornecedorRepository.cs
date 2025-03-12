using Business.Models;

namespace Business.Interfaces.Repositories;

public interface IFornecedorRepository : IBaseRepository<Fornecedor>
{
    Task<Fornecedor> ObterFornecedorEndereco(Guid id);
    Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id);
    Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId);
}
