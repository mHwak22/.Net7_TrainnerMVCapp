using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using trainnerMVCapp.Models;

using BOL;
using BLL;
using DAL;

namespace trainnerMVCapp.Controllers;

public class TrainerController : Controller
{
    private readonly ILogger<TrainerController> _logger;

    public TrainerController(ILogger<TrainerController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        Admin admin = new Admin();
        List<Trainer> trainers = admin.GetAllTrainers();
        this.ViewData["trainers"] = trainers;
        return View();

    }

    public IActionResult Reg()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Reg(Trainer trainer)
    {
        Admin tr = new Admin();
        if (tr.AddTrainer(trainer))
        {
            return RedirectToAction("Index");
        }
        return View();
    }

public IActionResult Remove()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Remove(int id)
    {

        Admin admin = new Admin();
       
            if (admin.DeleteTrainer(id))
            {
                return RedirectToAction("Index");
            }
      
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string Email, string Password)
    {

        Admin admin = new Admin();
        List<Trainer> trainers = admin.GetAllTrainers();
        foreach (Trainer trs in trainers)
        {
            if (trs.Email.Equals(Email) && trs.Password.Equals(Password))
            {
                return RedirectToAction("Index");
            }
        }
        return View();
    }

    
}
