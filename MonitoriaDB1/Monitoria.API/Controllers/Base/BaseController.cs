using Microsoft.AspNetCore.Mvc;
using Monitoria.Application.Shared.Apps;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoria.API.Controllers.Base
{

    public class BaseController<TEntity> : Controller where TEntity : class
    {
        private readonly AppServiceBase<TEntity> _appServiceBase;

        public BaseController(AppServiceBase<TEntity> appServiceBase)
        {
            _appServiceBase = appServiceBase;
        }

        public async Task<IActionResult> ResponseAsync(object result)
        {
            if (!_appServiceBase.Notifications.Any())
            {
                try
                {
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return BadRequest($"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
                }
            }
            else
            {
                return BadRequest(new { errors = _appServiceBase.Notifications });
            }
        }

        public async Task<IActionResult> ResponseExceptionAsync(Exception ex)
        {
            return BadRequest(new { errors = ex.Message, exception = ex.ToString() });
        }
    }
}