using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuggerYourBuddy
{
    public class GlobalVariables
    {
        public static wMainMenu wMainMenu = (wMainMenu)Application.OpenForms[0];
        public static Boolean gameExists = false;
    }
}
