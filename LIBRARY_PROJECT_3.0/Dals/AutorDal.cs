using LIBRARY_PROJECT_3._0.DalModels;
using LIBRARY_PROJECT_3._0.DalModels.AutorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARY_PROJECT_3._0.Dals
{
    internal class AutorDal
    {
        private LibraryDBEntities db = new LibraryDBEntities();

        public IList<AutorDalModel> getAuthorNameList =>
            db.Autors.Select(
                author => new AutorDalModel
                {
                    Autor = author.FirstName + " " + author.LastName
                }).ToList();

        public IList<AutorDalModelForSelector> getAuthorList =>
            db.Autors.Select(
                author => new AutorDalModelForSelector
                {
                    ID = author.ID,
                    Name = author.FirstName + " " + author.LastName
                }).ToList();

    }
}
