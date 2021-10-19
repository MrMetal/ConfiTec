using System;
using System.Threading.Tasks;
using DemoConfiTec.Domain.Models;

namespace DemoConfiTec.Domain.Interfaces.Services
{
    public interface IUsuarioService : IDisposable
    {
        Task<bool> Adicionar(Usuario usuario);
        Task<bool> Atualizar(Usuario usuario);
        Task<bool> Remover(int id);
    }
}