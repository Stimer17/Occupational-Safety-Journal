using System;

namespace Journal.ViewModel
{
    public class ViewModelDateOfPassege
    {
        public bool AddDateOfPassege(int id, DateTime DateOfPassege, DateTime RepeatDateOfPassege)
        {
            Passage passage = new Passage();
            gr691_fnvEntities db = new gr691_fnvEntities();
            try
            {
                passage.Номер_прохождения = Convert.ToInt32(id);
                passage.Дата_прохождения = Convert.ToDateTime(DateOfPassege);
                passage.Дата_повторного_прохождения = Convert.ToDateTime(RepeatDateOfPassege);
                db.Passages.Add(passage);
                db.SaveChanges();
            }
            catch
            {
                return  false;
            }
            return true;
        }
    }
}
