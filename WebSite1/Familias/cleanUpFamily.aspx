<%@ Page Language="C#"%>

<script runat="server" >
    protected void Page_Load(object sender, EventArgs e)
    {
        int objId = Convert.ToInt16(Request.QueryString["id"]);
        int objIdentifier = Convert.ToInt16(Request.QueryString["identifier"]);
        int objVersion = Convert.ToInt16(Request.QueryString["version"]);
        ABMCFamily abmc = new ABMCFamily();
        int idFamilia = Convert.ToInt16(objId);
        if (abmc.deleteFamily(idFamilia))
        {
            Family a = new Family();
            ABMCObservacion abmcObs = new ABMCObservacion();

            abmcObs.deleteAllObjectObservations(a.GetType().ToString(), objIdentifier, objVersion);
            //System.Collections.Generic.List<Observacion> lista =  abmcObs.obtenerObservaciones(a.GetType().ToString(), objIdentifier, objVersion);
            //foreach (Observacion item in lista)
            //{
            //    abmcObs.eliminarObservacion(item.Id);
            //}

            ABMCFamilyAtribute abmcFamAtt = new ABMCFamilyAtribute();
            abmcFamAtt.deleteWithFamilyId(idFamilia);
        }
        
        
    }
</script>
