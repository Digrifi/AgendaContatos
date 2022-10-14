using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Model.Enums.Status;
//using System.Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Model.Enums;

namespace Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Model.Classes
{
    public class Contato
    {
        public int IdContato { get; set; }  

        public String Nome { get; set; }
        public Char Sexo { get; set; }
        public String Email { get; set; }
        public int Telefone { get; set; }
        public int Celular { get; set; }
        public string Uf { get; set; }
        public string Cidade { get; set; }

        public StatusContato StatusCt { get; set; }

        public Contato(string nome, char sexo, string email, int telefone, int celular, string uf, string cidade)
        {
            Nome = nome;
            Sexo = sexo;
            Email = email;
            Telefone = telefone;
            Celular = celular;
            Uf = uf;
            Cidade = cidade;
            StatusCt = StatusContato.A;

        }
    }
}
