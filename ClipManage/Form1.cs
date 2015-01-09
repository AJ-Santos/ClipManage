using System;
using System.Windows.Forms;

// ClipMange is a small Cilpboard manager. It can copy, paste, and clear the clipboard.
// Logged build dates: 
//		Start 12/28/13 @ 3:58pm End 12/28/13 @ 5:30pm
//		Start 1/22/14 @ 9:00pm End 1/22/14 @
// © 2014 Antonio Santos
namespace ClipManage
{
    public partial class Form1 : Form
    {	

		public static string clipText = Clipboard.GetText();

        /// <summary>
        /// Paste the contents of the clipboard once the program
        /// starts.
        /// </summary>
        private void onProgramStart()
        {
            textClipboard.Text = clipText;
        }

        public Form1()
        {
            InitializeComponent();
            onProgramStart();
        }

        // Clears the text box and the clipboard
        private void clearButton_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            textClipboard.Clear();
        }

        // Copies the text in the text box to the clipboard.
        private void copyButton_Click(object sender, EventArgs e)
        {

			if (textClipboard.Text == "")
				{
					const string message = "There is no text to copy to the Clipboard.";
					const string caption = "Error!";
					MessageBox.Show(message, caption,
							MessageBoxButtons.OK,
							MessageBoxIcon.Error);

				}
			
			else
				{
					Clipboard.SetText(textClipboard.Text);
						// Display a MessageBox to inform the user that 
						// the text has been copied to the Clipboard.
						const string message = "Your text has been copied to the Clipboard.";
						const string caption = "Text Copied"; 
						MessageBox.Show(message, caption,
										MessageBoxButtons.OK,
										MessageBoxIcon.Information);
				}
        }

        // Clears the text box and pastes the contents of clipboard.
        private void pasteButton_Click(object sender, EventArgs e)
        {
			clipText = Clipboard.GetText();

			if (clipText == textClipboard.Text)
			{
			const string message = "You have not entered any new text to paste.";
			const string caption = "Error!";
			MessageBox.Show(message, caption,
							MessageBoxButtons.OK,
							MessageBoxIcon.Error);
			}

			else if (clipText.Length > 0)
				{
				textClipboard.Clear();
				textClipboard.Text = clipText;
				}
        }

		// When the user clicks the Close button.
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
			{
			const string message =
				"Are you sure that you would like to close the program?";
			const string caption = "Program Closing";
			var result = MessageBox.Show(message, caption,
										 MessageBoxButtons.YesNo,
										 MessageBoxIcon.Question);

			// If the no button was pressed ... 
			if (result == DialogResult.No)
				{
				// cancel the closure of the form.
				e.Cancel = true;
				}
			}
		}
    }