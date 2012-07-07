using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace client
{
    class DataProcess
    {
        //public static LinkedList<string> process(string s)
        //{
        //    LinkedList<string> beforeList = new LinkedList<string>();
        //    int i, j;
        //    i = s.IndexOf("<b>");
        //    j = s.IndexOf("</b>");
        //    while (i != -1 && j != -1)
        //    {
        //        beforeList.AddLast(new LinkedListNode<string>(new string(s.ToCharArray(), i + 3, j - i - 3)));
        //        i = s.IndexOf("<b>", j);
        //        if (i != -1)
        //        {
        //            j = s.IndexOf("</b>", i);
        //        }
        //    }
        //    return beforeList;
        //}

        public static string TextToXml(string s)
        {

            int i, j;
            i = s.IndexOf("|");
            j = s.IndexOf("|", i + 1);
            if (i != -1)
            {
                s = s.Remove(i, 1);
                j--;
            }
            while (i != -1 && j != -1)
            {

                s = s.Insert(i, "<b>");
                j = j + 3;
                s = s.Remove(j, 1);
                s = s.Insert(j, "</b>");
                i = j + 4;
                j = s.IndexOf("|");
            }
            return s;
        }

    }
}
