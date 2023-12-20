using SMS.Services.Interface;
using SMSServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSServices.web
{
    public class SMSServices : ISMSService
    {
        private readonly ILogger<SMSServices> _logger;
        private static List<StudentModel> _items;

        public SMSServices(ILogger<SMSServices> logger)
        {
            _logger = logger;
            _items = LoadStudentsFromJson();
        }

        public IEnumerable<StudentModel> GetAll()
        {
            return _items;
        }

        public StudentModel GetByID(string id)
        {
            /*int sid = int.Parse(id);
            return _items[sid];*/
            return _items.Find(sid => sid.ID == id);
        }

        public void Add(StudentModel newStudent)
        {
            _items.Add(newStudent);
            SaveStudentsToJson();
        }

        public bool Update(string id, StudentModel updatedStudent)
        {
            var existingStudent = _items.Find(sid => sid.ID == id);
            if (existingStudent == null)
            {
                return false;
            }

            existingStudent.ID = updatedStudent.ID;
            existingStudent.FirstName = updatedStudent.FirstName;
            existingStudent.MidName = updatedStudent.MidName;
            existingStudent.LastName = updatedStudent.LastName;
            existingStudent.JoiningBatch = updatedStudent.JoiningBatch;
            existingStudent.DeptSub = updatedStudent.DeptSub;
            existingStudent.DegreeChoise = updatedStudent.DegreeChoise;
            SaveStudentsToJson();

            return true;
        }

        public bool Delete(string id)
        {
            var studentToRemove = _items.Find(sid => sid.ID == id);

            if (studentToRemove == null)
            {
                return false;
            }
            _items.Remove(studentToRemove);
            SaveStudentsToJson();
            return true;
        }
        public List<StudentModel> LoadStudentsFromJson()
        {

            try
            {
                string json = File.ReadAllText("students.json");
                _items = JsonConvert.DeserializeObject<List<StudentModel>>(json);
                return _items;
            }
            catch (FileNotFoundException)
            {

                File.WriteAllText("students.json", "[]");
                return new List<StudentModel>();
            }
        }
        public void SaveStudentsToJson()
        {

            string json = JsonConvert.SerializeObject(_items, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("students.json", json);
        }

    }
}
