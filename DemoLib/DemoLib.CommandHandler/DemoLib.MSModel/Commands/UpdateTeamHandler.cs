using System;
using System.Collections.Generic;
using System.Linq;
using Siemens.SimaticIT.Unified.Common;
using Siemens.SimaticIT.Unified.Common.Information;
using Siemens.SimaticIT.Handler;
using Siemens.SimaticIT.Unified;
using Siemens.SimaticIT.SDK.Diagnostics.Common;
using Siemens.SimaticIT.SDK.Diagnostics.Tracing;
using Siemens.Mom.Presales.Training.MasterData.DemoLib.MSModel.DataModel;

namespace Siemens.Mom.Presales.Training.MasterData.DemoLib.MSModel.Commands
{
    /// <summary>
    /// Partial class init
    /// </summary>
    [Handler(HandlerCategory.BasicMethod)]
    public partial class UpdateTeamHandlerShell 
    {
        /// <summary>
        /// This is the handler the MES engineer should write
        /// This is the ENTRY POINT for the user in VS IDE
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HandlerEntryPoint]
        private UpdateTeam.Response UpdateTeamHandler(UpdateTeam command)
        {
            ITracer tracer = platform.Tracer;
            tracer.Write("Siemens-SimaticIT-Trace-Custom", Category.Informational, "update Team Start...");
            try
            {
                var entity = platform.GetEntity<ITeam>(command.Id);
                if (entity == null)
                {
                    return new UpdateTeam.Response { Error = new ExecutionError(-1010, string.Format("[{0}]已经不存在，不允许更新", command.Team.Name)) };
                }
                else
                {
                    var existentity = platform.Query<ITeam>().FirstOrDefault(x => x.Name == command.Team.Name);
                    if(existentity != null)
                    {
                        return new UpdateTeam.Response { Error = new ExecutionError(-1010, string.Format("[{0}]已经有其它记录，不允许更新", command.Team.Name)) };
                    }
                    entity.Name = command.Team.Name;
                    entity.Description = command.Team.Description;
                    entity.Number = command.Team.Number;
                    entity.IsActive = command.IsActive;
                    entity.IsLeader = command.IsLeader;
                }
                platform.Submit(entity);
                tracer.Write("Siemens-SimaticIT-Trace-Custom", Category.Informational, "Update Team End...");
                return new UpdateTeam.Response { };
            }
            catch (Exception ex)
            {
                return new UpdateTeam.Response { Error = new ExecutionError(-1010, string.Format("[{0}]更新发生异常,异常信息是：{1}", command.Team.Name, ex.Message)) };
            }
        }
    }
}
