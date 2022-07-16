using LIBRARY_PROJECT_3._0.DalModels.CategoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARY_PROJECT_3._0.Dals
{
    internal class CategoryDal
    {
        private LibraryDBEntities db = new LibraryDBEntities();
        public IList<CategoryDalModelForSelector> getCategoryList =>
            db.Categories.Select
            (
                category => new CategoryDalModelForSelector
                {
                    ID = category.ID,
                    Name = category.Categorie,
                }).ToList();

    }
}
