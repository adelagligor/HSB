using HairStyleBookingApp.Data;
using HairStyleBookingApp.Models;
using HairStyleBookingApp.Models.DBObjects;

namespace HairStyleBookingApp.Repository
{
    public class AppointmentRepository
    {
        private readonly ApplicationDbContext _DBContext;   //in Data am ApplicationDbContext care a fost generat la Scaffold(crrez o instanta 
        //din clasa respectiva; folosim _DBContext sa comunicam cu baza de date
        public AppointmentRepository()  //in constuctor aloc o valoare pentru variabila _DBContext
        {
            _DBContext = new ApplicationDbContext();
        }

        public AppointmentRepository(ApplicationDbContext dbContext)   // primeste dbContext din afara lui in momentul in care este contruit obiectul
        {
            _DBContext = dbContext;
        }

        private AppointmentModel MapDBObjectToModel(Appointment dbobject)
        {
            var model = new AppointmentModel();
            if (dbobject != null)
            {
                model.IdAppointment = dbobject.IdAppointment;
                model.IdClient = dbobject.IdClient;
                model.IdService = dbobject.IdService;
                model.IdEmployee = dbobject.IdEmployee;
                model.StartsAt = dbobject.StartsAt;
                model.EndsAt = dbobject.EndsAt;

            }
            return model;
        }
        private Appointment MapModelToDBObject(AppointmentModel model)
        {
            var dbobject = new Appointment();
            if (model != null)
            {
                dbobject.IdAppointment = model.IdAppointment;
                dbobject.IdClient = model.IdClient;
                dbobject.IdService = model.IdService;
                dbobject.IdEmployee = model.IdEmployee;
                dbobject.StartsAt = model.StartsAt;
                dbobject.EndsAt = model.EndsAt;


            }
            return dbobject;
        }
        public List<AppointmentModel> GetAllAppointments()
        {
            var list = new List<AppointmentModel>();
            foreach (var dbobject in _DBContext.Appointments)   //citim din _DBContext lista de Announcements; itereaza peste toate dbobjects care sunt in Appointments
            {
                list.Add(MapDBObjectToModel(dbobject)); //avem dbobjects, pe care le convertim in Modele iar apoi le punem in lista
            }
            return list;
        }
        public AppointmentModel GetAppointmentById(Guid id)
        {
            return MapDBObjectToModel(_DBContext.Appointments.FirstOrDefault(x => x.IdAppointment == id));
            //pe colectia Appointments aplic LambdaExpression FirstorDefault(nu pun datatype pentru ca o sa-l deduca implicit) si expresia
            //Lambda expressionul cauta in toata lista de Appointments pana cand gaseste dbobject care are proprietarea de Idannouncement egala cu id-ul pe care l-am dat ca parametru
            //returneaza dbobjectul respectiv sau default care e nul si-l da la MapDBObjectToModel care il mapeaza si il converteste in model si merge la return si astfel functia returneaza modelul
        }

        public void InsertAppointment(AppointmentModel model) // vine din View
        {
            model.IdAppointment = Guid.NewGuid();// trebuie sa-i dam un ID nou, vine de pe view si nu are id
            _DBContext.Appointments.Add(MapModelToDBObject(model));
            _DBContext.SaveChanges();
        }

        public void UpdateAppointment(AppointmentModel model)
        {
            var dbobject = _DBContext.Appointments.FirstOrDefault(x => x.IdAppointment == model.IdAppointment);
            //pe _DBContext pe colectia de Appointments folosesc Lambda 
            if (dbobject != null)
            {
                dbobject.IdAppointment = model.IdAppointment;
                dbobject.IdClient = model.IdClient;
                dbobject.IdService = model.IdService;
                dbobject.IdEmployee = model.IdEmployee;
                dbobject.StartsAt = model.StartsAt;
                dbobject.EndsAt = model.EndsAt;

                _DBContext.SaveChanges();
            }
        }
        public void DeleteAppointment(Guid id)
        {
            var dbobject = _DBContext.Appointments.FirstOrDefault(x => x.IdAppointment == id);
            if (dbobject != null)
            {
                _DBContext.Appointments.Remove(dbobject);
                _DBContext.SaveChanges();
            }
        }
    }
}
