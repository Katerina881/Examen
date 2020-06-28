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
    public class OsnLogic : IOsn
    {
        public void CreateOrUpdate(OsnBindingModel model)
        {
            using (var context = new Database())
            {
                Osn element = context.Osns.FirstOrDefault(rec => rec.Name == model.Name && rec.Id != model.Id);
                if (element != null)
                {
                    //название
                    throw new Exception("Уже есть блюдо с таким названием");
                }
                if (model.Id.HasValue)
                {
                    element = context.Osns.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Osn();
                    context.Osns.Add(element);
                }
                element.Name = model.Name;
                element.Type = model.Type;
                element.DateCreate = model.DateCreate;
                context.SaveChanges();
            }
        }
        public void Delete(OsnBindingModel model)
        {
            using (var context = new Database())
            {
                Osn element = context.Osns.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Osns.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<OsnViewModel> Read(OsnBindingModel model)
        {
            using (var context = new Database())
            {
                return context.Osns
                .Where(rec => model == null || rec.Id == model.Id)
                .Select(rec => new OsnViewModel
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
