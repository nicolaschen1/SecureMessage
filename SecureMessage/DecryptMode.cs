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
    public partial class DecryptMode : Form
    {
        public DecryptMode()
        {
            InitializeComponent();
        }


        /*** MENU BAR ***/
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

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void instructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpecialMessageBox multiLines = new SpecialMessageBox();

            string[] instructions = new string[]
            {
                "DECRYPT MODE"
                , ""
                , "1) Enter your cipher message."
                , ""
                , "2) Click on 'Decrypt the message' to get the initial message."        
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

        private void clearButton_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(encryptedMessage.Text))
            {
                errorProvider1.SetError(encryptedMessage, "Enter the message you want to decrypt");
            }
            else
            {
                errorProvider1.Clear();
                string encryptedText = encryptedMessage.Text.Trim();

                try
                {
                    string decryptedText = SecurityEngine.DecryptMessage(encryptedText, true);
                    decryptedMessage.Text = decryptedText;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.ToString());
                    MessageBox.Show("This is not an encrypted message. Please make sure to enter an encrypted message.","Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    Reset();
                }                
            }
        }


        /*** METHODS ***/
        public void Reset()
        {
            encryptedMessage.Text = String.Empty;
            decryptedMessage.Text = String.Empty;
        }

        private void encryptedMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                if (sender != null)
                    ((TextBox)sender).SelectAll();
            }
        }

        private void decryptedMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                if (sender != null)
                    ((TextBox)sender).SelectAll();
            }
        }
    }
}