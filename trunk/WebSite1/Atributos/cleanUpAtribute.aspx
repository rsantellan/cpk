<%@ Page Language="C#"%>

<script runat="server" >
    protected void Page_Load(object sender, EventArgs e)
    {
        int objId = Convert.ToInt16(Request.QueryString["id"]);
        int objIdentifier = Convert.ToInt16(Request.QueryString["identifier"]);
        int objVersion = Convert.ToInt16(Request.QueryString["version"]);
		ABMCAtributo abmc = new ABMCAtributo();
        if (abmc.deleteAtribute(Convert.ToInt16(objId)))
        {
            //ABMCTreeNode abmcTree = new ABMCTreeNode();
            //abmcTree.deleteTreeNodeStructure(objIdentifier, objVersion);
            Atributo a = new Atributo();
            ABMCObservacion abmcObs = new ABMCObservacion();
            System.Collections.Generic.List<Observacion> lista =  abmcObs.obtenerObservaciones(a.GetType().ToString(), objIdentifier, objVersion);
            foreach (Observacion item in lista)
            {
                abmcObs.eliminarObservacion(item.Id);
            }
            ABMCAtributoTree abmcTree = new ABMCAtributoTree();
            abmcTree.deleteAll(objId);
        }
        
        
    }
</script>
