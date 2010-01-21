<%@ WebService Language="C#" Class="WebServiceFlia" %>

using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Collections.Generic;
using System.Text;
using System.Data.Linq;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class WebServiceFlia  : System.Web.Services.WebService {

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }
     [WebMethod]
   public decimal GetFliaUltimoID(string pUsuario)
    {
        System.IO.StreamWriter sw = new System.IO.StreamWriter("c:\\temp\\dbconnFlia.txt", true);
        sw.WriteLine("Nombre de autor " +(pUsuario));
        sw.Close();
        
        DataClassesDataContext db = new DataClassesDataContext();
        var query = 
            from t in
            (from t in db.FamiliaInformacionGeneral
            where
              t.Usuario == pUsuario
            select new {
              t.Id,
              Dummy = "x"
            })
            group t by new { t.Dummy } into g
            select new {
              Column1 = (System.Int32?)g.Max(p => p.Id)
            };
        decimal salida = 0;
        foreach (var r in query){
            salida = Convert.ToDecimal(r.Column1);
        };
        System.IO.StreamWriter sw1 = new System.IO.StreamWriter("c:\\temp\\dbconnFlia.txt", true);
        sw1.WriteLine("Id flia a Modificar " + Convert.ToString(salida));
        sw1.Close();

        return salida;


        

    }


}