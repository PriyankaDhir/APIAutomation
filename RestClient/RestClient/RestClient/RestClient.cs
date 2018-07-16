using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace RestClient
{
    public enum httpVerb
    {
        GET
    }

    class RestClient
    {
        public string endpoint { get; set; }
        public httpVerb httpMethod {get;set; }

        public RestClient()
        {
            endpoint = String.Empty;
            httpMethod = httpVerb.GET;
        }

        public class MyObject
        {
            public string largest_capital { get; set; }
            public string capital { get; set; }
        }

        public string makeRequest()
        {
            string strResponseValue = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endpoint);

            request.Method = httpMethod.ToString();

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode != HttpStatusCode.OK)
                    {
                    throw new ApplicationException("error code: " + response.StatusCode.ToString());
                }

                Stream responseStream = response.GetResponseStream();

                {
                    if(responseStream !=null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {

                            string strResponseValue1 = reader.ReadToEnd();
                            int index = strResponseValue1.IndexOf("largest_city");
                            if (index != -1)
                            {


                            int index1 = strResponseValue1.Substring(index + 17, strResponseValue1.Length- (index + 17)).IndexOf(",");
                             strResponseValue =  "Largest City  :  " + strResponseValue1.Substring(index+17, index1-1);

                                //MyObject myobj = (MyObject)js.Deserialize(strResponseValue, typeof(MyObject));4
                            }
                            else
                            { 
                                MessageBox.Show("Largest City not found!");
                                strResponseValue = "Largest City Not Found!";
                            }
                           
                            index = strResponseValue1.IndexOf("capital");
                            if (index != -1)
                            {
                                int index1 = strResponseValue1.Substring(index + 12, strResponseValue1.Length - (index + 12)).IndexOf("}");
                                strResponseValue = strResponseValue + "\r\n" +  "Capital   :  " + strResponseValue1.Substring(index + 12, index1 - 6);
                                //MyObject myobj = (MyObject)js.Deserialize(strResponseValue, typeof(MyObject));4
                            }
                            else
                            {
                                MessageBox.Show("Capital not found!");
                                strResponseValue = strResponseValue + "\r\n" + "Capital Not Found!";
                            }
                        }
                        //JavaScriptSerializer js = new JavaScriptSerializer();
                        //var persons = js.Deserialize<List<MyObject>>(strResponseValue);
                    }
                }
            }
                return strResponseValue;
        }
    }
}
