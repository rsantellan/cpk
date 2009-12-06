using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.Odbc;

[System.ComponentModel.Description("Atributo")]
public partial class AtributoInformacionGeneral : System.Web.UI.UserControl, SmartPart.IConnectionConsumerControl
{
    System.Data.Odbc.OdbcConnection _con;
    System.Data.Odbc.OdbcCommand _cmd;

    protected void Page_Load(object sender, EventArgs e)
    {
       
        LabeIdentificador.Text = Convert.ToString(this.getNewId());
        LabelVersion.Text = "1";
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
        //this._con = new OdbcConnection("DSN=FormFlow");
        //this._con.Open();
        //this._cmd = this._con.CreateCommand();
        //this._cmd.CommandText = "SELECT Identificador FROM AtributoInformacionGeneral WHERE Identificador = (SELECT MAX(Identificador)  FROM AtributoInformacionGeneral) )";
        //OdbcDataReader DbReader = this._cmd.ExecuteReader();
        int max = 0;
        //while (DbReader.Read())
        //{
        //    max = Int16.Parse(DbReader["identificador"].ToString());
        //}
        //this._con.Close();
        max = max + 1;
        return max;
    }

    protected void ButtonGuardar_Click(object sender, EventArgs e)
    {

        this.guardar();
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
                this.LabeIdentificador.Text + ",'" +
                this.LabelAutor.Text + "'," +
                this.LabelVersion.Text + ",'" +
                this.LabelFechaCreacion.Text + "','" +
                this.CalendarDesde.SelectedDate.Date.ToString() + "','" +
                this.CalendarHasta.SelectedDate.Date.ToString() + "','" +
                this.TextBoxDescripcion.Text + "','" +
                this.TextBoxDescripcion.Text + "'," +
                modificable + ");";
        this._con = new OdbcConnection("DSN=FormFlow");
        this._con.Open();
        this._cmd = this._con.CreateCommand();
        this._cmd.CommandText = sql;
        //this._cmd.Connection = this._con;
        this._cmd.ExecuteNonQuery();
        this._con.Close();
        //this.LabeIdentificador.Text = sql;
    }
    #region IConnectionConsumerControl Members

    public string ConsumerMenuLabel
    {
        get { return "Receives text data from"; }
    }

    public void SetConsumerData(object data)
    {
        if (data.GetType() == typeof(string))
        {
            String dato = data.ToString();
            if(dato.Equals("save")){
                this.guardar();
            }
        }
    }

    #endregion


}
