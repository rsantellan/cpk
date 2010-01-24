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
            if (!String.IsNullOrEmpty(id))
            {
                this.checkStatus(Convert.ToInt16(id));
                Product atr = new Product();
                this.HiddenFieldClass.Value = atr.GetType().ToString();
                this.cargarCoberturas();
                Product used = cargarDatosBase(Convert.ToInt16(id));
                this.cargarCoberturasProducto(used.Id);
                int version = used.Version;
                this.HiddenFieldVersion.Value = this.LabelVersion.Text;
                this.HiddenFieldIdentificador.Value = this.LabelProducto.Text;
                this.HiddenFieldId.Value = id;
            }

        }
       
    }

    private void cargarCoberturasProducto(int id)
    {
        List<int> lista = ABMCProductoCobertura.getProductoCovertura(id);
        foreach (int i in lista)
        {
            switch (i)
            {
                case 1:
                    this.CheckBoxCobertura1.Checked = true;
                    break;
                case 2:
                    this.CheckBoxCobertura2.Checked = true;
                    break;
                case 3:
                    this.CheckBoxCobertura3.Checked = true;
                    break;
                case 4:
                    this.CheckBoxCobertura4.Checked = true;
                    break;
                default:
                    break;
            }
        }
    }

    private void cargarCoberturas()
    {
        DataSet datos = ABMCCoberturas.getAllCoberturas();
        int place = 0;
        foreach (DataRow row in datos.Tables[0].Rows)
        {
            switch (place)
            {
                case 0:
                    this.LabelCobertura1.Text = row[1].ToString();
                    place++;
                    break;
                case 1:
                    this.LabelCobertura2.Text = row[1].ToString();
                    place++;
                    break;
                case 2:
                    this.LabelCobertura3.Text = row[1].ToString();
                    place++;
                    break;
                case 3:
                    this.LabelCobertura4.Text = row[1].ToString();
                    place++;
                    break;
                default:
                    break;
            }
        }
    }

    private void checkStatus(int id)
    {
        DataSet ds = ABMCProductValue.retrieveProductValueByProductId(id);
        if (ds.Tables[0].Rows.Count != 0)
        {
            this.redirectToPage(id);
         }
        else
        {
           this.blockProduct(id);
         }
        
    }

    private void blockProduct(int pId)
    {
        if (!ABMCProductValue.blockProduct(pId))
        {
            this.redirectToPage(pId);
        }
    }

    private void redirectToPage(int id)
    {
        Response.Redirect("ValoracionProductoBloqueado.htm");
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

    private Product cargarDatosBase(int id)
    {
        ABMCProduct abmc = new ABMCProduct();
        Product a = abmc.getProduct(id);
        this.LabelVersion.Text = (a.Version).ToString();
        this.LabelProducto.Text = a.Identificador.ToString();
        this.LabelAutor.Text = a.Autor;
        this.LabelFechaCreacion.Text = a.FechaCreacion.ToShortDateString();
        this.LabelVigenciaHasta.Text = a.FechaVigenciaHasta.ToShortDateString();
        this.LabelNombreProducto.Text = a.Nombre;
        this.LabelVigenciaDesde.Text = a.FechaVigenciaDesde.ToShortDateString();
        ABMCFamily pFamily = new ABMCFamily();
        a.Family = pFamily.getFamily(a.FamilyId);
        this.LabelFamiliaProducto.Text = a.Family.Nombre;
        this.LabelGrupoFamiliaProducto.Text = a.Family.Grupo;
        return a;
    }

    protected void ButtonSalvar_Click(object sender, EventArgs e)
    {
       this.guardar();
    }

    private void guardar()
    {
        int id = Convert.ToInt16(this.HiddenFieldId.Value);
        ProductValue review = new ProductValue();
        review.ProductId = id;
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
        review.Author = userFull;
        review.CreatedAt = DateTime.Now;
        review.FemeninoAdulto = Convert.ToInt16(this.TextBoxFemeninoAdulto.Text);
        review.FemeninoAdultoMayor = Convert.ToInt16(this.TextBoxFemeninoAdultoMayor.Text);
        review.MasculinoAdulto = Convert.ToInt16(this.TextBoxMasculinoAdulto.Text);
        review.MasculinoAdultoMayor = Convert.ToInt16(this.TextBoxMasculinoAdultoMayor.Text);
        Boolean state = ABMCProductValue.saveValueOfProduct(review);
        if (!state)
        {
            this.redirectToPage(review.ProductId);
        }

        ABMCProductValue.deleteBlock(id);
        ABMCProduct abmcProduct = new ABMCProduct();
        Product changed = abmcProduct.getProduct(id);
        changed.Estado = review.Resolution;
        abmcProduct.updateProduct(changed);
        if (review.Resolution == "Rechazado")
        {
            //Response.Redirect("http://moss.denallix.com/_layouts/FormServer.aspx?XsnLocation=http://moss.denallix.com/FliaReject/Forms/template_.xsn&OpenIn=browser&SaveLocation=http://moss.denallix.com/FliaReject");
        }
        //Response.Redirect("MantenimientoProductos.aspx");
        //Response.Redirect("http://moss.denallix.com/_layouts/FormServer.aspx?XsnLocation=http://moss.denallix.com/Rev%20Flias/Forms/template_.xsn&OpenIn=browser&SaveLocation=http://moss.denallix.com/Rev%20Flias");
    }

    protected void ButtonCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("MantenimientoProductos.aspx");
    }

}
