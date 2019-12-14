using AutoMapper;
using DateAccessLayer;
using Domain;
using MVCPresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPresentationLayer.Controllers
{
    public class ClienteController : Controller
    {
        //ModelBiding
        //defaultmodelbinder
        // GET: Cliente
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Crete(ClienteViewModel viewModel)
        {
            using (ComercialDataContext ctx = new ComercialDataContext())
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<ClienteViewModel, Cliente>());
                IMapper mapper = config.CreateMapper();
                Cliente cliente = mapper.Map<Cliente>(viewModel);
                ctx.Clientes.Add(cliente);
                ctx.SaveChanges();
            }
                return RedirectToAction("Index");
        }

        //meusite.com/Cliente
        //meusite.com/Cliente/Index
        [HttpGet]
        public ActionResult Index()
        {
            using (ComercialDataContext data = new ComercialDataContext())
            {
                List<Cliente> Clientes =  data.Clientes.AsNoTracking().ToList();
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Cliente, ClienteViewModel>());
                IMapper mapper = config.CreateMapper();
                List<ClienteViewModel> result  = mapper.Map<List<ClienteViewModel>>(Clientes);
                return View(result);
            }            
        }
    }
}