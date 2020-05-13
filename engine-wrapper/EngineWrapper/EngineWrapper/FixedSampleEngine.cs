using EngineWrapper.Logger;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace EngineWrapper
{
    public class FixedSampleEngine
    {   
        [DllImport("libtopsimengwrapper.so")]
        public static extern void Invoke([MarshalAs(UnmanagedType.LPStr)] string request,
       StringBuilder response);

        public static string ComputeOutput(string requestMessage)
        {  
            var response = new StringBuilder(3000);
            Invoke(requestMessage, response);
            return Convert.ToString(response);            
        }
    }
}
