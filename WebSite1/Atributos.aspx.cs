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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            String id = Request.QueryString["id"];
            Atributo atr = new Atributo();
            this.HiddenFieldClass.Value = atr.GetType().ToString();
            if (!String.IsNullOrEmpty(id))
            {
                int version = cargarDatosBase(Convert.ToInt16(id));
                this.reservarIdCompleto();
                this.loadTable(version);
            }
            else
            {
                LabelVersion.Text = "0";
                LabelIdentificador.Text = Convert.ToString(this.getNewId());
                this.HiddenField1.Value = LabelIdentificador.Text;
                
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
            this.HiddenField1.Value = LabelIdentificador.Text;
            
        }
        
    }

    private int identificador;

    public void loadTable(int pVersion)
    {
        Atributo atr = new Atributo();
        ABMCObservacion abmc = new ABMCObservacion();
        System.Collections.Generic.List<Observacion> lista = abmc.obtenerObservaciones(atr.GetType().ToString(), this.identificador, pVersion);

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
            cell.InnerText = item.Tarea ;
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
        ABMCAtributo abmc = new ABMCAtributo();
        Atributo a = abmc.obtenerAtributo(id);
        this.LabelVersion.Text = (a.Version +1).ToString();
        this.LabelIdentificador.Text = a.Identificador.ToString();
        this.LabelAutor.Text = a.Autor;
        this.LabelFechaCreacion.Text = a.FechaCreacion.ToShortDateString();
        this.TextBoxCalendarHasta.Text = a.FechaVigenciaHasta.ToShortDateString();
        this.TextBoxDescripcion.Text = a.Descripcion;
        this.TextBoxNombre.Text = a.Nombre;
        this.TextCalendarDesde.Text = a.FechaVigenciaDesde.ToShortDateString();
        this.CheckBoxModificable.Checked = a.EsModificable;
        return a.Version;
    }

    private int getNewId()
    {
        String lastId = Convert.ToString(Session["LastIdentifier"]);
        int salida;
        if (String.IsNullOrEmpty(lastId))
        {
            ABMCAtributo abmc = new ABMCAtributo();
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

    private void reservarId()
    {
        Atributo a = new Atributo();
        a.Version = Convert.ToInt16(this.LabelVersion.Text);
        a.Identificador = Convert.ToInt16(this.LabelIdentificador.Text);
        a.Autor = " ";
        a.Descripcion = " ";
        a.EsModificable = true;
        a.Nombre = " ";
        a.FechaCreacion = DateTime.Now;
        a.FechaVigenciaDesde = DateTime.Now;
        a.FechaVigenciaHasta = DateTime.Now;
        ABMCAtributo abmc = new ABMCAtributo();
        abmc.guardarAtributo(a);
        a = abmc.obtenerAtributoPorIdentificadorYVersion(a.Identificador, a.Version);
        this.identificador = a.Identificador;
        this.HiddenFieldId.Value = a.Id.ToString();
    }

    private void reservarIdCompleto()
    {
        Atributo a = new Atributo();
        a.Autor = this.LabelAutor.Text;
        a.Descripcion = this.TextBoxDescripcion.Text;
        a.EsModificable = this.CheckBoxModificable.Checked;
        a.FechaCreacion = DateTime.Parse(this.LabelFechaCreacion.Text);
        a.FechaVigenciaDesde = DateTime.Parse(this.TextCalendarDesde.Text);
        a.FechaVigenciaHasta = DateTime.Parse(this.TextBoxCalendarHasta.Text);
        a.Identificador = Convert.ToInt16(this.LabelIdentificador.Text);
        a.Nombre = this.TextBoxNombre.Text;
        a.Version = Convert.ToInt16(this.LabelVersion.Text);
        ABMCAtributo abmc = new ABMCAtributo();
        abmc.guardarAtributo(a);
        a = abmc.obtenerAtributoPorIdentificadorYVersion(a.Identificador, a.Version);
        this.identificador = a.Identificador;
        this.HiddenFieldId.Value = a.Id.ToString();
    }

    private void guardar()
    {
        Atributo a = new Atributo();
        a.Id = Convert.ToInt16(this.HiddenFieldId.Value);
        a.Autor = this.LabelAutor.Text;
        a.Descripcion = this.TextBoxDescripcion.Text;
        a.EsModificable = this.CheckBoxModificable.Checked;
        a.FechaCreacion = DateTime.Parse(this.LabelFechaCreacion.Text);
        a.FechaVigenciaDesde = DateTime.Parse(this.TextCalendarDesde.Text);
        a.FechaVigenciaHasta = DateTime.Parse(this.TextBoxCalendarHasta.Text);
        a.Identificador = Convert.ToInt16(this.LabelIdentificador.Text);
        a.Nombre = this.TextBoxNombre.Text;
        a.Version = Convert.ToInt16(this.LabelVersion.Text);
        ABMCAtributo abmc = new ABMCAtributo();
        abmc.updateAtributo(a);
    }
    protected void ButtonCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("MantenimientoAtributos.aspx");
    }
}
