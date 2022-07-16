using LIBRARY_PROJECT_3._0.DalModels.PublisherModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARY_PROJECT_3._0.Dals
{
    internal class PublisherDal
    {
        private LibraryDBEntities db = new LibraryDBEntities();
        public IList<PublisherDalModel> GetPublisherList =>
            db.Publishers.Select(
                publisher => new PublisherDalModel
                {
                    Name = publisher.Name,
                    City = publisher.City,
                    Street = publisher.Street,
                    BuildingNum = publisher.BuildingNum,
                    Postcode = publisher.Postcode,
                }).ToList();
        public IList<PublisherDalModelForSelector> GetPublisherForSelectorList =>
            db.Publishers.Select(
                publisher => new PublisherDalModelForSelector
                {
                    ID = publisher.ID,
                    Name = publisher.Name,                    
                }).ToList();
    }
}
