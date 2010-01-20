<%@ Page Language="C#"%>

<script runat="server" >
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Clear();
        Response.ContentType = "text";
        Response.Flush();
        int objId = Convert.ToInt16(Request.QueryString["id"]);
        Log.saveInLog(objId.ToString());
        ABMCFamily abmc = new ABMCFamily();
        int idFamilia = Convert.ToInt16(objId);
        Family fam = abmc.getFamily(objId);
        Log.saveInLog(fam.Grupo);
        //Response.Write(fam.Grupo);
        if (fam != null)
        {
            Response.Write(fam.Grupo);
        }
        Response.End();
    }
</script>
