using System;

namespace Journal.ViewModel
{
    public class ViewModelInstructed
    {
        
        public bool AddInstructed(int id, string name)
        {
            gr691_fnvEntities db = new gr691_fnvEntities();
            Instructed instructed = new Instructed();
            try
            {
                instructed.Номер_инструктурируемого = Convert.ToInt32(id);
                instructed.ФИО_инструктурируемого = Convert.ToString(name);
                db.Instructeds.Add(instructed);
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
