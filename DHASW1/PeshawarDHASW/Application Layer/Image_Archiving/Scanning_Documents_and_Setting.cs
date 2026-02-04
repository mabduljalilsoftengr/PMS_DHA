using PeshawarDHASW.Data_Layer.clsImageArchiving;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using WIA;

namespace PeshawarDHASW.Application_Layer.Image_Archiving
{
    public partial class Scanning_Documents_and_Setting : Telerik.WinControls.UI.RadForm
    {
       
        public Scanning_Documents_and_Setting()
        {
            InitializeComponent();
        }
        private Image Img;
        private Size OriginalImageSize;
        private Size ModifiedImageSize;

        int cropX;
        int cropY;
        int cropWidth;

        int cropHeight;
        //int oCropX;
        //int oCropY;
        public Pen cropPen;

        public DashStyle cropDashStyle = DashStyle.DashDot;
        public bool Makeselection = false;

        public bool CreateText = false;
        public Scanning_Documents_and_Setting(Image Imgs)
        {
            InitializeComponent();
            Img = Imgs;
            LoadImage();

        }
       
        private void LoadImage()
        {
            //we set the picturebox size according to image, we can get image width and height with the help of Image.Width and Image.height properties.
            int imgWidth = Img.Width;
            int imghieght = Img.Height;
            picImage.Width = imgWidth;
            picImage.Height = imghieght;
            picImage.Image = Img;
            PictureBoxLocation();
            OriginalImageSize = new Size(imgWidth, imghieght);

            SetResizeInfo();
        }
        private void PictureBoxLocation()
        {
            int _x = 0;
            int _y = 0;
            if (SplitContainer1.Panel1.Width > picImage.Width)
            {
                _x = (SplitContainer1.Panel1.Width - picImage.Width) / 2;
            }
            if (SplitContainer1.Panel1.Height > picImage.Height)
            {
                _y = (SplitContainer1.Panel1.Height - picImage.Height) / 2;
            }
            picImage.Location = new Point(_x, _y);
        }

        private void SetResizeInfo()
        {

            lbloriginalSize.Text = OriginalImageSize.ToString();
            lblModifiedSize.Text = ModifiedImageSize.ToString();

        }

        private void SplitContainer1_Panel1_Resize(object sender, EventArgs e)
        {
            PictureBoxLocation();
        }
        # region "-----------------------------Crop Image------------------------------------"
     

        private void btnCrop_Click(object sender, EventArgs e)
        {

            Cursor = Cursors.Default;

            try
            {
                if (cropWidth < 1)
                {
                    return;
                }
                Rectangle rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
                //First we define a rectangle with the help of already calculated points
                Bitmap OriginalImage = new Bitmap(picImage.Image, picImage.Width, picImage.Height);
                //Original image
                Bitmap _img = new Bitmap(cropWidth, cropHeight);
                // for cropinf image
                Graphics g = Graphics.FromImage(_img);
                // create graphics
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                //set image attributes
                g.DrawImage(OriginalImage, 0, 0, rect, GraphicsUnit.Pixel);

                picImage.Image = _img;
                picImage.Width = _img.Width;
                picImage.Height = _img.Height;
                PictureBoxLocation();
                btnCrop.Enabled = false;
            }
            catch (Exception ex)
            {
            }
        }


        private void picImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (TabControl1.SelectedIndex == 4)
            {
                Point TextStartLocation = e.Location;
                if (CreateText)
                {
                    Cursor = Cursors.IBeam;
                }
            }
            else
            {
                Cursor = Cursors.Default;
                if (Makeselection)
                {

                    try
                    {
                        if (e.Button == System.Windows.Forms.MouseButtons.Left)
                        {
                            Cursor = Cursors.Cross;
                            cropX = e.X;
                            cropY = e.Y;

                            cropPen = new Pen(Color.Black, 1);
                            cropPen.DashStyle = DashStyle.DashDotDot;


                        }
                        picImage.Refresh();
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }
        private void picImage_MouseUp(object sender, MouseEventArgs e)
        {
            if (Makeselection)
            {
                Cursor = Cursors.Default;
            }

        }

        private void picImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (TabControl1.SelectedIndex == 4)
            {
                Point TextStartLocation = e.Location;
                if (CreateText)
                {
                    Cursor = Cursors.IBeam;
                }
            }
            else
            {
                Cursor = Cursors.Default;
                if (Makeselection)
                {

                    try
                    {
                        if (picImage.Image == null)
                            return;


                        if (e.Button == System.Windows.Forms.MouseButtons.Left)
                        {
                            picImage.Refresh();
                            cropWidth = e.X - cropX;
                            cropHeight = e.Y - cropY;
                            picImage.CreateGraphics().DrawRectangle(cropPen, cropX, cropY, cropWidth, cropHeight);
                        }



                    }
                    catch (Exception ex)
                    {
                        //if (ex.Number == 5)
                        //    return;
                    }
                }
            }

        }
        #endregion
        private void Scanning_Documents_and_Setting_Load(object sender, EventArgs e)
        {
            BindDomainIUpDown();
            // set Slider Attributes
            trackBarZoom.Minimum = 1;
            trackBarZoom.Maximum = 10;
            trackBarZoom.SmallChange = 1;
            trackBarZoom.LargeChange = 1;
            trackBarZoom.UseWaitCursor = false;

            // reduce flickering
            this.DoubleBuffered = true;
        }
        private void BindDomainIUpDown()
        {
            for (int i = 1; i <= 999; i++)
            {
                DomainUpDown1.Items.Add(i);
            }
            DomainUpDown1.Text = "100";
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            cls_ImageHolder.ImagesContainer.Add(picImage.Image);
            this.Close();
        }

        private void MakeSelection_Click(object sender, EventArgs e)
        {
            Makeselection = true;
            btnCrop.Enabled = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {

            Bitmap bm_source = new Bitmap(picImage.Image);
            // Make a bitmap for the result.
            int Width = 0;
            bool widthbool = int.TryParse(ModifiedImageSize.Width.ToString(), out Width);
            int Height = 0;
            bool heightbool = int.TryParse(ModifiedImageSize.Height.ToString(), out Height);
            if (widthbool == true && heightbool == true)
            {
                Bitmap bm_dest = new Bitmap(Convert.ToInt32(ModifiedImageSize.Width), Convert.ToInt32(ModifiedImageSize.Height));
                // Make a Graphics object for the result Bitmap.
                Graphics gr_dest = Graphics.FromImage(bm_dest);
                // Copy the source image into the destination bitmap.
                gr_dest.DrawImage(bm_source, 0, 0, bm_dest.Width + 1, bm_dest.Height + 1);
                // Display the result.
                picImage.Image = bm_dest;
                picImage.Width = bm_dest.Width;
                picImage.Height = bm_dest.Height;
                PictureBoxLocation();
            }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+"\n"+ex.InnerException+"\n"+ex.StackTrace);
            }
        }

        private void btnRotateLeft_Click(object sender, EventArgs e)
        {
            picImage.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            picImage.Refresh();
        }

        private void btnRotateRight_Click(object sender, EventArgs e)
        {
            picImage.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            picImage.Refresh();
        }

        private void btnRotateHorizantal_Click(object sender, EventArgs e)
        {
            picImage.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            picImage.Refresh();
        }

        private void btnRotatevertical_Click(object sender, EventArgs e)
        {
            picImage.Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            picImage.Refresh();
        }

        private void btnCreateText_Click(object sender, EventArgs e)
        {

        }

        private void TrackBarBrightness_Scroll(object sender, EventArgs e)
        {

            DomainUpDownBrightness.Text = TrackBarBrightness.Value.ToString();


            float value = TrackBarBrightness.Value * 0.01f;
            float[][] colorMatrixElements = {
                                             new float[] {      1,      0,      0,      0,      0   },
                                             new float[] {      0,      1,      0,      0,      0   },
                                                new float[] {      0,      0,      1,      0,      0   },
                                             new float[] {      0,      0,      0,      1,      0   },
                                             new float[] {   value,   value,  value,    0,      1   }
                                            };
            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);
            ImageAttributes imageAttributes = new ImageAttributes();


            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            Image _img = Img;
            //PictureBox1.Image
            Graphics _g = default(Graphics);
            Bitmap bm_dest = new Bitmap(Convert.ToInt32(_img.Width), Convert.ToInt32(_img.Height));
            // bm_dest = cls_ImageConstrast.Contrast(bm_dest, 10);
            _g = Graphics.FromImage(bm_dest);
            _g.DrawImage(_img, new Rectangle(0, 0, bm_dest.Width + 1, bm_dest.Height + 1), 0, 0, bm_dest.Width + 1, bm_dest.Height + 1, GraphicsUnit.Pixel, imageAttributes);
            picImage.Image = bm_dest;
        }

        private void ContrastTrackar_Scroll(object sender, EventArgs e)
        {
            DomainUpDownContrast.Text = ContrastTrackar.Value.ToString();
            float value = TrackBarBrightness.Value * 0.01f;
            float[][] colorMatrixElements = {
                                             new float[] {      1,      0,      0,      0,      0   },
                                             new float[] {      0,      1,      0,      0,      0   },
                                             new float[] {      0,      0,      1,      0,      0   },
                                             new float[] {      0,      0,      0,      1,      0   },
                                             new float[] {    value,  value,  value,    0,      1   }
                                            };
            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);
            ImageAttributes imageAttributes = new ImageAttributes();


            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            Image _img = Img;
            //PictureBox1.Image
            Graphics _g = default(Graphics);
            Bitmap bm_dest = new Bitmap(Convert.ToInt32(_img.Width), Convert.ToInt32(_img.Height));
            // bm_dest = cls_ImageConstrast.Contrast(bm_dest, 10);
            _g = Graphics.FromImage(bm_dest);
            _g.DrawImage(_img, new Rectangle(0, 0, bm_dest.Width + 1, bm_dest.Height + 1), 0, 0, bm_dest.Width + 1, bm_dest.Height + 1, GraphicsUnit.Pixel, imageAttributes);
            bm_dest = cls_ImageContrast.Contrast(bm_dest, ContrastTrackar.Value);
            picImage.Image = bm_dest;
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog Dlg = new OpenFileDialog();
            Dlg.Filter = "";
            Dlg.Title = "Select image";
            if (Dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Img = Image.FromFile(Dlg.FileName);
                //Image.FromFile(String) method creates an image from the specifed file, here dlg.Filename contains the name of the file from which to create the image
                LoadImage();
            }
        }

        private void DomainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
            int percentage = 0;
            try
            {
                percentage = Convert.ToInt32(DomainUpDown1.Text);
                ModifiedImageSize = new Size((OriginalImageSize.Width * percentage) / 100, (OriginalImageSize.Height * percentage) / 100);
                SetResizeInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Percentage");
                return;
            }
        }
        private Image imgOriginal;
        private void trackBarZoom_Scroll(object sender, ScrollEventArgs e)
        {
            if (trackBarZoom.Value > 0)
            {
                picImage.Image = null;
                imgOriginal = Img;
                picImage.Image = PictureBoxZoom(imgOriginal, new Size(Convert.ToInt32(trackBarZoom.Value), Convert.ToInt32(trackBarZoom.Value)));
            }
        }
        public Image PictureBoxZoom(Image img, Size size)
        {
            imgOriginal = img;
            Bitmap bm = new Bitmap(imgOriginal, Convert.ToInt32(imgOriginal.Width / size.Width), Convert.ToInt32(imgOriginal.Height / size.Height));
            Graphics grap = Graphics.FromImage(bm);
            //grap.InterpolationMode = InterpolationMode.HighQualityBicubic;
            return bm;
        }
    }
}
