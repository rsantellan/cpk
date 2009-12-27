<%@ Page Language="C#"%>

<script runat="server" >
    protected void Page_Load(object sender, EventArgs e)
    {
        string qs = Request.QueryString["tarea"];
        string observacion = Request.QueryString["observacion"];
        int objId = Convert.ToInt16(Request.QueryString["objectId"]);
        string objClass = Request.QueryString["objectClass"];
        int objVersion = Convert.ToInt16(Request.QueryString["objectVersion"]);
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
        Observacion ob = new Observacion();
        ob.Autor = user;
        ob.MiObservacion = observacion;
        ob.ObjectClass = objClass;
        ob.ObjectId = objId;
        ob.Tarea = qs;
        ob.Fecha = DateTime.Now;
        ob.ObjectVersion = objVersion;
        ABMCObservacion abmc = new ABMCObservacion();
        if (abmc.guardarObservacion(ob))
        {
            int id = abmc.obtenerObservacionId(ob);
            Response.Write(ob.Fecha.ToShortDateString() + "|" + user+ "|" +id);
        }
        else
        {
            Response.Write("No OK");
        }
        
    }
</script>
