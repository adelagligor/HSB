using HairStyleBookingApp.Models;
using HairStyleBookingApp.Repository;

namespace HairStyleBookingApp.ViewModels
{
    public class AppointmentViewModel
    {
        public List<ClientModel> Clients { get; set; }
        public List<ServiceModel> Services { get; set; } 
        public List<EmployeeModel> Employees { get; set; }


        public Guid IdAppointment { get; set; }
        public Guid IdClient { get; set; }
        public Guid IdService { get; set; }
        public Guid IdEmployee { get; set; }
        public DateTime StartsAt { get; set; }
        public DateTime EndsAt { get; set; }
        public string ClientName { get; set; }
        public string ServiceName { get; set; } 
        public string EmployeeName { get; set; }    

        //public AppointmentViewModel( AppointmentModel model, ClientRepository clientRepository,
        //    ServiceRepository serviceRepository, EmployeeRepository employeeRepository )
        //{
        //    IdAppointment = model.IdAppointment;
        //    IdClient = model.IdClient;
        //    IdService = model.IdService;
        //    IdEmployee = model.IdEmployee;
        //    StartsAt= model.StartsAt;
        //    EndsAt= model.EndsAt;
        //    var client=clientRepository.GetClientById(model.IdClient);
        //    ClientName= client.Name;  
        //    var service=serviceRepository.GetServiceById(model.IdService);
        //    ServiceName= service.ServiceName;
        //    var employee= employeeRepository.GetEmployeeById(model.IdEmployee);
        //    EmployeeName= employee.Name;


        //}
        public AppointmentViewModel(AppointmentModel model, ClientRepository clientRepository,
                                    ServiceRepository serviceRepository,
                                    EmployeeRepository employeeRepository)
        {
            this.IdAppointment = model.IdAppointment;
            this.IdClient = model.IdClient;
            this.IdService = model.IdService;
            this.IdEmployee = model.IdEmployee;
            this.StartsAt= model.StartsAt;
            this.EndsAt= model.EndsAt;
            ClientName = clientRepository.GetClientById(model.IdClient).Name;
            ServiceName= serviceRepository.GetServiceById(model.IdService).ServiceName;
            EmployeeName = employeeRepository.GetEmployeeById(model.IdEmployee).Name;

            this.Clients = clientRepository.GetAllClients();
            this.Services = serviceRepository.GetAllServices(); 
            this.Employees = employeeRepository.GetAllEmployees();
        }
    }
}
