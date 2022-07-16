using LIBRARY_PROJECT_3._0.DalModels.ReaderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARY_PROJECT_3._0.Dals
{
    internal class ReaderDal
    {
        private LibraryDBEntities db = new LibraryDBEntities();
        public IList<ReaderDalModel> getReaderList =>
            db.Readers.Select(
                reader => new ReaderDalModel
                {
                    FirstName = reader.FirstName,
                    LastName = reader.LastName,
                    PESEL = reader.PESEL,
                    Email = reader.Email,
                    Phone = reader.Phone,
                }).ToList();
    }
}
