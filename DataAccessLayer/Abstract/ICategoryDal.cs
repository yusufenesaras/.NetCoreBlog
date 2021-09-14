using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICategoryDal
    {
        List<Category> ListAllCategory();
        void AddCategory(Category category);
        void DeleteCategort(Category category);
        void UpdateCategort(Category category);
        Category GetById(int id);

    }
}
