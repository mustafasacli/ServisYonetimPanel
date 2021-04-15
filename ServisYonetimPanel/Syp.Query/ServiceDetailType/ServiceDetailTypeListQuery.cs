using SI.Query.Core;

namespace Syp.Query.ServiceDetailType
{
    /// <summary>
    /// </summary>
    public class ServiceDetailTypeListQuery : IQuery<ServiceDetailTypeList>
    {
        public string Name
        { get; set; }
    }
}