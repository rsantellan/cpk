using Microsoft.Office.InfoPath;
using System;
using System.Xml;
using System.Xml.XPath;

namespace DefinicionModificacionAtributo
{
    public partial class FormCode
    {
        // No se admiten variables miembro en los formularios habilitados para el explorador.
        // En su lugar, escriba y lea estos valores del diccionario FormState
        // utilizando código como el siguiente:
        //
        // private object _memberVariable
        // {
        //     get
        //     {
        //         return FormState["_memberVariable"];
        //     }
        //     set
        //     {
        //         FormState["_memberVariable"] = value;
        //     }
        // }

        // NOTA: Microsoft Office InfoPath requiere el siguiente procedimiento.
        // Puede modificarse utilizando Microsoft Office InfoPath.
        public void InternalStartup()
        {
        }
    }
}
