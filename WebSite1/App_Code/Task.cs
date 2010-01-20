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
/// Descripción breve de Tareas
/// </summary>
public class Task
{
    private int _id;
    private int _identificador;
    private String _autor;
    private DateTime _fechaCreacion;
    private String _titulo;
    private String _responsable;
    private Boolean _habilitada;
    private String _usuario;
    private String _descripcion;

#region Propiedades
    public int Id { get { return this._id; } set { this._id = value; } }
    public String Autor { get { return this._autor; } set { this._autor = value; } }
    public int Identificador { get { return this._identificador; } set { this._identificador = value; } }
    public DateTime FechaCreacion { get { return this._fechaCreacion; } set { this._fechaCreacion = value; } }
    public String Titulo { get { return this._titulo; } set { this._titulo = value; } }
    public String Responsable { get { return this._responsable; } set { this._responsable = value; } }
    public Boolean Habilitada { get { return this._habilitada; } set { this._habilitada = value; } }
    public String Usuario { get { return this._usuario; } set { this._usuario = value; } }
    public String Descripcion { get { return this._descripcion; } set { this._descripcion = value; } }
    
#endregion

    public Task()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    
}
