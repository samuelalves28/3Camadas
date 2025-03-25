using Business.Interfaces.Notificador;
using Business.Interfaces.Repositories;
using Business.Interfaces.Services;
using Business.Models;
using Business.Models.Validations;
using Business.Notificacoes;

namespace Business.Services;

public class FornecedorService(IFornecedorRepository fornecedorRepository, INotificador notificador) : BaseService(notificador), IFornecedorService
{
    public async Task Adicionar(Fornecedor fornecedor)
    {

        if (!ExecuteValidacao(new FornecedorValidation(), fornecedor) || !ExecuteValidacao(new EnderecoValidation(), fornecedor.Endereco)) return;

        if (fornecedorRepository.Buscar(f => f.Documento == fornecedor.Documento).Result.Any())
        {
            Notificar("Já existe um fornecedor com este documento informado.");
            return;
        }

        await fornecedorRepository.Adicionar(fornecedor);
    }

    public async Task Atualizar(Fornecedor fornecedor)
    {
        if (!ExecuteValidacao(new FornecedorValidation(), fornecedor)) return;

        if (fornecedorRepository.Buscar(f => f.Documento == fornecedor.Documento && f.Id != fornecedor.Id).Result.Any())
        {
            Notificar("Já existe um fornecedor com este documento informado.");
            return;
        }

        await fornecedorRepository.Atualizar(fornecedor);
    }

    public async Task Remover(Guid id)
    {
        var fornecedor = await fornecedorRepository.ObterFornecedorProdutosEndereco(id);

        if (fornecedor == null)
        {
            Notificar("Fornecedor não encontrado.");
            return;
        }

        if (fornecedor.Produtos.Count == 0)
        {
            Notificar("O fornecedor possui produtos cadastrados!");
            return;
        }

        var endereco = await fornecedorRepository.ObterEnderecoPorFornecedor(id);

        if (endereco != null)
            await fornecedorRepository.RemoverEnderecoFornecedor(endereco);

        await fornecedorRepository.Remover(id);
    }

    public void Dispose() => fornecedorRepository.Dispose();
}
