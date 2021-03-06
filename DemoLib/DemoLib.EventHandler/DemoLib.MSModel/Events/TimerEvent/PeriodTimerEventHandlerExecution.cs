using System;

using Siemens.SimaticIT.Unified.Common;
using Siemens.SimaticIT.Unified.Lean;

using Siemens.SimaticIT.SystemData.Foundation.Events;

namespace Siemens.Mom.Presales.Training.MasterData.DemoLib.MSModel.Events
{
    /// <summary>
    /// 
    /// </summary>
    [UnifiedEvent("Siemens.SimaticIT.SystemData.Foundation.Events.TimerEvent",true)]
    public partial class PeriodTimerEventHandlerShell : IEventHandler
    {
        private IUnifiedSdkEvent platform;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unifiedSdk"></param>
        /// <param name="evt"></param>
        /// <param name="envelope"></param>
        /// <returns></returns>
        public void Execute(IUnifiedSdkEvent unifiedSdk, IEvent evt, EventEnvelope envelope)
        {
            platform = unifiedSdk;

            PeriodTimerEventHandler((TimerEvent)evt, envelope);
        }

        /// <summary>
        /// 
        /// </summary>
        public global::System.Type GetEventType()
        {
            return typeof(TimerEvent);
        }
    }
}
