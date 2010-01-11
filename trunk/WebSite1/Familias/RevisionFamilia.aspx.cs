using System;
using System.Collections.Generic;
using System.Collections;
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
            this.HiddenFieldId.Value = id;
            if (!String.IsNullOrEmpty(id))
            {
                int version = cargarDatosBase(Convert.ToInt16(id));
                this.cargarDatosDeAtributos(Convert.ToInt16(id));
                
            }
            this.HiddenFieldVersion.Value = this.LabelVersion.Text;
            this.HiddenFieldIdentificador.Value = this.LabelFamilia.Text;
        }
    }

    private void cargarDatosDeAtributos(int pId)
    {
        ABMCAtributo abmc = new ABMCAtributo();
        DataSet datos = abmc.listOfAtributesByFamily(pId);
        DataSet show = new DataSet();

        DataTable dt = new DataTable();
        show.Tables.Add(dt);
        DataColumn dc = new DataColumn("Atributo");
        dt.Columns.Add(dc);
        dc = new DataColumn("verAtributo");
        dc.ColumnMapping = MappingType.Hidden;
        dt.Columns.Add(dc);
        dc = new DataColumn("Ver");
        dt.Columns.Add(dc);
        dc = new DataColumn("Id");
        dt.Columns.Add(dc);
        

        DataRow dr;
        if (datos.Tables[0].Rows.Count == 0)
        {
            //this.LabelError.Visible = true;
        }
        else
        {
            //this.LabelError.Visible = false;
        }
        foreach (DataRow row in datos.Tables[0].Rows)
        {
            ArrayList misDatos = new ArrayList();
            misDatos.Add(row[7].ToString());
            misDatos.Add(" Ver ");
            misDatos.Add(row[0].ToString());
            misDatos.Add(row[0].ToString());
            dr = dt.NewRow();
            dr.ItemArray = misDatos.ToArray();
            dt.Rows.Add(dr);
        }
        this.GridViewAtributos.DataSource = show;
        this.GridViewAtributos.DataBind();
        this.GridViewAtributos.Visible = true;
    }

    private int cargarDatosBase(int id)
    {
        ABMCFamily abmc = new ABMCFamily();
        Family a = abmc.getFamily(id);
        this.LabelVersion.Text = (a.Version + 1).ToString();
        this.LabelFamilia.Text = a.Identificador.ToString();
        this.LabelAutor.Text = a.Autor;
        this.LabelFechaCreacion.Text = a.FechaCreacion.ToShortDateString();
        this.LabelFechaVigenciaHasta.Text = a.FechaVigenciaHasta.ToShortDateString();
        this.LabelNombreFamilia.Text = a.Nombre;
        this.LabelFechaVigenciaDesde.Text = a.FechaVigenciaDesde.ToShortDateString();
        this.LabelGrupo.Text = a.Grupo;
        return a.Version;
    }


    protected void ButtonSalvar_Click(object sender, EventArgs e)
    {
        FamilyReview review = new FamilyReview();
        review.FamilyId = Convert.ToInt16(this.HiddenFieldId.Value);
        review.Resolution = this.DropDownListResolution.SelectedValue.ToString();
        review.Observation = this.TextBoxObservacion.Text;
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
        review.Author = user;
        review.CreatedAt = DateTime.Now;
        ABMCFamilyReview abmc = new ABMCFamilyReview();
        abmc.saveReviewOfFamily(review);
        ABMCFamily abmcFamily = new ABMCFamily();
        Family changed = abmcFamily.getFamily(Convert.ToInt16(this.HiddenFieldId.Value));
        changed.Estado = review.Resolution;
        abmcFamily.updateFamily(changed);
        Response.Redirect("MantenimientoFamilias.aspx");
    }

    

    protected void ButtonCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("MantenimientoFamilias.aspx");
    }
}
