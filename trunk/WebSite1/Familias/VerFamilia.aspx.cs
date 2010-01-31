using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class Familias_InsertarFamilia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            String id = Request.QueryString["id"];
            String newVersion = Request.QueryString["ver"];
            Family atr = new Family();
            this.HiddenFieldClass.Value = atr.GetType().ToString();
            if (!String.IsNullOrEmpty(id))
            {
                Family used = cargarDatosBase(Convert.ToInt16(id));
                int version = used.Version;
                this.loadObservationTable(version, Convert.ToInt16(this.LabelFamilia.Text));
            }
            this.HiddenFieldVersion.Value = this.LabelVersion.Text;
            this.HiddenFieldIdentificador.Value = this.LabelFamilia.Text;
        }
    }

    private String getShortUser()
    {
        String userFull = User.Identity.Name.ToString(); //HttpContext.Current.User.Identity.Name;
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
        return user;
    }

    public void loadObservationTable(int pVersion, int pIdentificador)
    {
        Family fam = new Family();
        ABMCObservacion abmc = new ABMCObservacion();
        System.Collections.Generic.List<Observacion> lista = abmc.obtenerObservaciones(fam.GetType().ToString(), pIdentificador, pVersion);

        HtmlTableRow row = new HtmlTableRow();
        HtmlTableCell cell = new HtmlTableCell();

        foreach (Observacion item in lista)
        {
            item.ObjectVersion = item.ObjectVersion + 1;
            abmc.guardarObservacion(item);
            int myId = abmc.obtenerObservacionId(item);
            item.Id = myId;
            row = new HtmlTableRow();
            row.ID = "row_" + item.Id.ToString();
            cell = new HtmlTableCell();
            cell.InnerText = item.Tarea;
            row.Controls.Add(cell);
            cell = new HtmlTableCell();
            cell.InnerText = item.MiObservacion;
            row.Controls.Add(cell);
            cell = new HtmlTableCell();
            cell.InnerText = item.Autor;
            row.Controls.Add(cell);
            cell = new HtmlTableCell();
            cell.InnerText = item.Fecha.ToShortDateString();
            row.Controls.Add(cell);
            cell = new HtmlTableCell();
            cell.InnerHtml = "<button id='tableButton_" + item.Id + "' onclick='deleteObservation(" + item.Id + ")' class='btn'>Eliminar</button>";
            row.Controls.Add(cell);
            this.observaciones.Controls.Add(row);

        }

    }

    private Family cargarDatosBase(int id)
    {
        ABMCFamily abmc = new ABMCFamily();
        Family a = abmc.getFamily(id);
        this.LabelVersion.Text = (a.Version + 1).ToString();
        this.LabelFamilia.Text = a.Identificador.ToString();
        this.LabelAutor.Text = a.Autor;
        this.LabelFechaCreacion.Text = a.FechaCreacion.ToShortDateString();
        this.TextBoxCalendarHasta.Text = a.FechaVigenciaHasta.ToShortDateString();
        this.TextBoxNombre.Text = a.Nombre;
        this.TextCalendarDesde.Text = a.FechaVigenciaDesde.ToShortDateString();
        this.DropDownListGruposFamilia.SelectedValue = a.Grupo;
        return a;
    }

    protected void ButtonCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("MantenimientoFamilias.aspx");
    }
}
