using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Repository.Repositories.PagesRepository;

namespace API.Controllers
{
    [ApiController]

    [Route("api")]
    public class PagesController : Controller
    {
        

        private IOurTeamRepository _teamRepository;
        private IAdvertisementRepository _adsRepository;
        private IAboutRepository _aboutRepository;
        private ISliderRepository _sliderRepository;

        public PagesController(IOurTeamRepository teamRepository, IAdvertisementRepository adsRepository, IAboutRepository aboutRepository, ISliderRepository sliderRepository)
        {
            _teamRepository = teamRepository;
            _adsRepository = adsRepository;
            _aboutRepository = aboutRepository;
            _sliderRepository = sliderRepository;

        }

        [HttpGet("ourteam")]
        public  ActionResult<IEnumerable<OurTeam>> GetResult()

        {
            var teams = _teamRepository.GetOurTeams();
            return Ok(teams);
        }
        [HttpGet("slider")]
        public ActionResult<IEnumerable<SliderItem>> GetSlider()

        {
            var teams = _sliderRepository.GetSliders();
            return Ok(teams);
        }
        [HttpGet("advertisement")]
        public ActionResult<IEnumerable<Advertisement>> GetAds()

        {
            var teams = _adsRepository.GetAdvertisements();
            return Ok(teams);
        }
        [HttpGet("about")]
        public ActionResult<IEnumerable<About>> GetAbout()

        {
            var teams = _aboutRepository.GetAbouts();
            return Ok(teams);
        }
    }
}
