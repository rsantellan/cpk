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
        int tarea = 0;
        if (!String.IsNullOrEmpty(this.TextBoxTarea.Text))
        {
            try
            {
                tarea = Convert.ToInt16(this.TextBoxTarea.Text);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
        ABMCTask abmc = new ABMCTask();
        DataSet datos = abmc.searchTask(this.TextBoxTaskTitulo.Text, tarea, this.DropDownListAutores.SelectedValue, this.DropDownListResponsables.SelectedValue);
        DataSet show = new DataSet();

        DataTable dt = new DataTable();
        show.Tables.Add(dt);
        DataColumn dc = new DataColumn("ID");
        dt.Columns.Add(dc);
        dc = new DataColumn("ModificarMostrar");
        dc.ColumnMapping = MappingType.Hidden;
        dt.Columns.Add(dc);
        dc = new DataColumn("Tarea");
        dt.Columns.Add(dc);
        dc = new DataColumn("Titulo");
        dt.Columns.Add(dc);
        dc = new DataColumn("fecha_de_creacion");
        dt.Columns.Add(dc);
        dc = new DataColumn("Autor");
        dt.Columns.Add(dc);
        dc = new DataColumn("Responsable");
        dt.Columns.Add(dc);
        dc = new DataColumn("Habilitada");
        dt.Columns.Add(dc);

        DataRow dr;
        if (datos.Tables.Count == 0)
        {
            return;
        }
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
            misDatos.Add(row[1].ToString());
            misDatos.Add(row[4].ToString());
            
            DateTime dateTimes;
            dateTimes = DateTime.Parse(row[3].ToString());
            misDatos.Add(dateTimes.ToShortDateString());
            misDatos.Add(row[2].ToString());
            misDatos.Add(row[5].ToString());
            Boolean habilitado = Convert.ToBoolean(row[7].ToString());
            if (habilitado)
            {
                misDatos.Add("No");
            }
            else
            {
                misDatos.Add("Si");
            }
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
