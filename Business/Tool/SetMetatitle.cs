using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tool
{
    public class SetMetatitle
    {
        public string Metatitle(string Name)
        {
            var resuilt = "";
            for (var i=0;i<Name.Length;i++)
            {
                if (Name[i].ToString() == " ")
                    resuilt += "-";
                else
                    resuilt += Name[i].ToString();
            }
            return resuilt;
        }
    }
}
