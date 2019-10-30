using System;
using System.Collections.Generic;
using System.Linq;
using Siemens.SimaticIT.Unified.Common;
using Siemens.SimaticIT.Unified.Common.Information;
using Siemens.SimaticIT.Handler;
using Siemens.SimaticIT.Unified;
using Siemens.SimaticIT.SDK.Diagnostics.Tracing;
using Siemens.SimaticIT.SDK.Diagnostics.Common;
using Siemens.Mom.Presales.Training.MasterData.DemoLib.MSModel.DataModel;

namespace Siemens.Mom.Presales.Training.MasterData.DemoLib.MSModel.Commands
{
    /// <summary>
    /// Partial class init
    /// </summary>
    [Handler(HandlerCategory.BasicMethod)]
    public partial class CreateTeamHandlerShell 
    {
        /// <summary>
        /// This is the handler the MES engineer should write
        /// This is the ENTRY POINT for the user in VS IDE
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HandlerEntryPoint]
        private CreateTeam.Response CreateTeamHandler(CreateTeam command)
        {
            ITracer tracer = platform.Tracer;
            tracer.Write("Siemens-SimaticIT-Trace-Custom", Category.Informational, "Create Team Start...");
            try
            {
                var entity = platform.Create<ITeam>();
                entity.Name = command.Team.Name;
                entity.Description = command.Team.Description;
                entity.Number = command.Team.Number;
                entity.IsActive = command.IsActive;
                entity.IsLeader = command.IsLeader;

                PropertyValuesSpecification<ITeam> pv = new PropertyValuesSpecification<ITeam>();
                pv.Add("Name", command.Team.Name);
                var existentity = platform.GetEntity<ITeam>(pv);
                if (existentity == null)
                {
                    platform.Submit(entity);
                }
                else
                {
                    return new CreateTeam.Response { Error = new ExecutionError(-1010, string.Format("[{0}]已经存在，不允许创建",command.Team.Name)) };
                }
                tracer.Write("Siemens-SimaticIT-Trace-Custom", Category.Informational, "Create Team End...");
                return new CreateTeam.Response { Id = entity.Id};
            }
            catch(Exception ex)
            {
                return new CreateTeam.Response { Error = new ExecutionError(-1010, string.Format("[{0}]创建发生异常,异常信息是：{1}", command.Team.Name,ex.Message)) };
            }
        }
    }
}
