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
        List<AtributoInformacionGeneral> salida = new List<AtributoInformacionGeneral>();
        DataClassesDataContext db = new DataClassesDataContext();
        var rules = from t0 in db.FamiliaAtributo
                    join t in db.AtributoInformacionGeneral on new { idAtributo = Convert.ToInt32(t0.idAtributo) } equals new { idAtributo = t.Id }
                    where
                      t0.idFamilia == pAttr &&
                      t0.idAtributo == t.Id
                    select new
                    {
                        t0.idFamilia,
                        t0.idAtributo,
                        t.Id,
                        t.Identificador,
                        t.Autor,
                        t.Version,
                        t.FechaCreacion,
                        t.FechaVigenciaDesde,
                        t.FechaVigenciaHasta,
                        t.Nombre,
                        t.Descripcion,
                        t.EsModificable
                    };
            foreach (var r in rules){
            AtributoInformacionGeneral item = new AtributoInformacionGeneral();
            item.Id =  r.Id;
            item.Identificador = r.Identificador;
            item.Autor = r.Autor;
            item.Version = r.Version;
            item.FechaCreacion= r.FechaCreacion;
            item.FechaVigenciaDesde = r.FechaVigenciaDesde;
            item.FechaVigenciaHasta = r.FechaVigenciaHasta;
            item.Nombre= r.Nombre;
            item.Descripcion = r.Descripcion;
            item.EsModificable = r.EsModificable;
             salida.Add(item);
            ;
        }
                 
        return salida;
    }
    
    [OperationContract]
    public List<AtributoInformacionGeneral> GetAtributoPorNombre(string pNom)
    {
     List<AtributoInformacionGeneral> salida = new List<AtributoInformacionGeneral>();
        DataClassesDataContext db = new DataClassesDataContext();
        var rules = from t in db.AtributoInformacionGeneral
                    where
                   t.Nombre.StartsWith(pNom) &&

                   (from t0 in db.AtributoInformacionGeneral
                    group t0 by new
                    {
                        t0.Identificador
                    } into g
                    select new
                    {
                        Column1 = (System.Int32?)g.Max(p => p.Version)
                    }).Single() != null
                    select new
                    {
                        t.Id,
                        t.Identificador,
                        t.Autor,
                        t.Version,
                        t.FechaCreacion,
                        t.FechaVigenciaDesde,
                        t.FechaVigenciaHasta,
                        t.Nombre,
                        t.Descripcion,
                        t.EsModificable
                        
                    };

        foreach (var r in rules){
            AtributoInformacionGeneral item = new AtributoInformacionGeneral();
            item.Id =  r.Id;
            item.Identificador = r.Identificador;
            item.Autor = r.Autor;
            item.Version = r.Version;
            item.FechaCreacion= r.FechaCreacion;
            item.FechaVigenciaDesde = r.FechaVigenciaDesde;
            item.FechaVigenciaHasta = r.FechaVigenciaHasta;
            item.Nombre= r.Nombre;
            item.Descripcion = r.Descripcion;
            item.EsModificable = r.EsModificable;
             salida.Add(item);
            ;
        }
        
            return salida;
       
    }
	 
	 [OperationContract]

    public bool SaveAttrFlia(List<AtributoInformacionGeneral> list, int pflia)
    {
	if (this.DeleteFlia(pflia) == true && this.Save(list, pflia) == true) {return true;}
    
	return false;
    }

    private bool Save(List<AtributoInformacionGeneral> list, int pflia)
    {

        foreach (AtributoInformacionGeneral a in list){
            DataClassesDataContext db = new DataClassesDataContext();

            var fa = new FamiliaAtributo
            {
                idFamilia = pflia,
                idAtributo = a.Id
            };
            db.FamiliaAtributo.InsertOnSubmit(fa);
            db.SubmitChanges();
        } 
		return true;
      }

    private bool DeleteFlia(int pflia)
    {
        
        DataClassesDataContext db = new DataClassesDataContext();
        var queryFamiliaAtributo =
		from t in db.FamiliaAtributo
		where
        t.idFamilia == Convert.ToDecimal(pflia)
		select t;
        foreach (var del in queryFamiliaAtributo)
        {
            db.FamiliaAtributo.DeleteOnSubmit(del);
        }
        db.SubmitChanges();
		return true;

    }

    [OperationContract]
    public List<FamiliaAtributo> GetFlia(int pFlia)
    {
        DataClassesDataContext db = new DataClassesDataContext();
        var rules = from item in db.FamiliaAtributo
                    where item.idFamilia == pFlia
                    select item;
        return rules.ToList();
    }

}
