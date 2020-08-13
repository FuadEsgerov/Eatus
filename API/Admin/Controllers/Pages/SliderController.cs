using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Libs;
using Admin.Models.Pages;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Repository.Repositories.PagesRepository;
using Repository.Services;

namespace Admin.Controllers.Pages
{
    public class SliderController : Controller
    {
        private readonly ISliderRepository _sliderRepository;
        private readonly IMapper _mapper;
        private readonly IFileManager _fileManager;
        private readonly ICloudinaryService _cloudinaryService;

        public SliderController(ICloudinaryService cloudinaryService, ISliderRepository sliderRepository, IMapper mapper, IFileManager fileManager)
        {
            _sliderRepository = sliderRepository;
            _mapper = mapper;
            _fileManager = fileManager;
            _cloudinaryService = cloudinaryService;

        }


        public IActionResult Index()
        {
            var homeslider = _sliderRepository.GetSliders();
            var model = _mapper.Map<IEnumerable<SliderItem>, IEnumerable<SliderViewModel>>(homeslider);
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SliderViewModel slider)
        {

            if (ModelState.IsValid)
            {
                SliderItem model = _mapper.Map<SliderViewModel, SliderItem>(slider);

                _sliderRepository.CreateSlider(model);
                return RedirectToAction("index");
            }
            return View(slider);

        }

        public IActionResult Edit(int id)
        {
            SliderItem slider = _sliderRepository.GetSliderById(id);
            if (slider == null) return NotFound();
            var model = _mapper.Map<SliderItem, SliderViewModel>(slider);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SliderViewModel slider)
        {
            if (slider == null) return NotFound();

            if (ModelState.IsValid)
            {
                SliderItem model = _mapper.Map<SliderViewModel, SliderItem>(slider);
 

                SliderItem sliderToUpdate = _sliderRepository.GetSliderById(slider.Id);
                if (sliderToUpdate == null) return NotFound();
                _sliderRepository.UpdateSlider(sliderToUpdate, model);
                return RedirectToAction("index");
            }
            return View(slider);
        }


        public IActionResult Delete(int id)
        {
            SliderItem slider = _sliderRepository.GetSliderById(id);
            if (slider == null) return NotFound();
            _sliderRepository.DeleteSlider(slider);
            return RedirectToAction("index");
        }
        [HttpPost]
        public IActionResult Upload(IFormFile file, int? sliderId)
        {
            var filename = _fileManager.Upload(file);
            var publicId = _cloudinaryService.Store(filename);
            _fileManager.Delete(filename);

            if (sliderId != null)
            {
                SliderItem slidePhoto = new SliderItem
                {
                    //AddedBy = _admin.Fullname,
                    //AddedDate = DateTime.Now,
                    Image = publicId,


                };
                //_sliderRepository.AddPhoto(slidePhoto);
            }

            return Ok(new
            {
                filename = publicId,
                src = _cloudinaryService.BuildUrl(publicId)
            });
        }

        [HttpPost]
        public IActionResult Remove(string name, int? id)
        {
            if (id != null)
            {
                //_sliderRepository.RemovePhotoById((int)id);
            }

            _cloudinaryService.Delete(name);

            return Ok(new { status = 200 });
        }
    }
}
