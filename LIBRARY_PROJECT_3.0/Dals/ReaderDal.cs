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

        internal void Add(string firstname, string lastname, string pesel, string email, string phone)
        {
            var newReader = new Reader()
            {
                FirstName = firstname,
                LastName = lastname,
                PESEL = pesel,
                Email = email,
                Phone = phone
            };

            db.Readers.Add(newReader);
            db.SaveChanges();
        }

        internal void Update(string email, string firstname, string lastname, string pesel, string emailUpdate, string phone)
        {
            var readerToUpdate = db.Readers
                .Where(read => read.Email == email)
                .Select(read => read)
                .Single();

            if (readerToUpdate != null)
            {
                readerToUpdate.FirstName = firstname;
                readerToUpdate.LastName = lastname;
                readerToUpdate.PESEL = pesel;
                readerToUpdate.Email = emailUpdate;
                readerToUpdate.Phone = phone;
            }
            db.SaveChanges();
        }

        internal void Delete(string email)
        {
            var readerToDelete =
                db.Readers
                .Where(pub => pub.Email == email)
                .Select(pub => pub)
                .Single();
            
            db.Readers.Remove(readerToDelete);
            db.SaveChanges();
        }
    }

}
