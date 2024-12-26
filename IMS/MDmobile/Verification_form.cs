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

    public partial class Verification_form : Form
    {
        private string work;
        private int OTP;
        private int check_forget_var = 0;

        public Verification_form(string input)
        {
            InitializeComponent();
            work = input;

            
        }

        private void form_component(bool value,string msg)
        {
            lbl_msg.Text = msg;
            txt_code.Visible = !value;
            lbl_code.Visible = !value;
            btn_resend.Visible = !value;
            pictureBox13.Visible = value;
            pic_email.Visible = value;
            pic_email1.Visible = value;
            txt_email.Visible = value;
            pictureBox13.Location = new Point(119, 86);
            pic_email.Location = new Point(140, 100);
            pic_email1.Location = new Point(140, 100);
            txt_email.Location = new Point(170, 102);
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
        
        private void check_load_component()
        {
            Random random = new Random();
            OTP = random.Next(100000, 1000000);

            if (work == "Login")
            {
                if (Email_Send.Send_Email(OTP, Form1.Email, Form1.Username, work))
                {
                    form_component(false, "\t\tNew Device Found! Verify yourself to Login\nEnter Verification Code which is sent to your Email:");
                }
                else
                {
                    this.Close();
                }
            }
            else if (work == "Sign_up")
            {
                if (Email_Send.Send_Email(OTP, Form1.Email, Form1.Username, work))
                {
                    form_component(false, "\t\tWelcome! Verify yourself to create your account\nEnter Verification Code which is sent to your Email:");
                }
                else
                {
                    this.Close();
                }

            }
            else if (work == "Forget")
            {
                form_component(true, "\t\tForget Password! Don't woory\nEnter your email-address to proceed");
                lbl_msg.Focus();
            }
        }

        private void Verification_form_Load(object sender, EventArgs e)
        {
            check_load_component();     // Function Call to which one component is load
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            if(work == "Login")
            {
                if(check_OTP_Input())      // Function Call to check input
                {
                    this.Close();
                }
            }
            else if (work == "Sign_up")
            {
                if (check_OTP_Input())      // Function Call to check input
                {
                    this.Close();
                }
            }
            else if (work == "Forget")
            {
                if(check_forget_var == 0)
                {
                    check_forget();         // Function Call to get Email
                }
                else if(check_forget_var == 1)
                {
                    if (check_OTP_Input())      // Function Call to check input
                    {
                        txt_display_password.Visible = true;
                        txt_display_password.Text = $"Your Password : {Form1.Password}";
                        check_forget_var = 2;
                    }
                }
                
            }

        }

        private bool check_OTP_Input()
        {
            if(!string.IsNullOrEmpty(txt_code.Text))
            {
                int code = int.Parse(txt_code.Text);
                if(code ==  OTP)
                {
                    Form1.OTP_verified = true;
                    return true;
                }
                else
                {
                    MessageBox.Show("Enter Correct Verification Code", "Invalid Input", MessageBoxButtons.OK);
                    txt_code.Clear();
                    txt_code.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Enter Verification Code","Input Required",MessageBoxButtons.OK);
                return false;
            }
        }

        private void check_forget()
        {
            if(string.IsNullOrEmpty(txt_email.Text) || (txt_email.ForeColor == Color.DimGray && txt_email.Text == "Email"))
            {
                MessageBox.Show("Enter Your Email-Address", "Input Required", MessageBoxButtons.OK);
            }
            else
            {
                Form1.Email = txt_email.Text;

                // Check the email from database

                string query = "SELECT password FROM login WHERE email = @email";
                int check_input = sql_con.select_query(query, "checking", Form1.Email, "Forget");

                if (check_input == 1)
                {
                    Random random = new Random();
                    OTP = random.Next(100000, 1000000);

                    if (Email_Send.Send_Email(OTP, Form1.Email, Form1.Username, work))
                    {
                        form_component(false, "To Get Your Password\nEnter the Verification Code : ");
                        check_forget_var = 1;
                        return;
                    }
                }
                else if(check_input == 0)
                {
                    MessageBox.Show("Enter Correct Email-Address", "Invalid Input", MessageBoxButtons.OK);
                    txt_email.Clear();
                    txt_email.Focus();
                }

            }
        }

        private void pictureboxButton1_Click(object sender, EventArgs e)
        {
            if(work == "Login"  ||  work == "Sign_up")
            {
                this.Close();
            }
            else if(work == "Forget")
            {
                if(check_forget_var == 1)
                {
                    check_forget_var = 0;
                    txt_email.Text = "Email";
                    txt_email.ForeColor = Color.DimGray;
                    pic_email1.Visible = false;
                    check_load_component();     // Function Call to which one component is load
                }
                else if(check_forget_var == 0  || check_forget_var == 2)
                {
                    this.Close();
                }
            }
        }

        private void btn_resend_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Random random = new Random();
            OTP = random.Next(100000, 1000000);
            Email_Send.Send_Email(OTP, Form1.Email, Form1.Username, work);
        }
    }

    

}
