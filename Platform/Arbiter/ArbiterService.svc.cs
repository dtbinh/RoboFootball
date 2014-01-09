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
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ArbiterService
    {
        private void CheckIfCouldStart()
        {
            using(var manager= new ConfigurationSvc.MembershipManagerClient)
            {
            }
        }
    }
}
