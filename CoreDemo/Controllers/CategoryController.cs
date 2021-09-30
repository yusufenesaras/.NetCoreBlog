using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        //private readonly ICategoryService _categoryService;
        //public CategoryController(ICategoryService categoryService)
        //{
        //    _categoryService = categoryService;
        //}

        public IActionResult Index()
        {
            var values = categoryManager.GetList();
            return View(values);
        }
    }
}
