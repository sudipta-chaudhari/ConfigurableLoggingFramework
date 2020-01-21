using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using SLogConfiguration;
using System;

namespace SLog
{
    public class SLogAction : ActionFilterAttribute
    {
        #region Variables
        private readonly ILog sLogger = null;
        #endregion

        #region Ctor
        public SLogAction(IConfiguration configuration)
        {
            SLogConfig.ApplicationName = "SLog";
            SLogConfig.LoggerName = "SLogger";
            SLogConfig.ApplicationType = ApplicationType.WebService;
            SLogConfig.LogConnectionString = configuration.GetConnectionString("SLogs");
            SLogConfig.UserName = Environment.UserName;
            SLogConfig.MachineName = Environment.MachineName;

            sLogger = SLog.Initialize(SLogConfig.LogConnectionString, SLogConfig.LoggerName, SLogConfig.ApplicationName, SLogConfig.ApplicationType, 
                SLogLevel.Message, SLogConfig.UserName, LoggerType.FILE);
        }
        #endregion

        #region Methods
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            CaptureLog("Api call started.", SLogConfig.ApplicationType.ToString(), 
                ((ControllerActionDescriptor)context.ActionDescriptor).ActionName, SLogConfig.UserName, SLogConfig.MachineName);
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            CaptureLog("Api call finished.", SLogConfig.ApplicationType.ToString(),
                ((ControllerActionDescriptor)context.ActionDescriptor).ActionName, SLogConfig.UserName, SLogConfig.MachineName);
        }
        private void CaptureLog(string message, string eventType, string memberName, string userName, string userMachineName)
        {
            sLogger.LogMessage(eventType, memberName + " " + message);
        }
        #endregion
    }
}
