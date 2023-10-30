using CalcTaxes.Domain.Dto.Request;
using Microsoft.AspNetCore.Mvc;

namespace CalcTaxes.Controllers
{
    public class FundoController : Controller
    {
        [HttpPost]
        [Route("/Aplicacao")]
        public void Aplicacao(AplicacaoRequest aplicacaoRequest)
        {
            
        }
    }
}
