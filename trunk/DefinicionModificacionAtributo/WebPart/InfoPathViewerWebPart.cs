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

namespace WebPart
{
     public class InfoPathViewerWebPart : System.Web.UI.WebControls.WebParts.WebPart    {
         private const string defaultxsnlocation = "";
         private string _xsnlocation = defaultxsnlocation;
         private XmlFormView viewform;
         
         [Personalizable(), WebBrowsable(),WebDisplayName("XSNLocation"),WebDescription("URL of the web-enabled InfoPath form to display")]
         public string XSNLocation        {
             get { return _xsnlocation;
             }
             set { _xsnlocation = value; 
            }        
         }        
         
         protected override void RenderContents(System.Web.UI.HtmlTextWriter writer){
             base.RenderContents(writer);            
             this.EnsureChildControls();
         }        
         
         protected override void CreateChildControls(){
             base.CreateChildControls();
             viewform = new XmlFormView();
             if (_xsnlocation.Length > 0){
                 viewform.XsnLocation = _xsnlocation;
             }            
             viewform.Initialize += new EventHandler<InitializeEventArgs>(viewform_Initialize);
             this.Controls.Add(viewform);
         }        
         void viewform_Initialize(object sender, InitializeEventArgs e){
             try{
                 XPathNavigator xNavMain = viewform.XmlForm.MainDataSource.CreateNavigator();
                 XmlNamespaceManager xNameSpace = new XmlNamespaceManager(new NameTable());
                 xNameSpace.AddNamespace("my", "http://.../office/infopath/2003/myXSD/2006-08-07T07:37:16");
                 XPathNavigator fSummary = xNavMain.SelectSingleNode("/my:myFields/my:Summary", xNameSpace);
                 if (fSummary != null){
                     fSummary.SetValue("Hello InfoPath");
                 }
                 else
                 {                    
                     EventLog.WriteEntry("InfoPathWebPart", "fSummary not found", EventLogEntryType.Information);
                 }                            
             }            
             catch (Exception ex)
             {                
                 EventLog.WriteEntry("WebParts.InfoPathViewerWebPart", ex.ToString(),EventLogEntryType.Error);
             }             
         }

     }
 }
