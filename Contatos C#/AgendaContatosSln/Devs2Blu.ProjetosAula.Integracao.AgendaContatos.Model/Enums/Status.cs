using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Model.Enums
{
    public class Status
    {
        public enum StatusCompromisso
        {
            [Description("inativo")]
            I = 1,
            [Description("ativo")]
            A = 2,
            [Description("concluído")]
            C = 3,
            [Description("remarcado")]
            R = 4,

        }
        public enum StatusContato
        {
            [Description("Inativo")]
            I = 1,
            [Description("Ativo")]
            A = 2
        }
    }
}
