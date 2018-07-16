using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void cmdGO_Click(object sender, EventArgs e)
        {
            RestClient rClient = new RestClient();
            rClient.endpoint = "http://services.groupkt.com/state/get/USA/" + comboBox1.Text+".json";

            //string strResponse = String.Empty;

            txtResponse.Text = rClient.makeRequest();
        }
    }
}
