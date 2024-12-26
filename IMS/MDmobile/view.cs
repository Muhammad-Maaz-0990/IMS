using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace MDmobile
{
    public partial class view : Form
    {
        public int id;
        DataTable dtt;
        String name;
        String date;
        String netbill;
        String received = "0";
        String pre = "0";
        String balance = "0";
        public view(DataTable dt, String na, String date1, int iD,String net,String rece,String pr,String bal)
        {
            InitializeComponent();
            id = iD;
            dtt = dt;
            name = na;
            date = date1;
            netbill = net;
            received = rece;
            pre = pr;
            balance = bal;
        }

        private void view_Load(object sender, EventArgs e)
        {
            bill rpt = new bill();
            TextObject text = (TextObject)rpt.ReportDefinition.Sections["Section1"].ReportObjects["id"];
            text.Text = id.ToString();
            text = (TextObject)rpt.ReportDefinition.Sections["Section1"].ReportObjects["date"];
            text.Text = date;
            text = (TextObject)rpt.ReportDefinition.Sections["Section1"].ReportObjects["nm"];
            text.Text = name;
            text = (TextObject)rpt.ReportDefinition.Sections["Section4"].ReportObjects["netbill"];
            text.Text = netbill;
            text = (TextObject)rpt.ReportDefinition.Sections["Section4"].ReportObjects["Text3"];
            text.Text = received;
            text = (TextObject)rpt.ReportDefinition.Sections["Section4"].ReportObjects["Text8"];
            text.Text = pre;
            text = (TextObject)rpt.ReportDefinition.Sections["Section4"].ReportObjects["Text15"];
            text.Text = balance;
            rpt.Database.Tables["dt1"].SetDataSource(dtt);
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
