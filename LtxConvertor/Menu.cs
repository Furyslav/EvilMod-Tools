using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LtxConvertor
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            this.AllowDrop = true;
            this.DragDrop += new DragEventHandler(MenuDragDrop);
            this.DragEnter += new DragEventHandler(MenuDragEnter);
        }

        private string[] files = new string[] { };

        private void MenuDragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void MenuDragEnter(object sender, DragEventArgs e)
        {
            try
            {
                List<string> newFiles = ((string[])e.Data.GetData(DataFormats.FileDrop)).ToList();
                newFiles.AddRange(files);
                files = newFiles.Where(t => t.Substring(t.Length - 3, 3) == "ltx" || t.Substring(t.Length - 3, 3) == "lte").ToArray();
            }
            catch
            {
                MessageBox.Show("Error adding new files");
            }
           
        }

        private void buttonFiles_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Liquid WOTR|*.ltx|Liquid BattleRealms|*.lte", Multiselect = true, InitialDirectory = Application.StartupPath })
            {
                files = ofd.ShowDialog() == DialogResult.OK ? ofd.FileNames : new string[] { };
                this.textBoxFiles.Lines = files;
            }
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {

        }

        //about
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxFiles_TextChanged(object sender, EventArgs e)
        {
            files = this.textBoxFiles.Lines;
        }
    }
}
