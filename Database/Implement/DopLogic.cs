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
    public class DopLogic : IDop
    {
        public void CreateOrUpdate(DopBindingModel model)
        {
            using (var context = new Database())
            {
                Dop element = context.Dops.FirstOrDefault(rec => rec.DopName == model.DopName && rec.Id != model.Id);
                if (element != null)
                {
                    //название
                    throw new Exception("Уже есть блюдо с таким названием");
                }
                if (model.Id.HasValue)
                {
                    element = context.Dops.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Dop();
                    context.Dops.Add(element);
                }
                element.DopName = model.DopName;
                element.DataCreateDop = model.DataCreateDop;
                element.Count = model.Count;
                element.Place = model.Place;
                element.OsnId = model.OsnId;
                context.SaveChanges();
            }
        }
        public void Delete(DopBindingModel model)
        {
            using (var context = new Database())
            {
                Dop element = context.Dops.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Dops.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<DopViewModel> Read(DopBindingModel model)
        {
            using (var context = new Database())
            {
                return context.Dops
                .Where(rec => model == null || rec.Id == model.Id || (model.DateFrom.HasValue && model.DateTo.HasValue && rec.Osn.DateCreate >= model.DateFrom && rec.Osn.DateCreate <= model.DateTo))
                .Select(rec => new DopViewModel
                {
                    Id = rec.Id,
                    OsnId = rec.OsnId,
                    DopName = rec.DopName,
                    Count = rec.Count,
                    DataCreateDop = rec.DataCreateDop,
                    Place = rec.Place,
                    Name = rec.Osn.Name,
                    DateCreate = rec.Osn.DateCreate
                })
                .ToList();
            }
        }
    }
}
