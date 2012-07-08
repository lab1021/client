using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace client
{
    class DataList
    {
        //string str;
        //LinkedList<string> beforeList;

        //public DataList()
        //{
        //    beforeList = new LinkedList<string>() ;
        //}
        public static LinkedList<string> process(string s)
        {
            LinkedList<string> beforeList = new LinkedList<string>();
            int i, j;
            i = s.IndexOf("<p>");
            j = s.IndexOf("</p>");
            while (i != -1 && j != -1)
            {
                beforeList.AddLast(new LinkedListNode<string>(new string(s.ToCharArray(), i + 3, j - i - 3)));
                i = s.IndexOf("<p>", j);
                if (i != -1)
                {
                    j = s.IndexOf("</p>", i);
                }
            }
            return beforeList;
        }

        public static string listtostring(LinkedList<string> list)
        {
            string str="";
            LinkedListNode<string> listnode = list.First;
            while (listnode != null)
            {
                str = "<p>" + listnode.Value + "</p>";
                listnode = listnode.Next;
            }
            return str;
        }

    }
}
