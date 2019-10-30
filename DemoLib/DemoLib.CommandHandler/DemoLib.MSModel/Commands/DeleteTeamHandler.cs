using System;
using System.Collections.Generic;
using System.Linq;
using Siemens.SimaticIT.Unified.Common;
using Siemens.SimaticIT.Unified.Common.Information;
using Siemens.SimaticIT.Handler;
using Siemens.SimaticIT.Unified;
using Siemens.SimaticIT.SDK.Diagnostics.Tracing;
using Siemens.Mom.Presales.Training.MasterData.DemoLib.MSModel.DataModel;
using Siemens.SimaticIT.SDK.Diagnostics.Common;

namespace Siemens.Mom.Presales.Training.MasterData.DemoLib.MSModel.Commands
{
    /// <summary>
    /// Partial class init
    /// </summary>
    [Handler(HandlerCategory.BasicMethod)]
    public partial class DeleteTeamHandlerShell 
    {
        /// <summary>
        /// This is the handler the MES engineer should write
        /// This is the ENTRY POINT for the user in VS IDE
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HandlerEntryPoint]
        private DeleteTeam.Response DeleteTeamHandler(DeleteTeam command)
        {
            ITracer tracer = platform.Tracer;
            tracer.Write("Siemens-SimaticIT-Trace-Custom", Category.Informational, "Delete Team Start...");
            try
            {
                var entity = platform.GetEntity<ITeam>(command.Id);
                if (entity == null)
                {
                    return new DeleteTeam.Response { Error = new ExecutionError(-1010, "删除的对象不存在") };
                }
                platform.Delete(entity);
                tracer.Write("Siemens-SimaticIT-Trace-Custom", Category.Informational, "Delete Team End...");
                return new DeleteTeam.Response { };
            }
            catch (Exception ex)
            {
                return new DeleteTeam.Response { Error = new ExecutionError(-1010, string.Format("删除发生异常,异常信息是：{0}", ex.Message)) };
            }
        }
    }
}
