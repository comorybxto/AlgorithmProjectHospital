using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmProjectHospital.Structures;

namespace AlgorithmProjectHospital
{
    /// <summary>
    /// Represents a patient in the healthcare system, containing personal details such as ID, fullname, gender, birthdate, and medical examination history.
    /// Provides functionality to manage the patient's medical examinations and compare patients based on their ID.
    /// </summary>
    internal class Patient : IComparable<Patient>
    {
        public string Fullname { get; set; }
        public char Gender { get; set; }
        public string IDno { get; set; }
        public DateTime Bdate { get; set; }
        public DateTime LastExamination { get; set; }
        public string Diagnosis { get; set; }

        public Stack<Examination> ExaminationHistory { get; set; }

        /// <summary>
        /// Constructor to initialize a new patient with the given details.
        /// </summary>
        /// <param name="idno">The patient's unique ID number.</param>
        /// <param name="fullname">The patient's fullname.</param>
        /// <param name="gender">The patient's gender ('M' or 'F').</param>
        /// <param name="bdate">The patient's birthdate.</param>
        public Patient(string idno, string fullname, char gender , DateTime bdate)
        {
            (IDno, Fullname, Gender, Bdate) = (idno, fullname, gender, bdate);
            ExaminationHistory = new Stack<Examination>();
        }

        /// <summary>
        /// Default constructor to initialize an empty patient object.
        /// </summary>
        public Patient()
        {
            ExaminationHistory = new Stack<Examination>();
        }

        /// <summary>
        /// Adds a new examination to the patient's examination history.
        /// </summary>
        /// <param name="examination">An Examination object containing the examination details.</param>
        public void AddExaminationInfo(Examination examination)
        {
            LastExamination = examination.Date;
            Diagnosis = examination.Diagnosis;
            ExaminationHistory.Push(examination);
        }

        /// <summary>
        /// Adds a new examination to the patient's examination history.
        /// </summary>
        /// <param name="date">The date of the examination.</param>
        /// <param name="diagnosis">The diagnosis made during the examination.</param>
        /// <param name="treatment">The treatment prescribed during the examination.</param>
        public void AddExaminationInfo(DateTime date, string diagnosis, string treatment)
        {
            var examination = new Examination(date, diagnosis, treatment);
            AddExaminationInfo(examination); // Calls the other overloaded method with the Examination object
        }

        /// <summary>
        /// Compares two patients based on their ID number.
        /// </summary>
        /// <param name="other">The other patient to compare to.</param>
        /// <returns>An integer indicating whether this patient's ID is less than, equal to or greater than the other patient's ID.</returns>
        public int CompareTo(Patient other)
        {
            return this.IDno.CompareTo(other.IDno);
        }

        /// <summary>
        /// Initializes a new Patient with only the ID number, useful for searching by ID.
        /// </summary>
        /// <param name="id">The patient's ID number.</param>
        /// <returns>A new Patient object with the specified ID.</returns>
        public static Patient WithID(string id)
        {
            return new Patient { IDno = id };
        }

        public override string ToString()
        {
            var examInfo = LastExamination == default
                ? "Last Diagnosis: -"
                : $"Last Diagnosis ({LastExamination.ToString("yyyy.MM.dd"),-5}): {Diagnosis,-20}";

            return $"{IDno,-5} {Fullname,-30} {Gender,-2} {Bdate.ToString("yyyy.MM.dd"),-20} {examInfo}";
        }
    }
}
