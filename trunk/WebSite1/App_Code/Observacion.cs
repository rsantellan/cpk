using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Descripción breve de Observacion
/// </summary>
public class Observacion
{
    private int _id;
    private String _tarea;
    private String _observacion;
    private String _autor;
    private DateTime _fecha;
    private int _objectId;
    private String _objectClass;
    private int _objectVersion;

    public int Id
    {
        get
        {
            return this._id;
        }
        set
        {
            this._id = value;
        }
    }

    public String Tarea { get { return this._tarea; } set { this._tarea = value; } }
    public String MiObservacion { get { return this._observacion; } set { this._observacion = value; } }
    public String Autor { get { return this._autor; } set { this._autor = value; } }
    public DateTime Fecha { get { return this._fecha; } set { this._fecha = value; } }
    public int ObjectId { get { return this._objectId; } set { this._objectId = value; } }
    public String ObjectClass { get { return this._objectClass; } set { this._objectClass = value; } }
    public int ObjectVersion { get { return this._objectVersion; } set { this._objectVersion = value; } }

    public Observacion()
    {

    }

    //id,
    //tarea,
    //observacion,
    //autor,
    //fecha,
    //object_id,
    //object_class

}
