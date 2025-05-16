using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace Lern_Oeriode_4
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string vorname = textBox1.Text.Trim();
            string nachname = textBox2.Text.Trim();
            string benutzername = textBox3.Text.Trim();
            string email = textBox4.Text.Trim();
            string passwort = textBox5.Text.Trim();

            if (string.IsNullOrEmpty(vorname) || string.IsNullOrEmpty(nachname) ||
                string.IsNullOrEmpty(benutzername) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(passwort))
            {
                MessageBox.Show("Bitte alle Felder ausfüllen!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string verbindung = @"Data Source = C:\\Users\\gianl\\source\\repos\\Lern-Oeriode-4\\Lern-Oeriode-4\\BlackJack.db";

            using (var connection = new SqliteConnection(verbindung))
            {
                connection.Open();

               
                string checkSql = "SELECT COUNT(*) FROM benutzer WHERE benutzername = @bn OR email = @em";
                using (var checkCmd = new SqliteCommand(checkSql, connection))
                {
                    checkCmd.Parameters.AddWithValue("@bn", benutzername);
                    checkCmd.Parameters.AddWithValue("@em", email);

                    long existiert = (long)checkCmd.ExecuteScalar();
                    if (existiert > 0)
                    {
                        MessageBox.Show("Benutzername oder E-Mail ist bereits vergeben.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                
                string insertSql = @"
                    INSERT INTO benutzer 
                    (vorname, nachname, benutzername, email, passwort, registriert_am, guthaben_geld, guthaben_jetons)
                    VALUES 
                    (@vorname, @nachname, @benutzername, @email, @passwort, @registriert_am, @geld, @jetons)";

                using (var cmd = new SqliteCommand(insertSql, connection))
                {
                    cmd.Parameters.AddWithValue("@vorname", vorname);
                    cmd.Parameters.AddWithValue("@nachname", nachname);
                    cmd.Parameters.AddWithValue("@benutzername", benutzername);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@passwort", passwort);
                    cmd.Parameters.AddWithValue("@registriert_am", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@geld", 10000);
                    cmd.Parameters.AddWithValue("@jetons", 0);

                    try
                    {
                       
                        
                        this.Hide();
                        var loginForm = new LogIn();
                        loginForm.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Fehler bei der Registrierung:\n" + ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
