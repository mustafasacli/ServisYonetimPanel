namespace Syp.Business.Interfaces
{
    using SimpleInfra.Common.Response;
    using System;
    using System.Collections.Generic;
    using Syp.ViewModel;

    public interface IServiceUserBusiness
    {
        SimpleResponse<ServiceUserViewModel> Create(ServiceUserViewModel viewModel);

        SimpleResponse<ServiceUserViewModel> Read(int id);

        SimpleResponse Update(ServiceUserViewModel viewModel);

        SimpleResponse Delete(ServiceUserViewModel viewModel);

        SimpleResponse Delete(int id);

        SimpleResponse<List<ServiceUserViewModel>> ReadAll();
    }
}