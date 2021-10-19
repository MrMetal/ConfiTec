using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DemoConfiTec.Business.ViewModels;
using DemoConfiTec.Domain.Interfaces;
using DemoConfiTec.Domain.Interfaces.Repository;
using DemoConfiTec.Domain.Interfaces.Services;
using DemoConfiTec.Domain.Models;
using Microsoft.AspNetCore.Authorization;

namespace DemoConfiTec.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : MainController
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioController(INotificador notificador, 
                                 IUsuarioRepository usuarioRepository, 
                                 IUsuarioService usuarioService, 
                                 IMapper mapper) : base(notificador)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioService = usuarioService;
            _mapper = mapper;
        }
        
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<UsuarioViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<UsuarioViewModel>>(await _usuarioRepository.ObterTodos());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UsuarioViewModel>> ObterPorId(int id)
        {
            var usuario = _mapper.Map<UsuarioViewModel>(await _usuarioRepository.ObterPorId(id));
            if (usuario == null) return NotFound();

            return usuario;
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioViewModel>> Adicionar([FromBody] UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            
            await _usuarioService.Adicionar(_mapper.Map<Usuario>(usuarioViewModel));

            return CustomResponse(usuarioViewModel);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<UsuarioViewModel>> Atualizar(int id, UsuarioViewModel usuarioViewModel)
        {
            if (id != usuarioViewModel.Id) return CustomResponse(usuarioViewModel);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _usuarioService.Atualizar(_mapper.Map<Usuario>(usuarioViewModel));

            return CustomResponse(usuarioViewModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<UsuarioViewModel>> Excluir(int id)
        {
            var usuarioViewModel = await ObterUsuario(id);

            if (usuarioViewModel == null) return NotFound();

            await _usuarioService.Remover(id);

            return CustomResponse(usuarioViewModel);
        }

        private async Task<UsuarioViewModel> ObterUsuario(int id)
        {
            return _mapper.Map<UsuarioViewModel>(await _usuarioRepository.ObterPorId(id));
        }

       
    }
}
