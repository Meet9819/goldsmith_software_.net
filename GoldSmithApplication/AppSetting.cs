using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldSmithApplication
{

    class AppSetting
    {
       // public static string constring;
        public static String ConnectionString()
        {
        //     public static String ConnectionString(int i)
        //{



            //if (i == 1)
            //{
            //     constring = "Server=148.72.232.171;port=3306;Database=goldsmith;username='goldsmith';Password='loveyoudad9820102993'";


            //}
            //else if(i == 2)
            //{
             //  constring = "Server=localhost;port=3306;Database=Goldsmith;Uid='root';";

            //}
           // string constring = "Server=148.72.232.171;port=3306;Database=goldsmith;username='goldsmith';Password='loveyoudad9820102993'";
            string constring = "Server=localhost;port=3306;Database=Goldsmith;Uid='root';";

            return constring;
        }
    }
}
