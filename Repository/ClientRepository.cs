using HairStyleBookingApp.Data;
using HairStyleBookingApp.Models;
using HairStyleBookingApp.Models.DBObjects;
using System.Diagnostics.Metrics;

namespace HairStyleBookingApp.Repository
{
    public class ClientRepository
    {
        private readonly ApplicationDbContext _DBContext;
        public ClientRepository()
        {
            _DBContext = new ApplicationDbContext();
        }

        public ClientRepository(ApplicationDbContext dbContext)
        {
            _DBContext = dbContext;
        }

        private ClientModel MapDBObjectToModel(Client dbobject)
        {
            var model = new ClientModel();
            if (dbobject != null)
            {
                model.IdClient = dbobject.IdClient;
                model.Name = dbobject.Name;
                model.Phone = dbobject.Phone;
                model.Email = dbobject.Email;
                model.Notes = dbobject.Notes;
               
            }
            return model;
        }
        private Client MapModelToDBObject(ClientModel model)
        {
            var dbobject = new Client();
            if (model != null)
            {
                dbobject.IdClient = model.IdClient;
                dbobject.Name = model.Name;
                dbobject.Phone = model.Phone;
                dbobject.Email = model.Email;
                dbobject.Notes = model.Notes;
                

            }
            return dbobject;
        }
        public List<ClientModel> GetAllClients()
        {
            var list = new List<ClientModel>();
            foreach (var dbobject in _DBContext.Clients)
            {
                list.Add(MapDBObjectToModel(dbobject));
            }
            return list;
        }
        public ClientModel GetClientById(Guid id)
        {
            return MapDBObjectToModel(_DBContext.Clients.FirstOrDefault(x => x.IdClient == id));

        }

        public void InsertClient(ClientModel model)
        {
            model.IdClient = Guid.NewGuid();
            _DBContext.Clients.Add(MapModelToDBObject(model));
            _DBContext.SaveChanges();
        }

        public void UpdateClient(ClientModel model)
        {
            var dbobject = _DBContext.Clients.FirstOrDefault(x => x.IdClient == model.IdClient);

            if (dbobject != null)
            {
                dbobject.IdClient = model.IdClient;
                dbobject.Name = model.Name;
                dbobject.Phone = model.Phone;
                dbobject.Email = model.Email;
                dbobject.Notes = model.Notes;
                
                _DBContext.SaveChanges();
            }
        }
        public void DeleteClient(Guid id)
        {
            var dbobject = _DBContext.Clients.FirstOrDefault(x => x.IdClient == id);
            if (dbobject != null)
            {
                _DBContext.Clients.Remove(dbobject);
                _DBContext.SaveChanges();
            }

        }
    }
}
