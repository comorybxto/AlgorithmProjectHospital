using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmProjectHospital
{
    internal class Examination
    {
        public DateTime Date { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }

        public Examination(DateTime date, string diagnosis, string treatment)
        {
            Date = date;
            Diagnosis = diagnosis;
            Treatment = treatment;
        }

        public override string ToString()
        {
            return $"{Date.ToString("(yyyy.MM.dd)"),-15} {Diagnosis,-30} {Treatment,-30}";
        }
    }
}
