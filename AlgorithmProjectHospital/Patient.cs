using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmProjectHospital.Structures;

namespace AlgorithmProjectHospital
{
    internal class Patient : IComparable<Patient>
    {
        public string Fullname { get; set; }
        public char Gender { get; set; }
        public string IDno { get; set; }
        public DateTime Bdate { get; set; }
        public DateTime LastExamination { get; set; }
        public string Diagnosis { get; set; }

        public Stack<Examination> ExaminationHistory { get; set; }

        public Patient(string idno, string fullname, char gender , DateTime bdate) {
            (IDno, Fullname, Gender, Bdate) = (idno, fullname, gender, bdate);
            ExaminationHistory = new Stack<Examination>();
        }
        public Patient()
        {
            ExaminationHistory = new Stack<Examination>();
        }

        public void AddExaminationInfo(DateTime date, string diagnosis, string treatment)
        {
            var examination = new Examination(date, diagnosis, treatment);
            AddExaminationInfo(examination);
        }

        public void AddExaminationInfo(Examination examination)
        {
            LastExamination = examination.Date;
            Diagnosis = examination.Diagnosis;
            ExaminationHistory.Push(examination);
        }

        public override string ToString()
        {
            var examInfo = LastExamination == default
                ? "Last Diagnosis: -"
                : $"Last Diagnosis ({LastExamination.ToString("yyyy.MM.dd"),-5}): {Diagnosis,-20}";

            return $"{IDno,-5} {Fullname,-30} {Gender,-2} {Bdate.ToString("yyyy.MM.dd"),-20} {examInfo}";
        }

        public int CompareTo(Patient other)
        {
            return this.IDno.CompareTo(other.IDno);
        }

        public static Patient WithID(string id)
        {
            return new Patient { IDno = id };
        }
    }
}
