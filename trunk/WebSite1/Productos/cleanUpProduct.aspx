<%@ Page Language="C#"%>

<script runat="server" >
    protected void Page_Load(object sender, EventArgs e)
    {
        Log.saveInLog("Borrando el producto");
        int objId = Convert.ToInt16(Request.QueryString["id"]);
        int objIdentifier = Convert.ToInt16(Request.QueryString["identifier"]);
        int objVersion = Convert.ToInt16(Request.QueryString["version"]);
        ABMCProduct abmc = new ABMCProduct();
        int idProducto = Convert.ToInt16(objId);
        if (abmc.deleteProduct(idProducto))
        {
            Product a = new Product();
            ABMCObservacion abmcObs = new ABMCObservacion();

            abmcObs.deleteAllObjectObservations(a.GetType().ToString(), objIdentifier, objVersion);
            //System.Collections.Generic.List<Observacion> lista =  abmcObs.obtenerObservaciones(a.GetType().ToString(), objIdentifier, objVersion);
            //foreach (Observacion item in lista)
            //{
            //    abmcObs.eliminarObservacion(item.Id);
            //}

            //ABMCFamilyAtribute abmcFamAtt = new ABMCFamilyAtribute();
            //abmcFamAtt.deleteWithFamilyId(idFamilia);
        }
        
        
    }
</script>
