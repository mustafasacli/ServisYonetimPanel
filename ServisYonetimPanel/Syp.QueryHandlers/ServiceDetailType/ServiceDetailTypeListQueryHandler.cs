using SI.QueryHandler.Base;
using SimpleInfra.Common.Response;
using SimpleInfra.Data.Extensions;
using Syp.Query.ServiceDetailType;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Syp.QueryHandlers.ServiceDetailType
{
    public class ServiceDetailTypeListQueryHandler : BaseQueryHandler<ServiceDetailTypeListQuery, ServiceDetailTypeList>
    {
        public override SimpleResponse<ServiceDetailTypeList> Handle(ServiceDetailTypeListQuery query)
        {
            var response = new SimpleResponse<ServiceDetailTypeList>();

            try
            {
                using (var connection = GetDbConnection())
                {
                    try
                    {
                        connection.OpenIfNot();
                        var result = connection.QueryList<Syp.Entity.ServiceDetailType>("select * from service_detail_type where is_deleted = false and lower(detail_type_name) like '%' || :name || '%'", new { name = query.Name.ToLowerInvariant() });
                        response.Data = new ServiceDetailTypeList
                        {
                            List = result.Select(p => new Syp.Query.ServiceDetailType.ServiceDetailType
                            {
                                DetailTypeName = p.DetailTypeName,
                                Id = p.Id
                            }).ToList() ?? new List<Query.ServiceDetailType.ServiceDetailType>()
                        };
                        response.ResponseCode = response.Data?.List?.Count ?? 0;
                        response.RCode = result.ToString();
                    }
                    finally
                    {
                        connection.CloseIfNot();
                    }
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = -500;
                DayLogger.Error(ex);
            }

            return response;
        }
    }
}