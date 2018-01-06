/*
SecureMessage
VERSION: 1.0

Inputs: Message to encrypt.

Outputs: Encrypted message.

Description: This software tool allows to encrypt and decrypt a message.

Developer: Nicolas CHEN
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SecureMessage
{
    public class SpecialMessageBox
    {
        public void MessageBoxMultiLines(IEnumerable<string> lines)
        {
            var instructionLine = new StringBuilder();
            bool firstLine = false;
            foreach (string line in lines)
            {
                if (firstLine)
                    instructionLine.Append(Environment.NewLine);

                instructionLine.Append(line);
                firstLine = true;
            }
            MessageBox.Show(instructionLine.ToString(), "Information");
        }
    }
}