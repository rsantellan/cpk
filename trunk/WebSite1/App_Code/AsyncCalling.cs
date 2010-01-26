using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de AsyncCalling
/// </summary>
public class AsyncCalling
{
	public AsyncCalling()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    private String replicateAttRules(int pIdentifier, int pVersion, int pNewVersion)
    {
        ABMCAtributosReglas abmc = new ABMCAtributosReglas();
        abmc.replicateDataRule(pIdentifier, pVersion, pNewVersion);
        return "";
    }

    public delegate string DelegateWithParameters(int param1,
                       int param2, int param3);

    public void CallReplicateDataWithParameters(int pIdentifier, int pVersion, int pNewVersion)
    {

        //this.replicateAttRules(pIdentifier, pVersion,pNewVersion);

        // create the delegate
        DelegateWithParameters delFoo =
            new DelegateWithParameters(replicateAttRules);

        // call the BeginInvoke function!
        IAsyncResult tag =
            delFoo.BeginInvoke(pIdentifier, pVersion, pNewVersion, null, null);
        Log.saveInLog("<!--------------------------------!>");
        // normally control is returned right away,
        // so you can do other work here...

        // calling end invoke to get the return value
        string strResult = delFoo.EndInvoke(tag);

    }

    public delegate string DelegateTreeWithParameters(int param1,
                       int param2);

    public void CallReplicateTreeWithParameters(int pOldId, int pNewId)
    {

        //this.replicateAttTree(pOldId, pNewId);

        // create the delegate
        DelegateTreeWithParameters delFoo =
            new DelegateTreeWithParameters(replicateAttTree);

        // call the BeginInvoke function!
        IAsyncResult tag =
            delFoo.BeginInvoke(pOldId, pNewId, null, null);
        Log.saveInLog("<!--------------------------------!>");
        // normally control is returned right away,
        // so you can do other work here...

        // calling end invoke to get the return value
        string strResult = delFoo.EndInvoke(tag);

    }

    private String replicateAttTree(int pOldId, int pNewId)
    {
        ABMCAtributoTree abmc = new ABMCAtributoTree();
        abmc.saveNodes(pOldId, pNewId);
        return "";
    }
}
