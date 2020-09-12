using Logic.BindingModel;
using Logic.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Interface
{
    public interface IVklad
    {
        List<VkladViewModel> Read(VkladBindingModel model);
        void CreateOrUpdate(VkladBindingModel model);
        void Delete(VkladBindingModel model);
    }
}
