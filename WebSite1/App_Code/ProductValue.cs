using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de FamilyReview
/// </summary>
public class ProductValue
{
    private int _productId;
    private int _femeninoAdulto;
    private int _femeninoAdultoMayor;
    private int _masculinoAdulto;
    private int _masculinoAdultoMayor;
    private String _resolution;
    private String _observation;
    private String _author;
    private DateTime _createdAt;

    public int ProductId { get { return this._productId; } set { this._productId = value; } }
    public int FemeninoAdulto { get { return this._femeninoAdulto; } set { this._femeninoAdulto = value; } }
    public int FemeninoAdultoMayor { get { return this._femeninoAdultoMayor; } set { this._femeninoAdultoMayor = value; } }
    public int MasculinoAdulto { get { return this._masculinoAdulto; } set { this._masculinoAdulto = value; } }
    public int MasculinoAdultoMayor { get { return this._masculinoAdultoMayor; } set { this._masculinoAdultoMayor = value; } }
    public String Resolution { get{return this._resolution;} set{this._resolution=value;} }
    public String Observation {get {return this._observation;} set{this._observation=value;}}
    public String Author {get {return this._author;} set{this._author=value;}}
    public DateTime CreatedAt { get { return this._createdAt; } set { this._createdAt = value; } }
    public ProductValue()
	{
	}
}
