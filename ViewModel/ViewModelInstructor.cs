using System;

namespace Journal.ViewModel
{
    public class ViewModelInstructor
    {
       
        public bool AddInstructor(int id, string name)
        {
            gr691_fnvEntities db = new gr691_fnvEntities();
            Instructor instructor = new Instructor();
            try
            {
                instructor.Номер_инструктора = Convert.ToInt32(id);
                instructor.ФИО_инструктора = Convert.ToString(name);
                db.Instructors.Add(instructor);
                db.SaveChanges();
            }
            catch
            {
                return false;

            }
            return true;
        }
    }
}
