using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index()
        {
            var values = blogManager.GetBlogListWithCategory();
            return View(values);
        }
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = blogManager.GetBlogById(id);
            return View(values);
        }
        public IActionResult BlogListByWriter()
        {
            var values = blogManager.GetListWithCategoryByWriterBm(1);
            return View(values);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            List<SelectListItem> categoryValues = (from x in categoryManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {

            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(p);
            if (results.IsValid)
            {
                p.BlogStatus = true;
                p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterId = 1;
                blogManager.TAdd(p);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else if (!results.IsValid)
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            else
            {
                ModelState.AddModelError("WriterPassword", "Girdiğiniz Şifreler Eşleşmedi Lütfen Tekrar Deneyin");
            }
            return View();
        }
        public IActionResult DeleteBlog(int id)
        {
            var blogValue = blogManager.TGetById(id);
            blogManager.TDelete(blogValue);
            return RedirectToAction("BlogListByWriter");
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogValue = blogManager.TGetById(id);
            List<SelectListItem> categoryValues = (from x in categoryManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            return View(blogValue);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
            p.WriterId = 1;
            p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.BlogStatus = true;
            blogManager.TUpdate(p);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
