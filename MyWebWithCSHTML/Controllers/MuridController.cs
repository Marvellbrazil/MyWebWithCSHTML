using Microsoft.AspNetCore.Mvc;
using MyWebWithCSHTML.Models;

namespace MyWebWithCSHTML.Controllers;

public class MuridController : Controller
{
    private static List<Murid> _muridList = new List<Murid>
    {
        new Murid { Id = 1, Nama = "Akbar", NIS = "A1B1C1", Kelas = "3DKV", Umur = 19 },
        new Murid { Id = 2, Nama = "Faisal", NIS = "A2B2C1", Kelas = "2RPL", Umur = 17 },
    };
    
    public IActionResult Index()
    {
        return View(_muridList);
    }

    public IActionResult Detail(int id)
    {
        var murid = _muridList.FirstOrDefault(m => m.Id == id);
        if (murid == null) return NotFound();
        
        return View(murid);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Murid murid)
    {
        murid.Id = _muridList.Max(m => m.Id) + 1;
        _muridList.Add(murid);

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Edit(Murid murid)
    {
        var existing = _muridList.FirstOrDefault(m => m.Id == murid.Id);
        if (existing == null) return NotFound();

        existing.Nama = murid.Nama;
        existing.NIS = murid.NIS;
        existing.Kelas = murid.Kelas;
        existing.Umur = murid.Umur;

        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var murid = _muridList.FirstOrDefault(m => m.Id == id);
        if (murid == null) return NotFound();

        return View(murid);
    }

    [HttpPost]
    public IActionResult DeleteConfirmed(int id)
    {
        var murid = _muridList.FirstOrDefault(m => m.Id == id);
        if (murid != null) _muridList.Remove(murid);

        return RedirectToAction("Index");
    }
}