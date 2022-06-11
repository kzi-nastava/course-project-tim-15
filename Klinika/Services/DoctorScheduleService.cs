using Klinika.Models;
using Klinika.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.Repositories;
using Klinika.Roles;

namespace Klinika.Services
{
    public class DoctorScheduleService
    {
        private readonly IVacationRequestRepo vacationRequestRepo;
        private readonly IScheduledAppointmentsRepo appointmentsRepo;
        public DoctorScheduleService(IVacationRequestRepo vacationRequestRepo, IScheduledAppointmentsRepo appointmentsRepo)
        {
            this.vacationRequestRepo = vacationRequestRepo;
            this.appointmentsRepo = appointmentsRepo;
        }
        public bool IsOccupied(int doctorID, TimeSlot timeSlot, DateTime day)
        {
            DateTime start = new DateTime(day.Year, day.Month, day.Day, timeSlot.from.Hour, timeSlot.from.Minute, timeSlot.from.Second);
            DateTime end = new DateTime(day.Year, day.Month, day.Day, timeSlot.to.Hour, timeSlot.to.Minute, timeSlot.to.Second);
            return IsOccupied(doctorID, new TimeSlot(start, end));
        }
        public bool IsOccupied(DateTime start, int doctorID, int duration = 15, int forAppointmentID = -1)
        {
            return IsOccupied(doctorID, new TimeSlot(start, duration), forAppointmentID);
        }
        public bool IsOccupied(int doctorID, TimeSlot slot, int forAppointmentID = -1)
        {
            List<Appointment> forSelectedTimeSpan = appointmentsRepo.GetAll().Where(
                x => x.doctorID == doctorID && slot.DoesOverlap(new TimeSlot(x.dateTime, x.duration)) && !x.isDeleted && x.id != forAppointmentID).ToList();
            bool onVacation = IsOnVacation(slot.from, doctorID);
            if (forSelectedTimeSpan.Count == 0) return false || onVacation;
            return true;
        }
        private bool IsOnVacation(DateTime start, int doctorID)
        {
            List<VacationRequest> forSelectedTimeSpan = vacationRequestRepo.GetAll(doctorID).Where(
                x => x.fromDate < start && x.toDate > start && x.status != (char)VacationRequest.Statuses.DENIED).ToList();
            
            if (forSelectedTimeSpan.Count == 0) return false;
            return true;
        }
        public List<Appointment> GetAppointments(DateTime date, int doctorID, int days = 1) 
            => appointmentsRepo.GetAll(date.ToString("yyyy-MM-dd"), doctorID, User.RoleType.DOCTOR, days);
    }
}
