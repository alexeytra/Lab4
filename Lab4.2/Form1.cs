using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_Leave(object sender, EventArgs e)
        {
           
        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Clear();

            char[] message;
            int size;

            MemoryMappedFile sharedMemory = MemoryMappedFile.OpenExisting("MemoryFile");
            using (MemoryMappedViewAccessor reader = sharedMemory.CreateViewAccessor(0, 4, MemoryMappedFileAccess.Read))
            {
                size = reader.ReadInt32(0);
            }
            using (MemoryMappedViewAccessor reader = sharedMemory.CreateViewAccessor(4, size * 2, MemoryMappedFileAccess.Read))
            {
                message = new char[size];
                reader.ReadArray<char>(0, message, 0, size);
            }

            String str = new String(message);
            this.richTextBox1.AppendText(str);
        }
    }
}
