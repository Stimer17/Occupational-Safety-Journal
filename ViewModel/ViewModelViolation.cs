using System;

namespace Journal.ViewModel
{
    public class ViewModelViolation
    {
        public bool AddViolation(int id, string name)
        { 
            gr691_fnvEntities db = new gr691_fnvEntities();
            Violation violation = new Violation();
            try
            {
                violation.Номер_нарушения = Convert.ToInt32(id);
                violation.Название = Convert.ToString(name);
                db.Violations.Add(violation);
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
