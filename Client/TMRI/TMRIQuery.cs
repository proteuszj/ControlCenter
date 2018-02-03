#pragma warning disable 414,162
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using static Client.Utils;
using static Client.DBM;

namespace Client.TMRI
{
    /// <summary>
    /// TMRI Query Interface
    /// </summary>
    static class TMRIQuery
    {
        internal static bool QueryPlace(out string message, string fzjg, string kskm, string gxsj)
        {
            string id = "17C01";
            string queryBodyXml = $"<fzjg>{fzjg}</fzjg>";
            if (!string.IsNullOrEmpty(kskm))
            {
                switch (kskm)
                {
                    case "科目一": kskm = "1"; break;
                    case "科目二": kskm = "2"; break;
                    case "科目三": kskm = "3"; break;
                    default: kskm = string.Empty; break;
                }
                queryBodyXml += $"<kskm>{kskm}</kskm>";
            }
            if (!string.IsNullOrEmpty(gxsj)) queryBodyXml += $"<gxsj>{gxsj}</gxsj>";

            TMRIQueryResponse response;
            if (!DoQuery(out message, out response, id, queryBodyXml)) return false;
            return true;
        }//end of method

        internal static bool QueryDevice(out string message, string fzjg, string kcxh, string gxsj)
        {
            string id = "17C02";
            string queryBodyXml = $"<fzjg>{fzjg}</fzjg><kcxh>{kcxh}</kcxh>";
            if (!string.IsNullOrEmpty(gxsj)) queryBodyXml += $"<gxsj>{gxsj}</gxsj>";

            TMRIQueryResponse response;
            if (!DoQuery(out message, out response, id, queryBodyXml)) return false;
            return true;
        }//end of method

        internal static bool QueryCar(out string message, string fzjg, string glbm, string kcxh, string gxsj)
        {
            string id = "17C03";
            string queryBodyXml = $"<fzjg>{fzjg}</fzjg>" + $"<glbm>{glbm}</glbm>" + $"<kcxh>{kcxh}</kcxh>";
            if (!string.IsNullOrEmpty(gxsj)) queryBodyXml += $"<gxsj>{gxsj}</gxsj>";

            TMRIQueryResponse response;
            if (!DoQuery(out message, out response, id, queryBodyXml)) return false;
            return true;
        }//end of method

        internal static bool QueryExaminator(out string message, string fzjg, string glbm, string gxsj)
        {
            string id = "17C04";
            string queryBodyXml = $"<fzjg>{fzjg}</fzjg><glbm>{glbm}</glbm>";
            if (!string.IsNullOrEmpty(gxsj)) queryBodyXml += $"<gxsj>{gxsj}</gxsj>";

            TMRIQueryResponse response;
            if (!DoQuery(out message, out response, id, queryBodyXml)) return false;
            return true;
        }//end of method

        internal static bool QuerySchool(out string message, string fzjg, string gxsj)
        {
            string id = "17C05";
            string queryBodyXml = $"<fzjg>{fzjg}</fzjg>";
            if (!string.IsNullOrEmpty(gxsj)) queryBodyXml += $"<gxsj>{gxsj}</gxsj>";

            TMRIQueryResponse response;
            if (!DoQuery(out message, out response, id, queryBodyXml)) return false;
            return true;
        }//end of method

        internal static bool QueryGroup(out string message, string glbm, string kskm, DateTime ksrq, string kcxh, string kscx, string kscc)
        {
            string id = "17C06";
            switch (kskm)
            {
                case "科目一": kskm = "1"; break;
                case "科目二": kskm = "2"; break;
                case "科目三": kskm = "3"; break;
                default: kskm = string.Empty; break;
            }
            switch (kscc)
            {
                case "上午场": kscc = "0"; break;
                case "下午场": kscc = "1"; break;
                default: kscc = string.Empty; break;
            }
            string queryBodyXml = $"<glbm>{glbm}</glbm><kskm>{kskm}</kskm><ksrq>{ksrq.ToString("yyyy-MM-dd")}</ksrq><kcxh>{kcxh}</kcxh>";
            if (!string.IsNullOrEmpty(kscx)) queryBodyXml += $"<kscx>{kscx}</kscx>";
            if (!string.IsNullOrEmpty(kscc)) queryBodyXml += $"<kscc>{kscc}</kscc>";

            TMRIQueryResponse response;
            if (!DoQuery(out message, out response, id, queryBodyXml)) return false;
            return true;
        }//end of method

        internal static bool QueryGroupDetail(out string message, string xh)
        {
            string id = "17C07";
            string queryBodyXml = $"<xh>{xh}</xh>";

            TMRIQueryResponse response;
            if (!DoQuery(out message, out response, id, queryBodyXml)) return false;
            return true;
        }//end of method

        internal static bool QueryBook(out string message, string kskm, DateTime ksrq, string ksdd, string sfzmhm)
        {
            string id = "17C08";
            switch (kskm)
            {
                case "科目一": kskm = "1"; break;
                case "科目二": kskm = "2"; break;
                case "科目三": kskm = "3"; break;
                default: kskm = string.Empty; break;
            }
            string queryBodyXml = $"<kskm>{kskm}</kskm><ksrq>{ksrq.ToString("yyyy-MM-dd")}</ksrq>";
            if (!string.IsNullOrEmpty(ksdd)) queryBodyXml += $"<ksdd>{ksdd}</ksdd>";
            if (!string.IsNullOrEmpty(sfzmhm)) queryBodyXml += $"<sfzmhm>{sfzmhm}</sfzmhm>";

            TMRIQueryResponse response;
            if (!DoQuery(out message, out response, id, queryBodyXml)) return false;
            return true;
        }//end of method

        internal static bool QueryTime(out string message, string xh)
        {
            string id = "17C09";
            string queryBodyXml = $"<xh>{xh}</xh>";

            TMRIQueryResponse response;
            if (!DoQuery(out message, out response, id, queryBodyXml)) return false;
            return true;
        }//end of method

        internal static bool QueryPhotoTime(out string message, string lsh, string kskm, string sfzmhm, DateTime ksrq, string yycs, string bcyykscs, out TMRIQueryResponse response)
        {
            string id = "17C57";
            string queryBodyXml = $"<lsh>{lsh}</lsh>" + $"<kskm>{kskm}</kskm>" + $"<sfzmhm>{sfzmhm}</sfzmhm>" + $"<ksrq>{ksrq.ToString("yyyyMMdd")}</ksrq>" + $"<yycs>{yycs}</yycs>" + $"<bcyykscs>{bcyykscs}</bcyykscs>";

            if (!DoQuery(out message, out response, id, queryBodyXml)) return false;
            return true;
        }//end of method

        internal static bool QueryPhoto(out string message, string sfzmhm, out Bitmap photo)
        {
            string id = "17C58";
            string queryBodyXml = $"<sfzmhm>{sfzmhm}</sfzmhm>";
            photo = null;

            TMRIQueryResponse response;
            if (!DoQuery(out message, out response, id, queryBodyXml)) return false;

            if (response.Items.Count > 0)
            {
                photo = ((TMRIQueryResponseItemOf17C58Photo)response.Items[0]).photo;
                return true;
            }
            else
            {
                message += "无照片数据";
                return false;
            }
        }//end of method

        internal static bool QueryCheck(out string message, string azdm, DateTime ksrq)
        {
            string id = "17C61";
            string queryBodyXml = $"<azdm>{azdm}</azdm>" + $"<ksrq>{ksrq.ToString("yyyyMMdd")}</ksrq> ";

            TMRIQueryResponse response;
            if (!DoQuery(out message, out response, id, queryBodyXml)) return false;
            return true;
        }//end of method

        static bool DoQuery(out string message, out TMRIQueryResponse response, string id, string queryBodyXml)
        {
            bool flag = true;
            //            string queryXmlDoc = queryHeader + System.Web.HttpUtility.UrlEncode(queryBodyXml, Encoding.GetEncoding("UTF-8")) + queryFooter;
            string queryXmlDoc = queryHeader + queryBodyXml + queryFooter;
#if true
            StreamWriter sw = new StreamWriter(@".\" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-") + id + "-QUERY.txt");
#endif
            Program.mainForm.toolStripLabel_message.Text = "数据下载中，请稍候……";
            Application.DoEvents();
            try
            {
                try
                {
#if true
                    sw.WriteLine(id.Substring(0, 2));
                    sw.WriteLine(Form_Config.ServiceSerialNumber);
                    sw.WriteLine(id);
                    sw.WriteLine(queryXmlDoc);
                    sw.WriteLine();
#endif
                    string queryResponseXmlDoc = System.Web.HttpUtility.UrlDecode(tmri.queryObjectOut(id.Substring(0, 2), Form_Config.ServiceSerialNumber, id, queryXmlDoc), Encoding.GetEncoding("UTF-8"));

#if true
                    sw.WriteLine(queryResponseXmlDoc);
                    sw.Flush();
#endif
                    response = new TMRIQueryResponse(id, queryResponseXmlDoc);
                    message = response.message;

                    if ("1" != response.code) flag = false;
                    else
                    {
                        Program.mainForm.toolStripLabel_message.Text = message + $"写入数据库，共{response.Items.Count}条记录，请稍等……";
                        Application.DoEvents();
                        Program.mainForm.toolStripProgressBar.Visible = true;
                        Program.mainForm.toolStripProgressBar.Maximum = response.Items.Count;
                        flag = response.process(ref message);
                    }
#if true
                    sw.WriteLine(message);
#endif
                    return flag;
                }
                catch (Exception ex)
                {
                    message = ex.Message;
#if true
                    sw.WriteLine(message);
#endif
                }
            }
            finally
            {
#if true
                sw.Close();
#endif
                Program.mainForm.toolStripLabel_message.Text = "";
                Program.mainForm.toolStripProgressBar.Visible = false;
                Program.mainForm.toolStripProgressBar.Value = 0;
            }
            response = null;
            return false;
        }//end of methd

        static TMRIOutAccess.TmriJaxRpcOutAccessClient tmri = new TMRIOutAccess.TmriJaxRpcOutAccessClient();
        static string fzjg = "苏B";
        static string ksdd = "3202820203";
        static string kcxh = "32000647";
        static string queryHeader = "<?xml version=\"1.0\" encoding=\"GBK\"?><root><QueryCondition>";
        static string queryFooter = "</QueryCondition></root>";
    }//end of class TMRIQuery

    /// <summary>
    /// TMRI Query Response
    /// </summary>
    internal class TMRIQueryResponse
    {
        internal string code;
        internal string message;
        int rownum;
        internal List<TMRIQueryResponseItem> Items = new List<TMRIQueryResponseItem>();

        /// <summary>
        /// constructor with id and response xml as parameters
        /// </summary>
        /// <param name="id">interface identity(jkid)</param>
        /// <param name="queryResponseXmlDoc">query respose xml string</param>
        internal TMRIQueryResponse(string id, string queryResponseXmlDoc)
        {
            XmlReader reader = XmlReader.Create(new StringReader(queryResponseXmlDoc));
            reader.MoveToContent();
            if ("root" != reader.Name) throw new TMRIException(TMRIException.TypeEnum.SchemaError, "root", reader.Name);
            reader.ReadStartElement("root");
            reader.MoveToContent();
            if ("head" != reader.Name) throw new TMRIException(TMRIException.TypeEnum.SchemaError, "head", reader.Name);
            reader.ReadStartElement("head");
            reader.MoveToContent();
            while (XmlNodeType.EndElement != reader.NodeType)  //code, message and rownum
            {
                switch (reader.Name)
                {
                    case "code":
                        code = reader.ReadElementContentAsString();
                        break;
                    case "message":
                        message = reader.ReadElementContentAsString();
                        break;
                    case "rownum":
                        rownum = reader.ReadElementContentAsInt();
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
            if (XmlNodeType.EndElement == reader.NodeType)
            {
                reader.ReadEndElement();
                reader.Close();
                throw new TMRIException(TMRIException.TypeEnum.ErrorMessage, message);
            }
            if ("body" != reader.Name) throw new TMRIException(TMRIException.TypeEnum.SchemaError, "body", reader.Name);
            reader.ReadStartElement("body");
            reader.MoveToContent();

            if ("1" == code)
                //for (int i = 0; i < rownum; i++)
                while (XmlNodeType.EndElement != reader.NodeType)
                    Items.Add(TMRIQueryResponseItem.Create(id, reader));

            reader.ReadEndElement();//body
            reader.MoveToContent();
            reader.ReadEndElement();//root
            reader.Close();
        }//end of constructor 

        /// <summary>
        /// process all response(s)
        /// </summary>
        /// <param name="message">output message</param>
        /// <returns>susseed or fail</returns>
        internal bool process(ref string message)
        {
            message += $"，共{Items.Count}条记录" + Console.Out.NewLine;
            bool flag = true;
            foreach (TMRIQueryResponseItem item in Items)
                if (!item.process(ref message)) flag = false;
            return flag;
        }//end of method
    }//end of class TMRIQueryResponse

    /// <summary>
    /// abstract parent of TMRI Query Response Body Item
    /// </summary>
    abstract class TMRIQueryResponseItem
    {
        /// <summary>
        /// TMRIQueryResponseItem factory
        /// </summary>
        /// <param name="id">interface identity(jkid)</param>
        /// <param name="reader">XmlReader that point to a TMRI Query Response Body Item (element "drvpara" or "drvexam")</param>
        /// <returns></returns>
        internal static TMRIQueryResponseItem Create(string id, XmlReader reader)
        {
            switch (id)
            {
                case "17C01": return new TMRIQueryResponseItemOf17C01Place(reader);
                case "17C02": return new TMRIQueryResponseItemOf17C02Device(reader);
                case "17C03": return new TMRIQueryResponseItemOf17C03Car(reader);
                case "17C04": return new TMRIQueryResponseItemOf17C04Examinator(reader);
                case "17C05": return new TMRIQueryResponseItemOf17C05School(reader);
                case "17C06": return new TMRIQueryResponseItemOf17C06Group(reader);
                case "17C07": return new TMRIQueryResponseItemOf17C07GroupDetail(reader);
                case "17C08": return new TMRIQueryResponseItemOf17C08Book(reader);
                case "17C09": return new TMRIQueryResponseItemOf17C09Time(reader);
                case "17C57": return new TMRIQueryResponseItemOf17C57PhotoTime(reader);
                case "17C58": return new TMRIQueryResponseItemOf17C58Photo(reader);
                case "17C61": return new TMRIQueryResponseItemOf17C61Check(reader);
                default: throw new TMRIException(TMRIException.TypeEnum.UnknownID, id);
            }//end of switch     
        }//end of method

        /// <summary>
        /// process with this response item
        /// </summary>
        /// <param name="message">output message</param>
        /// <returns>succeed or fail</returns>
        internal virtual bool process(ref string message)
        {
            Program.mainForm.toolStripProgressBar.PerformStep();
            return true;
        }//end of method

        /// <summary>
        /// constructor with XmlReader as parameter
        /// </summary>
        /// <param name="reader">XmlReader that point to a TMRI Query Response Body Item (element "drvpara" or "drvexam" etc.)</param>
        protected TMRIQueryResponseItem(XmlReader reader)
        {
            //      if ("drvpara" == reader.Name || "drvexam" == reader.Name || "drvphoto" == reader.Name || "examphoto" == reader.Name || "examresult" == reader.Name)
            {
                reader.ReadStartElement();
                reader.MoveToContent();
                readItemBody(reader);
                reader.ReadEndElement();
                reader.MoveToContent();
            }
        }//end of constructor

        /// <summary>
        /// read query response item body
        /// </summary>
        /// <param name="reader">XmlReader that point to the first element of item body</param>
        protected abstract void readItemBody(XmlReader reader);

        /// <summary>
        /// read element as DateTime as "yyyy-MM-dd hh24:mi:ss"
        /// </summary>
        /// <param name="reader">XmlReader that point to a datetime string elemen</param>
        /// <returns>element datetime string value as "yyyymmdd"</returns>
        protected string readElementAsDateString(XmlReader reader)
        {
            string data = reader.ReadElementContentAsString();
            if (string.IsNullOrEmpty(data)) return data;
            return data.Remove(7, 1).Remove(4, 1).Substring(0, 8);
        }//end of method

        /// <summary>
        /// read element as DateTime as "yyyy-MM-dd hh24:mi:ss"
        /// </summary>
        /// <param name="reader">XmlReader that point to a datetime string element</param>
        /// <returns>element datetime string value as "yyyymmddhh24miss"</returns>
        protected string readElementAsDateTimeString(XmlReader reader)
        {
            string data = reader.ReadElementContentAsString();
            if (string.IsNullOrEmpty(data)) return data;
            return data.Remove(16, 1).Remove(13, 1).Remove(10, 1).Remove(7, 1).Remove(4, 1);
        }//end of method
    }//end of class TMRIQueryResponseItem

    /// <summary>
    /// TMRI Query Response Body Item of Place, 17C01
    /// </summary>
    class TMRIQueryResponseItemOf17C01Place : TMRIQueryResponseItem
    {
        /// <summary>
        /// constructor with XmlReader as parameter
        /// </summary>
        /// <param name="reader">XmlReader that point to a TMRI Query Response Body Item (element "drvpara")</param>
        internal TMRIQueryResponseItemOf17C01Place(XmlReader reader) : base(reader)
        {
        }//end of constructor

        /// <summary>
        /// process with this response item
        /// </summary>
        /// <param name="message">output message</param>
        /// <returns>succeed or fail</returns>
        internal override bool process(ref string message)
        {
            bool flag = base.process(ref message);
            try
            {
                mDBM.Query17C01Place(xh, fzjg, glbm, kskm, kcmc, kcdddh,
                    kkcx, ywlx, zdysrq, ysr, kmeyyms, fzms, kmeksrsxz,
                    kmezkrsxz, kmeckrsxz, zksfdz, cksfdz, zklwrq, cklwrq, kczt,
                    zksbs, cksbs, cjsj, gxsj);
            }
            catch (Exception ex)
            {
                message += ex.Message + Console.Out.NewLine;
                flag = false;
            }

            return flag;
        }//end of method

        /// <summary>
        /// read query response item body
        /// </summary>
        /// <param name="reader">XmlReader that point to the first element of item body</param>
        protected override void readItemBody(XmlReader reader)
        {
            while (XmlNodeType.EndElement != reader.NodeType)
            {
                switch (reader.Name.ToLower())
                {
                    case "xh": xh = reader.ReadElementContentAsString(); break;
                    case "fzjg": fzjg = reader.ReadElementContentAsString(); break;
                    case "glbm": glbm = reader.ReadElementContentAsString(); break;
                    case "kskm": kskm = reader.ReadElementContentAsString(); break;
                    case "kcmc": kcmc = reader.ReadElementContentAsString(); break;
                    case "kcdddh": kcdddh = reader.ReadElementContentAsString(); break;
                    case "kkcx": kkcx = reader.ReadElementContentAsString(); break;
                    case "ywlx": ywlx = reader.ReadElementContentAsString(); break;
                    case "zdysrq": zdysrq = readElementAsDateString(reader); break;
                    case "ysr": ysr = reader.ReadElementContentAsString(); break;
                    case "kmeyyms": kmeyyms = reader.ReadElementContentAsString(); break;
                    case "fzms": fzms = reader.ReadElementContentAsString(); break;
                    case "kmeksrsxz": kmeksrsxz = reader.ReadElementContentAsString(); break;
                    case "kmezkrsxz": kmezkrsxz = reader.ReadElementContentAsString(); break;
                    case "kmeckrsxz": kmeckrsxz = reader.ReadElementContentAsString(); break;
                    case "zksfdz": zksfdz = reader.ReadElementContentAsString(); break;
                    case "cksfdz": cksfdz = reader.ReadElementContentAsString(); break;
                    case "zklwrq": zklwrq = readElementAsDateTimeString(reader); break;
                    case "cklwrq": cklwrq = readElementAsDateTimeString(reader); break;
                    case "kczt": kczt = reader.ReadElementContentAsString(); break;
                    case "zksbs": zksbs = reader.ReadElementContentAsString(); break;
                    case "cksbs": cksbs = reader.ReadElementContentAsString(); break;
                    case "cjsj": cjsj = readElementAsDateTimeString(reader); break;
                    case "gxsj": gxsj = readElementAsDateTimeString(reader); break;
                    default: reader.ReadElementContentAsString(); break;
                }//end of switch
                reader.MoveToContent();
            }
        }//end of method

        string xh;          //序号  Char	8	不可空
        string fzjg;        //发证机关 Varchar2	10	不可空
        string glbm;        //管理部门 Varchar2	12	不可空
        string kskm;        //考试科目 Char	1	不可空 同上
        string kcmc;        //考场名称    Varchar2	128	不可空
        string kcdddh;      //考场代码 Varchar2	64	不可空
        string kkcx;        //适用准驾车型范围 Varchar2	24	不可空
        string ywlx;        //适用业务类型范围 Varchar2	10	可空
        string zdysrq;      //总队验收日期 Date        不可空 yyyy-MM-dd hh24:mi:ss
        string ysr;         //验收人 Varchar2	32	不可空
        string kmeyyms;     //科目二预约模式 Char	1	不可空	1一次预约；2两次预约
        string fzms;        //分组模式 Char	1	不可空	1按学员；2按教练车
        string kmeksrsxz;      //考试人数限制 Number      不可空
        string kmezkrsxz;      //科目二桩考人数限制 Number      不可空
        string kmeckrsxz;      //科目二场考人数限制 Number      不可空
        string zksfdz;      //桩考评判方式 Char	1	不可空	1计算机自动评判；0人工评判
        string cksfdz;      //场考评判方式 Char	1	不可空	1计算机自动评判；0人工评判
        string zklwrq;      //桩考开始联网时间 Date        可空 yyyy-MM-dd
        string cklwrq;      //场考开始联网时间 Date        可空 yyyy-MM-dd
        string kczt;        //使用状态 Char	1	不可空 A正常；B暂停考试；C取消考试
        string zksbs;          //桩考设备数 Number      不可空
        string cksbs;          //场考设备数 Number      不可空
        string cjsj;        //创建日期 Date        不可空 yyyy-MM-dd hh24:mi:ss
        string gxsj;        //更新日期 Date        不可空 yyyy-MM-dd hh24:mi:ss
    }//end of class TMRIQueryResponseItemOf17C01Place

    /// <summary>
    /// TMRI Query Response Body Item of Device, 17C02
    /// </summary>
    class TMRIQueryResponseItemOf17C02Device : TMRIQueryResponseItem
    {
        /// <summary>
        /// constructor with XmlReader as parameter
        /// </summary>
        /// <param name="reader">XmlReader that point to a TMRI Query Response Body Item (element "drvpara")</param>
        internal TMRIQueryResponseItemOf17C02Device(XmlReader reader) : base(reader)
        {
        }//end of constructor

        /// <summary>
        /// process with this response item
        /// </summary>
        /// <param name="message">output message</param>
        /// <returns>succeed or fail</returns>
        internal override bool process(ref string message)
        {
            bool flag = base.process(ref message);
            try
            {
                mDBM.Query17C02Device(xh, sbbh, sbms, zzcs, sbxh, ksxm,
                    ksxmsm, ppfs, kcxh, syzjcx, ysrq, badckssj, bamxsksrs,
                    jyyxqz, syzt, cjsj, gxsj);
            }
            catch (Exception ex)
            {
                message += ex.Message + Console.Out.NewLine;
                flag = false;
            }

            return flag;
        }//end of method

        /// <summary>
        /// read query response item body
        /// </summary>
        /// <param name="reader">XmlReader that point to the first element of item body</param>
        protected override void readItemBody(XmlReader reader)
        {
            while (XmlNodeType.EndElement != reader.NodeType)
            {
                switch (reader.Name.ToLower())
                {
                    case "xh": xh = reader.ReadElementContentAsString(); break;
                    case "sbbh": sbbh = reader.ReadElementContentAsString(); break;
                    case "sbms": sbms = reader.ReadElementContentAsString(); break;
                    case "zzcs": zzcs = reader.ReadElementContentAsString(); break;
                    case "sbxh": sbxh = reader.ReadElementContentAsString(); break;
                    case "ksxm": ksxm = reader.ReadElementContentAsString(); break;
                    case "ksxmsm": ksxmsm = reader.ReadElementContentAsString(); break;
                    case "ppfs": ppfs = reader.ReadElementContentAsString(); break;
                    case "kcxh": kcxh = reader.ReadElementContentAsString(); break;
                    case "syzjcx": syzjcx = reader.ReadElementContentAsString(); break;
                    case "ysrq": ysrq = readElementAsDateString(reader); break;
                    case "badckssj": badckssj = reader.ReadElementContentAsString(); break;
                    case "bamxsksrs": bamxsksrs = reader.ReadElementContentAsString(); break;
                    case "jyyxqz": jyyxqz = readElementAsDateString(reader); break;
                    case "syzt": syzt = reader.ReadElementContentAsString(); break;
                    case "cjsj": cjsj = readElementAsDateTimeString(reader); break;
                    case "gxsj": gxsj = readElementAsDateTimeString(reader); break;
                    default: reader.ReadElementContentAsString(); break;
                }//end of switch
                reader.MoveToContent();
            }
        }//end of method

        string xh;          //序号  char	8	不可空
        string sbbh;        //设备编号 Varchar2	10	不可空
        string sbms;        //设备描述 Varchar2	512	不可空
        string zzcs;        //制造厂商 Varchar2	512	不可空
        string sbxh;        //设备型号 Varchar2	512	不可空
        string ksxm;        //考试项目 Char	5	不可空
        string ksxmsm;      //考试项目说明 Varchar2	256	不可空
        string ppfs;        //评判方式 Char	1	不可空	0计算机自动评判；1人工评判
        string kcxh;        //考场序号 char	8	不可空
        string syzjcx;      //适用准驾车型范围 Varchar2	30	不可空
        string ysrq;        //验收日期 Date        不可空 yyyymmdd
        string badckssj;       //备案单次考试时间 Number      不可空 单位为min
        string bamxsksrs;      //备案每小时考试人次   Number 不可空
        string jyyxqz;      //检验有效期止  Date 不可空 yyyymmdd
        string syzt;        //使用状态 Char        不可空 A正常；B故障；C暂停考试；D报废
        string cjsj;        //创建时间 Date        不可空 yyyymmddhh24miss
        string gxsj;        //更新日期 Date        不可空 yyyymmddhh24miss
    }//end of class TMRIQueryResponseItemOf17C02Device

    /// <summary>
    /// TMRI Query Response Body Item of Car, 17C03
    /// </summary>
    class TMRIQueryResponseItemOf17C03Car : TMRIQueryResponseItem
    {
        /// <summary>
        /// constructor with XmlReader as parameter
        /// </summary>
        /// <param name="reader">XmlReader that point to a TMRI Query Response Body Item (element "drvpara")</param>
        internal TMRIQueryResponseItemOf17C03Car(XmlReader reader) : base(reader)
        {
        }//end of constructor

        /// <summary>
        /// process with this response item
        /// </summary>
        /// <param name="message">output message</param>
        /// <returns>succeed or fail</returns>
        internal override bool process(ref string message)
        {
            bool flag = base.process(ref message);
            try
            {
                mDBM.Query17C03Car(xh, jbr, shr, hpzl, zt, ksczt, cllx,
                    shsj, clpp, ccdjrq, qzbfqz, fzjg, hphm, syzjcx, ipdz,
                    cjsj, gxsj);
            }
            catch (Exception ex)
            {
                message += ex.Message + Console.Out.NewLine;
                flag = false;
            }

            return flag;
        }//end of method

        /// <summary>
        /// read query response item body
        /// </summary>
        /// <param name="reader">XmlReader that point to the first element of item body</param>
        protected override void readItemBody(XmlReader reader)
        {
            while (XmlNodeType.EndElement != reader.NodeType)
            {
                switch (reader.Name.ToLower())
                {
                    case "xh": xh = reader.ReadElementContentAsString(); break;
                    case "jbr": jbr = reader.ReadElementContentAsString(); break;
                    case "shr": shr = reader.ReadElementContentAsString(); break;
                    case "hpzl": hpzl = reader.ReadElementContentAsString(); break;
                    case "zt": zt = reader.ReadElementContentAsString(); break;
                    case "ksczt": ksczt = reader.ReadElementContentAsString(); break;
                    case "cllx": cllx = reader.ReadElementContentAsString(); break;
                    case "shsj": shsj = reader.ReadElementContentAsString(); break;
                    case "clpp": clpp = reader.ReadElementContentAsString(); break;
                    case "ccdjrq": ccdjrq = readElementAsDateString(reader); break;
                    case "qzbfqz": qzbfqz = readElementAsDateString(reader); break;
                    case "fzjg": fzjg = reader.ReadElementContentAsString(); break;
                    case "hphm": hphm = reader.ReadElementContentAsString(); break;
                    case "syzjcx": syzjcx = reader.ReadElementContentAsString(); break;
                    case "ipdz": ipdz = reader.ReadElementContentAsString(); break;
                    case "cjsj": cjsj = readElementAsDateTimeString(reader); break;
                    case "gxsj": gxsj = readElementAsDateTimeString(reader); break;
                    default: reader.ReadElementContentAsString(); break;
                }//end of switch
                reader.MoveToContent();
            }
        }//end of method

        string xh;          //序号  char	8	不可空
        string jbr;         //经办人 Varchar2	30	不可空
        string shr;         //审核人 Varchar2	30	不可空
        string hpzl;        //号牌种类    CHAR	2
        string zt;          //??状态
        string ksczt;       //??考试车状态
        string cllx;        //车辆类型
        string shsj;        //??        Date        不可空 yyyy-MM-dd hh24:mi:ss
        string clpp;        //??车辆品牌
        string ccdjrq;      //初次登记日期        Date       yyyymmdd
        string qzbfqz;      //强制报废期止 Date       yyyymmdd
        string fzjg;        //发证机关    Varchar2	10	不可空
        string hphm;        //号牌号码    VARCHAR2	15
        string syzjcx;      //适用准驾车型范围    Varchar2	30	不可空
        string ipdz;        //IP地址
        string cjsj;        //创建时间    Date 不可空 yyyymmddhh24miss
        string gxsj;        //更新日期 Date        不可空 yyyymmddhh24miss
    }//end of class TMRIQueryResponseItemOf17C03Car

    /// <summary>
    /// TMRI Query Response Body Item of Examinator, 17C04
    /// </summary>
    class TMRIQueryResponseItemOf17C04Examinator : TMRIQueryResponseItem
    {
        /// <summary>
        /// constructor with XmlReader as parameter
        /// </summary>
        /// <param name="reader">XmlReader that point to a TMRI Query Response Body Item (element "drvpara")</param>
        internal TMRIQueryResponseItemOf17C04Examinator(XmlReader reader) : base(reader)
        {
        }//end of constructor

        /// <summary>
        /// process with this response item
        /// </summary>
        /// <param name="message">output message</param>
        /// <returns>succeed or fail</returns>
        internal override bool process(ref string message)
        {
            bool flag = base.process(ref message);
            try
            {
                mDBM.Query17C04Examinator(xh, sszd, glbm, sfzmmc, sfzmhm,
                    dabh, xm, xb, csrq, zkcx, fzrq, kszyxqz,
                    kszzt, gzdw, jbr, fzjg, cjsj, gxsj);
            }
            catch (Exception ex)
            {
                message += ex.Message + Console.Out.NewLine;
                flag = false;
            }

            return flag;
        }//end of method

        /// <summary>
        /// read query response item body
        /// </summary>
        /// <param name="reader">XmlReader that point to the first element of item body</param>
        protected override void readItemBody(XmlReader reader)
        {
            while (XmlNodeType.EndElement != reader.NodeType)
            {
                switch (reader.Name.ToLower())
                {
                    case "xh": xh = reader.ReadElementContentAsString(); break;
                    case "sszd": sszd = reader.ReadElementContentAsString(); break;
                    case "glbm": glbm = reader.ReadElementContentAsString(); break;
                    case "sfzmmc": sfzmmc = reader.ReadElementContentAsString(); break;
                    case "sfzmhm": sfzmhm = reader.ReadElementContentAsString(); break;
                    case "dabh": dabh = reader.ReadElementContentAsString(); break;
                    case "xm": xm = reader.ReadElementContentAsString(); break;
                    case "xb": xb = reader.ReadElementContentAsString(); break;
                    case "csrq": csrq = readElementAsDateString(reader); break;
                    case "zkcx": zkcx = reader.ReadElementContentAsString(); break;
                    case "fzrq": fzrq = readElementAsDateString(reader); break;
                    case "kszyxqz": kszyxqz = readElementAsDateString(reader); break;
                    case "kszzt": kszzt = reader.ReadElementContentAsString(); break;
                    case "gzdw": gzdw = reader.ReadElementContentAsString(); break;
                    case "jbr": jbr = reader.ReadElementContentAsString(); break;
                    case "fzjg": fzjg = reader.ReadElementContentAsString(); break;
                    case "cjsj": cjsj = readElementAsDateTimeString(reader); break;
                    case "gxsj": gxsj = readElementAsDateTimeString(reader); break;
                    default: reader.ReadElementContentAsString(); break;
                }//end of switch
                reader.MoveToContent();
            }
        }//end of method

        string xh;          //序号  char	8	不可空
        string sszd;        //所属发证机关  Varchar2	10	不可空
        string glbm;        //管理部门 Varchar2	12	可空
        string sfzmmc;      //身份证明名称 Char	1	不可空
        string sfzmhm;      //身份证明号码 Varchar2	18	不可空
        string dabh;        //驾驶证档案编号 Varchar2	12	可空 符合GA/T 16.21
        string xm;          //姓名  Varchar2	30	不可空
        string xb;          //性别 Char	1	不可空 符合GB/T 2261.1
        string csrq;        //出生日期    Date 不可空 yyyymmdd
        string zkcx;        //考试准驾车型范围 Varchar2	32	不可空
        string fzrq;        //考试员证发证日期 Date        不可空 yyyymmdd
        string kszyxqz;     //考试员证有效期止 Date        不可空 yyyymmdd
        string kszzt;       //考试员证状态 Varchar2	1       A正常；B过期；C注销
        string gzdw;        //工作单位 Varchar2	128	可空
        string jbr;         //经办人 Varchar2	30	不可空
        string fzjg;        //考试员证发证单位 Varchar2	64	不可空
        string cjsj;        //创建时间 Date        不可空 yyyymmddhh24miss
        string gxsj;        //更新时间 Date        不可空 yyyymmddhh24miss
    }//end of class TMRIQueryResponseItemOf17C04Examinator

    /// <summary>
    /// TMRI Query Response Body Item of School, 17C05
    /// </summary>
    class TMRIQueryResponseItemOf17C05School : TMRIQueryResponseItem
    {
        /// <summary>
        /// constructor with XmlReader as parameter
        /// </summary>
        /// <param name="reader">XmlReader that point to a TMRI Query Response Body Item (element "drvpara")</param>
        internal TMRIQueryResponseItemOf17C05School(XmlReader reader) : base(reader)
        {
        }//end of constructor

        /// <summary>
        /// process with this response item
        /// </summary>
        /// <param name="message">output message</param>
        /// <returns>succeed or fail</returns>
        internal override bool process(ref string message)
        {
            bool flag = base.process(ref message);
            try
            {
                mDBM.Query17C05School(xh, jxmc, jxjc, jxdm, jxdz, lxdh,
                    lxr, frdb, zczj, jxjb, kpxcx, fzjg, jxzt, shr,
                    cjsj, gxsj);
            }
            catch (Exception ex)
            {
                message += ex.Message + Console.Out.NewLine;
                flag = false;
            }

            return flag;
        }//end of method

        /// <summary>
        /// read query response item body
        /// </summary>
        /// <param name="reader">XmlReader that point to the first element of item body</param>
        protected override void readItemBody(XmlReader reader)
        {
            while (XmlNodeType.EndElement != reader.NodeType)
            {
                switch (reader.Name.ToLower())
                {
                    case "xh": xh = reader.ReadElementContentAsString(); break;
                    case "jxmc": jxmc = reader.ReadElementContentAsString(); break;
                    case "jxjc": jxjc = reader.ReadElementContentAsString(); break;
                    case "jxdm": jxdm = reader.ReadElementContentAsString(); break;
                    case "jxdz": jxdz = reader.ReadElementContentAsString(); break;
                    case "lxdh": lxdh = reader.ReadElementContentAsString(); break;
                    case "lxr": lxr = reader.ReadElementContentAsString(); break;
                    case "frdb": frdb = reader.ReadElementContentAsString(); break;
                    case "zczj": zczj = reader.ReadElementContentAsString(); break;
                    case "jxjb": jxjb = reader.ReadElementContentAsString(); break;
                    case "kpxcx": kpxcx = reader.ReadElementContentAsString(); break;
                    case "fzjg": fzjg = reader.ReadElementContentAsString(); break;
                    case "jxzt": jxzt = reader.ReadElementContentAsString(); break;
                    case "shr": shr = reader.ReadElementContentAsString(); break;
                    case "cjsj": cjsj = readElementAsDateTimeString(reader); break;
                    case "gxsj": gxsj = readElementAsDateTimeString(reader); break;
                    default: reader.ReadElementContentAsString(); break;
                }//end of switch
                reader.MoveToContent();
            }
        }//end of method

        string xh;          //序号  char	8	不可空
        string jxmc;        //驾校名称    Varchar2	256	可空
        string jxjc;        //驾校简称 Varchar2	64	不可空
        string jxdm;        //驾校代码 Varchar2	64	不可空
        string jxdz;        //驾校地址 Varchar2	256	不可空
        string lxdh;        //联系电话 Varchar2	20	不可空
        string lxr;         //联系人 Varchar2	30	不可空
        string frdb;        //法人代表 Varchar2	30	不可空
        string zczj;           //注册资金 number      可空
        string jxjb;        //驾校级别 Char	1	不可空	1一级；2二级；3三级；0其他
        string kpxcx;       //培训准驾车型 Varchar2	30	可空
        string fzjg;        //所属发证机关 Varchar2	10	可空
        string jxzt;        //驾校状态 Char	1	可空 A正常；B暂停受理；C取消资格
        string shr;         //审核人 Varchar2	30	不可空
        string cjsj;        //创建时间 Date        不可空 yyyymmddhh24miss
        string gxsj;        //更新时间 Date        不可空 yyyymmddhh24miss
    }//end of class TMRIQueryResponseItemOf17C05School

    /// <summary>
    /// TMRI Query Response Body Item of Group, 17C06
    /// </summary>
    class TMRIQueryResponseItemOf17C06Group : TMRIQueryResponseItem
    {
        /// <summary>
        /// constructor with XmlReader as parameter
        /// </summary>
        /// <param name="reader">XmlReader that point to a TMRI Query Response Body Item (element "drvexam")</param>
        internal TMRIQueryResponseItemOf17C06Group(XmlReader reader) : base(reader)
        {
        }//end of constructor

        /// <summary>
        /// process with this response item
        /// </summary>
        /// <param name="message">output message</param>
        /// <returns>succeed or fail</returns>
        internal override bool process(ref string message)
        {
            bool flag = base.process(ref message);
            try
            {
                mDBM.Query17C06Group(xh, kskm, ksrq, ksdd, kcxh, kscx,
                    kscc, kchp, ksy, ksxm, glbm, ksxl);
            }
            catch (Exception ex)
            {
                message += ex.Message + Console.Out.NewLine;
                flag = false;
            }

            return flag;
        }//end of method

        /// <summary>
        /// read query response item body
        /// </summary>
        /// <param name="reader">XmlReader that point to the first element of item body</param>
        protected override void readItemBody(XmlReader reader)
        {
            while (XmlNodeType.EndElement != reader.NodeType)
            {
                switch (reader.Name.ToLower())
                {
                    case "xh": xh = reader.ReadElementContentAsString(); break;
                    case "kskm": kskm = reader.ReadElementContentAsString(); break;
                    case "ksrq": ksrq = readElementAsDateString(reader); break;
                    case "ksdd": ksdd = reader.ReadElementContentAsString(); break;
                    case "kcxh": kcxh = reader.ReadElementContentAsString(); break;
                    case "kscx": kscx = reader.ReadElementContentAsString(); break;
                    case "kscc": kscc = reader.ReadElementContentAsString(); break;
                    case "kchp": kchp = reader.ReadElementContentAsString(); break;
                    case "ksy": ksy = reader.ReadElementContentAsString(); break;
                    case "ksxm": ksxm = reader.ReadElementContentAsString(); break;
                    case "glbm": glbm = reader.ReadElementContentAsString(); break;
                    case "ksxl": ksxl = reader.ReadElementContentAsString(); break;
                    default: reader.ReadElementContentAsString(); break;
                }//end of switch
                reader.MoveToContent();
            }
        }//end of method

        string xh;          //序号  char	8	不可空
        string kskm;        //考试科目    Char	1	不可空
        string ksrq;        //考试日期 Date        不可空 yyyymmdd
        string ksdd;        //考试地点 Varchar2	64	不可空 考试地点代号
        string kcxh;        //考场序号    Char	8	不可空 考场唯一编号
        string kscx;        //考试车型    Varchar2	15	不可空
        string kscc;        //考试场次 Number      不可空
        string kchp;        //考车号牌 Varchar2	15	可空
        string ksy;         //考试员 Varchar2	30	可空
        string ksxm;        //考试项目 Varchar2	256	可空
        string glbm;        //管理部门 Varchar2	12	可空
        string ksxl;        //考试线路 Char	10	可空
    }//end of class TMRIQueryResponseItemOf17C06Group

    /// <summary>
    /// TMRI Query Response Body Item of Group Detail, 17C07
    /// </summary>
    class TMRIQueryResponseItemOf17C07GroupDetail : TMRIQueryResponseItem
    {
        /// <summary>
        /// constructor with XmlReader as parameter
        /// </summary>
        /// <param name="reader">XmlReader that point to a TMRI Query Response Body Item (element "drvexam")</param>
        internal TMRIQueryResponseItemOf17C07GroupDetail(XmlReader reader) : base(reader)
        {
        }//end of constructor

        /// <summary>
        /// process with this response item
        /// </summary>
        /// <param name="message">output message</param>
        /// <returns>succeed or fail</returns>
        internal override bool process(ref string message)
        {
            bool flag = base.process(ref message);
            try
            {
                mDBM.Query17C07GroupDetail(xh, sfzmhm, xm, dlr, kchp, Jxxh);
            }
            catch (Exception ex)
            {
                message += ex.Message + Console.Out.NewLine;
                flag = false;
            }

            return flag;
        }//end of method

        /// <summary>
        /// read query response item body
        /// </summary>
        /// <param name="reader">XmlReader that point to the first element of item body</param>
        protected override void readItemBody(XmlReader reader)
        {
            while (XmlNodeType.EndElement != reader.NodeType)
            {
                switch (reader.Name.ToLower())
                {
                    case "xh": xh = reader.ReadElementContentAsString(); break;
                    case "sfzmhm": sfzmhm = reader.ReadElementContentAsString(); break;
                    case "xm": xm = reader.ReadElementContentAsString(); break;
                    case "dlr": dlr = reader.ReadElementContentAsString(); break;
                    case "kchp": kchp = reader.ReadElementContentAsString(); break;
                    case "Jxxh": Jxxh = reader.ReadElementContentAsString(); break;
                    default: reader.ReadElementContentAsString(); break;
                }//end of switch
                reader.MoveToContent();
            }
        }//end of method

        string xh;          //分组序号, 来自请求参数
        string sfzmhm;      //身份证明号码  Varchar2	20	不可空
        string xm;          //姓名 Varchar2	30	不可空
        string dlr;         //代理人 Varchar2	64	可空 对应驾校代码
        string kchp;        //考车号牌    Varchar2	15	可空
        string Jxxh;        //驾校序号 Char	8	可空 对应驾校唯一编号
    }//end of class TMRIQueryResponseItemOf17C07GroupDetail

    /// <summary>
    /// TMRI Query Response Body Item of Book, 17C08
    /// </summary>
    class TMRIQueryResponseItemOf17C08Book : TMRIQueryResponseItem
    {
        /// <summary>
        /// constructor with XmlReader as parameter
        /// </summary>
        /// <param name="reader">XmlReader that point to a TMRI Query Response Body Item (element "drvexam")</param>
        internal TMRIQueryResponseItemOf17C08Book(XmlReader reader) : base(reader)
        {
        }//end of constructor

        /// <summary>
        /// process with this response item
        /// </summary>
        /// <param name="message">output message</param>
        /// <returns>succeed or fail</returns>
        internal override bool process(ref string message)
        {
            bool flag = base.process(ref message);
            try
            {
                mDBM.Query17C08Book(lsh, kskm, zkzmbh, sfzmmc, sfzmhm, xm,
                    ksyy, xxsj, yyrq, ykrq, kscx, ksdd, kscc, kchp,
                    jbr, glbm, dlr, ksrq, kscs, ksy1, ksy2, zt,
                    pxshrq, sfyk, zkykrq, zksfhg, clzl, jly, zkkf,
                    ckyy, ywblbm, yycs, bcyykscs);
            }
            catch (Exception ex)
            {
                message += ex.Message + Console.Out.NewLine;
                flag = false;
            }

            return flag;
        }//end of method

        /// <summary>
        /// read query response item body
        /// </summary>
        /// <param name="reader">XmlReader that point to the first element of item body</param>
        protected override void readItemBody(XmlReader reader)
        {
            while (XmlNodeType.EndElement != reader.NodeType)
            {
                switch (reader.Name.ToLower())
                {
                    case "lsh": lsh = reader.ReadElementContentAsString(); break;
                    case "kskm": kskm = reader.ReadElementContentAsString(); break;
                    case "zkzmbh": zkzmbh = reader.ReadElementContentAsString(); break;
                    case "sfzmmc": sfzmmc = reader.ReadElementContentAsString(); break;
                    case "sfzmhm": sfzmhm = reader.ReadElementContentAsString(); break;
                    case "xm": xm = reader.ReadElementContentAsString(); break;
                    case "ksyy": ksyy = reader.ReadElementContentAsString(); break;
                    case "xxsj": xxsj = reader.ReadElementContentAsString(); break;
                    case "yyrq": yyrq = readElementAsDateTimeString(reader); break;
                    case "ykrq": ykrq = readElementAsDateString(reader); break;
                    case "kscx": kscx = reader.ReadElementContentAsString(); break;
                    case "ksdd": ksdd = reader.ReadElementContentAsString(); break;
                    case "kscc": kscc = reader.ReadElementContentAsString(); break;
                    case "kchp": kchp = reader.ReadElementContentAsString(); break;
                    case "jbr": jbr = reader.ReadElementContentAsString(); break;
                    case "glbm": glbm = reader.ReadElementContentAsString(); break;
                    case "dlr": dlr = reader.ReadElementContentAsString(); break;
                    case "ksrq": ksrq = readElementAsDateString(reader); break;
                    case "kscs": kscs = reader.ReadElementContentAsString(); break;
                    case "ksy1": ksy1 = reader.ReadElementContentAsString(); break;
                    case "ksy2": ksy2 = reader.ReadElementContentAsString(); break;
                    case "zt": zt = reader.ReadElementContentAsString(); break;
                    case "pxshrq": pxshrq = readElementAsDateString(reader); break;
                    case "sfyk": sfyk = reader.ReadElementContentAsString(); break;
                    case "zkykrq": zkykrq = readElementAsDateString(reader); break;
                    case "zksfhg": zksfhg = reader.ReadElementContentAsString(); break;
                    case "clzl": clzl = reader.ReadElementContentAsString(); break;
                    case "jly": jly = reader.ReadElementContentAsString(); break;
                    case "zkkf": zkkf = reader.ReadElementContentAsString(); break;
                    case "ckyy": ckyy = reader.ReadElementContentAsString(); break;
                    case "ywblbm": ywblbm = reader.ReadElementContentAsString(); break;
                    case "yycs": yycs = reader.ReadElementContentAsString(); break;
                    case "bcyykscs": bcyykscs = reader.ReadElementContentAsString(); break;
                    default: reader.ReadElementContentAsString(); break;
                }//end of switch
                reader.MoveToContent();
            }
        }//end of method

        string lsh;         //流水号 Varchar2	13	不可空
        string kskm;        //考试科目 Char	1	不可空	1科目一；2科目二；3科目三
        string zkzmbh;      //准考证明编号 Char	12	不可空
        string sfzmmc;      //身份证明名称 Char	1	不可空
        string sfzmhm;      //身份证明号码 Varchar2	18	不可空
        string xm;          //姓名 Varchar2	30	不可空
        string ksyy;        //考试原因 Char	1	不可空
        string xxsj;           //学习时间 Number      可空
        string yyrq;        //预约日期 Date        不可空 yyyymmddhhmmss
        string ykrq;        //约考日期 Date        不可空 yyyymmdd
        string kscx;        //考试车型 Varchar2	6	不可空
        string ksdd;        //考试地点 Varchar2	64	不可空
        string kscc;           //考试场次 Number      不可空
        string kchp;        //考试车辆号牌 Varchar2	15	可空
        string jbr;         //经办人 Varchar2	30	不可空
        string glbm;        //管理部门 Varchar2	12	不可空
        string dlr;         //代理人 Varchar2	64	可空
        string ksrq;        //考试日期 Date        可空 yyyymmdd
        string kscs;           //考试次数 Number      可空
        string ksy1;        //考试员1 Varchar2	30	可空
        string ksy2;        //考试员2 Varchar2	30	可空
        string zt;          //状态 Char	1	不可空	0未考试；2考试不合格
        string pxshrq;      //培训审核日期 Date        可空 yyyymmdd
        string sfyk;        //是否夜考 Char	1	可空	0否；1是
        string zkykrq;      //桩考约考日期 Date        可空 yyyymmdd
        string zksfhg;      //桩考是否合格 Char	1	可空
        string clzl;        //车辆种类 Varchar2	10	可空
        string jly;         //教练员 Varchar2	30	可空
        string zkkf;           //桩考扣分 Number      可空
        string ckyy;        //场考是否已约 Char	1	不可空	0未预约；1已预约
        string ywblbm;      //业务办理部门 Varchar2	12	不可空
        string yycs;           //预约次数 Number	1	不可空
        string bcyykscs;       //本次预约考试次数 Number	1	不可空
    }//end of class TMRIQueryResponseItemOf17C08Book

    /// <summary>
    /// TMRI Query Response Body Item of Time, 17C09
    /// </summary>
    class TMRIQueryResponseItemOf17C09Time : TMRIQueryResponseItem
    {
        /// <summary>
        /// constructor with XmlReader as parameter
        /// </summary>
        /// <param name="reader">XmlReader that point to a TMRI Query Response Body Item (element "drvexam")</param>
        internal TMRIQueryResponseItemOf17C09Time(XmlReader reader) : base(reader)
        {
        }//end of constructor

        /// <summary>
        /// process with this response item
        /// </summary>
        /// <param name="message">output message</param>
        /// <returns>succeed or fail</returns>
        internal override bool process(ref string message)
        {
            bool flag = base.process(ref message);
            try
            {
                SYSTEMTIME sysTime = new SYSTEMTIME();
                sysTime.wYear = Convert.ToUInt16(sj.Substring(0, 4));
                sysTime.wMonth = Convert.ToUInt16(sj.Substring(4, 2));
                sysTime.wDay = Convert.ToUInt16(sj.Substring(6, 2));
                sysTime.wHour = Convert.ToUInt16(sj.Substring(8, 2));
                sysTime.wMinute = Convert.ToUInt16(sj.Substring(10, 2));
                sysTime.wSecond = Convert.ToUInt16(sj.Substring(12, 2));
                flag = SetLocalTime(ref sysTime);
                if (!flag)
                    message += GetSystemErrorMessage(GetLastError());
            }
            catch (Exception ex)
            {
                message += ex;
                flag = false;
            }
            return flag;
        }//end of method

        /// <summary>
        /// read query response item body
        /// </summary>
        /// <param name="reader">XmlReader that point to the first element of item body</param>
        protected override void readItemBody(XmlReader reader)
        {
            while (XmlNodeType.EndElement != reader.NodeType)
            {
                switch (reader.Name.ToLower())
                {
                    case "sj": sj = readElementAsDateTimeString(reader); break;
                    default: reader.ReadElementContentAsString(); break;
                }//end of switch
                reader.MoveToContent();
            }
        }//end of method

        string sj;          //考试监管系统时间 Date        不可空 yyyymmddhhmmss
    }//end of class TMRIQueryResponseItemOf17C09Time

    /// <summary>
    /// TMRI Query Response Body Item of PhotoTime, 17C57
    /// </summary>
    class TMRIQueryResponseItemOf17C57PhotoTime : TMRIQueryResponseItem
    {
        /// <summary>
        /// constructor with XmlReader as parameter
        /// </summary>
        /// <param name="reader">XmlReader that point to a TMRI Query Response Body Item (element "examphoto")</param>
        internal TMRIQueryResponseItemOf17C57PhotoTime(XmlReader reader) : base(reader)
        {
        }//end of constructor

        /// <summary>
        /// process with this response item
        /// </summary>
        /// <param name="message">output message</param>
        /// <returns>succeed or fail</returns>
        internal override bool process(ref string message)
        {
            bool flag = base.process(ref message);

            return flag;
        }//end of method

        /// <summary>
        /// read query response item body
        /// </summary>
        /// <param name="reader">XmlReader that point to the first element of item body</param>
        protected override void readItemBody(XmlReader reader)
        {
            while (XmlNodeType.EndElement != reader.NodeType)
            {
                switch (reader.Name.ToLower())
                {
                    //case "kssj": kssj = reader.ReadElementContentAsString(); break;
                    case "kssj": kssj = readElementAsDateTimeString(reader); break;
                    default: reader.ReadElementContentAsString(); break;
                }//end of switch
                reader.MoveToContent();
            }
        }//end of method

        internal string kssj;        //所拍摄照片的拍摄时间	Date		不可空	yyyymmddhhmmss
    }//end of class TMRIQueryResponseItemOf17C57PhotoTime

    /// <summary>
    /// TMRI Query Response Body Item of Photo, 17C58
    /// </summary>
    class TMRIQueryResponseItemOf17C58Photo : TMRIQueryResponseItem
    {
        internal Bitmap photo;

        /// <summary>
        /// constructor with XmlReader as parameter
        /// </summary>
        /// <param name="reader">XmlReader that point to a TMRI Query Response Body Item (element "drvphoto")</param>
        internal TMRIQueryResponseItemOf17C58Photo(XmlReader reader) : base(reader)
        {
        }//end of constructor

        /// <summary>
        /// process with this response item
        /// </summary>
        /// <param name="message">output message</param>
        /// <returns>succeed or fail</returns>
        internal override bool process(ref string message)
        {
            bool flag = base.process(ref message);
            byte[] photoBinary = Convert.FromBase64String(zpstr.Replace(' ', '+'));

            MemoryStream ms = new MemoryStream(photoBinary);
            photo = new Bitmap(ms);

            return flag;
        }//end of method

        /// <summary>
        /// read query response item body
        /// </summary>
        /// <param name="reader">XmlReader that point to the first element of item body</paramm
        protected override void readItemBody(XmlReader reader)
        {
            while (XmlNodeType.EndElement != reader.NodeType)
            {
                switch (reader.Name.ToLower())
                {
                    case "zpstr": zpstr = reader.ReadElementContentAsString(); break;
                    case "sfzmhm": sfzmhm = reader.ReadElementContentAsString(); break;
                    default: reader.ReadElementContentAsString(); break;
                }//end of switch
                reader.MoveToContent();
            }
        }//end of method

        string zpstr;       //考生照片 BLOB        不可空 Base64编码的字符串
        string sfzmhm;
    }//end of class TMRIQueryResponseItemOf17C58Photo

    /// <summary>
    /// TMRI Query Response Body Item of Check, 17C61
    /// </summary>
    class TMRIQueryResponseItemOf17C61Check : TMRIQueryResponseItem
    {
        /// <summary>
        /// constructor with XmlReader as parameter
        /// </summary>
        /// <param name="reader">XmlReader that point to a TMRI Query Response Body Item (element "examresult")</param>
        internal TMRIQueryResponseItemOf17C61Check(XmlReader reader) : base(reader)
        {
        }//end of constructor

        /// <summary>
        /// process with this response item
        /// </summary>
        /// <param name="message">output message</param>
        /// <returns>succeed or fail</returns>
        internal override bool process(ref string message)
        {
            bool flag = base.process(ref message);
            throw new NotImplementedException();

            return flag;
        }//end of method

        /// <summary>
        /// read query response item body
        /// </summary>
        /// <param name="reader">XmlReader that point to the first element of item body</param>
        protected override void readItemBody(XmlReader reader)
        {
            while (XmlNodeType.EndElement != reader.NodeType)
            {
                switch (reader.Name.ToLower())
                {
                    case "lsh": lsh = reader.ReadElementContentAsString(); break;
                    case "kskm": kskm = reader.ReadElementContentAsString(); break;
                    case "sfzmhm": sfzmhm = reader.ReadElementContentAsString(); break;
                    case "kssj": kssj = readElementAsDateTimeString(reader); break;
                    case "jssj": jssj = readElementAsDateTimeString(reader); break;
                    case "kcxh": kcxh = reader.ReadElementContentAsString(); break;
                    case "kcmc": kcmc = reader.ReadElementContentAsString(); break;
                    default: reader.ReadElementContentAsString(); break;
                }//end of switch
                reader.MoveToContent();
            }
        }//end of method

        string lsh;         //流水号 Varchar2	13	不可空
        string kskm;        //考试科目 Char	1	不可空
        string sfzmhm;      //身份证明号码 Varchar2	18	不可空
        string kssj;        //考试开始时间 Date        不可空
        string jssj;        //考试结束时间 Date        不可空
        string kcxh;        //考场序号 Varchar2	8	可空
        string kcmc;        //考场名称 Varchar2	128	可空
    }//end of class TMRIQueryResponseItemOf17C61Check
}
