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
/// Descripción breve de Atributo
/// </summary>
public class Atributo
{
    private int _id;
    private int _identificador;
    private String _autor;
    private int _version;
    private DateTime _fechaCreacion;
    private DateTime _fechaVigenciaDesde;
    private DateTime _fechaVigenciaHasta;
    private String _nombre;
    private String _descripcion;
    private Boolean _esModificable;

#region Propiedades
    public int Id { get { return this._id; } set { this._id = value; } }
    public String Autor { get { return this._autor; } set { this._autor = value; } }
    public int Identificador { get { return this._identificador; } set { this._identificador = value; } }
    public int Version { get { return this._version; } set { this._version = value; } }
    public DateTime FechaCreacion { get { return this._fechaCreacion; } set { this._fechaCreacion = value; } }
    public DateTime FechaVigenciaDesde { get { return this._fechaVigenciaDesde; } set { this._fechaVigenciaDesde = value; } }
    public DateTime FechaVigenciaHasta { get { return this._fechaVigenciaHasta; } set { this._fechaVigenciaHasta = value; } }
    public String Nombre { get { return this._nombre; } set { this._nombre = value; } }
    public String Descripcion { get { return this._descripcion; } set { this._descripcion = value; } }
    public Boolean EsModificable { get { return this._esModificable; } set { this._esModificable = value; } }
    
#endregion

    public Atributo()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    
}
