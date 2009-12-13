using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.Odbc;


public partial class Atributos : System.Web.UI.Page
{

    System.Data.Odbc.OdbcConnection _con;
    System.Data.Odbc.OdbcCommand _cmd;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Write("Esto es el numero que me pasaron ");
        String id = Request.QueryString["id"];
        String identificador = Request.QueryString["identificador"];
        //Response.Write(id);
        LabelVersion.Text = identificador;
        LabelIdentificador.Text = Convert.ToString(this.getNewId());
        this.HiddenField1.Value = LabelIdentificador.Text;

        String userFull = HttpContext.Current.User.Identity.Name;
        String user = "";
        bool save = false;
        foreach (char a in userFull)
        {
            if (save)
            {
                user += a;
            }
            if (a == '\\')
            {
                save = true;
            }

        }
        LabelAutor.Text = user;
        LabelFechaCreacion.Text = DateTime.Today.Date.ToShortDateString();
    }

    private int getNewId()
    {
        int max = 0;
        try
        {
            this._con = new OdbcConnection("DSN=FormFlow");
            this._con.Open();
            this._cmd = this._con.CreateCommand();
            this._cmd.CommandText = "SELECT Identificador FROM AtributoInformacionGeneral WHERE Identificador = (SELECT MAX(Identificador)  FROM AtributoInformacionGeneral) ";
            this._cmd.Connection = this._con;
            OdbcDataReader DbReader = this._cmd.ExecuteReader();

            while (DbReader.Read())
            {
                max = Convert.ToInt16((DbReader["identificador"].ToString()));
            }

        }
        catch (Exception e)
        {
            this.LabelVersion.Text = e.Message;
        }
        finally
        {
            this._con.Close();
        }

        max = max + 1;
        return max;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.RequiredFieldValidator1.IsValid
            && this.RequiredFieldValidator2.IsValid
            && this.RequiredFieldValidator3.IsValid
            && this.RequiredFieldValidatorCalendarDesde.IsValid)
        {

            this.guardar();
        }
    }

    private void guardar()
    {
        int modificable = 0;
        if (this.CheckBoxModificable.Checked)
        {
            modificable = 1;
        }
        String sql = "INSERT INTO " +
                "AtributoInformacionGeneral " +
                "(" +
                "Identificador," +
                "Autor," +
                "Version," +
                "FechaCreacion," +
                "FechaVigenciaDesde," +
                "FechaVigenciaHasta," +
                "Nombre," +
                "Descripcion," +
                "EsModificable" +
                ")" +
                "VALUES (" +
                this.LabelIdentificador.Text + ",'" +
                this.LabelAutor.Text + "'," +
                this.LabelVersion.Text + ",'" +
                this.LabelFechaCreacion.Text + "','" +
                this.TextCalendarDesde.Text + "','" +
                this.TextBoxCalendarHasta.Text + "','" +
                this.TextBoxDescripcion.Text + "','" +
                this.TextBoxDescripcion.Text + "'," +
                modificable + ");";
        this._con = new OdbcConnection("DSN=FormFlow");
        this._con.Open();
        this._cmd = this._con.CreateCommand();
        this._cmd.CommandText = sql;
        this._cmd.ExecuteNonQuery();
        this._con.Close();
    }
}
