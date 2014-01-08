using Analytics.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Analytics
{
    public class AnalyticsService : IAnalyticsManager
    {
        public DataContracts.AnalyticsData GetAnalyticsData()
        {
            throw new NotImplementedException();
        }
    }
}
