using Fachion.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fachion.Controllers
{
    public class CartController : Controller
    {
        IConfiguration configuration;
        CartCrud crud;
        ProductCrud procrud;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment env;
        public CartController(IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            this.configuration = configuration;
            crud = new CartCrud(this.configuration);
            procrud = new ProductCrud(this.configuration);
            this.env = env;
        }
        // GET: CartController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CartController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CartController/Create
        
        [HttpGet]
        
        public ActionResult AddCart( int id)
        {
            try
            {
                Cart c=new Cart();
                string CusId = HttpContext.Session.GetString("cus_id");
                c.CusId= Convert.ToInt32(id);
                c.Id=id;
                c.Qty = 1;
                int result= crud.AddToCart(c);
                if (result == 1)
                {
                    return RedirectToAction(nameof(ViewCart));
                }
                else 
                { 
                    return View();
                }
                
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }

        // GET: CartController/Edit/5
        public ActionResult ViewCart()
        {
            string CusId = HttpContext.Session.GetString("cus_id");
            var model=crud.ViewCart(Convert.ToInt32(CusId));
            return View(model);
        }

        
        // GET: CartController/Delete/5
        public ActionResult RemoveCart(int CartId)
        {
            try
            {
                var result = crud.DeleteCart(CartId);
                return RedirectToAction(nameof(ViewCart));
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
            
        }

        
    }
}
