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
        this.LabelError.Visible = false;
    }
    protected void ButtonBusqueda_Click(object sender, EventArgs e)
    {
        this.cargarDatos();
    }

    private void cargarDatos()
    {
        ABMCAtributo abmc = new ABMCAtributo();
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
                Console.WriteLine(e.Message);
            }
            
        }
        int estado;
        if (String.IsNullOrEmpty(this.DropDownListEstado.SelectedValue))
        {
            estado = -1;
        }
        else
        {
            estado = Convert.ToInt16(this.DropDownListEstado.SelectedValue);
        }
        DataSet datos = abmc.buscarAtributos(this.TextBoxNombre.Text, estado, this.DropDownListAutores.SelectedValue.ToString(), " ", version, vigenciaDesde, vigenciaHasta, vigenciaFinDesde, vigenciaFinHasta, creacionDesde, creacionHasta);
        DataSet show = new DataSet();

        DataTable dt = new DataTable();
        show.Tables.Add(dt);
        DataColumn dc = new DataColumn("ID");
        dt.Columns.Add(dc);
        dc = new DataColumn("ModificarMostrar");
        dc.ColumnMapping = MappingType.Hidden;
        dt.Columns.Add(dc);
        dc = new DataColumn("VersionadoMostrar");
        dt.Columns.Add(dc);
        dc = new DataColumn("Nombre");
        dt.Columns.Add(dc);
        dc = new DataColumn("Pilar");
        dt.Columns.Add(dc);
        dc = new DataColumn("fecha_de_creacion");
        dt.Columns.Add(dc);
        dc = new DataColumn("fecha_vigencia_desde");
        dt.Columns.Add(dc);
        dc = new DataColumn("fecha_vigencia_hasta");
        dt.Columns.Add(dc);
        dc = new DataColumn("Version");
        dt.Columns.Add(dc);
        dc = new DataColumn("Area");
        dt.Columns.Add(dc);
        dc = new DataColumn("Estado");
        dt.Columns.Add(dc);
        dc = new DataColumn("Autor");
        dt.Columns.Add(dc);

        DataRow dr;
        if (datos.Tables[0].Rows.Count == 0)
        {
            this.LabelError.Visible = true;
        }
        else
        {
            this.LabelError.Visible = false;
        }
        foreach (DataRow row in datos.Tables[0].Rows)
        {
            ArrayList misDatos = new ArrayList();
            misDatos.Add(row[0].ToString());
            misDatos.Add(" Modificar ");
            misDatos.Add(" Versionado ");
            misDatos.Add(row[7].ToString());
            misDatos.Add("Pilar");
            DateTime dateTimes;
            dateTimes = DateTime.Parse(row[4].ToString());
            misDatos.Add(dateTimes.ToShortDateString());
            dateTimes = DateTime.Parse(row[5].ToString());
            misDatos.Add(dateTimes.ToShortDateString());
            dateTimes = DateTime.Parse(row[6].ToString());
            misDatos.Add(dateTimes.ToShortDateString());
            misDatos.Add(row[3].ToString());
            misDatos.Add("Responsables");
            if (DateTime.Now > dateTimes)
            {
                misDatos.Add("No Activo");
            }
            else
            {
                misDatos.Add("Activo");
            }
            misDatos.Add(row[2].ToString());
            dr = dt.NewRow();
            dr.ItemArray = misDatos.ToArray();
            dt.Rows.Add(dr);
        }
        
        this.GridViewDatos.DataSource = show;
        this.GridViewDatos.DataBind();
        this.GridViewDatos.Visible = true;
        
        //this.GridViewDatos.Columns[2].Visible = false;
    }


    protected void GridViewDatos_SelectedIndexChanged(object sender, EventArgs e)
    {
        //GridViewRow dr = new GridViewRow(GridViewDatos.SelectedRow);
        
        //dr.BackColor = System.Drawing.Color.FromName("#FAF7DA");
        GridView grid = (GridView)sender;//-		sender	{System.Web.UI.WebControls.GridView}	object {System.Web.UI.WebControls.GridView}
        String place = "Atributos.aspx?id=" + grid.SelectedRow.Cells[1].Text + "&identificador=" + grid.SelectedRow.Cells[2].Text;
        Response.Redirect(place);
        //Server.Transfer(place);
        //Console.WriteLine(e);
    }
    protected void gridViewDatos_paging(object sender, GridViewPageEventArgs e)
    {
        GridViewDatos.PageIndex = e.NewPageIndex;
        this.cargarDatos();
    }
}
