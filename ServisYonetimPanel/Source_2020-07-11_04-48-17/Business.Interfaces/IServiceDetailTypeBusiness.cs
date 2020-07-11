namespace Syp.Business.Interfaces
{
    using SimpleInfra.Common.Response;
    using System;
    using System.Collections.Generic;
    using Syp.ViewModel;

    public interface IServiceDetailTypeBusiness
    {
        SimpleResponse<ServiceDetailTypeViewModel> Create(ServiceDetailTypeViewModel viewModel);

        SimpleResponse<ServiceDetailTypeViewModel> Read(int id);

        SimpleResponse Update(ServiceDetailTypeViewModel viewModel);

        SimpleResponse Delete(ServiceDetailTypeViewModel viewModel);

        SimpleResponse Delete(int id);

        SimpleResponse<List<ServiceDetailTypeViewModel>> ReadAll();
    }
}