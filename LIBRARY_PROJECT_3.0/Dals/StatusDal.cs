using LIBRARY_PROJECT_3._0.DalModels.StatusModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARY_PROJECT_3._0.Dals
{
    internal class StatusDal
    {
        private LibraryDBEntities db = new LibraryDBEntities();
        public IList<StatusDalModelForSelector> getStatusList =>
            db.Status.Select
            (
                status => new StatusDalModelForSelector
                {
                    ID = status.ID,
                    Name = status.Status1,
                }).ToList();
    }
}
