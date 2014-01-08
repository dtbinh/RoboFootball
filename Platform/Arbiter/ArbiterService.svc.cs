using Arbiter.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Arbiter
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ArbiterService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ArbiterService.svc or ArbiterService.svc.cs at the Solution Explorer and start debugging.
    public class ArbiterService : IGameManager
    {

        public void TeamReady(byte TemaId)
        {
            throw new NotImplementedException();
        }
    }
}
