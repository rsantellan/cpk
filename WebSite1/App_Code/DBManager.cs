using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de DBManager
/// </summary>
public class DBManager
{
	public DBManager()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    /// <summary>
    /// An static instance for all the connections
    /// </summary>
    /// <returns>Valid SqlConnection for the server</returns>
    public static SqlConnection getInstanceOfConnection()
    {
        SqlConnection sqlConn = new SqlConnection("Data Source=BLACKPOINT;Initial Catalog=formFlows;Integrated Security=True");
        return sqlConn;
    }
}
