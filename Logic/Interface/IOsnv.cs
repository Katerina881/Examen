using Logic.BindingModel;
using Logic.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Interface
{
    public interface IOsnv
    {
        List<OsnvViewModel> Read(OsnvBindingModel model);
        void CreateOrUpdate(OsnvBindingModel model);
        void Delete(OsnvBindingModel model);
    }
}
