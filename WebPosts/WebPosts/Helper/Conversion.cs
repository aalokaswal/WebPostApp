using System;
using System.Collections.Generic;
using System.Text;

namespace WebPosts.Helper
{
    public class Conversion
    {
        public static string GetHtml<T>(IEnumerable<T> list,string TableName, params Func<T, object>[] fxns)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<TABLE border =" + '"' +"1" + '"' + "style=" + '"' + "width:100%" + '"' + ">\n");
            var tableName = "";
            StringBuilder header = new StringBuilder(); 
            if(TableName == "WebPost")
            {
                tableName = "WebPost";

                header.Append("<TR>\n");
                header.Append("<TH>");
                header.Append(" ");
                header.Append("id");
                header.Append(" ");
                header.Append("</TH>");

                header.Append("<TH>");
                header.Append(" ");
                header.Append("title");
                header.Append(" ");
                header.Append("</TH>");

                header.Append("<TH>");
                header.Append(" ");
                header.Append("body");
                header.Append(" ");
                header.Append("</TH>");
                header.Append("</TR>");
                sb.Append(header.ToString()); 
            }
            else
            {
                tableName= "WebPost Comment List";

                header.Append("<TR>\n");
                header.Append("<TH>");
                header.Append(" ");
                header.Append("postid");
                header.Append(" ");
                header.Append("</TH>");

                header.Append("<TH>");
                header.Append(" ");
                header.Append("id");
                header.Append(" ");
                header.Append("</TH>");

                header.Append("<TH>");
                header.Append(" ");
                header.Append("name");
                header.Append(" ");
                header.Append("</TH>");

                header.Append("<TH>");
                header.Append(" ");
                header.Append("email");
                header.Append(" ");
                header.Append("</TH>");

                header.Append("<TH>");
                header.Append(" ");
                header.Append("body");
                header.Append(" ");
                header.Append("</TH>");
                header.Append("</TR>");
                sb.Append(header.ToString());
            }

            sb.Append("<caption>" + tableName + "</caption>");
           
            foreach (var item in list)
            {
                sb.Append("<TR>\n");
                foreach (var fxn in fxns)
                {
                    sb.Append("<TD>");
                    sb.Append(" ");
                    sb.Append(fxn(item));
                    sb.Append(" ");
                    sb.Append("</TD>");
                }
                sb.Append("</TR>\n");
            }
            sb.Append("</TABLE>");

            return sb.ToString();
        }
    }
}
