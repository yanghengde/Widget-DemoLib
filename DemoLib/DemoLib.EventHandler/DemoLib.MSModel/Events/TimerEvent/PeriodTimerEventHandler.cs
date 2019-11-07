using System;

using Siemens.SimaticIT.Unified.Common;
using Siemens.SimaticIT.Unified.Common.Information;
using Siemens.SimaticIT.Handler;

using Siemens.SimaticIT.SystemData.Foundation.Events;
using Siemens.SimaticIT.SystemData.Foundation.Types;
using Siemens.SimaticIT.SDK.Diagnostics.Tracing;
using Siemens.SimaticIT.SDK.Diagnostics.Common;

namespace Siemens.Mom.Presales.Training.MasterData.DemoLib.MSModel.Events
{
    /// <summary>
    /// 
    /// </summary>
    [Handler(HandlerCategory.Event)]
    public partial class PeriodTimerEventHandlerShell 
    {
        /// <summary>
        /// This is the Event handler the MES engineer should write
        /// This is the ENTRY POINT for the user in VS IDE
        /// </summary>
        /// <param name="evt"></param>
        /// <param name="envelope"></param>
        /// <returns></returns>
        [HandlerEntryPoint]
        private void PeriodTimerEventHandler (TimerEvent evt, EventEnvelope envelope)
        {
            evt.TimerMode = SimaticIT.SystemData.Foundation.Types.TimerModeEnum.Periodic;
            evt.TimerUniqueName = envelope.UserField1;
            evt.TimerType = SimaticIT.SystemData.Foundation.Types.TimerTypeEnum.Delay;
            evt.TimerID = new Guid(envelope.UserField2);
            evt.StartTime = DateTimeOffset.Parse(envelope.UserField3);
            evt.TimerInfoDelay = new TimerInfoDelayParameters(new TimeSpan(0, 0, 10));

            ITracer tracer = platform.Tracer;
            try
            {
                tracer.Write("Siemens-SimaticIT-Trace-BusinessLogic", Category.Informational, "PeriodTimerEventHandler Begin....");
                tracer.Write("Siemens-SimaticIT-Trace-BusinessLogic", Category.Informational, envelope.UserField1);
            }
            catch (Exception ex)
            {
                tracer.Write("Siemens-SimaticIT-Trace-BusinessLogic", Category.Informational, "PeriodTimerEventHandler Exception...." + ex.Message);
            }
        }
    }
}
