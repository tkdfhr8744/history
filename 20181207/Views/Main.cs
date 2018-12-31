using _20181207.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20181207
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            Load load = new Load(this);
            Load += load.GetHandler("main");
        }
    }
}
