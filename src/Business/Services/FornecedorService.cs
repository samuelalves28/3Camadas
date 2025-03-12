using Business.Interfaces.Repositories;
using Business.Interfaces.Services;
using Business.Models;
using Business.Models.Validations;

namespace Business.Services;

public class FornecedorService(IFornecedorRepository fornecedorRepository) : BaseService, IFornecedorService
{
    public async Task Adicionar(Fornecedor fornecedor)
    {
        
        if (!ExecuteValidacao(new FornecedorValidation(), fornecedor) || !ExecuteValidacao(new EnderecoValidation(), fornecedor.Endereco)) return;

        // validar se ja existe um fornecedor com o mesmo documento;

        await fornecedorRepository.Adicionar(fornecedor);
    }

    public async Task Atualizar(Fornecedor fornecedor)
    {
        if (!ExecuteValidacao(new FornecedorValidation(), fornecedor)) return;

        await fornecedorRepository.Atualizar(fornecedor);
    }

    public async Task Remover(Guid id)
    {
        await fornecedorRepository.Remover(id);
    }

    public void Dispose() => fornecedorRepository.Dispose();
}
