using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Collections.Generic;
using System.Text;

[ServiceContract(Namespace = "")]
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public class DBService1
{
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

    public void SaveRule1(System.Collections.ObjectModel.Collection<AttrReglas> preglas, int pIDattRel)
    {
    if (this.GetRules(pIDattRel).Count != 0) { this.DeleteRules(pIDattRel);
    System.IO.StreamWriter sw = new System.IO.StreamWriter("c:\\temp\\dbconnRules.txt", true);
    sw.WriteLine("Entre a Borrar");
    sw.Close();   
    
    }

    System.IO.StreamWriter sw1 = new System.IO.StreamWriter("c:\\temp\\dbconnRules.txt", true);
    sw1.WriteLine(Convert.ToString(this.GetRules(pIDattRel).Count));
    sw1.Close();

    foreach (AttrReglas q in preglas)
    {
         this.SaveRuleExec(q.NomRegal, Convert.ToInt32(q.IDAttRelacionado), q.NomModoEjecucion);
    }
            
    }

    public void SaveRuleExec(string pNomRegla, int pIDattRel, string pNameExec)
    {
        DataClassesDataContext db = new DataClassesDataContext();
        var rl = new AttrReglas
        {
            IDRegla = 0,
            NomRegal = Convert.ToString(pNomRegla),
            IDAttRelacionado = Convert.ToDecimal(pIDattRel),
            NomModoEjecucion = Convert.ToString(pNameExec)
        };
        db.AttrReglas.InsertOnSubmit(rl);
        db.SubmitChanges();
    }


    [OperationContract]
    private void DeleteRules(decimal pIDAttrRule)
    {
      
        DataClassesDataContext objetoData = new DataClassesDataContext();
        var eliminar = (from c in objetoData.AttrReglas
                        where c.IDRegla == pIDAttrRule
                        select c).ToList()[0];
        objetoData.AttrReglas.DeleteOnSubmit(eliminar);
        objetoData.SubmitChanges();
    }
	    [OperationContract]
    public void SaveRule(string pNomRegla, int pIDattRel, string pNameExec)
    {
        //if (this.GetRules(pIDattRel).Count != 0) { this.DeleteRules(pIDattRel); }
        DataClassesDataContext db = new DataClassesDataContext();
        var rl = new AttrReglas
        {
            NomRegal = Convert.ToString(pNomRegla),
            IDAttRelacionado = Convert.ToDecimal(pIDattRel),
            NomModoEjecucion = Convert.ToString(pNameExec)
        };
        db.AttrReglas.InsertOnSubmit(rl);
        db.SubmitChanges();
    }
	
	
    [OperationContract]
		public List<AttrReglasCondicion> GetRulesCondicion(int pAttr)
    {
        DataClassesDataContext db = new DataClassesDataContext();
        var rules = from item in db.AttrReglasCondicion
                    where item.idRegla == Convert.ToDecimal(pAttr)
                    select item;
        return rules.ToList();
    }
	 [OperationContract]
    public List<string> GetCondicionesReglasOperadorAritmetico()
    {
        List<string> salida = new List<string>();
        DataClassesDataContext db = new DataClassesDataContext();
        var x = from item in db.CondicionesReglasOperadorAritmetico
                    select new {item.NombreOPAr };
        foreach (var r in x)
        {
            salida.Add(r.NombreOPAr);
        }
        return salida.ToList();
    }

    [OperationContract]
    public List<string> GetCondicionesReglasOperadorLogico()
    {
        List<string> salida = new List<string>();
        DataClassesDataContext db = new DataClassesDataContext();
        var x = from item in db.CondicionesReglasOperadorLogico
                select new { item.NomOperadorLogico };
        foreach (var r in x)
        {
            salida.Add(r.NomOperadorLogico);
        }
        return salida.ToList();
    }
	
	[OperationContract]
    public List<TreeNodos> GetAttrRegla(decimal pID)
    {
     DataClassesDataContext db = new DataClassesDataContext();
        var query = 
            from t in db.TreeNodos
            where
              t.IDAttr == pID &&
              t.IDParent != 0
            select t;
    return query.ToList();
    }
	[OperationContract]
		public void SaveCondicion(decimal pIDRegla, decimal pIDatt, string pAttrNom, string pOpAritmetico, string pValor, string pOpLogico)
		{
			DataClassesDataContext db = new DataClassesDataContext();
			var Cond = new AttrReglasCondicion
			{
				idRegla = pIDRegla,
				AtributoID = pIDatt,
				AtributoNom = pAttrNom,
				OpreradorAritmetico = pOpAritmetico,
				ValorAttr = pValor,
				OperadorLogico = pOpLogico
				};
			db.AttrReglasCondicion.InsertOnSubmit(Cond);
			db.SubmitChanges();
		}
	[OperationContract]
		public List<AttrReglasAccion> GetRulesAccion(decimal pCondicion)
		{
			DataClassesDataContext db = new DataClassesDataContext();
			var rules = from item in db.AttrReglasAccion
						where item.idCondicion == pCondicion
						select item;
			return rules.ToList();
		}
	 [OperationContract]
		public void SaveAccion(decimal pIDCondiccion, decimal pIDatt, string pAttrNom, string pOpAritmetico, string pValor, string pMensaje)
		{
			DataClassesDataContext db1 = new DataClassesDataContext();
			var Acc = new AttrReglasAccion
			{
				idCondicion = pIDCondiccion,
				idAtributo = pIDatt,
				NomAtributo = pAttrNom,
				OpAritmetico = pOpAritmetico,
				Valor = pValor,
				Mensaje = pMensaje
			};
			db1.AttrReglasAccion.InsertOnSubmit(Acc);
			db1.SubmitChanges();
		}
 [OperationContract]
    private void DeleteAccion(decimal pIDaccion)
    {
        DataClassesDataContext objetoData = new DataClassesDataContext();
        var eliminar = (from c in objetoData.AttrReglasAccion
                        where c.id == pIDaccion
                        select c).ToList()[0];
        objetoData.AttrReglasAccion.DeleteOnSubmit(eliminar);
        objetoData.SubmitChanges();
    }

    [OperationContract]
    private void DeleteAcciones(List<decimal> pIdList)
    {
        foreach (decimal d in pIdList) {
            this.DeleteAccion(d);
        }
    }

    [OperationContract]
    private void DeleteCondicion(decimal pIDcond)
    {
        DataClassesDataContext objetoData = new DataClassesDataContext();
        var eliminar = (from c in objetoData.AttrReglasCondicion
                        where c.id == pIDcond
                        select c).ToList()[0];
        objetoData.AttrReglasCondicion.DeleteOnSubmit(eliminar);
        objetoData.SubmitChanges();
    }

    [OperationContract]
    private void DeleteCondiciones(List<decimal> pIdList)
    {
        foreach (decimal d in pIdList)
        {
            this.DeleteCondicion(d);
        }
    }
}