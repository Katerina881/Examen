using Database.Models;
using Logic.BindingModel;
using Logic.Interface;
using Logic.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database.Implement
{
    public class VkladLogic : IVklad
    {
        public void CreateOrUpdate(VkladBindingModel model)
        {
            using (var context = new Database())
            {
                Vklad element = context.Vklads.FirstOrDefault(rec => rec.VkladName == model.VkladName && rec.Id != model.Id);
                if (element != null)
                {
                    //название
                    throw new Exception("Уже есть банк с таким названием");
                }
                if (model.Id.HasValue)
                {
                    element = context.Vklads.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Vklad();
                    context.Vklads.Add(element);
                }
                element.VkladName = model.VkladName;
                element.DataCreateVklad = model.DataCreateVklad;
                element.Sum = model.Sum;
                element.TypeVal = model.TypeVal;
                element.BankId = model.BankId;
                context.SaveChanges();
            }
        }
        public void Delete(VkladBindingModel model)
        {
            using (var context = new Database())
            {
                Vklad element = context.Vklads.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Vklads.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<VkladViewModel> Read(VkladBindingModel model)
        {
            using (var context = new Database())
            {
                return context.Vklads
                .Where(rec => model == null || rec.Id == model.Id || (model.DateFrom.HasValue && model.DateTo.HasValue && rec.Bank.DateCreate >= model.DateFrom && rec.Bank.DateCreate <= model.DateTo))
                .Select(rec => new VkladViewModel
                {
                    Id = rec.Id,
                    BankId = rec.BankId,
                    VkladName = rec.VkladName,
                    Sum = rec.Sum,
                    DataCreateVklad = rec.DataCreateVklad,
                    TypeVal = rec.TypeVal,
                    Name = rec.Bank.Name,
                    DateCreate = rec.Bank.DateCreate
                })
                .ToList();
            }
        }
    }
}
