using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Net.NetworkInformation;


namespace MDmobile
{
    public class Email_Send
    {

        public static string get_mac_address()
        {
            var address = NetworkInterface.GetAllNetworkInterfaces();
            foreach (var add in address)
            {
                if (add.OperationalStatus == OperationalStatus.Up)
                {
                    return add.GetPhysicalAddress().ToString();
                }
            }
            return null;
        }

        public static bool Send_Email(int code,string recipent,string pass_name,string sender_msg)
        {
            
            try
            {

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587, // Common port for TLS
                    Credentials = new NetworkCredential("muhammadmaaz0017@gmail.com", "clhlgbwqbqxpmbwc"),
                    EnableSsl = true // Secure the connection
                };



                if(sender_msg == "Login")
                {
                    sender_msg = $"Hey {pass_name} \nI hope you are fine\n\nA login attempt requires further verification because we did not recognize your device. To complete the login, enter the verification code on the unrecognized device.\n\nVerification code: {code}\n\nIf you did not attempt to login to your account, your password may be compromised. kindly create a new, strong password for secure your account.\n\nBest Regards,\nMuhammad Maaz";
                }
                else if (sender_msg == "Sign_up")
                {
                    sender_msg = $"Dear {pass_name},\nThank you for signing up on our app. To ensure your account's security, we require email verification.\n\nVerification Code: {code}\n\nPlease enter this OTP code on our app to complete verification:\nIf you didn't request this verification, please ignore this email.\n\nContact us at [MuhammadMaaz@gmail.com] or [0316-8563659] if you face any issues.\n\nBest regards,\n[Muhammad Maaz]";
                }
                else if (sender_msg == "Forget")
                {
                    sender_msg = $"Hey {pass_name} \nForgot your password? No worries!\n\nA forget password attempt requires further verification because we did not recognize you. To complete this, enter the verification code on your device.\n\nVerification code: {code}\n\nIf you didn't request this reset, please ignore this email.\n\nBest Regards,\nMuhammad Maaz";
                }

                // Create the MailMessage instance
                MailMessage mail = new MailMessage("muhammadmaaz0017@gmail.com", recipent, "Verification Email", sender_msg);

                // Send the email
                smtpClient.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error Occur",MessageBoxButtons.OK);
                return false;
            }
        }
    }
}
