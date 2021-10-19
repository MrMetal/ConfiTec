using System;

namespace DemoConfiTec.Domain.Models
{
    public class Usuario : Entity
    {
        
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Escolaridade { get; set; }
    }
}