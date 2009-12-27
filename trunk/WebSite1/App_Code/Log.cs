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
using System.IO;

/// <summary>
/// Descripción breve de Log
/// </summary>
public class Log
{
	public Log()
	{
		
	}

    public static void saveInLog(String text)
    {
        StreamWriter sw = new StreamWriter("C:\\logApplication.txt", true);
        sw.WriteLine(text);
        sw.Close();
    }
}
