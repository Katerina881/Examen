using Logic.BindingModel;
using Logic.HelperInfo;
using Logic.Interface;
using Logic.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.BuisnessLogic
{
    public class ReportLogic
    {
        private readonly IBank Bank;
        private readonly IVklad Vklad;
        public ReportLogic(IBank Bank, IVklad Vklad)
        {
            this.Bank = Bank;
            this.Vklad = Vklad;
        }
        public List<VkladViewModel> GetVklads(ReportBindingModel model)
        {
            var Vklads = Vklad.Read(new VkladBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            });
            var list = new List<VkladViewModel>();
            foreach (var rec in Vklads)
            {
                var record = new VkladViewModel
                {
                    VkladName = rec.VkladName,
                    Name = rec.Name,
                    DataCreateVklad = rec.DataCreateVklad,
                    TypeVal = rec.TypeVal,
                    DateCreate = rec.DateCreate
                };
                list.Add(record);
            }
            return list;
        }
        public async void SaveVkladsToPdfFile(ReportBindingModel model)
        {
            string title = "Вклады банков за период";

            await Task.Run(() =>
            {
                SaveToPdf.CreateDoc(new PdfInfo
                {
                    FileName = model.FileName,
                    Title = title,
                    Vklads = GetVklads(model),
                });
            });
        }
    }
}