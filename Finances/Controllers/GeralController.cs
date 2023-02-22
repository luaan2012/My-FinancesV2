using Finances.Models;
using Finances.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Finances.CrossCutting.Helper;

namespace Finances.Controllers
{
    [Route("Geral")]
    public class GeralController : MainController
    {
        private readonly IGeralService _geralService;
        public GeralController(IGeralService geralService, ILogger<GeralController> logger) : base(logger)
        {
            _geralService = geralService;
        }
        
        [HttpPost, Route("SaveToDo")]
        public async Task<IActionResult> SaveToDo(ToDo toDo)
        {
            if(string.IsNullOrEmpty(toDo.Name))
                return BadRequest(new ReturnMessage
                {
                    Message = "Erro, nome vazio ou invalido",
                    Success = false
                });

            toDo.UsersId = HttpContext.Session.GetUsuario().Id;

            var result = await _geralService.SaveToDo(toDo);

            if(result != 1) 
                return BadRequest(new ReturnMessage 
                { 
                    Message = "Erro, tente novamente mais tarde",
                    Success = false
                });

            return Json(new ReturnMessage
            {
                Message = "Tarefa cadastrada!",
                Success = true                
            });;
        }

        [HttpPost, Route("RemoveToDo/{id:guid}")]
        public async Task<IActionResult> RemoveToDo(Guid id)
        {
            var result = await _geralService.RemoveToDo(id);

            if (result != 1)
                return BadRequest(new ReturnMessage
                {
                    Message = "Erro, tente novamente mais tarde",
                    Success = false
                });

            return Json(new ReturnMessage
            {
                Message = "Tarefa excluida com sucesso!",
                Success = true
            }); ;
        }

        [HttpPost, Route("CompleteToDo")]
        public async Task<IActionResult> CompleteToDo(ToDo toDo)
        {
            var result = await _geralService.CompleteToDo(toDo);

            if (result != 1)
                return BadRequest(new ReturnMessage
                {
                    Message = "Erro, tente novamente mais tarde",
                    Success = false
                });

            return Json(new ReturnMessage
            {
                Message = "Tarefa excluida com sucesso!",
                Success = true
            }); ;
        }

        [HttpPost, Route("AddProject")]
        public async Task<IActionResult> AddProject(Projects projects)
        {
            var result = await _geralService.SaveProject(projects);

            if (result != 1) return BadRequest(new ReturnMessage
            {
                Message = "Erro ao adicionar um projeto!",
                Success = false
            });
            
            return Json(new ReturnMessage
            {
                Message = "Projeto adicionado com sucesso!",
                Success = true
            });
        }

        [HttpPost, Route("RemoveProject")]
        public async Task<IActionResult> DeleteProject(Guid id)
        {
            var result = await _geralService.RemoveProject(id);

            if (result != 1) return BadRequest(new ReturnMessage
            {
                Message = "Erro ao remover o projeto!",
                Success = false
            });

            return Json(new ReturnMessage
            {
                Message = "Projeto removido com sucesso!",
                Success = true
            });
        }

        [HttpPost, Route("AddRemember")]
        public async Task<IActionResult> AddRemember(Remember remember)
        {
            var result = await _geralService.AddRemember(remember);

            if (result != 1) return BadRequest(new ReturnMessage
            {
                Message = "Erro ao adicionar lembrete!",
                Success = false
            });

            return Json(new ReturnMessage
            {
                Message = "Lembrete adicionar com sucesso!",
                Success = true
            });
        }

        [HttpPost, Route("RemoveRemember")]
        public async Task<IActionResult> RemoveRemember(Guid id)
        {
            var result = await _geralService.RemoveRemember(id);

            if (result != 1) return BadRequest(new ReturnMessage
            {
                Message = "Erro ao remover o lembrete!",
                Success = false
            });

            return Json(new ReturnMessage
            {
                Message = "Lembrete removido com sucesso!",
                Success = true
            });
        }

        [HttpPost, Route("AddDebts")]
        public async Task<IActionResult> AddDebts(Debts debts)
        {
            var result = await _geralService.AddDebts(debts);

            if (result != 1) return BadRequest(new ReturnMessage
            {
                Message = "Erro ao adicionar um divida!",
                Success = false
            });

            return Json(new ReturnMessage
            {
                Message = "Divida adicionado com sucesso!",
                Success = true
            });
        }

        [HttpPost, Route("RemoveDebts")]
        public async Task<IActionResult> RemoveDebts(Guid id)
        {
            var result = await _geralService.RemoveDebts(id);

            if (result != 1) return BadRequest(new ReturnMessage
            {
                Message = "Erro ao remover a divida!",
                Success = false
            });

            return Json(new ReturnMessage
            {
                Message = "Divida removido com sucesso!",
                Success = true
            });
        }

        [HttpPost, Route("FirstLogin")]
        public async Task<IActionResult> FirstLogin(Users revenue)
        {
            var result = await _geralService.FirstLogin(revenue);

            if (result != 1) return BadRequest(new ReturnMessage
            {
                Message = "Erro ao remover o primeiro!",
                Success = false
            });

            return Json(new ReturnMessage
            {
                Message = "Primeiro removido com sucesso!",
                Success = true
            });
        }

        [HttpPost, Route("SaveVisitor")]
        public async Task<IActionResult> SaveVisitor(VisitorsCountries visitor)
        {
            var result = await _geralService.SaveVisitor(visitor);

            if (result != 1) return BadRequest(new ReturnMessage
            {
                Message = "Erro ao adicionar a viagem!",
                Success = false
            });

            return Json(new ReturnMessage
            {
                Message = "Viagem adicionada com sucesso!",
                Success = true
            });
        }

        [HttpPost, Route("RemoveVisitor")]
        public async Task<IActionResult> RemoveVisitor(Guid id)
        {
            var result = await _geralService.RemoveVisitor(id);

            if (result != 1) return BadRequest(new ReturnMessage
            {
                Message = "Erro ao remover a viagem!",
                Success = false
            });

            return Json(new ReturnMessage
            {
                Message = "Viagem removido com sucesso!",
                Success = true
            });
        }

        [HttpPost, Route("ChangePay")]
        public async Task<IActionResult> ChangePay(Debts debts, bool pay)
        {
            var result = await _geralService.ChangeDebts(debts, pay);

            if (result != 1) return BadRequest(new ReturnMessage
            {
                Message = "Erro ao pagar essa divida!",
                Success = false
            });

            return Json(new ReturnMessage
            {
                Message = "Divida paga com sucesso!",
                Success = true
            });
        }
    }
}
