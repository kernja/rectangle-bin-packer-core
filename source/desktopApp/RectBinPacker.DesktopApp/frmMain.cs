using RectBinPacker.DesktopApp.Models;
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
        private readonly IAppService _appService;
        public frmMain(IAppService appService)
        {
            InitializeComponent();

            _appService = appService;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string exceptionMessage;
 
            if (_appService.AddImage(out exceptionMessage))
            {
                RefreshUI();
            }
            else 
            {
                if (!string.IsNullOrWhiteSpace(exceptionMessage))
                    MessageBox.Show(exceptionMessage);
            }
        }

        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstItems.SelectedItem != null)
            {
                pictureBox.Image = ((ImageListItem)lstItems.SelectedItem).Image;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstItems.SelectedItem != null)
            {
                _appService.RemoveImageListItem((ImageListItem)lstItems.SelectedItem);
                RefreshUI();
            }
        }

        private void RefreshUI()
        {
            lstItems.DataSource = null;
            lstItems.DataSource = _appService.GetImageListItems();
            lstItems.Refresh();
            lstItems.Update();
            lstItems.SelectedItem = null;
            pictureBox.Image = null;
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            Bitmap output;
            if (_appService.Solve(out output))
            {
                pictureBox.Image = output;
            } else
            {
                MessageBox.Show("Unable to generate atlas");
            }
        }
    }
}
