using Logic.BindingModel;
using Logic.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Interface
{
    public interface IBank
    {
        List<BankViewModel> Read(BankBindingModel model);
        void CreateOrUpdate(BankBindingModel model);
        void Delete(BankBindingModel model);
    }
}
