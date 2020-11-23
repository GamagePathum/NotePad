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

namespace NotePad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string Savepath = "";

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxt1.Clear();
            Savepath = "";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Savepath = ofd.FileName;
                rtxt1.Text = File.ReadAllText(Savepath);
                Text = ofd.SafeFileName;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Savepath.Length > 0)
            {
                File.WriteAllText(Savepath, rtxt1.Text);
            }
            else
                saveAsToolStripMenuItem_Click(null, null);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Savepath = sfd.FileName;
                File.WriteAllText(Savepath, rtxt1.Text);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxt1.Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxt1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtxt1.SelectedText.Length == 0)
            {
                Clipboard.SetText(rtxt1.Text);
            }
            else
                Clipboard.SetText(rtxt1.SelectedText);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxt1.SelectedText = Clipboard.GetText();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxt1.SelectedText = "";
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fd1.Font = rtxt1.Font;
            if (fd1.ShowDialog() == DialogResult.OK)
            {
                rtxt1.Font = fd1.Font;
            }
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Font f = rtxt1.Font;
            rtxt1.Font = new Font(f.Name, f.Size - 2, f.Style);
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Font f = rtxt1.Font;
            rtxt1.Font = new Font(f.Name, f.Size - 2, f.Style);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string message = "Do you want to Save?";

            switch (MessageBox.Show(message, "Notepad", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
            {
                case DialogResult.Yes:
                    saveAsToolStripMenuItem_Click(null, null);
                    break;

                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }
    }
}
