using System;
using System.Collections.Generic;

// Main Program
class Program
{
    static void Main(string[] args)
    {
        // Create hospital instance
        Hospital hospital = new Hospital();

        // Add patients
        Patient patient1 = new Patient(1, "Maria", 30 );
        Patient patient2 = new Patient(2, "Lima", 25);
        Patient patient3 = new Patient(2, "Anika", 32);
        hospital.AddPatient(patient1);
        hospital.AddPatient(patient2);
        hospital.AddPatient(patient3);

        // Add doctors
        Doctor doctor1 = new Doctor(101, "Udoy", 35, "Cardiology");
        Doctor doctor2 = new Doctor(102, "Akaied", 45, "Orthopedics");
        hospital.AddDoctor(doctor1);
        hospital.AddDoctor(doctor2);

        // Add staff
        Staff staff1 = new Staff(1, "Atif", 39, "Ward Boy");
        Staff staff2 = new Staff(2, "Harun", 35, "Security Guard");
        hospital.AddStaff(staff1);
        hospital.AddStaff(staff2);

        // Schedule appointments
        Appointment appointment1 = new Appointment(1001, patient1, doctor1, staff1, DateTime.Now.AddDays(1));
        Appointment appointment2 = new Appointment(1002, patient2, doctor2, staff2, DateTime.Now.AddDays(2));
        hospital.ScheduleAppointment(appointment1);
        hospital.ScheduleAppointment(appointment2);

        // Display data
        hospital.DisplayPatients();
        Console.WriteLine("\n");
        hospital.DisplayDoctors();
        Console.WriteLine("\n");
        hospital.DisplayStaffs();
        Console.WriteLine("\n");
        hospital.DisplayAllAppointments();

        // Calculate bill
        double bill = Billing.CalculateBill(1500, 700);
        Console.WriteLine($"Total Bill: {bill}");
    }
}

// Abstract class for Person
public abstract class Person
{
    public string Name ;
    public int Age ;

    protected Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public abstract void DisplayInfo();
}

// Patient class
public class Patient : Person
{
    public int PatientID ;
   
    public Patient(int patientId, string name, int age) : base(name, age)
    {
        PatientID = patientId;
        
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"PatientID: {PatientID}, Name: {Name}, Age: {Age}");
    }
}

// Doctor class
public class Doctor : Person
{
    public int DoctorID ;
    public string Specialisation ;

    public Doctor(int doctorId, string name, int age, string specialisation) : base(name, age)
    {
        DoctorID = doctorId;
        Specialisation = specialisation;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"DoctorID: {DoctorID}, Name: {Name}, Age: {Age}, Specialisation: {Specialisation}");
    }
}

// Staff class
public class Staff : Person
{
    public int StaffID ;
    public string Role ;

    public Staff(int staffId, string name, int age, string role) : base(name, age)
    {
        StaffID = staffId;
        Role = role;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"StaffID: {StaffID}, Name: {Name}, Age: {Age}, Role: {Role}");
    }
}

// Appointment class
public class Appointment
{
    public int AppointmentID ;
    public Patient Patient ;
    public Doctor Doctor ;
    public Staff Staff ;
    public DateTime Date ;

    public Appointment(int appointmentId, Patient patient, Doctor doctor, Staff staff, DateTime date)
    {
        AppointmentID = appointmentId;
        Patient = patient;
        Doctor = doctor;
        Staff = staff;
        Date = date;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"AppointmentID: {AppointmentID}, Patient: {Patient.Name}, Doctor: {Doctor.Name}, Staff: {Staff.Name}, Date: {Date}");
    }
}

// Billing System
public class Billing
{
    public static double CalculateBill(double consultationFee, double serviceCharge)
    {
        return consultationFee + serviceCharge;
    }
}

// Hospital class
public class Hospital
{
    private List<Patient> patients = new List<Patient>();
    private List<Doctor> doctors = new List<Doctor>();
    private List<Staff> staffs = new List<Staff>();
    private List<Appointment> appointments = new List<Appointment>();

    public void AddPatient(Patient patient) => patients.Add(patient);

    public void AddDoctor(Doctor doctor) => doctors.Add(doctor);

    public void AddStaff(Staff staff) => staffs.Add(staff);

    public void ScheduleAppointment(Appointment appointment) => appointments.Add(appointment);

    public void DisplayAllAppointments()
    {
        Console.WriteLine("Appointments:");
        foreach (var appointment in appointments)
            appointment.DisplayInfo();
    }

    public void DisplayPatients()
    {
        Console.WriteLine("Patients:");
        foreach (var patient in patients)
            patient.DisplayInfo();
    }

    public void DisplayStaffs()
    {
        Console.WriteLine("Staffs:");
        foreach (var staff in staffs)
            staff.DisplayInfo();
    }

    public void DisplayDoctors()
    {
        Console.WriteLine("Doctors:");
        foreach (var doctor in doctors)
            doctor.DisplayInfo();
    }
}
