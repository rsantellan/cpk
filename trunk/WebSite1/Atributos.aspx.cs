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
        String id = Request.QueryString["id"];
        if (!String.IsNullOrEmpty(id))
        {
            cargarDatosBase(Convert.ToInt16(id));
        }
        else
        {

            //String identificador = Request.QueryString["identificador"];
            LabelVersion.Text = "0";
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
    }
    private void cargarDatosBase(int id)
    {
        ABMCAtributo abmc = new ABMCAtributo();
        Atributo a = abmc.obtenerAtributo(id);
        this.LabelVersion.Text = a.Version.ToString();
        this.LabelIdentificador.Text = a.Identificador.ToString();
        this.LabelAutor.Text = a.Autor;
        this.LabelFechaCreacion.Text = a.FechaCreacion.ToShortDateString();
        this.TextBoxCalendarHasta.Text = a.FechaVigenciaHasta.ToShortDateString();
        this.TextBoxDescripcion.Text = a.Descripcion;
        this.TextBoxNombre.Text = a.Nombre;
        this.TextCalendarDesde.Text = a.FechaVigenciaDesde.ToShortDateString();
        this.CheckBoxModificable.Checked = a.EsModificable;
    }

    private int getNewId()
    {
        ABMCAtributo abmc = new ABMCAtributo();
        return abmc.getLastIdentifier();
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
    }
}
