using System;

namespace Journal.ViewModel
{
    public class ViewModelInstruct
    {
        public bool AddInstruct(int idInstruct, string name, int idInstructed, int idInstructor, int idDateOfPassege, int idViolation, int NumberviewInstruct)
        {
            gr691_fnvEntities db = new gr691_fnvEntities();
            OSJ osj = new OSJ();
            try
            {
                osj.Номер_инструктажа = Convert.ToInt32(idInstruct);
                osj.Название_инструктажа = Convert.ToString(name);
                osj.Номер_инструктурируемого = Convert.ToInt32(idInstructed);
                osj.Номер_инструктора = Convert.ToInt32(idInstructor);
                osj.Номер_прохождения = Convert.ToInt32(idDateOfPassege);
                osj.Номер_нарушения = Convert.ToInt32(idViolation);
                osj.Номер_вида_инструктажа = Convert.ToInt32(NumberviewInstruct);
                db.OSJs.Add(osj);
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
