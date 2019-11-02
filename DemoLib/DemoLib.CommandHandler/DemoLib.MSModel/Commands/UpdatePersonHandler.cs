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
    public partial class UpdatePersonHandlerShell 
    {
        /// <summary>
        /// This is the handler the MES engineer should write
        /// This is the ENTRY POINT for the user in VS IDE
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HandlerEntryPoint]
        private UpdatePerson.Response UpdatePersonHandler(UpdatePerson command)
        {
            ITracer tracer = platform.Tracer;
            tracer.Write("Siemens-SimaticIT-Trace-Custom", Category.Informational, "Update Person Start...");
            try
            {
                var entity = platform.GetEntity<IPerson>(command.Id);
                if (entity == null)
                {
                   return new UpdatePerson.Response { Error = new ExecutionError(-1010, string.Format("[{0}]已经不存在，不允许更新", command.FirstName)) };
                }
                else
                {
                    var existentity = platform.Query<IPerson>().FirstOrDefault(x => x.FirstName == command.FirstName && x.LastName == command.LastName);
                    if(existentity != null)
                    {
                        if (!existentity.Id.Equals(command.Id))
                        {
                            return new UpdatePerson.Response { Error = new ExecutionError(-1010, string.Format("[{0}]+[{1}]已经存在，不允许更新", command.FirstName,command.LastName)) };
                        }
                    }
                    entity.FirstName = command.FirstName;
                    entity.LastName = command.LastName;
                    entity.IsActive = command.IsActive;
                    entity.Birthday = command.Birthday;
                    entity.Age = command.Age;
                    entity.Sex = command.Sex;
                }
                platform.Submit(entity);
                tracer.Write("Siemens-SimaticIT-Trace-Custom", Category.Informational, "Update Person End...");
                return new UpdatePerson.Response { };
            }
            catch (Exception ex)
            {
                return new UpdatePerson.Response { Error = new ExecutionError(-1010, string.Format("[{0}]更新发生异常,异常信息是：{1}", command.FirstName, ex.Message)) };
            }
        }
    }
}
