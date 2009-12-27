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

public partial class AjaxTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ButtonComun_Click(object sender, EventArgs e)
    {
        this.TextBoxComun.Text = this.TextBoxComun.Text + " comun ";
    }
    protected void ButtonAjax_Click(object sender, EventArgs e)
    {
        this.TextBoxAjax.Text = this.TextBoxAjax.Text + " ajax ";
    }
}
