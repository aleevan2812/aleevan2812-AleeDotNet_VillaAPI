using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Villa_Web.Models;
using Villa_Web.Models.Dto;
using Villa_Web.Services.IServices;

namespace Villa_Web.Controllers;

public class VillaController : Controller
{
    private readonly IMapper _mapper;
    private readonly IVillaService _villaService;

    public VillaController(IVillaService villaService, IMapper mapper)
    {
        _villaService = villaService;
        _mapper = mapper;
    }

    public async Task<IActionResult> IndexVilla()
    {
        List<VillaDTO> list = new();

        var response = await _villaService.GetAllAsync<APIResponse>();
        if (response != null && response.IsSuccess)
            list = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Result));
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
        if (ModelState.IsValid)
        {
            var response = await _villaService.CreateAsync<APIResponse>(model);
            if (response != null && response.IsSuccess) return RedirectToAction(nameof(IndexVilla));
        }

        return View(model);
    }

    public async Task<IActionResult> UpdateVilla(int villaId)
    {
        var response = await _villaService.GetAsync<APIResponse>(villaId);
        if (response != null && response.IsSuccess)
        {
            var model = JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(response.Result));
            return View(_mapper.Map<VillaUpdateDTO>(model));
        }

        return NotFound();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateVilla(VillaUpdateDTO model)
    {
        if (ModelState.IsValid)
        {
            var response = await _villaService.UpdateAsync<APIResponse>(model);
            if (response != null && response.IsSuccess) return RedirectToAction(nameof(IndexVilla));
        }

        return View(model);
    }
}