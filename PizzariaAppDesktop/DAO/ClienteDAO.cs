using PizzariaAppDesktop.ConnectionFactory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzariaAppDesktop.DAO
{
    public class ClienteDAO
    {
        public DataTable GetClientes()
        {
            DbConnection conn = ConexaoDb.GetConnection();
            DbCommand comando = ConexaoDb.GetCommand(conn);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM cliente";
            DbDataReader reader = ConexaoDb.GetDataReader(comando);
            DataTable table = new DataTable();
            table.Load(reader);
            return table;
        }

        public void IncluirCliente(Cliente cliente)
        {
            DbConnection conn = ConexaoDb.GetConnection();
            DbCommand comando = ConexaoDb.GetCommand(conn);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "INSERT INTO Cliente (nome, cpf) VALUES(@nome, @cpf)";
            comando.Parameters.Add(new SqlParameter("nome",cliente.Nome));
            comando.Parameters.Add(new SqlParameter("cpf", cliente.Cpf));
            comando.ExecuteNonQuery();
        }

        public void AlterarCliente(Cliente cliente)
        {
            DbConnection conn = ConexaoDb.GetConnection();
            DbCommand comando = ConexaoDb.GetCommand(conn);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "UPDATE Cliente SET nome = @nome, cpf = @cpf WHERE id = @id";
            comando.Parameters.Add(new SqlParameter("nome", cliente.Nome));
            comando.Parameters.Add(new SqlParameter("cpf", cliente.Cpf));
            comando.Parameters.Add(new SqlParameter("id", cliente.Id));
            comando.ExecuteNonQuery();
        }

        public void ExcluirCliente(int id)
        {
            DbConnection conn = ConexaoDb.GetConnection();
            DbCommand comando = ConexaoDb.GetCommand(conn);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "DELETE FROM Cliente WHERE id = @id";
            comando.Parameters.Add(new SqlParameter("id", id));
            comando.ExecuteNonQuery();
        }

        public int ContarClientes()
        {
            DbConnection conn = ConexaoDb.GetConnection();
            DbCommand comando = ConexaoDb.GetCommand(conn);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT COUNT(*) FROM Cliente";
            return Convert.ToInt32(comando.ExecuteScalar());
        }
    }
}
