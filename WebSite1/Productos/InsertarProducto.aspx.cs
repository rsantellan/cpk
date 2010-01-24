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
            this.cargarFamilias();
            String id = Request.QueryString["id"];
            String newVersion = Request.QueryString["ver"];
            Product atr = new Product();
            this.HiddenFieldClass.Value = atr.GetType().ToString();
            this.cargarCoberturas();
            if (!String.IsNullOrEmpty(id))
            {
                Product used = cargarDatosBase(Convert.ToInt16(id));
                if (!String.IsNullOrEmpty(newVersion))
                {
                    LabelVersion.Text = "0";
                    int newId = this.getNewId();
                    this.LabelProducto.Text = Convert.ToString(newId);
                    used.Identificador = newId;
                }
                else
                {
                    this.cargarCoberturasProducto(used.Id);
                    int version = used.Version;
                    this.loadObservationTable(version, Convert.ToInt16(this.LabelProducto.Text));
                }
                this.reservarIdCompleto(used);

            }
            else
            {
                LabelVersion.Text = "0";
                this.LabelProducto.Text = Convert.ToString(this.getNewId());
                this.HiddenFieldIdentificador.Value = this.LabelProducto.Text;

                LabelAutor.Text = this.getShortUser();
                LabelFechaCreacion.Text = DateTime.Today.Date.ToShortDateString();
                this.reservarId();
            }
            this.HiddenFieldVersion.Value = this.LabelVersion.Text;
            this.HiddenFieldIdentificador.Value = this.LabelProducto.Text;
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

    public void cargarFamilias()
    {
        DataSet ds = ABMCFamily.getAllFamilyOnLastVersion();

        
        DropDownList1.DataSource = ds.Tables[0];
        DropDownList1.DataTextField = ds.Tables[0].Columns["Nombre"].ColumnName.ToString();
        DropDownList1.DataValueField = ds.Tables[0].Columns["Id"].ColumnName.ToString();
        DropDownList1.DataBind();
    }
    public void loadObservationTable(int pVersion, int pIdentificador)
    {
        Product fam = new Product();
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

    private Product cargarDatosBase(int id)
    {
        ABMCProduct abmc = new ABMCProduct();
        Product a = abmc.getProduct(id);
        this.LabelVersion.Text = (a.Version + 1).ToString();
        this.LabelProducto.Text = a.Identificador.ToString();
        this.LabelAutor.Text = a.Autor;
        this.LabelFechaCreacion.Text = a.FechaCreacion.ToShortDateString();
        this.TextBoxCalendarHasta.Text = a.FechaVigenciaHasta.ToShortDateString();
        this.TextBoxNombre.Text = a.Nombre;
        this.TextCalendarDesde.Text = a.FechaVigenciaDesde.ToShortDateString();
        ABMCFamily pFamily = new ABMCFamily();
        a.Family = pFamily.getFamily(a.FamilyId);
        this.DropDownList1.SelectedValue = a.Family.Id.ToString();
        this.mostrado.Text = a.Family.Grupo;
        return a;
    }

    private void reservarId()
    {
        Product a = new Product();
        a.Version = Convert.ToInt16(this.LabelVersion.Text);
        a.Identificador = Convert.ToInt16(this.LabelProducto.Text);
        a.Autor = " ";
        a.Descripcion = " ";
        a.Nombre = " ";
        a.Estado = " ";
        a.FechaCreacion = DateTime.Now;
        a.FechaVigenciaDesde = DateTime.Now;
        a.FechaVigenciaHasta = DateTime.Now;
        String userFull = User.Identity.Name.ToString();
        a.Usuario = userFull;
        ABMCProduct abmc = new ABMCProduct();
        abmc.saveProduct(a);
        a = abmc.getProductByIdentifierAndVersion(a.Identificador, a.Version);
        this.HiddenFieldId.Value = a.Id.ToString();
    }

    private void reservarIdCompleto(Product reserve)
    {
        String userFull = User.Identity.Name.ToString();
        reserve.Usuario = userFull;
        reserve.Version = reserve.Version + 1;
        ABMCProduct abmc = new ABMCProduct();
        abmc.saveProduct(reserve);
        reserve = abmc.getProductByIdentifierAndVersion(reserve.Identificador, reserve.Version);
        this.HiddenFieldId.Value = reserve.Id.ToString();
    }

    private int getNewId()
    {
        int salida;
        ABMCProduct abmc = new ABMCProduct();
        salida = abmc.getLastIdentifier();
        return salida;
    }
    protected void ButtonSalvar_Click(object sender, EventArgs e)
    {
        if (this.RequiredFieldValidator2.IsValid
            && this.RangeValidator2.IsValid
            && this.RequiredFieldValidator3.IsValid
            && this.RequiredFieldValidatorCalendarDesde.IsValid)
        {
            DateTime FechaVigenciaDesde = DateTime.Parse(this.TextCalendarDesde.Text);
            DateTime FechaVigenciaHasta = DateTime.Parse(this.TextBoxCalendarHasta.Text);
            this.guardar();
        }
    }

    private void guardar()
    {
        Product a = new Product();
        a.Id = Convert.ToInt16(this.HiddenFieldId.Value);
        a.Autor = this.LabelAutor.Text;
        a.FamilyId = Convert.ToInt16(this.DropDownList1.SelectedValue.ToString());
        a.FechaCreacion = DateTime.Parse(this.LabelFechaCreacion.Text);
        a.FechaVigenciaDesde = DateTime.Parse(this.TextCalendarDesde.Text);
        a.FechaVigenciaHasta = DateTime.Parse(this.TextBoxCalendarHasta.Text);
        a.Identificador = Convert.ToInt16(this.LabelProducto.Text);
        a.Nombre = this.TextBoxNombre.Text;
        a.Version = Convert.ToInt16(this.LabelVersion.Text);
        a.Estado = Family.ENCURSO;
        String userFull = User.Identity.Name.ToString();
        a.Usuario = userFull;
        a.Autor = this.getShortUser();
        a.Descripcion = this.TextBoxDescripcion.Text;
        ABMCProduct abmc = new ABMCProduct();
        abmc.updateProduct(a);
        if (this.CheckBoxCobertura1.Checked)
        {
            ProductoCobertura cob1 = new ProductoCobertura();
            cob1.IdCondicionado = 1;
            cob1.IdProducto = a.Id;
            ABMCProductoCobertura.save(cob1);
        }
        if (this.CheckBoxCobertura2.Checked)
        {
            ProductoCobertura cob1 = new ProductoCobertura();
            cob1.IdCondicionado = 2;
            cob1.IdProducto = a.Id;
            ABMCProductoCobertura.save(cob1);
        }
        if (this.CheckBoxCobertura3.Checked)
        {
            ProductoCobertura cob1 = new ProductoCobertura();
            cob1.IdCondicionado = 3;
            cob1.IdProducto = a.Id;
            ABMCProductoCobertura.save(cob1);
        }
        if (this.CheckBoxCobertura4.Checked)
        {
            ProductoCobertura cob1 = new ProductoCobertura();
            cob1.IdCondicionado = 4;
            cob1.IdProducto = a.Id;
            ABMCProductoCobertura.save(cob1);
        }
        Response.Redirect("MantenimientoProductos.aspx");
        //Response.Redirect("http://moss.denallix.com/_layouts/FormServer.aspx?XsnLocation=http://moss.denallix.com/Rev%20Flias/Forms/template_.xsn&OpenIn=browser&SaveLocation=http://moss.denallix.com/Rev%20Flias");
    }

    protected void ButtonCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("MantenimientoProductos.aspx");
    }

}
