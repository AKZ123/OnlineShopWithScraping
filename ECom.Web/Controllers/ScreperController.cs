using ECom.Entities;
using ECom.Services;
using ECom.Web.ScreperRepository;
using ECom.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECom.Web.Controllers
{
    public class ScreperController : Controller
    {
        // GET: Screper
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult Add(int ProductID)
        {
            ScreperProductViewModel model = new ScreperProductViewModel();
            var product = ProductsService.Instance.GetOnlyProduct(ProductID);

            model.ProductID = product.ID;
            model.Name = product.Name;
            model.Description = product.Description;
            model.Price = product.Price;
            //model.CategoryID = product.Category != null ? product.Category.ID : 0;
            model.ImageURL = product.ImageURl;

           // model.AvailableCategories = CategoriesService.Instance.GetAllCategories();
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Add(ScreperProductViewModel model)
        {
            var NewScreper = new ScreperURL();
            NewScreper.Name = model.ScreperName;
            NewScreper.SUrl = model.ScreperURL;
            NewScreper.ProductID = model.ProductID;

            ScreperService.Instance.AddScreper(NewScreper);
            return RedirectToAction("ProductTable", "Product");
        }

        [HttpGet]
        public ActionResult Cmpr_Details(int ID)
        {
            ScreperProductCompareViewModel model = new ScreperProductCompareViewModel();

            model.Product = ProductsService.Instance.GetProduct(ID);
            model.AvailableScreperSiteNames = ScreperService.Instance.GetScreperNames(ID);
            //GetScreperName(0);
            if (model.Product == null) return HttpNotFound();

            return View(model);
        }

        public ActionResult ViewScreperProduct(int ScreperID)
        {
            Product1 otherProduct = new Product1();

            var ScreperUrlName= ScreperService.Instance.GetScreper(ScreperID);
            string NAME= ScreperUrlName.Name;
            string Url = ScreperUrlName.SUrl;

            ScreperProductRepository SPR = new ScreperProductRepository();
            SPR.GetScreperProduct(NAME, Url);

            otherProduct.ID = SPR.id;
            otherProduct.Name = SPR.name;
            otherProduct.Price = SPR.price;
            otherProduct.Description = SPR.description;
            otherProduct.ImageURl = SPR.imageURl;

            return PartialView(otherProduct);
        }
    }
}