using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.ValueObjects.Enums
{
    public enum EErrorResponseCode
    {
        Undefined = 0,
        /// <summary>
        /// This will be returned if an invalid username is used in the request, 
        /// or if the username does not have the rights to modify the resource.
        /// </summary>
        UnAuthorized_User,

        /// <summary>
        /// This will be returned if the body of the message contains invalid JSON.
        /// </summary>
        Invalid_Json,
        /// <summary>
        /// This will be returned if the addressed resource does not exist. 
        /// E.g. the user specifies a light ID that does not exist.
        /// </summary>
        Url_Resouce_NotAvailable,

        /// <summary>
        /// This will be returned if the method (GET/POST/PUT/DELETE) used is not supported by the URL 
        /// E.g. DELETE is not supported on the /config resource
        /// </summary>
        Method_NotAvailable,
        /// <summary>
        /// Will be returned if required parameters are not present in the message body. 
        /// The presence of invalid parameters should not trigger this error as long as 
        /// all required parameters are present.
        /// </summary>
        Missing_Parameters,

        /// <summary>
        /// This will be returned if a parameter sent in the message body does not exist. 
        /// This error is specific to PUT commands; 
        /// invalid parameters in other commands are simply ignored.
        /// </summary>
        Parameter_NotAvailable,

        /// <summary>
        /// This will be returned if the value set for a parameter is of the incorrect format or is out of range.
        /// </summary>
        Invalid_Parameter_Value,
        /// <summary>
        /// This will be returned if an attempt to modify a read only parameter is made
        /// </summary>
        Readonly_Parameter,
        /// <summary>
        /// List in request contains too many items
        /// </summary>
        Too_Many_Parameters,
        /// <summary>
        /// Command requires portal connection. Returned if portalservices is “false“ or the portal connection is down
        /// </summary>
        Protal_Connection_Required,

        /// <summary>
        /// This will be returned if there is an internal error in the processing of the command. 
        /// This indicates an error in the bridge, not in the message being sent.
        /// </summary>
        Interal_Error = 901
    }
}
