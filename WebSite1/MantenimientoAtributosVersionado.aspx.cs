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

public partial class MantenimientoAtributos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //this.GridViewDatos.Visible = false;
    }
    protected void ButtonBusqueda_Click(object sender, EventArgs e)
    {
        this.Label1.Text = "Funciono ajax :)";
        this.cargarDatos();
    }

    private void cargarDatos()
    {
        ABMCAtributo abmc = new ABMCAtributo();
        this.Label2.Text = this.DropDownListAutores.SelectedValue.ToString();
        this.LabelError.Text = this.DropDownListAutores.SelectedValue.ToString();
        DateTime creacionDesde = new DateTime();
        if (string.IsNullOrEmpty(this.TextBoxCreacionDesde.Text))
        {
            creacionDesde = DateTime.MinValue;
        }
        else
        {
            creacionDesde = DateTime.Parse(this.TextBoxCreacionDesde.Text);
        }
        DateTime creacionHasta = new DateTime();
        if (string.IsNullOrEmpty(this.TextBoxCreacionHasta.Text))
        {
            creacionHasta = DateTime.MinValue;
        }
        else
        {
            creacionHasta = DateTime.Parse(this.TextBoxCreacionHasta.Text);
        }
        DateTime vigenciaFinDesde = new DateTime();
        if (string.IsNullOrEmpty(this.TextBoxVigenciaFinDesde.Text))
        {
            vigenciaFinDesde = DateTime.MinValue;
        }
        else
        {
            vigenciaFinDesde = DateTime.Parse(this.TextBoxVigenciaFinDesde.Text);
        }
        DateTime vigenciaFinHasta = new DateTime();
        if (string.IsNullOrEmpty(this.TextBoxVigenciaFinHasta.Text))
        {
            vigenciaFinHasta = DateTime.MinValue;
        }
        else
        {
            vigenciaFinHasta = DateTime.Parse(this.TextBoxVigenciaFinHasta.Text);
        }
        DateTime vigenciaDesde = new DateTime();
        if (string.IsNullOrEmpty(this.TextBoxVigenciaDesde.Text))
        {
            vigenciaDesde = DateTime.MinValue;
        }
        else
        {
            vigenciaDesde = DateTime.Parse(this.TextBoxVigenciaDesde.Text);
        }
        DateTime vigenciaHasta = new DateTime();
        if (string.IsNullOrEmpty(this.TextBoxVigenciaHasta.Text))
        {
            vigenciaHasta = DateTime.MinValue;
        }
        else
        {
            vigenciaHasta = DateTime.Parse(this.TextBoxVigenciaHasta.Text);
        }
        int version = 0;
        if (!String.IsNullOrEmpty(this.TextBoxVersion.Text))
        {
            try
            {
                version = Convert.ToInt16(this.TextBoxVersion.Text);
            }
            catch (Exception e)
            {
               
            }
            
        }
        DataSet datos = abmc.buscarAtributos(this.TextBoxNombre.Text, Convert.ToBoolean(this.DropDownListEstado.SelectedValue), this.DropDownListAutores.SelectedValue.ToString(), " ", version, vigenciaDesde, vigenciaHasta, vigenciaFinDesde, vigenciaFinHasta, creacionDesde, creacionHasta);
        //foreach (DataRow row in datos.Tables[0].rows)
        //{
            
        //}
        this.GridViewDatos.DataSource = datos;
        this.GridViewDatos.DataBind();
        this.GridViewDatos.Visible = true;
    }


    protected void GridViewDatos_SelectedIndexChanged(object sender, EventArgs e)
    {
        //GridViewRow dr = new GridViewRow(GridViewDatos.SelectedRow);
        
        //dr.BackColor = System.Drawing.Color.FromName("#FAF7DA");
        GridView grid = (GridView)sender;//-		sender	{System.Web.UI.WebControls.GridView}	object {System.Web.UI.WebControls.GridView}
        this.Label2.Text = grid.SelectedRow.Cells[1].Text;
        String place = "Atributos.aspx?id=" + grid.SelectedRow.Cells[1].Text + "&identificador=" + grid.SelectedRow.Cells[2].Text;
        Response.Redirect(place);
        //Server.Transfer(place);
        //Console.WriteLine(e);
    }
}
