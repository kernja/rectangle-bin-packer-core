using RectBinPacker.DesktopApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RectBinPacker.DesktopApp
{
    public partial class frmMain : Form, IFrmMain
    {
        private readonly IFilePickerService _filePickerService;
        public frmMain(IFilePickerService filePickerService)
        {
            InitializeComponent();

            _filePickerService = filePickerService;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string path;
            string filename;

            if (_filePickerService.SelectFile("Select file...", "PNG Files|*.png", out path, out filename))
            {
                var foo = 1;
            }
        }
    }
}
