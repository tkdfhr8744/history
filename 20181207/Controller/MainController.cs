using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _20181207.Modules;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace _20181207.Controller
{
    class MainController
    {
        private Commons comm;
        private Panel head, contents, view, controller;
        private Button btn1, btn2, btn3;
        private ListView listView;
        private TextBox textBox1, textBox2, textBox3, textBox4, textBox5, textBox6;
        private Form parentForm, tagetForm;
        private Hashtable hashtable;

        public MainController(Form parentForm)
        {
            this.parentForm = parentForm;
            comm = new Commons();
            getView();
        }

        private void getView()
        {
            hashtable = new Hashtable();
            hashtable.Add("sX", 1000);
            hashtable.Add("sY", 100);
            hashtable.Add("pX", 0);
            hashtable.Add("pY", 0);
            hashtable.Add("color", 1);
            hashtable.Add("name", "head");
            head = comm.getPanel(hashtable, parentForm);

            hashtable = new Hashtable();
            hashtable.Add("sX", 1000);
            hashtable.Add("sY", 700);
            hashtable.Add("pX", 0);
            hashtable.Add("pY", 100);
            hashtable.Add("color", 4);
            hashtable.Add("name", "contents");
            contents = comm.getPanel(hashtable, parentForm);

            hashtable = new Hashtable();
            hashtable.Add("sX", 1000);
            hashtable.Add("sY", 20);
            hashtable.Add("pX", 0);
            hashtable.Add("pY", 0);
            hashtable.Add("color", 3);
            hashtable.Add("name", "controller");
            controller = comm.getPanel(hashtable, contents);

            hashtable = new Hashtable();
            hashtable.Add("sX", 1000);
            hashtable.Add("sY", 680);
            hashtable.Add("pX", 0);
            hashtable.Add("pY", 20);
            hashtable.Add("color", 0);
            hashtable.Add("name", "view");
            view = comm.getPanel(hashtable, contents);

            hashtable = new Hashtable();
            hashtable.Add("sX", 200);
            hashtable.Add("sY", 80);
            hashtable.Add("pX", 100);
            hashtable.Add("pY", 10);
            hashtable.Add("color", 0);
            hashtable.Add("name", "btn1");
            hashtable.Add("text", "입력");
            hashtable.Add("click", (EventHandler) SetInsert);
            btn1 = comm.getButton(hashtable, head);

            hashtable = new Hashtable();
            hashtable.Add("sX", 200);
            hashtable.Add("sY", 80);
            hashtable.Add("pX", 400);
            hashtable.Add("pY", 10);
            hashtable.Add("color", 0);
            hashtable.Add("name", "btn2");
            hashtable.Add("text", "수정");
            hashtable.Add("click", (EventHandler) SetUpdate);
            btn2 = comm.getButton(hashtable, head);

            hashtable = new Hashtable();
            hashtable.Add("sX", 200);
            hashtable.Add("sY", 80);
            hashtable.Add("pX", 700);
            hashtable.Add("pY", 10);
            hashtable.Add("color", 0);
            hashtable.Add("name", "btn3");
            hashtable.Add("text", "삭제");
            hashtable.Add("click", (EventHandler) SetDelete);
            btn3 = comm.getButton(hashtable, head);

            hashtable = new Hashtable();
            hashtable.Add("color", 0);
            hashtable.Add("name", "listView");
            hashtable.Add("click", (MouseEventHandler)listView_click);
            listView = comm.getListView(hashtable, view);

            hashtable = new Hashtable();
            hashtable.Add("width", 45);
            hashtable.Add("pX", 0);
            hashtable.Add("pY", 0);
            hashtable.Add("color", 0);
            hashtable.Add("name", "textBox1");
            hashtable.Add("enabled", false);
            textBox1 = comm.getTextBox(hashtable, controller);

            hashtable = new Hashtable();
            hashtable.Add("width", 100);
            hashtable.Add("pX", 45);
            hashtable.Add("pY", 0);
            hashtable.Add("color", 0);
            hashtable.Add("name", "textBox2");
            hashtable.Add("enabled", true);
            textBox2 = comm.getTextBox(hashtable, controller);

            hashtable = new Hashtable();
            hashtable.Add("width", 350);
            hashtable.Add("pX", 145);
            hashtable.Add("pY", 0);
            hashtable.Add("color", 0);
            hashtable.Add("name", "textBox3");
            hashtable.Add("enabled", true);
            textBox3 = comm.getTextBox(hashtable, controller);

            hashtable = new Hashtable();
            hashtable.Add("width", 100);
            hashtable.Add("pX", 495);
            hashtable.Add("pY", 0);
            hashtable.Add("color", 0);
            hashtable.Add("name", "textBox4");
            hashtable.Add("enabled", true);
            textBox4 = comm.getTextBox(hashtable, controller);

            hashtable = new Hashtable();
            hashtable.Add("width", 200);
            hashtable.Add("pX", 595);
            hashtable.Add("pY", 0);
            hashtable.Add("color", 0);
            hashtable.Add("name", "textBox5");
            hashtable.Add("enabled", false);
            textBox5 = comm.getTextBox(hashtable, controller);

            hashtable = new Hashtable();
            hashtable.Add("width", 200);
            hashtable.Add("pX", 795);
            hashtable.Add("pY", 0);
            hashtable.Add("color", 0);
            hashtable.Add("name", "textBox6");
            hashtable.Add("enabled", false);
            textBox6 = comm.getTextBox(hashtable, controller);

            GetSelect();
        }

        private void GetSelect()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            listView.Clear();

            listView.Columns.Add("nNo", 45, HorizontalAlignment.Center);        /* Notice 번호 */
            listView.Columns.Add("nTitle", 100, HorizontalAlignment.Left);      /* Notice 제목 */
            listView.Columns.Add("nContents", 350, HorizontalAlignment.Left);   /* Notice 내용 */
            listView.Columns.Add("mName", 100, HorizontalAlignment.Center);     /* Notice 작성자 이름 */
            listView.Columns.Add("regDate", 200, HorizontalAlignment.Left);     /* Notice 작성 현재날짜 */
            listView.Columns.Add("modDate", 200, HorizontalAlignment.Left);     /* Notice 수정 현재날짜 */
        
            //listView.Items.Add(new ListViewItem(new string[] { "1", "제목1", "내용1", "관리자", "2018-12-05", "2016-12-07" }));
        }

        private void SetInsert(object o, EventArgs e)
        {
            GetSelect();

            WebClient client = new WebClient();
            NameValueCollection data = new NameValueCollection();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Encoding = Encoding.UTF8;

            string url = "http://192.168.3.12:5000/api/Insert"; // 웹 호출 주소 정의하기
            string method = "POST";

            data.Add("id", "일"); // 파라메터값 정의하기 (key, value) 형식
            data.Add("name", "일번");
            data.Add("passwd", "1");

            byte[] result = client.UploadValues(url, method, data); // 데이터 호출 후 Byte[] 값 받기
            string strResult = Encoding.UTF8.GetString(result);

            ArrayList jList = JsonConvert.DeserializeObject<ArrayList>(strResult); // JSON 데이터 변경
            ArrayList list = new ArrayList(); // JSON 에서 LIST로 담을 객체 생성
            for (int i = 0; i < jList.Count; i++)
            {
                JObject jo = (JObject)jList[i];
                string[] arr = new string[jList.Count];
                // Key : Value 형식으로 데이터 담을 객체 생성
                foreach (JProperty col in jo.Properties()) // JSON 속성 가져오기
                {
                    if (col.Name == "nNo")
                    {
                        arr[0] = col.Value.ToString();
                    }
                    else if (col.Name == "nTitle")
                    {
                        arr[1] = col.Value.ToString();
                    }
                    else if (col.Name == "nContents")
                    {
                        arr[2] = col.Value.ToString();
                    }
                    else if (col.Name == "mName")
                    {
                        arr[3] = col.Value.ToString();
                    }
                    else if (col.Name == "regDate")
                    {
                        arr[4] = col.Value.ToString();
                    }
                    else if (col.Name == "modDate")
                    {
                        arr[5] = col.Value.ToString();
                    }

                    listView.Items.Add(new ListViewItem(arr));

                }

                // list.Add(ht); // JSON 에서 LIST 로 데이터 담기
                //listView.Items.Add(list.ToString());`
            }
        }
        private void SetUpdate(object o, EventArgs e)
        {
            MessageBox.Show("SetUpdate");
        }
        private void SetDelete(object o, EventArgs e)
        {
            MessageBox.Show("SetDelete");
        }
        private void listView_click(object o, EventArgs a)
        {
            MessageBox.Show("listView_click");
        }
    }
}
