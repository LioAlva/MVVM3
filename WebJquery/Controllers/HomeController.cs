using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebJquery.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult list()
        {
            var rows = new List<Producto>
            {
                new Producto{id="1",producto="Coca cola",Price=25.00m},
                new Producto{id="2",producto="Coca loca",Price=29.00m},
                new Producto{id="3",producto="Coca olaca",Price=28.00m},
                new Producto{id="4",producto="Coca lolca",Price=21.00m},
                new Producto{id="5",producto="Coca olalc",Price=20.00m},
                new Producto{id="6",producto="Coca colla",Price=20.00m},
                new Producto{id="7",producto="Coca locaa",Price=25.00m},
                new Producto{id="8",producto="Coca loaac",Price=28.00m},
                new Producto{id="9",producto="Coca calo",Price=28.00m},
                new Producto{id="10",producto="Coca ocla",Price=30.00m}
            };
            var response = new Response
            {
                count = rows.Count,
                success =false,
                 rows= rows
            };


            return Json(response, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult contacto(m model)
        {
            var msn = string.Format("{0} {1} {2}",model.nombre,model.correo,model.mensaje);
            return Json(msn, JsonRequestBehavior.AllowGet);
        }

        public JsonResult time()
        {
            var datetime =DateTime.Now;
            return Json(datetime.ToString(),JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult saluda(string nombrePost)
        {
            var saluda = "Hola";
            return Json(string.Format("{0} {1}",saluda, nombrePost), JsonRequestBehavior.AllowGet);
        }
        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

public class Response
{
    public bool success { get; set; }
    public int count{ get; set; }
    public object rows { get; set; }
}

public class m
{
    public string nombre { get; set; }
    public string correo { get; set; }
    public string mensaje { get; set; }
}

public class Stock
{
    public List<Producto> productos  { get; set; }
    public Stock()
    {
        productos = new List<Producto>();
    }
}

public  class Producto
{
    public string id { get; set; }
    public string producto { get; set; }
    public decimal Price { get; set; }
}