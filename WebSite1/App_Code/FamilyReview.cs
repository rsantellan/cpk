﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de FamilyReview
/// </summary>
public class FamilyReview
{
    private int _familyId;
    private String _resolution;
    private String _observation;
    private String _author;
    private DateTime _createdAt;

    public int FamilyId { get{return this._familyId;} set{this._familyId = value;} }
    public String Resolution { get{return this._resolution;} set{this._resolution=value;} }
    public String Observation {get {return this._observation;} set{this._observation=value;}}
    public String Author {get {return this._author;} set{this._author=value;}}
    public DateTime CreatedAt { get { return this._createdAt; } set { this._createdAt = value; } }
	public FamilyReview()
	{
	}
}
