using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lern_Oeriode_4
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string benutzername = textBox1.Text;
            string passwort = textBox2.Text;

            string verbindung = "Server=.;Database=firstdatabank;Trusted_Connection=True;";

            using(SqlConnection conn = new SqlConnection(verbindung))
            {
                conn.Open();
            }
        }
    }
}
