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
    public class BankLogic : IBank
    {
        public void CreateOrUpdate(BankBindingModel model)
        {
            using (var context = new Database())
            {
                Bank element = context.Banks.FirstOrDefault(rec => rec.Name == model.Name && rec.Id != model.Id);
                if (element != null)
                {
                    //название
                    throw new Exception("Уже есть банк с таким названием");
                }
                if (model.Id.HasValue)
                {
                    element = context.Banks.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Bank();
                    context.Banks.Add(element);
                }
                element.Name = model.Name;
                element.Type = model.Type;
                element.DateCreate = model.DateCreate;
                context.SaveChanges();
            }
        }
        public void Delete(BankBindingModel model)
        {
            using (var context = new Database())
            {
                Bank element = context.Banks.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Banks.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<BankViewModel> Read(BankBindingModel model)
        {
            using (var context = new Database())
            {
                return context.Banks
                .Where(rec => model == null || rec.Id == model.Id)
                .Select(rec => new BankViewModel
                {
                    Id = rec.Id,
                    Name = rec.Name,
                    Type = rec.Type,
                    DateCreate = rec.DateCreate
                })
                .ToList();
            }
        }
    }
}
