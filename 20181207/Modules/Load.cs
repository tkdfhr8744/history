using _20181207.Controller;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20181207.Modules
{
    class Load
    {
        private Form parentForm;

        public Load(Form parentForm)
        {
            this.parentForm = parentForm;
        }

        public EventHandler GetHandler(string viewName)
        {
            switch (viewName)
            {
                case "main":
                    return GetMainLoad;
                default:
                    return null;
            }
        }

        private void GetMainLoad(object o, EventArgs a)
        {
            parentForm.Size = new Size(1000, 800);
            parentForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            parentForm.MaximizeBox = false;
            parentForm.MinimizeBox = false;
            parentForm.Text = "게시판";
            new MainController(parentForm);
        }
    }
}
