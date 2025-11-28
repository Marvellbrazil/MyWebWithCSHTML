using Microsoft.AspNetCore.Mvc;
using MyWebWithCSHTML.Models;

namespace MyWebWithCSHTML.Controllers;

public class MahasiswaController : Controller
{
    private static List<Mahasiswa> _muridList = new List<Mahasiswa>
    {
        new Mahasiswa { Id = 1, Nama = "Akbar", NIS = "A1B1C1", Kelas = "3DKV", Umur = 19 },
        new Mahasiswa { Id = 2, Nama = "Faisal", NIS = "A2B2C1", Kelas = "2RPL", Umur = 17 },
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
    public IActionResult Create(Mahasiswa mahasiswa)
    {
        mahasiswa.Id = _muridList.Max(m => m.Id) + 1;
        _muridList.Add(mahasiswa);

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Edit(Mahasiswa mahasiswa)
    {
        var existing = _muridList.FirstOrDefault(m => m.Id == mahasiswa.Id);
        if (existing == null) return NotFound();

        existing.Nama = mahasiswa.Nama;
        existing.NIS = mahasiswa.NIS;
        existing.Kelas = mahasiswa.Kelas;
        existing.Umur = mahasiswa.Umur;

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