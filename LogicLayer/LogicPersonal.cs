using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using EntityLayer;

namespace LogicLayer
{
    public class LogicPersonal
    {
        public static List<EntityPersonal> LLPersonalList()
        {
            return DalPersonal.PersonalList();  
        }
        public static int LLPersonalAdd(EntityPersonal e)
        {
            if (e.Name != "" && e.Surname != "" && e.Wage>=2000 && e.Name.Length >= 3)
            {
                return DalPersonal.PersonalAdd(e);
            }
            else
            {
                return -1;

            }
        }

        public static bool LLPersonelDelete(int per)
        {
            if (per>=1)
            {
                return DataAccessLayer.DalPersonal.PersonalDelete(per);
            }
            else
            {
                return false;
            }
        }

        public static bool LLPersonelUpdate(EntityPersonal e)
        {
            if (e.Name.Length>=4 && e.Name != "" && e.Wage>=4500)
            {
                return DalPersonal.PersonalUpdate(e);
            }
            else
            {
                return false;
            }
        }
    }
}
