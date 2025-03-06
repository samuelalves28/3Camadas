using Business.Models.Validations.Documentos;
using FluentValidation;
using static Business.Models.Fornecedor;

namespace Business.Models.Validations;

public class FornecedorValidation : AbstractValidator<Fornecedor>
{
    public FornecedorValidation()
    {
        RuleFor(c => c.Nome)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        When(f => f.TipoFornecedor == ETipoFornecedor.PessoaFisica, () =>
        {
            RuleFor(f => f.Documento.Length)
            .Equal(CpfValidacao.TamanhoCpf).WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres para o tipo Pessoa Física");

            RuleFor(f => CpfValidacao.Validar(f.Documento))
                .Equal(true).WithMessage("O Documento fornecido é inválido");
        });

        When(f => f.TipoFornecedor == ETipoFornecedor.PessoaJuridica, () =>
        {
            RuleFor(f => f.Documento.Length)
            .Equal(CnpjValidacao.TamanhoCnpj).WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres para o tipo Pessoa Física");

            RuleFor(f => CnpjValidacao.Validar(f.Documento))
                .Equal(true).WithMessage("O Documento fornecido é inválido");
        });
    }
}
