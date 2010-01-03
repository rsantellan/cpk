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
            Family atr = new Family();
            this.HiddenFieldClass.Value = atr.GetType().ToString();
            if (!String.IsNullOrEmpty(id))
            {
                int version = cargarDatosBase(Convert.ToInt16(id));
                this.reservarIdCompleto();
                this.loadObservationTable(version, Convert.ToInt16(this.LabelFamilia.Text));
            }
            else
            {
                LabelVersion.Text = "0";
                this.LabelFamilia.Text = Convert.ToString(this.getNewId());
                this.HiddenFieldFamilia.Value = this.LabelFamilia.Text;

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
                LabelAutor.Text = user;
                LabelFechaCreacion.Text = DateTime.Today.Date.ToShortDateString();
                this.reservarId();
            }
            this.HiddenFieldVersion.Value = this.LabelVersion.Text;
            this.HiddenFieldFamilia.Value = this.LabelFamilia.Text;
        }
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

    private int cargarDatosBase(int id)
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
        return a.Version;
    }

    private void reservarId()
    {
        Family a = new Family();
        a.Version = Convert.ToInt16(this.LabelVersion.Text);
        a.Identificador = Convert.ToInt16(this.LabelFamilia.Text);
        a.Autor = " ";
        a.Grupo = " ";
        a.Nombre = " ";
        a.FechaCreacion = DateTime.Now;
        a.FechaVigenciaDesde = DateTime.Now;
        a.FechaVigenciaHasta = DateTime.Now;
        ABMCFamily abmc = new ABMCFamily();
        abmc.saveFamily(a);
        a = abmc.getFamilyByIdentifierAndVersion(a.Identificador, a.Version);
        this.HiddenFieldId.Value = a.Id.ToString();
    }

    private void reservarIdCompleto()
    {
        Family a = new Family();
        a.Autor = this.LabelAutor.Text;
        a.FechaCreacion = DateTime.Parse(this.LabelFechaCreacion.Text);
        a.FechaVigenciaDesde = DateTime.Parse(this.TextCalendarDesde.Text);
        a.FechaVigenciaHasta = DateTime.Parse(this.TextBoxCalendarHasta.Text);
        a.Identificador = Convert.ToInt16(this.LabelFamilia.Text);
        a.Nombre = this.TextBoxNombre.Text;
        a.Version = Convert.ToInt16(this.LabelVersion.Text);
        ABMCFamily abmc = new ABMCFamily();
        abmc.saveFamily(a);
        a = abmc.getFamilyByIdentifierAndVersion(a.Identificador, a.Version);
        this.HiddenFieldId.Value = a.Id.ToString();
    }

    private int getNewId()
    {
        String lastId = Convert.ToString(Session["LastIdentifier"]);
        int salida;
        if (String.IsNullOrEmpty(lastId))
        {
            ABMCFamily abmc = new ABMCFamily();
            salida = abmc.getLastIdentifier();
        }
        else
        {
            salida = Convert.ToInt16(lastId);
            salida = salida + 1;
        }
        Session["LastIdentifier"] = salida;
        return salida;
    }
}
