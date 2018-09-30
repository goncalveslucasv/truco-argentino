using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace dal
{
    public class Acceso
    {
        SqlConnection conexion;
        SqlTransaction transaccion;

        public void Abrir()
        {
            conexion = new SqlConnection("initial catalog=truco;data source=asd; integrated security=SSPI");
            conexion.Open();
        }

        public void Cerrar()
        {
            conexion.Close();
            conexion.Dispose();
            conexion = null;
        }

        public void AbrirTransaccion(){
            if(transaccion == null && conexion.State == ConnectionState.Open)
            {
                transaccion = conexion.BeginTransaction();
            }
        }
        public void RollbackTransaccion(){
            transaccion.Rollback();
        }
        public void CommitTransaccion(){
            transaccion.Commit();
        }

        public SqlCommand CrearComando(string nombreSP, List<SqlParameter> parametros)
        {
            SqlCommand cmd = new SqlCommand(nombreSP, conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Transaction = transaccion;
            if(parametros != null && parametros.Count() > 0)
            {
                cmd.Parameters.AddRange(parametros.ToArray());
            }

            return cmd;
        }

        public DataTable Leer(string nombreSP, List<SqlParameter> parametros)
        {
            DataTable tabla = new DataTable();
            using(SqlDataAdapter adaptador = new SqlDataAdapter())
            {
                adaptador.SelectCommand = CrearComando(nombreSP, parametros);
                adaptador.Fill(tabla);
                adaptador.Dispose();
            }
            return tabla;

        }

        public int Escribir(string nombreSP, List<SqlParameter> parametros)
        {
            SqlCommand cmd = CrearComando(nombreSP, parametros);
            int filasAfectadas = 0;
            try
            {
                filasAfectadas = cmd.ExecuteNonQuery();

            }
            catch
            {
                filasAfectadas = -1;
            }

            return filasAfectadas;


        }




    }
}
