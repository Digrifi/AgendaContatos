using Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Model.Enums.Status;

namespace Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Model.Classes
{
    public class Compromissos
    {
        public int IdCompromisso { get; set; } 
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public StatusCompromisso StatusComp { get; set; }

        public Compromissos(string titulo, string descricao, DateTime data)
        {
            Titulo = titulo;
            Descricao = descricao;
            Data = data;
            StatusComp = StatusCompromisso.A;
        }
    }
}
