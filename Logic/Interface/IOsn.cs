using Logic.BindingModel;
using Logic.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Interface
{
    public interface IOsn
    {
        List<OsnViewModel> Read(OsnBindingModel model);
        void CreateOrUpdate(OsnBindingModel model);
        void Delete(OsnBindingModel model);
    }
}
