﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión del motor en tiempo de ejecución:2.0.50727.3603
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;



[System.Data.Linq.Mapping.DatabaseAttribute(Name="formFlows")]
public partial class DataClassesDataContext : System.Data.Linq.DataContext
{
	
	private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
	
  #region Extensibility Method Definitions
  partial void OnCreated();
  partial void InsertTreeEstructuraItems(TreeEstructuraItems instance);
  partial void UpdateTreeEstructuraItems(TreeEstructuraItems instance);
  partial void DeleteTreeEstructuraItems(TreeEstructuraItems instance);
  partial void InsertTreeNodos(TreeNodos instance);
  partial void UpdateTreeNodos(TreeNodos instance);
  partial void DeleteTreeNodos(TreeNodos instance);
  #endregion
	
	public DataClassesDataContext() : 
			base(global::System.Configuration.ConfigurationManager.ConnectionStrings["formFlowsConnectionString"].ConnectionString, mappingSource)
	{
		OnCreated();
	}
	
	public DataClassesDataContext(string connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public DataClassesDataContext(System.Data.IDbConnection connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public DataClassesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public DataClassesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public System.Data.Linq.Table<TreeEstructuraItems> TreeEstructuraItems
	{
		get
		{
			return this.GetTable<TreeEstructuraItems>();
		}
	}
	
	public System.Data.Linq.Table<TreeNodos> TreeNodos
	{
		get
		{
			return this.GetTable<TreeNodos>();
		}
	}
}

[Table(Name="dbo.TreeEstructuraItems")]
[DataContract()]
public partial class TreeEstructuraItems : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private decimal _IDTreeEstructuraItem;
	
	private System.Nullable<bool> _EsRequerido;
	
	private System.Nullable<bool> _SoloLectura;
	
	private System.Nullable<bool> _MultiSeleccion;
	
	private string _SubTipo;
	
	private string _OrigenDeDatos;
	
	private string _Valores;
	
	private string _Ruta;
	
	private string _Metodo;
	
	private string _Tipo;
	
	private System.Nullable<decimal> _Largo;
	
	private System.Nullable<decimal> _Decimales;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDTreeEstructuraItemChanging(decimal value);
    partial void OnIDTreeEstructuraItemChanged();
    partial void OnEsRequeridoChanging(System.Nullable<bool> value);
    partial void OnEsRequeridoChanged();
    partial void OnSoloLecturaChanging(System.Nullable<bool> value);
    partial void OnSoloLecturaChanged();
    partial void OnMultiSeleccionChanging(System.Nullable<bool> value);
    partial void OnMultiSeleccionChanged();
    partial void OnSubTipoChanging(string value);
    partial void OnSubTipoChanged();
    partial void OnOrigenDeDatosChanging(string value);
    partial void OnOrigenDeDatosChanged();
    partial void OnValoresChanging(string value);
    partial void OnValoresChanged();
    partial void OnRutaChanging(string value);
    partial void OnRutaChanged();
    partial void OnMetodoChanging(string value);
    partial void OnMetodoChanged();
    partial void OnTipoChanging(string value);
    partial void OnTipoChanged();
    partial void OnLargoChanging(System.Nullable<decimal> value);
    partial void OnLargoChanged();
    partial void OnDecimalesChanging(System.Nullable<decimal> value);
    partial void OnDecimalesChanged();
    #endregion
	
	public TreeEstructuraItems()
	{
		this.Initialize();
	}
	
	[Column(Storage="_IDTreeEstructuraItem", DbType="Decimal(18,0) NOT NULL", IsPrimaryKey=true)]
	[DataMember(Order=1)]
	public decimal IDTreeEstructuraItem
	{
		get
		{
			return this._IDTreeEstructuraItem;
		}
		set
		{
			if ((this._IDTreeEstructuraItem != value))
			{
				this.OnIDTreeEstructuraItemChanging(value);
				this.SendPropertyChanging();
				this._IDTreeEstructuraItem = value;
				this.SendPropertyChanged("IDTreeEstructuraItem");
				this.OnIDTreeEstructuraItemChanged();
			}
		}
	}
	
	[Column(Storage="_EsRequerido", DbType="Bit")]
	[DataMember(Order=2)]
	public System.Nullable<bool> EsRequerido
	{
		get
		{
			return this._EsRequerido;
		}
		set
		{
			if ((this._EsRequerido != value))
			{
				this.OnEsRequeridoChanging(value);
				this.SendPropertyChanging();
				this._EsRequerido = value;
				this.SendPropertyChanged("EsRequerido");
				this.OnEsRequeridoChanged();
			}
		}
	}
	
	[Column(Storage="_SoloLectura", DbType="Bit")]
	[DataMember(Order=3)]
	public System.Nullable<bool> SoloLectura
	{
		get
		{
			return this._SoloLectura;
		}
		set
		{
			if ((this._SoloLectura != value))
			{
				this.OnSoloLecturaChanging(value);
				this.SendPropertyChanging();
				this._SoloLectura = value;
				this.SendPropertyChanged("SoloLectura");
				this.OnSoloLecturaChanged();
			}
		}
	}
	
	[Column(Storage="_MultiSeleccion", DbType="Bit")]
	[DataMember(Order=4)]
	public System.Nullable<bool> MultiSeleccion
	{
		get
		{
			return this._MultiSeleccion;
		}
		set
		{
			if ((this._MultiSeleccion != value))
			{
				this.OnMultiSeleccionChanging(value);
				this.SendPropertyChanging();
				this._MultiSeleccion = value;
				this.SendPropertyChanged("MultiSeleccion");
				this.OnMultiSeleccionChanged();
			}
		}
	}
	
	[Column(Storage="_SubTipo", DbType="VarChar(50)")]
	[DataMember(Order=5)]
	public string SubTipo
	{
		get
		{
			return this._SubTipo;
		}
		set
		{
			if ((this._SubTipo != value))
			{
				this.OnSubTipoChanging(value);
				this.SendPropertyChanging();
				this._SubTipo = value;
				this.SendPropertyChanged("SubTipo");
				this.OnSubTipoChanged();
			}
		}
	}
	
	[Column(Storage="_OrigenDeDatos", DbType="VarChar(50)")]
	[DataMember(Order=6)]
	public string OrigenDeDatos
	{
		get
		{
			return this._OrigenDeDatos;
		}
		set
		{
			if ((this._OrigenDeDatos != value))
			{
				this.OnOrigenDeDatosChanging(value);
				this.SendPropertyChanging();
				this._OrigenDeDatos = value;
				this.SendPropertyChanged("OrigenDeDatos");
				this.OnOrigenDeDatosChanged();
			}
		}
	}
	
	[Column(Storage="_Valores", DbType="VarChar(50)")]
	[DataMember(Order=7)]
	public string Valores
	{
		get
		{
			return this._Valores;
		}
		set
		{
			if ((this._Valores != value))
			{
				this.OnValoresChanging(value);
				this.SendPropertyChanging();
				this._Valores = value;
				this.SendPropertyChanged("Valores");
				this.OnValoresChanged();
			}
		}
	}
	
	[Column(Storage="_Ruta", DbType="VarChar(50)")]
	[DataMember(Order=8)]
	public string Ruta
	{
		get
		{
			return this._Ruta;
		}
		set
		{
			if ((this._Ruta != value))
			{
				this.OnRutaChanging(value);
				this.SendPropertyChanging();
				this._Ruta = value;
				this.SendPropertyChanged("Ruta");
				this.OnRutaChanged();
			}
		}
	}
	
	[Column(Storage="_Metodo", DbType="VarChar(50)")]
	[DataMember(Order=9)]
	public string Metodo
	{
		get
		{
			return this._Metodo;
		}
		set
		{
			if ((this._Metodo != value))
			{
				this.OnMetodoChanging(value);
				this.SendPropertyChanging();
				this._Metodo = value;
				this.SendPropertyChanged("Metodo");
				this.OnMetodoChanged();
			}
		}
	}
	
	[Column(Storage="_Tipo", DbType="VarChar(50)")]
	[DataMember(Order=10)]
	public string Tipo
	{
		get
		{
			return this._Tipo;
		}
		set
		{
			if ((this._Tipo != value))
			{
				this.OnTipoChanging(value);
				this.SendPropertyChanging();
				this._Tipo = value;
				this.SendPropertyChanged("Tipo");
				this.OnTipoChanged();
			}
		}
	}
	
	[Column(Storage="_Largo", DbType="Decimal(18,0)")]
	[DataMember(Order=11)]
	public System.Nullable<decimal> Largo
	{
		get
		{
			return this._Largo;
		}
		set
		{
			if ((this._Largo != value))
			{
				this.OnLargoChanging(value);
				this.SendPropertyChanging();
				this._Largo = value;
				this.SendPropertyChanged("Largo");
				this.OnLargoChanged();
			}
		}
	}
	
	[Column(Storage="_Decimales", DbType="Decimal(18,0)")]
	[DataMember(Order=12)]
	public System.Nullable<decimal> Decimales
	{
		get
		{
			return this._Decimales;
		}
		set
		{
			if ((this._Decimales != value))
			{
				this.OnDecimalesChanging(value);
				this.SendPropertyChanging();
				this._Decimales = value;
				this.SendPropertyChanged("Decimales");
				this.OnDecimalesChanged();
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
	
	private void Initialize()
	{
		OnCreated();
	}
	
	[OnDeserializing()]
	[System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
	public void OnDeserializing(StreamingContext context)
	{
		this.Initialize();
	}
}

[Table(Name="dbo.TreeNodos")]
[DataContract()]
public partial class TreeNodos : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private decimal _IDTree;
	
	private string _NomTree;
	
	private System.Nullable<decimal> _IDParent;
	
	private System.Nullable<decimal> _IDAttr;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDTreeChanging(decimal value);
    partial void OnIDTreeChanged();
    partial void OnNomTreeChanging(string value);
    partial void OnNomTreeChanged();
    partial void OnIDParentChanging(System.Nullable<decimal> value);
    partial void OnIDParentChanged();
    partial void OnIDAttrChanging(System.Nullable<decimal> value);
    partial void OnIDAttrChanged();
    #endregion
	
	public TreeNodos()
	{
		this.Initialize();
	}
	
	[Column(Storage="_IDTree", AutoSync=AutoSync.OnInsert, DbType="Decimal(18,0) NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	[DataMember(Order=1)]
	public decimal IDTree
	{
		get
		{
			return this._IDTree;
		}
		set
		{
			if ((this._IDTree != value))
			{
				this.OnIDTreeChanging(value);
				this.SendPropertyChanging();
				this._IDTree = value;
				this.SendPropertyChanged("IDTree");
				this.OnIDTreeChanged();
			}
		}
	}
	
	[Column(Storage="_NomTree", DbType="VarChar(50)")]
	[DataMember(Order=2)]
	public string NomTree
	{
		get
		{
			return this._NomTree;
		}
		set
		{
			if ((this._NomTree != value))
			{
				this.OnNomTreeChanging(value);
				this.SendPropertyChanging();
				this._NomTree = value;
				this.SendPropertyChanged("NomTree");
				this.OnNomTreeChanged();
			}
		}
	}
	
	[Column(Storage="_IDParent", DbType="Decimal(18,0)")]
	[DataMember(Order=3)]
	public System.Nullable<decimal> IDParent
	{
		get
		{
			return this._IDParent;
		}
		set
		{
			if ((this._IDParent != value))
			{
				this.OnIDParentChanging(value);
				this.SendPropertyChanging();
				this._IDParent = value;
				this.SendPropertyChanged("IDParent");
				this.OnIDParentChanged();
			}
		}
	}
	
	[Column(Storage="_IDAttr", DbType="Decimal(18,0)")]
	[DataMember(Order=4)]
	public System.Nullable<decimal> IDAttr
	{
		get
		{
			return this._IDAttr;
		}
		set
		{
			if ((this._IDAttr != value))
			{
				this.OnIDAttrChanging(value);
				this.SendPropertyChanging();
				this._IDAttr = value;
				this.SendPropertyChanged("IDAttr");
				this.OnIDAttrChanged();
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
	
	private void Initialize()
	{
		OnCreated();
	}
	
	[OnDeserializing()]
	[System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
	public void OnDeserializing(StreamingContext context)
	{
		this.Initialize();
	}
}
#pragma warning restore 1591
