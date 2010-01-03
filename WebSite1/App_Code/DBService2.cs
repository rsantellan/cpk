using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Collections.Generic;
using System.Text;

[ServiceContract(Namespace = "")]
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public class DBService2
{
    [OperationContract]
    public List<AtributoInformacionGeneral> GetAtributoPorID(int pAttr)
    {
        DataClassesDataContext db = new DataClassesDataContext();
        var rules = from item in db.AtributoInformacionGeneral
                    where item.Id == Convert.ToDecimal(pAttr)
                    select item;
        return rules.ToList();
    }
    
    [OperationContract]
    public List<AtributoInformacionGeneral> GetAtributoPorNombre(string pNom)
    {
        DataClassesDataContext db = new DataClassesDataContext();
        var rules = from item in db.AtributoInformacionGeneral
                    where item.Nombre == pNom
                    select item;
        return rules.ToList();
    }
}
