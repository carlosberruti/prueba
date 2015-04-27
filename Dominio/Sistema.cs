using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Configuration;


public class Sistema
{

    private static Sistema _instancia;


    public static Sistema Instancia
    {
        get
        {
            if (_instancia == null)
                _instancia = new Sistema();
            return Sistema._instancia;
        }
    }
	private Sistema()
	{
	
	}

    public bool ValidarUsuario(string pUsu, string pPass)
    {
        bool retorno = false;

        try
        {

            string connString = this.getStringConnection();
            DataTable dt = new DataTable();
            
            string query = "select * from usuarios where usuario='" + pUsu+"'";

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            
            da.Fill(dt);
            conn.Close();
            da.Dispose();
            if (dt.Rows.Count != 0)
            {
                string user = (string)dt.Rows[0][0];
                string pass = (string)dt.Rows[0][1];
                if (pUsu == user && pPass == pass)
                    retorno = true;
            }

        }
        catch (Exception e) {
            retorno = false;
        }
        
        return retorno;
    }
    private string getStringConnection() {

        
        Configuration rootWebConfig = WebConfigurationManager.OpenWebConfiguration("/");
        ConnectionStringSettings connString;
        String resultado = "";
        if (0 < rootWebConfig.ConnectionStrings.ConnectionStrings.Count)
        {
            connString =
                rootWebConfig.ConnectionStrings.ConnectionStrings["BDLOGIN"];
            if (null != connString)
            {
                Console.WriteLine("connection string = \"{0}\"",
                    connString.ConnectionString);
                resultado = connString.ConnectionString;
            }
            else
                Console.WriteLine("No Northwind connection string");
        }

        return resultado;
    
    
    }
    
}