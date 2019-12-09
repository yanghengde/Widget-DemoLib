using System;
using System.Collections.Generic;
using System.Linq;
using Siemens.SimaticIT.Unified.Common;
using Siemens.SimaticIT.Unified.Common.Information;
using Siemens.SimaticIT.Handler;
using Siemens.SimaticIT.Unified;

namespace Siemens.Mom.Presales.Training.MasterData.DemoLib.MSModel.Commands
{
    /// <summary>
    /// Partial class init
    /// </summary>
    [Handler(HandlerCategory.BasicMethod)]
    public partial class TestTransactionHandlerShell 
    {
        /// <summary>
        /// This is the handler the MES engineer should write
        /// This is the ENTRY POINT for the user in VS IDE
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HandlerEntryPoint]
        private TestTransaction.Response TestTransactionHandler(TestTransaction command)
        {
            try
            {
                var command1 = new CreatePerson
                {
                    Age = 11,
                    Birthday = DateTimeOffset.Now,
                    FirstName = "Hengdeyang",
                    IsActive = true,
                    LastName = "Oliv",
                    Sex = 0
                };

                var command2 = new CreateTeam
                {

                };


                platform.CallCommand<CreatePerson, CreatePerson.Response>(command1);
                platform.CallCommand<CreateTeam, CreateTeam.Response>(command2);


            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
