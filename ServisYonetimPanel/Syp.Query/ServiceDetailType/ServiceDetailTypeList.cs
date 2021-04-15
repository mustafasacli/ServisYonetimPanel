using SI.Query.Core;
using System.Collections.Generic;

namespace Syp.Query.ServiceDetailType
{
    public class ServiceDetailTypeList : IQueryResult
    {
        public List<ServiceDetailType> List { get; set; }
    }
}