using System;
using System.Windows.Forms;

namespace CarClient
{
    public partial class Form1 : Form
    {
        private CarWS.ClientInterfaceClient service;

        public Form1()
        {
            InitializeComponent();
            service = new CarWS.ClientInterfaceClient();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = service.loginCustomer(this.mail.Text, this.password.Text);
            if ( id > 0 )
            {
                this.status.Text = "Login success";
                this.Hide();
                Form2 form2 = new Form2(id);
                form2.ShowDialog();
                this.Close();
            } else
            {
                this.status.Text = "Login error";
            }
        }

        private void addAccount_Click(object sender, EventArgs e)
        {
            status2.Text = "Creating account..";

            if ( service.addAccount(newName.Text, newSurname.Text, newMail.Text, newPassword.Text) )
            {
                status2.Text = "Account created.";
            } else
            {
                status2.Text = "Creating error";
            }
            
        }
    }
}
