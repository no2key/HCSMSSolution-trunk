﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HCSMS.Model
{
    [Serializable]
    public class RequestHandleInfo
    {
        public string Description { get; set; }
        
       
        public string TargetId { get; set; }        
        public string SourceId { get; set; }
        public string EntityId { get; set; }
        public RequestType RequestType { get; set; }

        public bool IsHandled { get; set; }
    }
}
