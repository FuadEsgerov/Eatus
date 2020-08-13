using Repository.Data;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories.PagesRepository
{
    public interface ISliderRepository
    {
        IEnumerable<SliderItem> GetSliders();
        SliderItem CreateSlider(SliderItem model);
        SliderItem GetSliderById(int id);
        void UpdateSlider(SliderItem sliderToUpdate, SliderItem model);
        void DeleteSlider(SliderItem slider);
    }
    public class SliderRepository : ISliderRepository
    {
        private readonly AppDbContext _context;

        public SliderRepository(AppDbContext context)
        {
            _context = context;
        }
        public SliderItem CreateSlider(SliderItem model)
        {
         
            _context.SliderItems.Add(model);
            _context.SaveChanges();
            return model;
        }

        public void DeleteSlider(SliderItem slider)
        {
            _context.SliderItems.Remove(slider);
            _context.SaveChanges();
        }

        public SliderItem GetSliderById(int id)
        {
            return _context.SliderItems.Find(id);
        }

        public IEnumerable<SliderItem> GetSliders()
        {
            return _context.SliderItems.ToList();
        }

        public void UpdateSlider(SliderItem sliderToUpdate, SliderItem model)
        {
            sliderToUpdate.Status = model.Status;
            sliderToUpdate.Title = model.Title;
            sliderToUpdate.ActionText = model.ActionText;
            sliderToUpdate.Image = model.Image;
            sliderToUpdate.EndPoint = model.EndPoint;
            sliderToUpdate.Slogan = model.Slogan;
            _context.SaveChanges();
        }
    }

}
