using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HigurashiTranslationHelper
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        string text;

        private void importButton_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Title = "Encontre arquivos de scripts do Higurashi";
            ofd.Filter = "Arquivos de scripts de Higurashi (*.txt)|*.txt";

            var result = ofd.ShowDialog();

            if (result == DialogResult.Cancel)
                return;

            text = File.ReadAllText(ofd.FileName);

            populate();
        }

        Regex regex = new Regex("OutputLine\\(NULL,[ ]*.*,[\n]*		   NULL, \"(?<line>.*)\"\\)", RegexOptions.Compiled);
        void populate()
        {
            string final = "";
            var matches = regex.Matches(text.Replace("\r\n", "\n"));
            foreach(Match match in matches)
            {
                final += $"[${match.Groups["line"].Value}]\n";
            }
            textBox.Text = final;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {

        }
    }
}
