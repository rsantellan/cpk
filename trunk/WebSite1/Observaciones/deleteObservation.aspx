<%@ Page Language="C#"%>

<script runat="server" >
    protected void Page_Load(object sender, EventArgs e)
    {
        int objId = Convert.ToInt16(Request.QueryString["observationId"]);
        ABMCObservacion abmc = new ABMCObservacion();
        if (abmc.eliminarObservacion(objId))
        {
            Response.Write("1");
        }
        else
        {
            Response.Write("2");
        }
        
    }
</script>
