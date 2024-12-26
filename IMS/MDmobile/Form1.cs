using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDmobile
{
    

    public partial class Form1 : Form
    {

        public static string Email = "";
        public static string Username = "";
        public static string Password = "";
        public static string user_permissions = "";
        public static bool OTP_verified = false;

        public Form1()
        {
            InitializeComponent();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        { 

            label1.Focus();
            button1.FlatAppearance.BorderSize = 1;
            button3.FlatAppearance.BorderSize = 1;
            pictureBox1.Controls.Add(pictureBox2);
            pictureBox1.Controls.Add(pictureBox6);
            pictureBox1.Controls.Add(pictureBox10);
            pictureBox1.Controls.Add(pictureBox13);
            pictureBox1.Controls.Add(pictureBox16);
            pictureBox1.Controls.Add(label1);
            pictureBox1.Controls.Add(label2);
            pictureBox1.Controls.Add(linkLabel1);
            pictureBox1.Controls.Add(linkLabel2);
            pictureBox1.Controls.Add(linkLabel3);
            pictureBox1.Controls.Add(button3);
            pictureBox1.Controls.Add(button1);

            // Hiding components of sign up

            pic_email1.Visible = false;
            pic_sign_pass1.Visible = false;
            pic_sign_pass_show1.Visible = false;
            pic_sign_username1.Visible = false;
            linkLabel2.Visible = false;
        }

        private void clear_textboxes()
        {

            if (txt_username.ForeColor == Color.Black || txt_password.ForeColor == Color.Black)
            {
                txt_username.Text = "Username";
                txt_username.ForeColor = Color.DimGray;
                txt_password.Text = "Password";
                txt_password.ForeColor = Color.DimGray;
                txt_password.UseSystemPasswordChar = false;
                pic_username1.Visible = false;
                pic_pass1.Visible = false;
                pic_pass_show1.Visible = false;

            }
            if (txt_username1.ForeColor == Color.Black || txt_password1.ForeColor == Color.Black || txt_email.ForeColor == Color.Black)
            {
                txt_email.Text = "Email";
                txt_email.ForeColor = Color.DimGray;
                txt_username1.Text = "Username";
                txt_username1.ForeColor = Color.DimGray;
                txt_password1.Text = "Password";
                txt_password1.ForeColor = Color.DimGray;
                txt_password1.UseSystemPasswordChar = false;
                pic_email1.Visible = false;
                pic_sign_username1.Visible = false;
                pic_sign_pass1.Visible = false;
                pic_sign_pass_show1.Visible = false;
            }

        }

        private void login_component(bool value)
        {
            label1.Visible = value;
            txt_username.Visible = value;
            txt_password.Visible = value;
            pic_username.Visible = value;
            pic_pass.Visible = value;
            pic_pass_show.Visible = value;
            button3.Visible = value;
            linkLabel1.Visible = value;
            pictureBox2.Visible = value;
            pictureBox6.Visible = value;

            if (!value)
            {
                pic_username1.Visible = value;
                pic_pass1.Visible = value;
                pic_pass_show1.Visible = value;
            }

        }

        private void signup_component(bool value)
        {
            label2.Visible = value;
            txt_email.Visible = value;
            txt_password1.Visible = value;
            txt_username1.Visible = value;
            linkLabel3.Visible = value;
            button1.Visible = value;
            pic_email.Visible = value;
            pic_sign_pass.Visible = value;
            pic_sign_pass_show.Visible = value;
            pic_sign_username.Visible = value;
            pictureBox16.Visible = value;
            pictureBox10.Visible = value;
            pictureBox13.Visible = value;

            if(!value)
            {
                pic_email1.Visible = value;
                pic_sign_pass1.Visible = value;
                pic_sign_pass_show1.Visible = value;
                pic_sign_username1.Visible = value;
            }

        }

        private void pictureboxButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureboxButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = true;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox1.Image = Image.FromFile("back_image.gif");

            // Clear all text boxes of login and sign_up
            clear_textboxes();

            // Sign Up components disable
            signup_component(false);

            // Login components visible
            login_component(true);

            
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox1.Image = Image.FromFile("back_image_reverse.gif");

            // Login components disable
            login_component(false);

            // Clear all text boxes of login and sign_up
            //clear_textboxes();

            // Sign Up components visible
            signup_component(true);


        }

        private void txt_username_Validated(object sender, EventArgs e)
        {
            if (txt_username.Text == "")
            {
                txt_username.Text = "Username";
                txt_username.ForeColor = Color.DimGray;
                pic_username1.Visible = false;
            }
        }

        private void txt_username_Enter(object sender, EventArgs e)
        {
            if (txt_username.Text == "Username" && txt_username.ForeColor == Color.DimGray)
            {
                pic_username1.Visible = true;
                txt_username.Text = "";
                txt_username.ForeColor = Color.Black;
            }
        }

        private void txt_username1_Validated(object sender, EventArgs e)
        {
            if (txt_username1.Text == "")
            {
                txt_username1.Text = "Username";
                txt_username1.ForeColor = Color.DimGray;
                pic_sign_username1.Visible = false;
            }
        }

        private void txt_username1_Enter(object sender, EventArgs e)
        {
            if (txt_username1.Text == "Username" && txt_username.ForeColor == Color.DimGray)
            {
                pic_sign_username1.Visible = true;
                txt_username1.Text = "";
                txt_username1.ForeColor = Color.Black;
            }
        }

        private void txt_password_Validated(object sender, EventArgs e)
        {
            if (txt_password.Text == "")
            {
                txt_password.UseSystemPasswordChar = false;
                txt_password.Text = "Password";
                txt_password.ForeColor = Color.DimGray;
                pic_pass1.Visible = false;
            }
        }

        private void txt_password_Enter(object sender, EventArgs e)
        {
            if (txt_password.Text == "Password" && txt_password.ForeColor == Color.DimGray)
            {
                txt_password.UseSystemPasswordChar = true;
                pic_pass1.Visible = true;
                txt_password.Text = "";
                txt_password.ForeColor = Color.Black;
            }
        }

        private void txt_email_Validated(object sender, EventArgs e)
        {
            if (txt_email.Text == "")
            {
                txt_email.Text = "Email";
                txt_email.ForeColor = Color.DimGray;
                pic_email1.Visible = false;
            }
        }

        private void txt_email_Enter(object sender, EventArgs e)
        {
            if (txt_email.Text == "Email" && txt_email.ForeColor == Color.DimGray)
            {
                pic_email1.Visible = true;
                txt_email.Text = "";
                txt_email.ForeColor = Color.Black;
            }
        }

        private void txt_password1_Validated(object sender, EventArgs e)
        {
            if (txt_password1.Text == "")
            {
                txt_password1.UseSystemPasswordChar = false;
                txt_password1.Text = "Password";
                txt_password1.ForeColor = Color.DimGray;
                pic_sign_pass1.Visible = false;
            }
        }

        private void txt_password1_Enter(object sender, EventArgs e)
        {
            if (txt_password1.Text == "Password" && txt_password1.ForeColor == Color.DimGray)
            {
                txt_password1.UseSystemPasswordChar = true;
                pic_sign_pass1.Visible = true;
                txt_password1.Text = "";
                txt_password1.ForeColor = Color.Black;
            }
        }
        
        private void txt_password1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pic_sign_pass_show1_Click(object sender, EventArgs e)
        {
            if (txt_password1.Text != "Password" && txt_password1.ForeColor != Color.DimGray)
            {
                txt_password1.UseSystemPasswordChar = true;
            }
            pic_sign_pass_show1.Visible = false;
        }

        private void pic_pass_show1_Click(object sender, EventArgs e)
        {
            if (txt_password.Text != "" && txt_password.ForeColor != Color.DimGray)
            {
                txt_password.UseSystemPasswordChar = true;
            }
            pic_pass_show1.Visible = false;

        }

        private void pic_pass_show_Click(object sender, EventArgs e)
        {
            txt_password.UseSystemPasswordChar = false;
            pic_pass_show1.Visible = true;
        }

        private void pic_sign_pass_show_Click(object sender, EventArgs e)
        {
            txt_password1.UseSystemPasswordChar = false;
            pic_sign_pass_show1.Visible = true;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Username = txt_username.Text;
            Password = txt_password.Text;

            if (string.IsNullOrEmpty(Username) || (txt_username.ForeColor == Color.DimGray && txt_username.Text == "Username"))
            {
                MessageBox.Show("Enter Your Username", "Input Required", MessageBoxButtons.OK);
                return;
            }
            if (string.IsNullOrEmpty(Password) || (txt_password.ForeColor == Color.DimGray && txt_password.Text == "Password"))
            {
                MessageBox.Show("Enter Your Password", "Input Required", MessageBoxButtons.OK);
                return;
            }

            string query = "SELECT * FROM login WHERE username = @username AND password = @password";
            int select_value = sql_con.select_query(query, Username, Password, "Login");
            if (select_value == 1)
            {
                string address = Email_Send.get_mac_address();
                select_value = sql_con.select_address_query(Username, address);

                if (select_value == 0)
                {
                    clear_textboxes();  // Clear the textboxes
                    login_component(false);
                    Verification_form newform = new Verification_form("Login");
                    newform.ShowDialog();
                    login_component(true);

                    if (OTP_verified)
                    {
                        if (sql_con.insert_address_query(Username, address))
                        {
                            MessageBox.Show("Login Successfully", "Successfull", MessageBoxButtons.OK);
                            OTP_verified = false;
                            Dashboard newform1 = new Dashboard(user_permissions);
                            this.Visible = false;
                            newform1.ShowDialog();
                        }
                    }
                }
                else if(select_value == 1)
                {
                    MessageBox.Show("Login Successfully", "Successfull", MessageBoxButtons.OK);
                    clear_textboxes();  // Clear the textboxes
                    Dashboard newform1 = new Dashboard(user_permissions);
                    this.Visible = false;
                    newform1.ShowDialog();
                    return;
                }
                
            }
            else if(select_value == 0)
            {
                MessageBox.Show("Invalid Username or Password", "Login Denied", MessageBoxButtons.OK);
                clear_textboxes();  // Clear the textboxes
                return;
            }

            

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            login_component(false);
            Verification_form newform = new Verification_form("Forget");
            newform.ShowDialog();

            login_component(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Email = txt_email.Text;
           Username = txt_username1.Text;
           Password = txt_password1.Text;

            if (string.IsNullOrEmpty(Email) ||  (txt_email.ForeColor == Color.DimGray   &&  txt_email.Text == "Email"))
            {
                MessageBox.Show("Enter Your Email Address","Input Required",MessageBoxButtons.OK);
                txt_email.Focus();
                return;
            }
            if (string.IsNullOrEmpty(Username) || (txt_username1.ForeColor == Color.DimGray && txt_username1.Text == "Username"))
            {
                MessageBox.Show("Enter Your Username", "Input Required", MessageBoxButtons.OK);
                txt_username1.Focus();
                return;
            }
            if (string.IsNullOrEmpty(Password) || (txt_password1.ForeColor == Color.DimGray && txt_password1.Text == "Password"))
            {
                MessageBox.Show("Enter Your Password", "Input Required", MessageBoxButtons.OK);
                txt_password1.Focus();
                return;
            }

            

            string query = "SELECT COUNT(*) FROM login WHERE username = @username OR email = @email";
            int check_input = sql_con.select_query(query, Username, Email,"Sign_up");

            if(check_input == 1 )
            {
                MessageBox.Show("This User already contained", "Change Credentials", MessageBoxButtons.OK);
                clear_textboxes();      // Clear the textboxes
                return;
            }

            if(check_input == 0)
            {

                // Clear all text boxes of login and sign_up
                clear_textboxes();
                signup_component(false);
                Verification_form newform = new Verification_form("Sign_up");
                newform.ShowDialog();
                signup_component(true);

                if (OTP_verified)
                 {
                    if (sql_con.insert_query(Username, Password, Email))
                    {
                        MessageBox.Show("New User Signed In Successfully\nNow you can Login", "SuccessFull", MessageBoxButtons.OK);
                        OTP_verified = false;

                        pictureBox1.Image = Image.FromFile("back_image.gif");
                        // Sign Up components disable
                        signup_component(false);

                        // Login components visible
                        login_component(true);
                    }
                        
                 }
                
            }


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
