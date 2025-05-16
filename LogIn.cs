using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Microsoft.Data.Sqlite;

namespace Lern_Oeriode_4
{
    public partial class LogIn : Form
    {

        public SqliteConnection connection;

        public LogIn()
        {
            InitializeComponent();
            string connectionString = @"Data Source = C:\\Users\\gianl\\source\\repos\\Lern-Oeriode-4\\Lern-Oeriode-4\\BlackJack.db";
            connection = new SqliteConnection(connectionString);
            connection.Open();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string eingabe = textBox1.Text.Trim(); 
            string passwort = textBox2.Text.Trim();     

            string sql = @"
        SELECT COUNT(*) 
        FROM benutzer 
        WHERE (benutzername = @eingabe OR email = @eingabe)
        AND passwort = @passwort";

            using (var cmd = new SqliteCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@eingabe", eingabe);
                cmd.Parameters.AddWithValue("@passwort", passwort);

                long treffer = (long)cmd.ExecuteScalar();

                if (treffer > 0)
                {                    
                    MessageBox.Show("Login erfolgreich!", "Willkommen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    new Form1().Show();
                    this.Hide();
                }
                else
                {
                    
                    MessageBox.Show("Benutzername oder Passwort falsch", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

         
        private void button2_Click(object sender, EventArgs e)
        {
            
            register registrieren = new register(); 
            registrieren.Show();           
            this.Hide();
        }
    }
}
