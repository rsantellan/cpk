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
            Task atr = new Task();
            this.HiddenFieldClass.Value = atr.GetType().ToString();

            if (!String.IsNullOrEmpty(id))
            {
                Task used = cargarDatosBase(Convert.ToInt16(id));
            }
            else
            {
                this.LabelTarea.Text = Convert.ToString(this.getNewId());
                this.HiddenFieldIdentificador.Value = this.LabelTarea.Text;

                LabelAutor.Text = this.getShortUser();
                LabelFechaCreacion.Text = DateTime.Today.Date.ToShortDateString();
            }
            this.HiddenFieldIdentificador.Value = this.LabelTarea.Text;
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

 
    private Task cargarDatosBase(int id)
    {
        ABMCTask abmc = new ABMCTask();
        Task a = abmc.getTask(id);
        this.LabelTarea.Text = a.Identificador.ToString();
        this.LabelAutor.Text = a.Autor;
        this.LabelFechaCreacion.Text = a.FechaCreacion.ToShortDateString();
        this.TextBoxTitulo.Text = a.Titulo;
        return a;
    }

    private int getNewId()
    {
        int salida;
        ABMCTask abmc = new ABMCTask();
        salida = abmc.getLastIdentifier();
        return salida;
    }

    protected void ButtonSalvar_Click(object sender, EventArgs e)
    {
        if (this.RequiredFieldValidator3.IsValid)
        {
            this.guardar();
        }
    }

    private void guardar()
    {
        Task a = new Task();
        a.Autor = this.LabelAutor.Text;
        a.FechaCreacion = DateTime.Parse(this.LabelFechaCreacion.Text);
        a.Identificador = this.getNewId();
        a.Titulo = this.TextBoxTitulo.Text;
        String userFull = User.Identity.Name.ToString();
        a.Usuario = userFull;
        a.Autor = this.getShortUser();
        a.Habilitada = this.CheckBoxHabilitada.Checked;
        a.Responsable = this.DropDownListResponsable.SelectedValue;
        a.Descripcion = this.TextBoxDescripcion.Text;
        ABMCTask abmc = new ABMCTask();
        abmc.saveTask(a);
        //Response.Redirect("MantenimientoProductos.aspx");
        //Response.Redirect("http://moss.denallix.com/_layouts/FormServer.aspx?XsnLocation=http://moss.denallix.com/Rev%20Flias/Forms/template_.xsn&OpenIn=browser&SaveLocation=http://moss.denallix.com/Rev%20Flias");
    }

    protected void ButtonCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("MantenimientoProductos.aspx");
    }

}
