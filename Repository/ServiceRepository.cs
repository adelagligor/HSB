using HairStyleBookingApp.Data;
using HairStyleBookingApp.Models.DBObjects;
using HairStyleBookingApp.Models;

namespace HairStyleBookingApp.Repository
{
    public class ServiceRepository
    {
        private readonly ApplicationDbContext _DBContext;
        public ServiceRepository()
        {
            _DBContext = new ApplicationDbContext();
        }

        public ServiceRepository(ApplicationDbContext dbContext)
        {
            _DBContext = dbContext;
        }

        private ServiceModel MapDBObjectToModel(Service dbobject)
        {
            var model = new ServiceModel();
            if (dbobject != null)
            {
                model.IdService = dbobject.IdService;
                model.ServiceName = dbobject.ServiceName;
                model.TimeInMinutes = dbobject.TimeInMinutes;
                model.Price = dbobject.Price;


            }
            return model;
        }
        private Service MapModelToDBObject(ServiceModel model)
        {
            var dbobject = new Service();
            if (model != null)
            {
                dbobject.IdService = model.IdService;
                dbobject.ServiceName = model.ServiceName;
                dbobject.TimeInMinutes = model.TimeInMinutes;
                dbobject.Price = model.Price;



            }
            return dbobject;
        }
        public List<ServiceModel> GetAllServices()
        {
            var list = new List<ServiceModel>();
            foreach (var dbobject in _DBContext.Services)
            {
                list.Add(MapDBObjectToModel(dbobject));
            }
            return list;
        }
        public ServiceModel GetServiceById(Guid id)
        {
            return MapDBObjectToModel(_DBContext.Services.FirstOrDefault(x => x.IdService == id));

        }

        public void InsertService(ServiceModel model)
        {
            model.IdService = Guid.NewGuid();
            _DBContext.Services.Add(MapModelToDBObject(model));
            _DBContext.SaveChanges();
        }

        public void UpdateService(ServiceModel model)
        {
            var dbobject = _DBContext.Services.FirstOrDefault(x => x.IdService == model.IdService);

            if (dbobject != null)
            {
                dbobject.IdService = model.IdService;
                dbobject.ServiceName = model.ServiceName;
                dbobject.TimeInMinutes = model.TimeInMinutes;
                dbobject.Price = model.Price;


                _DBContext.SaveChanges();
            }
        }
        public void DeleteService(Guid id)
        {
            var dbobject = _DBContext.Services.FirstOrDefault(x => x.IdService == id);
            if (dbobject != null)
            {
                _DBContext.Services.Remove(dbobject);
                _DBContext.SaveChanges();
            }
        }
    }
}
