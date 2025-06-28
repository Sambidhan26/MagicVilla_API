using AutoMapper;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dto;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagicVilla_Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly IVillaService _services;
        private readonly IMapper _mapper;

        public VillaController(IVillaService services,IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }

        public async Task<IActionResult> IndexVilla()
        {
            List<VillaDTO> list = new();
            var response = await _services.GetAllAsync<APIResponse>();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Result));

            }
            return View(list);
        }
        public async Task<IActionResult> CreateVilla()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVilla(VillaCreateDTO model)
        {
            if(ModelState.IsValid) 
            {
                var response = await _services.CreateAsync<APIResponse>(model);
                if (response != null && response.IsSuccess) 
                {
                    return RedirectToAction(nameof(IndexVilla));
                }
            }
            return View(model);
        }

    }
}
