using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Collections.Generic;
using System.Text;
using System.Data.Linq;

[ServiceContract(Namespace = "")]
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public class DBService
{
    [OperationContract]
    public decimal SaveNode(int pIDParent, int pIDatt, string pName)
    {
        DataClassesDataContext db = new DataClassesDataContext();
        var tn = new TreeNodos
        {
            IDParent = (Convert.ToDecimal(pIDParent)),
            NomTree = pName,
            IDAttr = (Convert.ToDecimal(pIDatt))
        };
        db.TreeNodos.InsertOnSubmit(tn);
        db.SubmitChanges();
        return (this.UltimoID(pIDParent, pIDatt, pName));
    }
    public decimal UltimoID(int pIDParent, int pIDatt, string pName)
    {

        DataClassesDataContext db = new DataClassesDataContext();

        var nodo = (from p in db.TreeNodos
                    where p.IDParent == Convert.ToDecimal(pIDParent)
                    & p.NomTree == pName
                    & p.IDAttr == Convert.ToDecimal(pIDatt)
                    select p).Single();

        decimal id = nodo.IDTree;

        return id;
    }

    [OperationContract]
    public List<TreeNodos> GetTree(int pAttr)
    {
        DataClassesDataContext db = new DataClassesDataContext();
        var nodos = from item in db.TreeNodos
                    where item.IDAttr == Convert.ToDecimal(pAttr)
                    select item;
        return nodos.ToList();
    }


    [OperationContract]
    public List<TreeEstructuraItems> GetItem(int pIdNodo)
    {
        DataClassesDataContext db = new DataClassesDataContext();
        var nodos = from item in db.TreeEstructuraItems
                    where item.IDTreeEstructuraItem == Convert.ToDecimal(pIdNodo)
                    select item;
        return nodos.ToList();
    }

    [OperationContract]
    public void SaveNodeEstructure(int pIDTree, bool pEsReq, bool pSolol, bool pMulti, string pSubTipo, string pOrigDatos, string pValores, string pRuta, string pMetodo, string pTipo, int pLargo, int pDec)
    {
        if (this.GetItem(pIDTree).Count != 0) { this.DeleteNodeEstructure(pIDTree); }

        DataClassesDataContext db = new DataClassesDataContext();
        var ne = new TreeEstructuraItems
        {
            IDTreeEstructuraItem = (Convert.ToDecimal(pIDTree)),
            EsRequerido = pEsReq,
            SoloLectura = pSolol,
            MultiSeleccion = pMulti,
            SubTipo = pSubTipo,
            OrigenDeDatos = pOrigDatos,
            Valores = pValores,
            Ruta = pRuta,
            Metodo = pMetodo,
            Tipo = pTipo,
            Largo = pLargo,
            Decimales = pDec,
        };
        db.TreeEstructuraItems.InsertOnSubmit(ne);
        db.SubmitChanges();
    }

    private void DeleteNodeEstructure(int pIDTree)
    {

        DataClassesDataContext objetoData = new DataClassesDataContext();
        var eliminar = (from c in objetoData.TreeEstructuraItems
                        where c.IDTreeEstructuraItem == pIDTree
                        select c).ToList()[0];
        objetoData.TreeEstructuraItems.DeleteOnSubmit(eliminar);
        objetoData.SubmitChanges();
    }

    [OperationContract]
    public List<AttrReglas> GetRules(int pAttr)
    {
        DataClassesDataContext db = new DataClassesDataContext();
        var rules = from item in db.AttrReglas
                    where item.IDAttRelacionado == Convert.ToDecimal(pAttr)
                    select item;
        return rules.ToList();
    }

    [OperationContract]
    public void SaveRule(string pNomRegla, int pIDattRel, string pNameExec)
    {
        if (this.GetRules(pIDattRel).Count != 0) { this.DeleteRules(pIDattRel); }
        DataClassesDataContext db = new DataClassesDataContext();
        var rl = new AttrReglas
        {
            NomRegal = pNomRegla,
            IDAttRelacionado = (Convert.ToDecimal(pIDattRel)),
            NomModoEjecucion = pNameExec
        };
        db.AttrReglas.InsertOnSubmit(rl);
        db.SubmitChanges();
    }

    private void DeleteRules(int pIDAttrRule){
         DataClassesDataContext objetoData = new DataClassesDataContext();
        var eliminar = (from c in objetoData.AttrReglas
                        where c.IDAttRelacionado == pIDAttrRule
                        select c).ToList()[0];
        objetoData.AttrReglas.DeleteOnSubmit(eliminar);
        objetoData.SubmitChanges();
    }
}
