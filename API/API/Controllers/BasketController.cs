using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Repository.Repositories;

namespace API.Controllers
{

        public class BasketController : BaseApiController
        {
            private readonly IBasketRepository _basketRepository;
            public BasketController(IBasketRepository basketRepository)
            {
                _basketRepository = basketRepository;
            }

            [HttpGet]
            public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
            {
                var basket = await _basketRepository.GetBasketAsync(id);

                return Ok(basket ?? new CustomerBasket(id));
            }

            [HttpPost]
            public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket basket)
            {
                var updatedBasket = await _basketRepository.UpdateBasketAsync(basket);

                return Ok(updatedBasket);
            }

            [HttpDelete]
            public async Task DeleteBasketAsync(string id)
            {
                await _basketRepository.DeleteBasketAsync(id);
            }
        }
    }

