using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minecraft_Launcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
            panel1.BorderStyle = BorderStyle.FixedSingle; // this should fix the boarder style
            // plot twist, it actually did not worked, i had to create the boarder style myself trough panel
            
           

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://mail.google.com/mail/?view=cm&fs=1&to=contioldmc@gmail.com");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // checks if the account and password are filled
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                // if some details arent filled in
                MessageBox.Show("Please fill in all details. (Account and Password).", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string username = textBox1.Text;
                string password = textBox2.Text;

                // Verify that the username and password are correct
                if ((username == "cowweb" || username == "puppiu") && password == "goldenager")
                {
                    // this gets the path to the folder where the EXE is (IMPORTANT)
                    string basePath = AppDomain.CurrentDomain.BaseDirectory;

                    // Relative paths to folders and files
                    string minecraftJar = Path.Combine(basePath, "jars", "b1.2.jar");
                    string librariesPath = Path.Combine(basePath, "libraries");
                    string nativesPath = Path.Combine(basePath, "natives");

                    try
                    {
                        // Setting the classpath to run Minecraft (IMPORTANT)
                        string classpath =
                            $"\"{minecraftJar}\";" +
                            $"\"{Path.Combine(librariesPath, "lwjgl.jar")}\";" +
                            $"\"{Path.Combine(librariesPath, "lwjgl_util.jar")}\";" +
                            $"\"{Path.Combine(librariesPath, "jinput.jar")}\"";

                        // Starting a Minecraft process (IMPORTANT)
                        var startInfo = new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = "java",
                            Arguments = $"-Xmx2G -Xms1G -Djava.library.path=\"{nativesPath}\" -cp {classpath} net.minecraft.client.Minecraft {username}",
                            WorkingDirectory = Path.GetDirectoryName(minecraftJar),
                            UseShellExecute = false,
                            CreateNoWindow = true
                        };

                        System.Diagnostics.Process.Start(startInfo);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error trying to run the game: {ex.Message}", "Mistakes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // If the user enters the wrong name or password
                    MessageBox.Show("Invalid username or password. Please try again.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }









        // dont know why that is here but if i delete it, the code just stops working,,


        private void versionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }


    }

    
    
    
    

