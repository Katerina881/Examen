using Logic.BindingModel;
using Logic.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Interface
{
    public interface IDop
    {
        List<DopViewModel> Read(DopBindingModel model);
        void CreateOrUpdate(DopBindingModel model);
        void Delete(DopBindingModel model);
    }
}
