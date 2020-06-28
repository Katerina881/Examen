using Logic.BindingModel;
using Logic.HelperInfo;
using Logic.Interface;
using Logic.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.BuisnessLogic
{
    public class ReportLogic
    {
        private readonly IOsnv Osnv;
        private readonly IDop Dop;
        public ReportLogic(IOsnv Osnv, IDop Dop)
        {
            this.Osnv = Osnv;
            this.Dop = Dop;
        }
        public List<DopViewModel> GetDops(ReportBindingModel model)
        {
            var Dops = Dop.Read(new DopBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            });
            var list = new List<DopViewModel>();
            foreach (var rec in Dops)
            {
                var record = new DopViewModel
                {
                    DopName = rec.DopName,
                    Name = rec.Name,
                    DataCreateDop = rec.DataCreateDop,
                    Place = rec.Place,
                    DateCreate = rec.DateCreate
                };
                list.Add(record);
            }
            return list;
        }
        public void SaveDopsToPdfFile(ReportBindingModel model)
        {
            //названия
            string title = "Блюда и их продукты";
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = title,
                Dops = GetDops(model),
            });
        }
    }
}
