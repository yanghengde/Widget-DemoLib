using System;

using Siemens.SimaticIT.Unified.Common;
using Siemens.SimaticIT.Unified.Common.Information;
using Siemens.SimaticIT.Handler;

using Siemens.SimaticIT.SystemData.Foundation.Events;

namespace Siemens.Mom.Presales.Training.MasterData.DemoLib.MSModel.Events
{
    /// <summary>
    /// 
    /// </summary>
    [Handler(HandlerCategory.Event)]
    public partial class CommittedEvent_TransShell 
    {
        /// <summary>
        /// This is the Event handler the MES engineer should write
        /// This is the ENTRY POINT for the user in VS IDE
        /// </summary>
        /// <param name="evt"></param>
        /// <param name="envelope"></param>
        /// <returns></returns>
        [HandlerEntryPoint]
        private void CommittedEvent_Trans (CommittedEvent evt, EventEnvelope envelope)
        {

            // Put your code here

            throw new NotImplementedException();            
        }
    }
}
