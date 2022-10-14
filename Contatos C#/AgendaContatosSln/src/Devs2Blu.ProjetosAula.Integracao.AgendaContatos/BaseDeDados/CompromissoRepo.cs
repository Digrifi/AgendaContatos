
using Devs2Blu.ProjetosAula.Integracao.AgendaContatos.BaseDeDados;
using Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Model.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Devs2Blu.ProjetosAula.Integracao.Agendacompromissoss.BaseDeDados
{

    public class compromissosRepo
    {
        public MySqlDataReader FetchAll()
        {

            MySqlConnection conn = ConnectionMySql.GetConnection();
            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL_SELECT_COMPROMISSOS, conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                return dataReader;
            }
            catch (MySqlException myExc)
            {
                MessageBox.Show(myExc.Message, "Erro de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            // DataSet data = new DataSet();
        }
        public void Save(Compromissos compromisso)
        {
            try
            {
                MySqlConnection conn = ConnectionMySql.GetConnection();
                MySqlCommand cmd = new MySqlCommand(SQL_INSERT_COMPROMISSOS, conn);

                cmd.Parameters.Add("@titulo", MySqlDbType.VarChar, 45).Value = compromisso.Titulo;
                cmd.Parameters.Add("@descricao", MySqlDbType.VarChar, 45).Value = compromisso.Descricao;
                cmd.Parameters.Add("@data", MySqlDbType.DateTime).Value = compromisso.Data;
                cmd.Parameters.Add("@status", MySqlDbType.Enum).Value = compromisso.StatusComp;

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException myExc)
            {
                MessageBox.Show(myExc.Message, "Erro de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        public void Deletar(Compromissos compromisso)
        {
            try
            {
                MySqlConnection conn = ConnectionMySql.GetConnection();
                MySqlCommand cmd = new MySqlCommand(SQL_DELETE_COMPROMISSOS, conn);
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = compromisso.IdCompromisso;


                cmd.ExecuteNonQuery();
            }
            catch (MySqlException myExc)
            {
                MessageBox.Show(myExc.Message, "Erro de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public void Update(Compromissos compromisso)
        {
            try
            {
                MySqlConnection conn = ConnectionMySql.GetConnection();
                MySqlCommand cmd = new MySqlCommand(SQL_UPDATE_COMPROMISSOS, conn);
                cmd.Parameters.Add("@titulo", MySqlDbType.VarChar, 60).Value = compromisso.Titulo;
                cmd.Parameters.Add("@descricao", MySqlDbType.VarChar, 1).Value = compromisso.Descricao;
                cmd.Parameters.Add("@data", MySqlDbType.DateTime).Value = compromisso.Data;
                cmd.Parameters.Add("@status", MySqlDbType.Enum).Value = compromisso.StatusComp;

                //validação
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = compromisso.IdCompromisso;

                cmd.ExecuteNonQuery();

            }
            catch (MySqlException myExc)
            {
                MessageBox.Show(myExc.Message, "Erro de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        #region SQLS
        private const String SQL_SELECT_COMPROMISSOS = "SELECT * FROM agendacontatos";

        private const String SQL_INSERT_COMPROMISSOS = @"INSERT INTO agendacontatos
            (
titulo,          
data,
descricao,
status
            )
            VALUES
            (
@titulo,
            
@data,
@descricao,
@status)";
        private const String SQL_DELETE_COMPROMISSOS = @"DELETE FROM agendacontatos WHERE id = @id ";

        private const String SQL_UPDATE_COMPROMISSOS = @"UPDATE agendacontatos SET 
            nome = @nome,
            sexo = @sexo,
            email = @email,
            uf = @uf,
            WHERE id = @id ";
    }
    #endregion SQLS
}


