using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proj4
{
    public class Usuario
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public Usuario(int id, string Nome, string Email, string Senha)
        {
            this.id = id;
            this.Nome = Nome;
            this.Email = Email;
            this.Senha = Senha;
        }
        public Usuario(string Nome, string Email, string Senha)
        {
            this.id = 0;
            this.Nome = Nome;
            this.Email = Email;
            this.Senha = Senha;
        }




    }
}
