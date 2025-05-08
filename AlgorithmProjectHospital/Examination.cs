using System;

namespace AlgorithmProjectHospital
{
    internal class Examination
    {
        public DateTime Date { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }

        /// <summary>  
        /// Initializes a new instance of the <see cref="Examination"/> class with the specified date, diagnosis, and treatment.  
        /// </summary>  
        /// <param name="date">The date of the examination.</param>  
        /// <param name="diagnosis">The diagnosis made during the examination.</param>  
        /// <param name="treatment">The treatment prescribed during the examination.</param>  
        public Examination(DateTime date, string diagnosis, string treatment)
        {
            Date = date;
            Diagnosis = diagnosis;
            Treatment = treatment;
        }

        public bool Equals(Examination examination)
        {
            if (examination is Examination other)
            {
                return this.Date == other.Date &&
                    this.Diagnosis == other.Diagnosis &&
                    this.Treatment == other.Treatment;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{Date.ToString("(yyyy.MM.dd)"),-15} {Diagnosis,-30} {Treatment,-30}";
        }
    }
}
