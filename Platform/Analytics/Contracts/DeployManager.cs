using Analytics.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace Analytics.ServiceContracts
{
    [ServiceContract]
    public interface IAnalyticsManager
    {
        [OperationContract]
        AnalyticsData GetAnalyticsData();
    }
}