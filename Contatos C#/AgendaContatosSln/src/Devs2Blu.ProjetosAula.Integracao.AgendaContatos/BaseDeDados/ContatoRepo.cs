using Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Model.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Devs2Blu.ProjetosAula.Integracao.AgendaContatos.BaseDeDados
{
    public class ContatoRepo
    {
        public MySqlDataReader FetchAll()
        {

            MySqlConnection conn = ConnectionMySql.GetConnection();
            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL_SELECT_CONTATO, conn);
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
        public void Save(Contato contato)
        {
            try
            {
                MySqlConnection conn = ConnectionMySql.GetConnection();
                MySqlCommand cmd = new MySqlCommand(SQL_INSERT_CONTATO, conn);
                cmd.Parameters.Add("@nome", MySqlDbType.VarChar, 60).Value = contato.Nome;
                cmd.Parameters.Add("@sexo", MySqlDbType.VarChar, 1).Value = contato.Sexo;
                cmd.Parameters.Add("@email", MySqlDbType.VarChar, 50).Value = contato.Email;
                cmd.Parameters.Add("@uf", MySqlDbType.VarChar, 45).Value = contato.Nome;
                cmd.Parameters.Add("@status", MySqlDbType.Enum).Value = 'A';
                cmd.Parameters.Add("@telefone", MySqlDbType.VarChar, 20).Value = contato.Telefone;
                cmd.Parameters.Add("@telefone", MySqlDbType.VarChar, 20).Value = contato.Celular;

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException myExc)
            {
                MessageBox.Show(myExc.Message, "Erro de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        public void Deletar(Contato contato)
        {
            try
            {
                MySqlConnection conn = ConnectionMySql.GetConnection();
                MySqlCommand cmd = new MySqlCommand(SQL_DELETE_CONTATO, conn);
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = contato.IdContato;


                cmd.ExecuteNonQuery();
            }
            catch (MySqlException myExc)
            {
                MessageBox.Show(myExc.Message, "Erro de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public void Update(Contato contato)
        {
            try
            {
                MySqlConnection conn = ConnectionMySql.GetConnection();
                MySqlCommand cmd = new MySqlCommand(SQL_UPDATE_CONTATO, conn);
                cmd.Parameters.Add("@nome", MySqlDbType.VarChar, 60).Value = contato.Nome;
                cmd.Parameters.Add("@sexo", MySqlDbType.VarChar, 1).Value = contato.Sexo;
                cmd.Parameters.Add("@email", MySqlDbType.VarChar, 50).Value = contato.Email;
                cmd.Parameters.Add("@uf", MySqlDbType.VarChar, 45).Value = contato.Nome;

                //validação
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = contato.IdContato;
                cmd.ExecuteNonQuery();

            }
            catch (MySqlException myExc)
            {
                MessageBox.Show(myExc.Message, "Erro de MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        #region SQLS
        private const String SQL_SELECT_CONTATO = "SELECT * FROM agendacontatos";

        private const String SQL_INSERT_CONTATO = @"INSERT INTO agendacontatos
            (nome,
            celular,
            email,
            telefone,
            uf, 
            status
            )
            VALUES
            (@nome,
            @celular,
            @email,
            @uf,
            @status)";
        private const String SQL_DELETE_CONTATO = @"DELETE FROM agendacontatos WHERE id = @id ";

        private const String SQL_UPDATE_CONTATO = @"UPDATE agendacontatos SET 
nome = @nome,
sexo = @sexo,
email = @email,
uf = @uf,
WHERE id = @id ";
        #endregion

    }
}

