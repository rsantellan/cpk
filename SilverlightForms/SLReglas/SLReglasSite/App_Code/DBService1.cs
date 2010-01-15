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

    public void SaveRule(System.Collections.ObjectModel.Collection<AttrReglas> preglas, int pIDattRel)
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


    private void DeleteRules(int pIDAttrRule)
    {
        decimal id = Convert.ToDecimal(pIDAttrRule);
        
        DataClassesDataContext db = new DataClassesDataContext();
            try
        {

            var queryRuleAtributo =
            from t in db.AttrReglas
            where
            t.IDAttRelacionado == Convert.ToDecimal(pIDAttrRule)
            select t
            ;
            
            foreach (var del in queryRuleAtributo)
            {
                db.AttrReglas.DeleteOnSubmit(del);
            }
           
            db.SubmitChanges();
           
           
        }
        catch (Exception ex)
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter("c:\\temp\\dbconnRules.txt", true);
            sw.WriteLine(ex.Message);
            sw.Close();
        }
    }
 }

