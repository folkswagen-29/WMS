using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace onlineLegalWF.Class
{
    public class ReplaceCommRegis
    {
        #region Public
        public DbControllerBase zdb = new DbControllerBase();
        public string zconnstr = ConfigurationManager.AppSettings["BPMDB"].ToString();
        public string zconnstrrpa = ConfigurationManager.AppSettings["RPADB"].ToString();
        public WFFunctions zwf = new WFFunctions();
        #endregion

        public DataTable genTagData(ReplaceCommRegis_TagData data)
        {
            DataTable dtStr = new DataTable();
            dtStr.Columns.Add("tagname", typeof(string));
            dtStr.Columns.Add("tagvalue", typeof(string));

            DataRow dr0 = dtStr.NewRow();
            dr0["tagname"] = "#docno#";
            dr0["tagvalue"] = (!string.IsNullOrEmpty(data.docno) ? data.docno.Replace(",", "!comma") : "");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#subject#";
            dr0["tagvalue"] = (!string.IsNullOrEmpty(data.subject) ? data.subject.Replace(",", "!comma") : "");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#companyname_th#";
            dr0["tagvalue"] = (!string.IsNullOrEmpty(data.companyname_th) ? data.companyname_th.Replace(",", "!comma") : "");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#companyname_en#";
            dr0["tagvalue"] = (!string.IsNullOrEmpty(data.companyname_en) ? data.companyname_en.Replace(",", "!comma") : "");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#reqdate#";
            dr0["tagvalue"] = (!string.IsNullOrEmpty(data.reqdate) ? data.reqdate.Replace(",", "!comma") : ""); // Utillity.ConvertDateToLongDateTime(xreq_date, "en");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#mt_res_desc#";
            dr0["tagvalue"] = (!string.IsNullOrEmpty(data.mt_res_desc) ? data.mt_res_desc.Replace(",", "!comma") : "");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#mt_res_no#";
            dr0["tagvalue"] = (!string.IsNullOrEmpty(data.mt_res_no) ? data.mt_res_no.Replace(",", "!comma") : "");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#mt_res_date#";
            dr0["tagvalue"] = (!string.IsNullOrEmpty(data.mt_res_date) ? data.mt_res_date.Replace(",", "!comma") : "");
            dtStr.Rows.Add(dr0);

            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#name1#";
            dr0["tagvalue"] = (!string.IsNullOrEmpty(data.name1) ? data.name1.Replace(",", "!comma") : "");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#position1#";
            dr0["tagvalue"] = (!string.IsNullOrEmpty(data.position1) ? data.position1.Replace(",", "!comma") : "");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#date1#";
            dr0["tagvalue"] = (!string.IsNullOrEmpty(data.date1) ? data.date1.Replace(",", "!comma") : "");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#sign_name1#";
            dr0["tagvalue"] = (!string.IsNullOrEmpty(data.sign_name1) ? data.sign_name1.Replace(",", "!comma") : "");
            dtStr.Rows.Add(dr0);

            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#name2#";
            dr0["tagvalue"] = (!string.IsNullOrEmpty(data.name2) ? data.name2.Replace(",", "!comma") : "");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#position2#";
            dr0["tagvalue"] = (!string.IsNullOrEmpty(data.position2) ? data.position2.Replace(",", "!comma") : "");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#date2#";
            dr0["tagvalue"] = (!string.IsNullOrEmpty(data.date2) ? data.date2.Replace(",", "!comma") : "");
            dtStr.Rows.Add(dr0);
            dr0 = dtStr.NewRow();
            dr0["tagname"] = "#sign_name2#";
            dr0["tagvalue"] = (!string.IsNullOrEmpty(data.sign_name2) ? data.sign_name2.Replace(",", "!comma") : "");
            dtStr.Rows.Add(dr0);
            return dtStr;
        }

        public DataTable BindTagData(string xprocess_id, ReplaceCommRegis_TagData data)
        {
            ReplaceCommRegis_TagData res = new ReplaceCommRegis_TagData();

            string sql0 = @"SELECT [process_id],[req_no],[req_date],commreg.[toc_regis_code],toc.[toc_regis_desc],commreg.[subsidiary_code],[document_no],[mt_res_desc],[mt_res_no],[mt_res_date],
                                      CASE
                                        WHEN commreg.subsidiary_code IS NULL THEN commreg.company_name_th
                                        ELSE comsub.subsidiary_name_th
                                      END AS company_name_th,
                                      CASE
                                        WHEN commreg.subsidiary_code IS NULL THEN commreg.company_name_en
                                        ELSE comsub.subsidiary_name_en
                                      END AS company_name_en,
                                      [isrdregister],[status],[updated_datetime]
                                      FROM li_comm_regis_request AS commreg
                                      LEFT OUTER JOIN li_comm_regis_subsidiary AS comsub ON commreg.subsidiary_code = comsub.subsidiary_code
                                      INNER JOIN li_type_of_comm_regis AS toc ON commreg.toc_regis_code = toc.toc_regis_code
                              where process_id = '" + xprocess_id + "'";
            var dt0 = zdb.ExecSql_DataTable(sql0, zconnstr);
            if (dt0.Rows.Count > 0)
            {
                var dr0 = dt0.Rows[0];
                res.docno = dr0["document_no"].ToString();
                res.subject = dr0["toc_regis_desc"].ToString();
                res.companyname_th = dr0["company_name_th"].ToString();
                res.companyname_en = dr0["company_name_en"].ToString();
                res.reqdate = Utillity.ConvertDateToLongDateTime(Convert.ToDateTime(dr0["req_date"]), "en");
                res.mt_res_desc = dr0["mt_res_desc"].ToString();
                res.mt_res_no = dr0["mt_res_no"].ToString();
                res.mt_res_date = dr0["mt_res_date"].ToString();
                res.name1 = data.name1;
                res.position1 = data.position1;
                res.date1 = data.date1;
                res.name2 = data.name2;
                res.position2 = data.position2;
                res.date2 = data.date2;
            }

            string sql = "select * from wf_routing where process_id = '" + xprocess_id + "' ";
            var dt1 = zdb.ExecSql_DataTable(sql, zconnstr);
            if (dt1.Rows.Count > 0)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    var dr = dt1.Rows[i];

                    //if (dr["step_name"].ToString() == "GM Approve" && xexternal_domain == "N")
                    //{
                    //    res.name1 = data.name1;
                    //    res.position1 = data.position1;
                    //    res.date1 = data.date1;
                    //    if (dr["wf_status"].ToString() != "" && dr["updated_datetime"].ToString() != "")
                    //    {
                    //        res.sign_name1 = "Approved by system";
                    //        res.date1 = Utillity.ConvertDateToLongDateTime(Convert.ToDateTime(dr["updated_datetime"]), "en");
                    //    }
                    //}
                    //else if (dr["step_name"].ToString() == "Head AM Approve")
                    //{
                    //    res.name1 = data.name1;
                    //    res.position1 = data.position1;
                    //    res.date1 = data.date1;
                    //    if (dr["wf_status"].ToString() != "" && dr["updated_datetime"].ToString() != "")
                    //    {
                    //        res.sign_name1 = "Approved by system";
                    //        res.date1 = Utillity.ConvertDateToLongDateTime(Convert.ToDateTime(dr["updated_datetime"]), "en");
                    //    }
                    //}
                    //else if (dr["step_name"].ToString() == "Insurance Specialist Approve")
                    //{
                    //    if (dr["wf_status"].ToString() != "" && dr["updated_datetime"].ToString() != "")
                    //    {
                    //        res.sign_name2 = "Approved by system";
                    //        res.date2 = Utillity.ConvertDateToLongDateTime(Convert.ToDateTime(dr["updated_datetime"]), "en");
                    //    }
                    //}
                    //else if (dr["step_name"].ToString() == "Head of Compliance and Insurance Approve")
                    //{

                    //    if (dr["wf_status"].ToString() != "" && dr["updated_datetime"].ToString() != "")
                    //    {
                    //        res.sign_name22 = "Approved by system";
                    //        res.date22 = Utillity.ConvertDateToLongDateTime(Convert.ToDateTime(dr["updated_datetime"]), "en");
                    //    }
                    //}
                    //else if (dr["step_name"].ToString() == "Head of Legal Approve")
                    //{

                    //    if (dr["wf_status"].ToString() != "" && dr["updated_datetime"].ToString() != "")
                    //    {
                    //        res.sign_name3 = "Approved by system";
                    //        res.date3 = Utillity.ConvertDateToLongDateTime(Convert.ToDateTime(dr["updated_datetime"]), "en");
                    //    }
                    //}
                    //else if (dr["step_name"].ToString() == "Head of Risk Management Approve")
                    //{
                    //    if (dr["wf_status"].ToString() != "" && dr["updated_datetime"].ToString() != "")
                    //    {
                    //        res.sign_name4 = "Approved by system";
                    //        res.date4 = Utillity.ConvertDateToLongDateTime(Convert.ToDateTime(dr["updated_datetime"]), "en");
                    //    }
                    //}
                    //else if (dr["step_name"].ToString() == "CCO Approve")
                    //{
                    //    if (dr["wf_status"].ToString() != "" && dr["updated_datetime"].ToString() != "")
                    //    {
                    //        res.cb1 = "X";
                    //        res.sign_name5 = "Approved by system";
                    //        res.date5 = Utillity.ConvertDateToLongDateTime(Convert.ToDateTime(dr["updated_datetime"]), "en");
                    //    }
                    //}

                }
            }

            var dtStr = genTagData(res);
            return dtStr;
        }

        public class ReplaceCommRegis_TagData
        {
            public string docno { get; set; }
            public string subject { get; set; }
            public string companyname_th { get; set; }
            public string companyname_en { get; set; }
            public string reqdate { get; set; }
            public string mt_res_desc { get; set; }
            public string mt_res_no { get; set; }
            public string mt_res_date { get; set; }

            public string sign_name1 { get; set; }
            public string name1 { get; set; }
            public string position1 { get; set; }
            public string date1 { get; set; }

            public string sign_name2 { get; set; }
            public string name2 { get; set; }
            public string position2 { get; set; }
            public string date2 { get; set; }


        }
    }
}