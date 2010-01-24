using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ProductoCobertura
/// </summary>
public class ProductoCobertura
{
    private int _idProducto;
    private int _idCondicionado;
    
    public int IdProducto { get{ return this._idProducto;} set{this._idProducto=value;} }
    public int IdCondicionado { get { return this._idCondicionado; } set { this._idCondicionado = value; } }
    
    public ProductoCobertura()
	{
	}
}
