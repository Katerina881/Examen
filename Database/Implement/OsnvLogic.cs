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
    public class OsnvLogic : IOsnv
    {
        public void CreateOrUpdate(OsnvBindingModel model)
        {
            using (var context = new Database())
            {
                Osnv element = context.Osnvs.FirstOrDefault(rec => rec.Name == model.Name && rec.Id != model.Id);
                if (element != null)
                {
                    //название
                    throw new Exception("Уже есть блюдо с таким названием");
                }
                if (model.Id.HasValue)
                {
                    element = context.Osnvs.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Osnv();
                    context.Osnvs.Add(element);
                }
                element.Name = model.Name;
                element.Type = model.Type;
                element.DateCreate = model.DateCreate;
                context.SaveChanges();
            }
        }
        public void Delete(OsnvBindingModel model)
        {
            using (var context = new Database())
            {
                Osnv element = context.Osnvs.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Osnvs.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<OsnvViewModel> Read(OsnvBindingModel model)
        {
            using (var context = new Database())
            {
                return context.Osnvs
                .Where(rec => model == null || rec.Id == model.Id)
                .Select(rec => new OsnvViewModel
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
