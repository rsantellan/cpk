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


    private void DeleteRules(int pIDAttrRule)
    {
        decimal id = Convert.ToDecimal(pIDAttrRule);
        DataClassesDataContext objetoData = new DataClassesDataContext();
        var eliminar = (from c in objetoData.AttrReglas
                        where c.IDAttRelacionado == id
                        select c).ToList()[0];
        objetoData.AttrReglas.DeleteOnSubmit(eliminar);
        objetoData.SubmitChanges();
    }
}
