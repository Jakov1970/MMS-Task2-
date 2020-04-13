using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

//---------------------------------------------------
//
//GITHUB link https://github.com/Jakov1970/MMS-Task2- 
//za slucaj da ne mozete da se snadjete 
//
//---------------------------------------------------


namespace MeanRemovalAndSphere
{
    public partial class MainForm : Form
    {
        private Bitmap originalBitmap = null;
        private Bitmap previewBitmap = null;
        private Bitmap resultBitmap = null;
        
        public MainForm()
        {
            InitializeComponent();

            List<FilterBase> filterList = new List<FilterBase>();

            filterList.Add(new MeanRemoval());
            //filterList.Add(new SphereFilter());

            cmbFilterType.DataSource = filterList;
            cmbFilterType.DisplayMember = "FilterName";
            cmbFilterType.SelectedIndex = 0;
        }

        private void btnOpenOriginal_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select an image file.";
            ofd.Filter = "Image File (*.bmp,*.jpg,)|*.bmp;*.jpg";
            ofd.Filter += "|Bitmap Images(*.bmp)|*.bmp";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(ofd.FileName);
                originalBitmap = (Bitmap)Bitmap.FromStream(streamReader.BaseStream);
                streamReader.Close();

                previewBitmap = originalBitmap.CopyToSquareCanvas(picPreview.Width);
                picPreview.Image = previewBitmap;

                ApplyFilter(true);

                Bitmap copy = new Bitmap((Bitmap)this.picPreview.Image);

                SphereFilter.Sphere(copy, true);

                this.pictureBox1.Image = copy;

            }

        }

        private void ApplyFilter(bool preview)
        {
            if (previewBitmap == null)
            {
                return;
            }

            FilterBase filter = null;

            if (cmbFilterType.SelectedItem is FilterBase)
            {
                filter = (FilterBase)cmbFilterType.SelectedItem;
            }

            if (preview == true)
            {
                picPreview.Image = previewBitmap.ConvolutionFilter(filter);
            }
            else
            {
                resultBitmap = originalBitmap.ConvolutionFilter(filter);
            }
        }

        private void SelectedFilterIndexChangedEventHandler(object sender, EventArgs e)
        {
            ApplyFilter(true);
        }
    }
}
