using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Summaries
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void resetBTN_Click(object sender, EventArgs e)
        {
            usernameBox.Clear();
            passwordBox.Clear();
        }

        private void login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void loginBTN_Click(object sender, EventArgs e)
        {
            serverResponse response;
            UserSession session;

            string username = usernameBox.Text;
            string password = passwordBox.Text;
            string jsonResponse = LoginValidation(username, password);
            response = JsonConvert.DeserializeObject<serverResponse>(jsonResponse);

            if (response.status)
            {
                session = JsonConvert.DeserializeObject<UserSession>(jsonResponse);
                main mainForm = new main();
                this.Hide();
                mainForm.Show();
            }
            else
            {
                if((response.errors == null) || (response.errors.Length < 1))
                {
                    MessageBox.Show("Username or Password are incorrect.", "Wrong credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Error: " + response.errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private class serverResponse
        {
            public bool status { get; set; }
            public string errors { get; set; }
        }

        /// <summary>
        /// Sends a login request to the server through HTTPS
        /// </summary>
        /// <param name="username">The username given by the user to login</param>
        /// <param name="password">The password given by the user to login</param>
        /// <returns></returns>
        public static string LoginValidation(string username, string password)
        {
            string dadosPOST = "usrnm=" + username + "&psswd=" + password;
            var dados = Encoding.UTF8.GetBytes(dadosPOST);
            var requisicaoWeb = WebRequest.CreateHttp("https://joaogoncalves.myftp.org/restricted/loginvalidator.php");
            requisicaoWeb.Method = "POST";
            requisicaoWeb.ContentType = "application/x-www-form-urlencoded";
            requisicaoWeb.ContentLength = dados.Length;
            requisicaoWeb.UserAgent = "app";
            //precisamos escrever os dados post para o stream
            using (var stream = requisicaoWeb.GetRequestStream())
            {
                stream.Write(dados, 0, dados.Length);
                stream.Close();
            }
            //ler a resposta
            string finalData = "";
            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                finalData = reader.ReadToEnd();
                streamDados.Close();
                resposta.Close();
            }
            return finalData;
        }

        /// <summary>
        /// Escapes special characters in a string for use in an SQL statement.
        /// *** Does not take in account any kind of charset ***
        /// </summary>
        /// <param name="str">The string to be escaped.</param>
        /// <returns></returns>
        private static string MySQLEscape(string str)
        {
            return Regex.Replace(str, @"[\x00'""\b\n\r\t\cZ\\%_]",
                delegate (Match match)
                {
                    string v = match.Value;
                    switch (v)
                    {
                        case "\x00":            // ASCII NUL (0x00) character
                            return "\\0";
                        case "\b":              // BACKSPACE character
                            return "\\b";
                        case "\n":              // NEWLINE (linefeed) character
                            return "\\n";
                        case "\r":              // CARRIAGE RETURN character
                            return "\\r";
                        case "\t":              // TAB
                            return "\\t";
                        case "\u001A":          // Ctrl-Z
                            return "\\Z";
                        default:
                            return "\\" + v;
                    }
                });
        }

        private void passwordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginBTN_Click(sender, e);
            }
        }
    }
}
