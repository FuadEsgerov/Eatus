using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Models.Pages;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Repository.Repositories.PagesRepository;

namespace Admin.Controllers.Pages
{
    public class FaqController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IFaqRepository _faqRepository;
        public FaqController(IMapper mapper, IFaqRepository faqRepository)
        {
            _mapper = mapper;
            _faqRepository = faqRepository;
        }
        public IActionResult Index()
        {
            var faqs = _faqRepository.GetAllFaqs();
            var model = _mapper.Map<IEnumerable<Faq>, IEnumerable<FaqViewModel>>(faqs);
            return View(model);
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FaqViewModel faq)
        {
            if (ModelState.IsValid)
            {
                Faq model = _mapper.Map<FaqViewModel, Faq>(faq);
                _faqRepository.CreateFaq(model);
                return RedirectToAction("index");
            }
            return View(faq);
        }



        public IActionResult Edit(int id)
        {
            Faq faq = _faqRepository.GetFaqById(id);
            if (faq == null) return NotFound();
            var model = _mapper.Map<Faq, FaqViewModel>(faq);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FaqViewModel faq)
        {
            if (ModelState.IsValid)
            {
                Faq model = _mapper.Map<FaqViewModel, Faq>(faq);
                Faq fagToUpdate = _faqRepository.GetFaqById(faq.Id);
                if (fagToUpdate == null) return NotFound();
                _faqRepository.UpdateFaq(fagToUpdate, model);
                return RedirectToAction("index");
            }
            return View(faq);
        }
        public IActionResult Delete(int id)
        {
            Faq faq = _faqRepository.GetFaqById(id);
            if (faq == null) return NotFound();
            _faqRepository.DeleteFaq(faq);
            return RedirectToAction("index");
        }

    }
}
