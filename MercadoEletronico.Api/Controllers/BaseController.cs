using MercadoEletronico.Infrastructure.Transactions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MercadoEletronico.Api.Controllers
{
    public class BaseController: Controller
    {
        private readonly IUow _uow;

        public BaseController(IUow uow)
        {
            _uow = uow;
        }

        public new async Task<IActionResult> Response(object result, string message = "")
        {
            try
            {
                if (result == null)
                {
                    return BadRequest(new
                    {
                        message = message
                    });
                }
                else
                {
                    await _uow.Commit();
                    return Ok(result);
                }
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    message = e.Message
                });
            }
        }

    }
}
