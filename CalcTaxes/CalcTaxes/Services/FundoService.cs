using CalcTaxes.Domain.Dto.Request;
using CalcTaxes.Domain.Entities;

namespace CalcTaxes.Services
{
    public class FundoService
    {
        public readonly Cliente Cliente;
        private readonly DbContext _dbContext;
        private readonly ContaBanco _contaBanco;
        private readonly Fundo _fundo;
        private readonly Movimentacao _movimentacao;

        public FundoService(Cliente cliente, ContaBanco contaBanco, DbContext dbContext, Fundo fundo, Movimentacao movimentacao)
        {
            Cliente = cliente;
            _contaBanco = contaBanco;
            _dbContext = dbContext;
            _fundo = fundo;
            _movimentacao = movimentacao;
        }

        public void Aplicacao(AplicacaoRequest aplicacaoRequest)
        {
            removeSaldoCliente(aplicacaoRequest);
            AdicionaValorNoFundo(aplicacaoRequest);
            gravarMovimentacao(aplicacaoRequest);
        }

        public void removeSaldoCliente(AplicacaoRequest aplicacaoRequest)
        {
            _contaBanco.RemoveSaldo(aplicacaoRequest);
        }

        public void AdicionaValorNoFundo(AplicacaoRequest aplicacaoRequest)
        {
            _fundo.AdicionaSaldo(aplicacaoRequest);
        }

        public void gravarMovimentacao(AplicacaoRequest aplicacaoRequest)
        {
            var query = @"INSERT INTO Movimentacao
                         (tipoMovimentacao, data, valor, ClienteId)
                          VALUES
                          (@p0, @p1, @p2, @p3)";

            _dbContext.Execute(query, new { p0 = aplicacaoRequest.TipoMovimentacao, p1 = aplicacaoRequest.Data, p2 = DateTime.Now, p3 = aplicacaoRequest.ClienteId });
        }
    }
}
