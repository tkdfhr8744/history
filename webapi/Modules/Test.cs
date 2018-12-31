using System;
using System.Collections;
using MySql.Data.MySqlClient;

namespace webapi.Modules
{
    public class Test
    {
        public string id {set; get;}
        
        public string name {set; get;}
        
        public string passwd {set; get;}
    }
    public static class Query
    {
        
        public static ArrayList Getinsert(Test test)
        {
            Mysql my=new Mysql();

            string sql=string.Format("insert into Notice(mNo,nTitle,nContents) values({0},'{1}','{2}');",test.id,test.name,test.passwd);

            Console.WriteLine(sql);
            if(my.NonQuery(sql))
            {
                return GetSelect();
            }
            else
            {
                return new ArrayList();
            }
        }
        public static ArrayList GetSelect(){
            Mysql my=new Mysql();
            string sql="select n.nNo,n.nTitle,n.nContents,m.mName,DATE_FORMAT(n.regDate, '%Y-%m-%d') as regDate, DATE_FORMAT(n.modDate, '%Y-%m-%d') as modDate from Notice as n inner join Member as m on (n.mNo = m.mNo and m.delYn = 'N') where n.delYn = 'N';";
            
            MySqlDataReader sdr=my.Reader(sql);
            //string result="";
            ArrayList list=new ArrayList();
            while(sdr.Read())
            {
                Hashtable ht=new Hashtable();
                for(int i=0;i<sdr.FieldCount;i++)
                {
                    ht.Add(sdr.GetName(i),sdr.GetValue(i));
                //result += string.Format("{0} : {1}",sdr.GetName(i),sdr.GetValue(i));
                }
                //result+="\n";
                list.Add(ht);
            }
            return list;
        }
        public static ArrayList GetUpdate(Test test)
        {
            Mysql my=new Mysql();
            string sql=string.Format("update Notice set nTitle='{1}',nContents='{2}' where nNo={0};",test.id,test.name,test.passwd);
            
            if(my.NonQuery(sql))
            {
                return GetSelect();
            }
            else
            {
                return new ArrayList();
            }
        }
         public static ArrayList GetDelete(Test test)
        {
             Mysql my=new Mysql();
            string sql=string.Format("update Notice set delYn='N' where nNo={0};",test.id);
             if(my.NonQuery(sql))
            {
                return GetSelect();
            }
            else
            {
                return new ArrayList();
            }
        }
    }
}
