using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20181207.Modules
{
    class Commons
    {
        public Color getColor(int type)
        {
            switch (type)
            {
                case 1:
                    return Color.Red;
                case 2:
                    return Color.Blue;
                case 3:
                    return Color.Green;
                case 4:
                    return Color.Yellow;
                default:
                    return Color.White;
            }
        }

        public Panel getPanel(Hashtable hashtable, Control parentDomain)
        {
            Panel panel = new Panel();
            panel.Size = new Size(Convert.ToInt32(hashtable["sX"]), Convert.ToInt32(hashtable["sY"]));
            panel.Location = new Point(Convert.ToInt32(hashtable["pX"]), Convert.ToInt32(hashtable["pY"]));
            panel.BackColor = getColor(Convert.ToInt32(hashtable["color"]));
            panel.Name = hashtable["name"].ToString();
            parentDomain.Controls.Add(panel);
            return panel;
        }

        public Button getButton(Hashtable hashtable, Control parentDomain)
        {
            Button button = new Button();
            button.Size = new Size(Convert.ToInt32(hashtable["sX"]), Convert.ToInt32(hashtable["sY"]));
            button.Location = new Point(Convert.ToInt32(hashtable["pX"]), Convert.ToInt32(hashtable["pY"]));
            button.BackColor = getColor(Convert.ToInt32(hashtable["color"]));
            button.Name = hashtable["name"].ToString();
            button.Text = hashtable["text"].ToString();
            button.Click += (EventHandler)hashtable["click"];
            button.Cursor = Cursors.Hand;
            parentDomain.Controls.Add(button);
            return button;
        }

        public TextBox getTextBox(Hashtable hashtable, Control parentDomain)
        {
            TextBox textBox = new TextBox();
            textBox.Width = Convert.ToInt32(hashtable["width"].ToString());
            textBox.Location = new Point(Convert.ToInt32(hashtable["pX"]), Convert.ToInt32(hashtable["pY"]));
            textBox.BackColor = getColor(Convert.ToInt32(hashtable["color"]));
            textBox.Name = hashtable["name"].ToString();
            textBox.Enabled = (bool)hashtable["enabled"];
            parentDomain.Controls.Add(textBox);
            return textBox;
        }

        public ListView getListView(Hashtable hashtable, Control parentDomain)
        {
            ListView listView = new ListView();
            listView.Dock = DockStyle.Fill;
            listView.View = View.Details;
            listView.GridLines = true;
            listView.FullRowSelect = true;
            listView.BackColor = getColor(Convert.ToInt32(hashtable["color"]));
            listView.Name = hashtable["name"].ToString();
            listView.MouseClick += (MouseEventHandler)hashtable["click"];
            parentDomain.Controls.Add(listView);
            return listView;
        }
    }
}
