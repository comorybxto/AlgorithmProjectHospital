using AlgorithmProjectHospital.Structures;
using AlgorithmProjectHospital.Structures.BST;
using System;
using System.CodeDom;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmProjectHospital
{
    internal class Program
    {
        static SinglyLinkedList<Patient> patientList;
        static Queue<Patient> emergencyQueue;
        static BinarySearchTree<Patient> patientBST;

        static void Main(string[] args)
        {
            InitializePatients();


            while (true) // Menu loop
            {
                Asterisk();
                Title("    Main Menu    ");
                Console.WriteLine("1) Patient Registration");
                Console.WriteLine("2) Emergency Patient Registration");
                Console.WriteLine("3) Examination History");
                Console.WriteLine("4) Search by ID");
                Console.WriteLine("5) Exit");
                Asterisk();

                Console.Write("Select an option: ");
                string input = Console.ReadLine();
                Console.Clear();

                switch (input)
                {
                    case "1":
                        PatientRegistrationMenu();
                        break;
                    case "2":
                        EmergencyRegistrationMenu();
                        break;
                    case "3":
                        ExaminationHistory();
                        break;
                    case "4":
                        SearchMenu();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid selection. Try again.");
                        break;
                }
            }
        }

        static void InitializePatients()
        {
            Patient patient0 = new Patient("58019273645", "Selin Yalçın", 'F', new DateTime(1995, 12, 19));
            patient0.AddExaminationInfo(new DateTime(2024, 4, 24), "Status asthmaticus", "Nebulized bronchodilators, Corticosteroids, Oxygen\r\n\r\n");

            //Showcasing a different way of creating patients
            // Create an array of patients and assigning examination information to them
            Patient[] patientArray = [
            new Patient("47380219560", "Hüseyin Demirbaş", 'M', new DateTime(2001, 1, 16)),
            new Patient("10384592746", "Emre Bakır", 'M', new DateTime(2002, 6, 23)),
            new Patient("28471956308", "Ali Yılmaz", 'M', new DateTime(1998, 11, 5)),
            new Patient("50918236475", "Ayşe Demir", 'F', new DateTime(1995, 2, 17)),
            new Patient("98765432100", "Mert Şahin", 'M', new DateTime(2000, 3, 14)),
            new Patient("45612378901", "Elif Kaya", 'F', new DateTime(2003, 9, 8)),
            new Patient("19834567213", "Can Aksoy", 'M', new DateTime(1999, 4, 12)),
            new Patient("34598762145", "Zeynep Kurt", 'F', new DateTime(1997, 7, 1)),
            new Patient("75892134678", "Emre Toprak", 'M', new DateTime(2004, 10, 25)),
            new Patient("62489735129", "Buse Arslan", 'F', new DateTime(2005, 12, 3)),
            new Patient("81264357931", "Nazlı Öztürk", 'F', new DateTime(1994, 1, 9)),
            new Patient("21938475602", "Kerem Aydın", 'M', new DateTime(1996, 6, 15)),
            new Patient("39418276504", "Tolga Çelik", 'M', new DateTime(2001, 8, 30)),
            new Patient("38572019483", "Burak Koç", 'M', new DateTime(1990, 11, 11)),
            new Patient("76430192875", "Seda Polat", 'F', new DateTime(2000, 2, 6)),
            new Patient("14725836985", "Melis Güneş", 'F', new DateTime(1993, 5, 22)),
            new Patient("83920174562", "Onur Bilgin", 'M', new DateTime(1992, 9, 18)),
            ];

            patientArray[0].AddExaminationInfo(new DateTime(2022, 11, 1), "Diabetes", "Insulin therapy");
            patientArray[0].AddExaminationInfo(new DateTime(2024, 4, 23), "Diarrhea", "Probiotics");
            patientArray[1].AddExaminationInfo(new DateTime(2025, 1, 6), "Headache", "Arveles");
            patientArray[2].AddExaminationInfo(new DateTime(2023, 10, 12), "Asthma", "Ventolin");
            patientArray[4].AddExaminationInfo(new DateTime(2021, 9, 8), "Hypertension", "Lifestyle change");
            patientArray[5].AddExaminationInfo(new DateTime(2021, 10, 11), "High cholesterol", "Diet");
            patientArray[5].AddExaminationInfo(new DateTime(2024, 3, 14), "Migraine", "Parol");
            patientArray[6].AddExaminationInfo(new DateTime(2020, 6, 23), "Anemia", "Iron supplements");
            patientArray[7].AddExaminationInfo(new DateTime(2023, 7, 7), "Acute myocardial infarction", "Immediate PCI (angioplasty), Aspirin, Nitroglycerin");
            patientArray[8].AddExaminationInfo(new DateTime(2022, 5, 19), "Back pain", "Physical therapy");
            patientArray[9].AddExaminationInfo(new DateTime(2024, 1, 1), "Ischemic stroke", "IV thrombolysis (tPA), CT scan, ICU observation");
            patientArray[10].AddExaminationInfo(new DateTime(2023, 12, 20), "Allergy", "Antihistamines");
            patientArray[11].AddExaminationInfo(new DateTime(2022, 9, 9), "Tonsillitis", "Antibiotics");
            patientArray[11].AddExaminationInfo(new DateTime(2023, 2, 17), "Traumatic brain injury (TBI)", "CT scan, Neurosurgical consult, Monitoring in ICU");
            patientArray[13].AddExaminationInfo(new DateTime(2024, 4, 10), "Sprain", "Cold compress");
            patientArray[14].AddExaminationInfo(new DateTime(2023, 8, 28), "Flu", "Rest and fluids");
            patientArray[16].AddExaminationInfo(new DateTime(2022, 1, 7), "Ear infection", "Ototopical drops");
            patientArray[16].AddExaminationInfo(new DateTime(2022, 3, 30), "Cough", "Expectorant");
            patientArray[16].AddExaminationInfo(new DateTime(2025, 4, 15), "GERD", "Antacids");

            // Send the array over to a SinglyLinkedList
            patientList = new SinglyLinkedList<Patient>(patientArray);
            patientList.AddLast(patient0);

            // Fill Emergency Queue
            emergencyQueue = new Queue<Patient>();
            emergencyQueue.Enqueue(patient0);
            emergencyQueue.Enqueue(patientArray[7]);
            emergencyQueue.Enqueue(patientArray[9]);
            emergencyQueue.Enqueue(patientArray[11]);

            InitializeBST();
        }

        static void InitializeBST()
        {

            // Fill Binary Search Tree
            patientBST = new BinarySearchTree<Patient>();

            foreach (var patient in patientList)
                patientBST.Insert(patient);
        }

        static void PatientRegistrationMenu()
        {
            Asterisk();
            Title("Patient Registration Menu");
            Console.WriteLine("1) Add First");
            Console.WriteLine("2) Add Last");
            Console.WriteLine("3) Add Before (by ID)");
            Console.WriteLine("4) Add After (by ID)");
            Console.WriteLine("5) Remove (by ID)");
            Console.WriteLine("6) Clear All");
            Console.WriteLine("7) Show All Patients");
            Asterisk();

            Console.Write("Select an option: ");
            string input = Console.ReadLine();

            Console.Clear();

            switch (input)
            {
                case "1":
                    Console.WriteLine("Add a patient to the beginning.");
                    patientList.AddFirst(InputNewPatient());
                    break;
                case "2":
                    Console.WriteLine("Add a patient to the end.");
                    patientList.AddLast(InputNewPatient());
                    break;
                case "3":
                    Console.Write("Enter reference ID to insert before: ");
                    string referenceID = Console.ReadLine();

                    var current = patientList.Head;
                    while (current != null && current.Value.IDno != referenceID)
                        current = current.Next;

                    if (current != null)
                        patientList.AddBefore(current, InputNewPatient());

                    else Console.WriteLine("Patient not found.");
                    break;

                case "4":
                    Console.Write("Enter reference ID to insert after: ");
                    referenceID = Console.ReadLine();
                    current = patientList.Head;
                    while (current != null && current.Value.IDno != referenceID)
                        current = current.Next;

                    if (current != null)
                        patientList.AddAfter(current, InputNewPatient());
                    else Console.WriteLine("Patient not found.");
                    break;
                case "5":
                    Console.Write("Enter ID to delete: ");
                    string idToDelete = Console.ReadLine();
                    bool deleted = patientList.RemoveByID(idToDelete);
                    Console.WriteLine(deleted ? "Patient removed." : "Patient not found.");
                    break;
                case "6":
                    patientList.Clear();
                    emergencyQueue.Clear();
                    Console.WriteLine("All patients have been cleared.");
                    break;
                case "7":
                    Title("Patient List");
                    if (patientList.Head == null)
                    {
                        Console.WriteLine("Patient List is empty.");
                        break;
                    }
                    foreach (var p in patientList)
                        Console.WriteLine(p);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

        }

        static void EmergencyRegistrationMenu()
        {
            Asterisk();
            Title("Emergency Patient Queue");
            Console.WriteLine("1) Register a new emergency patient");
            Console.WriteLine("2) Show current emergency patients");
            Console.WriteLine("3) Return to main menu");
            Asterisk();

            Console.Write("\nSelect an option: ");
            string input = Console.ReadLine();

            Console.WriteLine();

            switch (input)
            {
                case "1":
                    AddEmergencyPatient();
                    Console.WriteLine("New emergency patient registered successfully.");
                    break;

                case "2":
                    if (emergencyQueue.IsEmpty())
                        Console.WriteLine("No emergency patients.");
                    else
                    {
                        var cloneQueue = emergencyQueue.Clone();
                        while (!cloneQueue.IsEmpty())
                            Console.WriteLine(cloneQueue.Dequeue());
                    }
                    break;
                case "3":
                    Console.Clear();
                    break;

                default:
                    Console.WriteLine("Invalid selection. Try again.");
                    break;
            }
        }

        static void ExaminationHistory()
        {
            Title("Examination History");
            foreach (var patient in patientList)
            {
                if (patient.ExaminationHistory.IsEmpty())
                    continue;
                Console.WriteLine($"{patient.IDno,-5} {patient.Fullname,-15}");
                var clone = patient.ExaminationHistory.Clone();
                foreach (var info in clone)
                    Console.WriteLine($">> {clone.Pop()}");
                Console.WriteLine();
            }
            Console.Write("Press any key to return to the menu. ");
            Console.ReadKey();
            Console.Clear();
        }

        static void SearchMenu()
        {


            if (patientList.Head == null)
            {
                Console.WriteLine("\nCannot search: Patient List is empty.\n\n");
                return;
            }
            InitializeBST();

            Title("Patient Search Menu");

            Console.Write("\nEnter Patient ID to search (11 digits): ");
            string id = Console.ReadLine();
            if (patientBST.TryFind(Patient.WithID(id), out Patient found))
                Console.WriteLine("\n" + found);
            else
            {
                Console.Write("Patient not found. Press C to continue searching. ");
                if (Console.ReadKey().Key == ConsoleKey.C)
                    SearchMenu(); 
                Console.Clear();
            }
        }

        public static Patient InputNewPatient()
        {
            string id;
            do
            {
                Console.Write("Enter Patient ID (11 digits): ");
                id = Console.ReadLine();
                if (id.Length != 11 || !id.All(char.IsDigit))
                    Console.WriteLine("Invalid input. Please enter a valid ID.");

                if (patientList.Any(patient => patient.IDno == id)) {
                    Console.WriteLine("A patient already exists with this ID. Please enter a different ID.");
                    continue;
                }

            } while (id.Length != 11 || !id.All(char.IsDigit));

            Console.Write("Enter Patient Fullname: ");
            string name = Console.ReadLine();

            char gender;
            do
            {
                Console.Write("Enter Patient Gender (M/F): ");
                gender = Console.ReadLine()[0];
                if (gender != 'M' && gender != 'F')
                    Console.WriteLine("Invalid input. Please enter 'M' for Male or 'F' for Female.");
            } while (gender != 'M' && gender != 'F');

            Console.Write("Enter Patient Birth Date (yyyy-mm-dd): ");
            DateTime birthDate;
            while (!DateTime.TryParse(Console.ReadLine(), out birthDate))
            {
                Console.Write("Invalid date format. Please enter again (yyyy-mm-dd): ");
            }

            Patient newPatient = new Patient(id, name, gender, birthDate);

            Console.Write("\nPress E to add examination information. ");
            if (Console.ReadKey().Key == ConsoleKey.E)
            {
                Console.WriteLine();
                newPatient.AddExaminationInfo(InputExaminationInformation());
            }

            return newPatient;
        }
        public static void AddEmergencyPatient()
        {
            Patient newPatient = InputNewPatient();
            emergencyQueue.Enqueue(newPatient);
        }

        public static Examination InputExaminationInformation()
        {

            Console.Write("Enter Examination Date (yyyy-mm-dd): ");
            DateTime date;
            while (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.Write("Invalid date format. Please enter again (yyyy-mm-dd): ");
            }

            Console.Write("Enter Examination Diagnosis: ");
            string diagnosis = Console.ReadLine();

            Console.Write("Enter Examination Treatment: ");
            var treatment = Console.ReadLine();

            Examination newExamination = new Examination(date, diagnosis, treatment);
            return newExamination;

        }

        public static void DeletePatientByID(string id)
        {
            // Delete from patientList
            var current = patientList.Head;
            while (current != null)
            {
                if (current.Value.IDno == id)
                {
                    patientList.RemoveByID(id);
                    Console.WriteLine("Patient removed from Patient List.");
                    break;
                }
                current = current.Next;
            }

            // Delete from emergencyQueue
            var tempQueue = new Queue<Patient>();
            while (!emergencyQueue.IsEmpty())
            {
                var patient = emergencyQueue.Dequeue();
                if (patient.IDno != id)
                    tempQueue.Enqueue(patient);
            }
            emergencyQueue = tempQueue;

            Console.WriteLine("Patient removed from emergencyQueue (if present).");
        }

        public static void Asterisk()
        {
            Console.WriteLine();
            Console.WriteLine(new string('*', Console.WindowWidth / 2));
            Console.WriteLine();
        }

        public static void Title(string title)
        {
            string separator = new string('-', (int)(title.Length * 2));
            Console.WriteLine(separator);
            Console.WriteLine(title.PadLeft((title.Length * 3) / 2));
            Console.WriteLine(separator);
        }
    }
}
