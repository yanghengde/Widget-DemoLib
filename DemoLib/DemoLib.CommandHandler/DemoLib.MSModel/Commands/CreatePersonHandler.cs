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
    public partial class CreatePersonHandlerShell 
    {
        /// <summary>
        /// This is the handler the MES engineer should write
        /// This is the ENTRY POINT for the user in VS IDE
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HandlerEntryPoint]
        private CreatePerson.Response CreatePersonHandler(CreatePerson command)
        {
            ITracer tracer = platform.Tracer;
            tracer.Write("Siemens-SimaticIT-Trace-Custom", Category.Informational, "Create Person Start...");
            try
            {
                var entity = platform.Create<IPerson>();
                entity.FirstName = command.FirstName;
                entity.LastName = command.LastName;
                entity.IsActive = command.IsActive;
                entity.Birthday = command.Birthday;
                entity.Age = command.Age;
                entity.Sex = command.Sex;

                PropertyValuesSpecification<IPerson> pv = new PropertyValuesSpecification<IPerson>();
                pv.Add("FirstName", command.FirstName.Trim());
                pv.Add("LastName", command.LastName.Trim());
                var existentity = platform.GetEntity<IPerson>(pv);
                if (existentity == null)
                {
                    platform.Submit(entity);
                }
                else
                {
                    return new CreatePerson.Response { Error = new ExecutionError(-1010, string.Format("[{0}]已经存在，不允许创建", command.FirstName)) };
                }
                tracer.Write("Siemens-SimaticIT-Trace-Custom", Category.Informational, "Create Person End...");
                return new CreatePerson.Response { Id = entity.Id };
            }
            catch (Exception ex)
            {
                return new CreatePerson.Response { Error = new ExecutionError(-1010, string.Format("[{0}]创建发生异常,异常信息是：{1}", command.FirstName, ex.Message)) };
            }
        }
    }
}
