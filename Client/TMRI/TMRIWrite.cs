
using System;
using System.IO;
using System.Text;
using System.Xml;

namespace Client.TMRI
{
    /// <summary>
    /// TMRI Write Interface
    /// </summary>
    static class TMRIWrite
    {
        internal static bool WriteCheckIn(out TMRIWriteResponse response, string sfzmhm, string kskm, string kcxh, string kscc, string qdxm)
        {
            string id = "17CB2";
            string writeBodyXml = $"<sfzmhm>{sfzmhm}</sfzmhm>";
            switch (kskm)
            {
                case "科目一": kskm = "1"; break;
                case "科目二": kskm = "2"; break;
                case "科目三": kskm = "3"; break;
                default: kskm = string.Empty; break;
            }
            switch (kscc)
            {
                case "上午场":kscc = "0";break;
                case "下午场":kscc = "1";break;
                default:kscc = string.Empty;break;
            }
            writeBodyXml += $"<kskm>{kskm}</kskm>";
            writeBodyXml += $"<kcxh>{kcxh}</kcxh>" + $"<kscc>{kscc}</kscc>";
            if (!string.IsNullOrEmpty(qdxm)) writeBodyXml += $"<qdxm>{qdxm}</qdxm>";

            if (!DoWrite(out response, id, writeBodyXml)) return false;
            return true;
        }//end of method

        internal static bool WriteCarAllocation(out TMRIWriteResponse response, string kchp, string kcxh, string kscc, string qdxm)
        {
            string id = "17CB3";
            switch (kscc)
            {
                case "上午场": kscc = "0"; break;
                case "下午场": kscc = "1"; break;
                default: kscc = string.Empty; break;
            }
            string writeBodyXml = $"<kchp>{kchp}</kchp>" + $"<kcxh>{kcxh}</kcxh>" + $"<kscc>{kscc}</kscc>";
            if (!string.IsNullOrEmpty(qdxm)) writeBodyXml += $"<qdxm>{qdxm}</qdxm>";

            if (!DoWrite(out response, id, writeBodyXml)) return false;
            return true;
        }//end of method

        static bool DoWrite(out TMRIWriteResponse response, string id, string writeBodyXml)
        {
            //string writeXmlDoc = System.Web.HttpUtility.UrlEncode(writeHeader + writeBodyXml + writeFooter, Encoding.GetEncoding("UTF-8"));
            string writeXmlDoc = writeHeader + writeBodyXml + writeFooter;
#if true
            StreamWriter sw = new StreamWriter(@".\" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-") + id + "-WRITE.txt");
#endif

            try
            {
                try
                {
#if true
                    sw.WriteLine(id.Substring(0, 2));
                    sw.WriteLine(Form_Config.ServiceSerialNumber);
                    sw.WriteLine(id);
                    sw.WriteLine(writeXmlDoc);
                    sw.WriteLine();
#endif
                    string writeResponseXmlDoc = System.Web.HttpUtility.UrlDecode(tmri.writeObjectOut(id.Substring(0, 2), Form_Config.ServiceSerialNumber, id, writeXmlDoc), Encoding.GetEncoding("UTF-8"));

#if true
                    sw.WriteLine(writeResponseXmlDoc);
#endif
                    response = new TMRIWriteResponse(id, writeResponseXmlDoc);
                    return "1" == response.code;
                }
                catch (Exception ex)
                {
#if true
                    sw.WriteLine(ex.Message);
#endif
                }
            }
            finally
            {
#if true
                sw.Close();
#endif
            }
            response = null;
            return false;
        }//end of method

        static TMRIOutAccess.TmriJaxRpcOutAccessClient tmri = new TMRIOutAccess.TmriJaxRpcOutAccessClient();
        static string writeHeader = "<?xml version=\"1.0\" encoding=\"GBK\"?><root><drvexam>";
        static string writeFooter = "</drvexam></root>";
    }//end of class TMRIWrite

    /// <summary>
    /// TMRI Write Response
    /// </summary>
    internal class TMRIWriteResponse
    {
        internal string code;
        internal string message;
        internal string message1;
        internal string keystr;
        internal string retobj;

        internal TMRIWriteResponse(string id, string writeResponseXmlDoc)
        {
            XmlReader reader = XmlReader.Create(new StringReader(writeResponseXmlDoc));
            reader.MoveToContent();
            if ("root" != reader.Name) throw new TMRIException(TMRIException.TypeEnum.SchemaError, "root", reader.Name);
            reader.ReadStartElement("root");
            reader.MoveToContent();
            if ("head" != reader.Name) throw new TMRIException(TMRIException.TypeEnum.SchemaError, "head", reader.Name);
            reader.ReadStartElement("head");
            reader.MoveToContent();
            while (XmlNodeType.EndElement != reader.NodeType)  //code, message and keystr
            {
                switch (reader.Name)
                {
                    case "code":
                        code = reader.ReadElementContentAsString();
                        break;
                    case "message":
                        message = reader.ReadElementContentAsString();
                        break;
                    case "message1":
                        message1 = reader.ReadElementContentAsString();
                        break;
                    case "keystr":
                        keystr = reader.ReadElementContentAsString();
                        break;
                    case "retobj":
                        retobj = reader.ReadElementContentAsString();
                        break;
                    default:
                        //throw new TMRIException(TMRIException.TypeEnum.SchemaError, "code, message or rownum", reader.Name);
                        reader.ReadElementContentAsString();
                        break;
                }//end of switch
                reader.MoveToContent();
            }

            reader.ReadEndElement();//head
            reader.MoveToContent();
            reader.ReadEndElement();//root
            reader.Close();
        }//end of constructor 
    }//end of class TMRIWriteResponse
}
