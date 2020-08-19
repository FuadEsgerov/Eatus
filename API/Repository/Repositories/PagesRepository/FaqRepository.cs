using Repository.Data;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories.PagesRepository
{
    public interface IFaqRepository
    {
        IEnumerable<Faq> GetFaqs();
        IEnumerable<Faq> GetAllFaqs();
        Faq CreateFaq(Faq model);
        Faq GetFaqById(int id);
        void UpdateFaq(Faq faqToUpdate, Faq model);
        void DeleteFaq(Faq faq);
    }
    public class FaqRepository : IFaqRepository
    {
        private readonly AppDbContext _context;

        public FaqRepository(AppDbContext context)
        {
            _context = context;
        }

        public Faq CreateFaq(Faq model)
        {
       
            _context.Faqs.Add(model);
            _context.SaveChanges();
            return model;
        }

        public void DeleteFaq(Faq faq)
        {
            _context.Faqs.Remove(faq);
            _context.SaveChanges();
        }

        public IEnumerable<Faq> GetAllFaqs()
        {
            return _context.Faqs.ToList();
        }

        public Faq GetFaqById(int id)
        {
            return _context.Faqs.Find(id);
        }

        public IEnumerable<Faq> GetFaqs()
        {
            return _context.Faqs.Where(f => f.Status)
                                        .ToList();
        }

        public void UpdateFaq(Faq faqToUpdate, Faq model)
        {
            faqToUpdate.Status = model.Status;
            faqToUpdate.Question = model.Question;
            faqToUpdate.Answer = model.Answer;
            _context.SaveChanges();
        }
    }
}
