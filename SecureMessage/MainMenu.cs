/*
SecureMessage
VERSION: 1.0

Inputs: Message to encrypt.

Outputs: Encrypted message.

Description: This software tool allows to encrypt and decrypt a message.

Developer: Nicolas CHEN
*/

using System;
using System.Windows.Forms;

namespace SecureMessage
{
    public partial class SecureMessage : Form
    {
        public SecureMessage()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void instructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpecialMessageBox multiLines = new SpecialMessageBox();

            string[] instructions = new string[]
            {
                "Welcome to Secure Message Software Tool"
                , ""
                , "This software tool aims to encrypt and decrypt a message."
                , ""
                , "There are two modes:"
                , ""
                , "1) Encrypt the message."
                , ""
                , "2) Decrypt the message"
            };

            multiLines.MessageBoxMultiLines(instructions);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpecialMessageBox multiLinesAbout = new SpecialMessageBox();

            string[] about = new string[]
            {
                "Secure Message Software Tool"
                , ""
                , "VERSION: 1.0"
                , ""
                , "Developed by Nicolas Chen"
            };

            multiLinesAbout.MessageBoxMultiLines(about);
        }

        private void encryptMode_Click(object sender, EventArgs e)
        {
            this.Hide();
            EncryptMode encryptWindow = new EncryptMode();
            encryptWindow.Show();           
        }

        private void decryptMode_Click(object sender, EventArgs e)
        {
            this.Hide();
            DecryptMode decryptWindow = new DecryptMode();
            decryptWindow.Show();
        }
    }
}