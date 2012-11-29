<%@ WebHandler Language="C#" Class="GetPosition" %>

using System;
using System.Web;
using BLL;
using Model;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Web.Script.Serialization;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;

public class GetPosition : IHttpHandler
{
    BLLScenic bllscenic = new BLLScenic();
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/json";
        string index = context.Request.Form[0];
        for (int i = 0,k=0; i < context.Request.Form.Count - 1; i++)
        {
            if (context.Request.Form[i] != "")
            {
                Scenic scenic;
                while (GetScenic(k + 1) == null)
                {
                    k++;
                }
                scenic = GetScenic(k + 1);
                scenic.Position = context.Request.Form[i];
                bllscenic.UpdateScenicInfo(scenic);
                k++;
            }

        }
    }

    public Scenic GetScenic(int id)
    {
        return bllscenic.GetScenicById(id);
    }


    public T FromJsonTo<T>(string jsonString)
    {
        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
        using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
        {
            T jsonObject = (T)ser.ReadObject(ms);
            return jsonObject;
        }
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}