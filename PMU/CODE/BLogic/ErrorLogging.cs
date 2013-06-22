//======================================================================================================
// Created By :  Vj
// Description:  Page to handle the Error logging part of the application
// For Instance: Database error
// Created On:   6/14/2013
//======================================================================================================

using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace PMU.CODE.BLogic
{
    public static class ErrorLogging
    {
        /// <summary>
        /// Log error mostly service with error details
        /// </summary>
        /// <param name="title">Title of the error</param>
        /// <param name="message">Detail of the error</param>
        public static void LogError(string title, string message)
        {
            LogEntry logEntry = new LogEntry();
            logEntry.Title = title;
            logEntry.Message = message;
            logEntry.Severity = System.Diagnostics.TraceEventType.Error;
            Logger.Write(logEntry);    
        }

        /// <summary>
        /// Log error when occur at page level when url is specified
        /// </summary>
        /// <param name="title">Title of the error</param>
        /// <param name="message">Detail of the error</param>
        /// <param name="url">URL of the page where error occured</param>
        public static void LogError(string title, string message, string url)
        {
            LogEntry logEntry = new LogEntry();

            Dictionary<string, object> exProperties = new Dictionary<string, object>();
            exProperties.Add("URL", url); 

            logEntry.Title = title;
            logEntry.Message = message;
            logEntry.Severity = System.Diagnostics.TraceEventType.Error;
            logEntry.ExtendedProperties = exProperties;
            Logger.Write(logEntry);
        }
    }
}