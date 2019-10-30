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
    public partial class DeletePersonHandlerShell 
    {
        /// <summary>
        /// This is the handler the MES engineer should write
        /// This is the ENTRY POINT for the user in VS IDE
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HandlerEntryPoint]
        private DeletePerson.Response DeletePersonHandler(DeletePerson command)
        {
            ITracer tracer = platform.Tracer;
            tracer.Write("Siemens-SimaticIT-Trace-Custom", Category.Informational, "Delete Person Start...");
            try
            {
                var entity = platform.GetEntity<IPerson>(command.Id);
                if (entity == null)
                {
                    return new DeletePerson.Response { Error = new ExecutionError(-1010, "删除的对象不存在") };
                }
                platform.Delete(entity);
                tracer.Write("Siemens-SimaticIT-Trace-Custom", Category.Informational, "Delete Person End...");
                return new DeletePerson.Response { };
            }
            catch (Exception ex)
            {
                return new DeletePerson.Response { Error = new ExecutionError(-1010, string.Format("删除发生异常,异常信息是：{0}", ex.Message)) };
            }
        }
    }
}
