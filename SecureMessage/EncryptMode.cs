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
    public partial class EncryptMode : Form
    {
        public EncryptMode()
        {
            InitializeComponent();
        }

        /*** MENU BAR ***/
        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void backToMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            SecureMessage menuWindow = new SecureMessage();
            menuWindow.Show();
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
                "ENCRYPT MODE"
                , ""
                , "1) Enter your message."
                , ""
                , "2) Click on 'Encrypt the message' to cipher your message."
                , ""
                , "3) Copy the encrypted message and paste in a text file."
                , ""
                , "4) Send this text file to your recipient."
                , ""
                , "5) The recipient shall use this tool to decrypt your message."                
            };

            multiLines.MessageBoxMultiLines(instructions);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SecureMessage developed by Nicolas Chen", "About");
        }


        /*** BUTTONS ***/
        private void backMenuButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            SecureMessage menuWindow = new SecureMessage();
            menuWindow.Show();            
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(initialMessage.Text))
            {
                errorProvider1.SetError(initialMessage, "Enter the message you want to encrypt");
            }
            else
            {
                errorProvider1.Clear();
                string clearText = initialMessage.Text.Trim();
                string cipherText = SecurityEngine.EncryptMessage(clearText, true);
                cipherMessage.Text = cipherText;                
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            Reset();
        }


        /*** METHODS ***/
        public void Reset()
        {
            initialMessage.Text = String.Empty;
            cipherMessage.Text = String.Empty;
        }

        private void initialMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                if (sender != null)
                    ((TextBox)sender).SelectAll();
            }
        }

        private void cipherMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                if (sender != null)
                    ((TextBox)sender).SelectAll();
            }
        }
    }
}
