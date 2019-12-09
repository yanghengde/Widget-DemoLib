using System;
using System.Collections.Generic;
using System.Linq;
using Siemens.SimaticIT.Unified.Common;
using Siemens.SimaticIT.Unified.Common.Information;
using Siemens.SimaticIT.Handler;
using Siemens.SimaticIT.Unified;
using Siemens.Mom.Presales.Training.MasterData.DemoLib.MSModel.DataModel;

namespace Siemens.Mom.Presales.Training.MasterData.DemoLib.MSModel.Commands
{
    /// <summary>
    /// Partial class init
    /// </summary>
    [Handler(HandlerCategory.BasicMethod)]
    public partial class AssignPersonToTeamHandlerShell 
    {
        /// <summary>
        /// This is the handler the MES engineer should write
        /// This is the ENTRY POINT for the user in VS IDE
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HandlerEntryPoint]
        private AssignPersonToTeam.Response AssignPersonToTeamHandler(AssignPersonToTeam command)
        {
            try
            {
                List<Guid> list = command.PersonIds;
                if (list != null)
                {
                    foreach (Guid guid in list)
                    {
                        var person = platform.GetEntity<IPerson>(guid);
                        if(person != null)
                        {
                            person.Teams_Id = command.TeamId;
                            platform.Submit(person);
                        }
                    }
                }

                return new AssignPersonToTeam.Response { };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
