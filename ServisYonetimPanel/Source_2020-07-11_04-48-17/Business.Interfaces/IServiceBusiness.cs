namespace Syp.Business.Interfaces
{
    using SimpleInfra.Common.Response;
    using System;
    using System.Collections.Generic;
    using Syp.ViewModel;

    public interface IServiceBusiness
    {
        SimpleResponse<ServiceViewModel> Create(ServiceViewModel viewModel);

        SimpleResponse<ServiceViewModel> Read(int id);

        SimpleResponse Update(ServiceViewModel viewModel);

        SimpleResponse Delete(ServiceViewModel viewModel);

        SimpleResponse Delete(int id);

        SimpleResponse<List<ServiceViewModel>> ReadAll();
    }
}