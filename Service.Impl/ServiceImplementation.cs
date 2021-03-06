﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HCSMS.Model;
using HCSMS.Model.Application;

namespace HCSMS.Service.Impl
{
    public abstract class ServiceImplementation
    {        
        
        public bool IsUsingReplyContainer{get;set;}
        

        public ServiceImplementation()
        {              
            IsUsingReplyContainer = true;

            this.ErrorHandler += HCSMSLog.OnErrorLog;
        }

#region Definition of Events for use of all class in Service Layer

        public delegate void NotifyEvent(object sender, NotifyEventArgs args);
        public delegate List<RequestHandleInfo> HandleEvent(object sender, HandleEventArgs args);
        public delegate void ErrorEvent(object sender, ErrorEventArgs args);

        // Event to fire when there is an error happens
        public event ErrorEvent ErrorHandler;
        // Event to fire when there is a reply for server happens
        public event NotifyEvent ServerReplyHandler;

#endregion

 # region Error management block

       protected virtual void raiseError(Exception ex)
        {
            ErrorEventArgs args = new ErrorEventArgs("Application Errors!", ex);           
            ErrorEventHandler(ErrorHandler, args);
        }       

# endregion

#region Server reply management block

      
        protected virtual void recieveServerMessage(string msg)
        {
            if (IsUsingReplyContainer)
            {
               NotifyEventHandler(ServerReplyHandler, new NotifyEventArgs(msg));                
            }
        }
        
#endregion

#region    Generic Method for handling event

        protected virtual void NotifyEventHandler(NotifyEvent handler, NotifyEventArgs args)
        {
            if (handler != null)
            {
                handler(this, args);               
            }
        }       
        protected virtual void ErrorEventHandler(ErrorEvent handler, ErrorEventArgs args)
        {
            if (handler != null)
            {
                handler(this, args);               
            }
        }

#endregion
    }
}