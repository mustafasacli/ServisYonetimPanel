namespace Syp.Business.Interfaces
{
    using SimpleInfra.Common.Response;
    using System;
    using System.Collections.Generic;
    using Syp.ViewModel;

    public interface IServiceDetailBusiness
    {
        SimpleResponse<ServiceDetailViewModel> Create(ServiceDetailViewModel viewModel);

        SimpleResponse<ServiceDetailViewModel> Read(int id);

        SimpleResponse Update(ServiceDetailViewModel viewModel);

        SimpleResponse Delete(ServiceDetailViewModel viewModel);

        SimpleResponse Delete(int id);

        SimpleResponse<List<ServiceDetailViewModel>> ReadAll();
    }
}