using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.ViewModel
{
    public class ViewModelNumberViewInstruct
    {
       
        public bool AddViewInstruct(int id, string name)
        {
            gr691_fnvEntities db = new gr691_fnvEntities();
            ViewInstruct viewInstruct = new ViewInstruct();
            try
            {
                viewInstruct.Номер_вида_инструктажа = Convert.ToInt32(id);
                viewInstruct.Наименование = Convert.ToString(name);
                db.ViewInstructs.Add(viewInstruct);
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
