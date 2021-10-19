using System;
using System.Threading.Tasks;
using DemoConfiTec.Business.Validations;
using DemoConfiTec.Data.UoW;
using DemoConfiTec.Domain.Interfaces;
using DemoConfiTec.Domain.Interfaces.Repository;
using DemoConfiTec.Domain.Interfaces.Services;
using DemoConfiTec.Domain.Models;

namespace DemoConfiTec.Business.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(INotificador notificador, 
                              IUnitOfWork uoW, 
                              IUsuarioRepository usuarioRepository) : base(notificador, uoW)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> Adicionar(Usuario usuario)
        {
            if (!ExecutarValidacao(new UsuarioValidation(), usuario)) return false;

            if (usuario.DataNascimento > DateTime.Now)
            {
                Notificar("A data de nascimento não pode ser maior que o dia de hoje.");
                return false;
            }

            _usuarioRepository.Adicionar(usuario);

            var result = await Commit();

            if (result != true)
            {
                Notificar("Não foi possível adicionar o usuario.");
                return false;
            }

            return true;

        }

        public async Task<bool> Atualizar(Usuario usuario)
        {
            if (!ExecutarValidacao(new UsuarioValidation(), usuario)) return false;

            _usuarioRepository.Atualizar(usuario);
            var result = await Commit();

            if (result != true)
            {
                Notificar("Não foi possível atualizar o usuario.");
                return false;
            }

            return true;
        }

        public async Task<bool> Remover(int id)
        {
            _usuarioRepository.Remover(id);

            var result = await Commit();

            if (result != true)
            {
                Notificar("Não foi possível remover o usuario.");
                return false;
            }

            return true;
        }

        public void Dispose()
        {
            _usuarioRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}