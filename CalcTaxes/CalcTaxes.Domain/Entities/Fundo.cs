using CalcTaxes.Domain.Dto.Request;

namespace CalcTaxes.Domain.Entities
{
    public class Fundo
    {
        private readonly DbContext _dbContext;

        public decimal Saldo { get; set; }

        public Fundo(decimal saldo, DbContext dbContext)
        {
            Saldo = saldo;
            _dbContext = dbContext;
        }

        public void AdicionaSaldo(AplicacaoRequest aplicacaoRequest)
        {
            var query = @"UPDATE f
                          SET f.saldo = f.saldo + @p0";

            _dbContext.Execute(query, new { p0 = aplicacaoRequest.Valor });
        }

        public void RemoveSaldo(AplicacaoRequest aplicacaoRequest)
        {
            var query = @"UPDATE f
                          SET f.saldo = f.saldo - @p0";

            _dbContext.Execute(query, new { p0 = aplicacaoRequest.Valor });
        }
    }
}

