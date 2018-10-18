using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Media;

using xc = Microsoft.Office.Interop.Excel;

using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.Util;

namespace Section_BULB
{
    public partial class Form1 : Form
    {
        private Capture CamCapture;             //ตัวแปร Capture
        private Image<Bgr, Byte> ImageFram;     //ประกาศตัวแปรรูปภาพ อ้างอิงไลบรารี่ EmguCV
        private Image<Bgr, Byte> ImageFram1;     //ประกาศตัวแปรรูปภาพ อ้างอิงไลบรารี่ EmguCV
        public int ll = 15, hl = 255, re_noise = 0, pixcut_low = 1, pixcut_high = 500, x_position, y_position = -2, flash, y_chart, total_frame_count;
        //     double[] time_collect = new double[1500]; // ลำดับ flash, เวลาวิดีโอ, พิกัด x, พิกัด y
        //     double[] x_pos = new double[1500]; // ลำดับ flash, เวลาวิดีโอ, พิกัด x, พิกัด y
        //     double[] y_pos = new double[1500]; // ลำดับ flash, เวลาวิดีโอ, พิกัด x, พิกัด y
        //     double[] flash_area = new double[3000];  //เก็บค่าพื้นที่ flash
        //     double[] time_line = new double[3000];   // เก็บค่าช่วงเวลาเพื่อ plot graph flash pattern

        double[,,] data_collection = new double[500, 6000, 3]; //////// เก็บ data ทั้งหมด
        int[,,] position_collection = new int[500, 6000, 3]; //////// เก็บ data ทั้งหมด
        int last_position = 1, position_count = 1;
        int error_position = 150;
        int count_no_fire;
        int x_compare, y_compare, x_result, y_result;
        int last_list;
        int count_no_flash;
        int excelrun_first = 1, excelrun_second = 2;

        string list_address, list_save_address, list_filename;
        int array_list_count = 0;
        int list_box_bound;
        int no_item = 1;
        bool stop_multi_run = false;

        double time_index;

        int F_count;

        double TotalFrame;



        xc.Application excelApp;
        xc.Workbook excelWorkbook;
        xc.Worksheet excelWorkSheet;
        xc.Sheets excelSheets;
        xc.Range excelCell;




        public Form1()
        {
            InitializeComponent();
            excelApp = new xc.Application();
            excelApp.Visible = true;

            address_file_listBox.DragDrop += listBoxFiles_DragDrop;
            address_file_listBox.DragEnter += listBoxFiles_DragEnter;

        }

        private void listBoxFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;

        }

        private void listBoxFiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                address_file_listBox.Items.Add(file);
                string fileName = Path.GetFileNameWithoutExtension(file);
                file_name_listBox.Items.Add(fileName);
                no_listBox.Items.Add(no_item);
                no_item++;
            }

        }

        public void Flash_detector(object sender, EventArgs e)
        {

            if (total_frame_count == F_count)
            {
                Application.Idle -= Flash_detector;
                Application.Idle -= start_video_Click;
                Application.Idle -= chart_showing;
                SystemSounds.Beep.Play();
                status.Text = "Finish";

                if (stock_file_run.Checked == true)
                {
                    Application.Idle += save_data;
                }
            }

            else
            {

                ImageFram = CamCapture.QueryFrame();

                time_index = CamCapture.GetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_POS_MSEC);

                flash = 0;

                ImageFram1 = ImageFram;
                Image<Hsv, Byte> hsvImage = ImageFram.Convert<Hsv, Byte>();
                Image<Gray, Byte> ResultImage = new Image<Gray, Byte>(hsvImage.Width, hsvImage.Height);

                Image<Gray, Byte> IlowCh0 = new Image<Gray, Byte>(hsvImage.Width, hsvImage.Height, new Gray(ll));

                Image<Gray, Byte> IHiCh0 = new Image<Gray, Byte>(hsvImage.Width, hsvImage.Height, new Gray(hl));


                pictureBox1.Image = ImageFram1.ToBitmap(pictureBox1.Width, pictureBox1.Height);

                /*
                Image<Hsv, Byte> hsvImage2 = ImageFram.Convert<Hsv, Byte>(); //Convert RGB > HSV. 
                Image<Gray, Byte> ResultImage2 = new Image<Gray, Byte>(hsvImage2.Width, hsvImage2.Height);

                
                Image<Gray, Byte> IlowCh2 = new Image<Gray, Byte>(hsvImage2.Width, hsvImage2.Height, new Gray(15));
                Image<Gray, Byte> IHiCh2 = new Image<Gray, Byte>(hsvImage2.Width, hsvImage2.Height, new Gray(255));
                
                CvInvoke.cvInRange(hsvImage[0], IlowCh0, IHiCh0, ResultImage);
                CvInvoke.cvInRange(hsvImage2[2], IlowCh2, IHiCh2, ResultImage2);


                CvInvoke.cvAnd(ResultImage, ResultImage2, ResultImage, (IntPtr)null);
                */


                //Use cvinrange() method and hsvImage[0] = hsvimage channel 0
                if (radioButton1.Checked == true)
                {
                    CvInvoke.cvInRange(hsvImage[0], IlowCh0, IHiCh0, ResultImage);
                }
                if (radioButton2.Checked == true)
                {
                    CvInvoke.cvInRange(hsvImage[1], IlowCh0, IHiCh0, ResultImage);
                }
                if (radioButton3.Checked == true)
                {
                    CvInvoke.cvInRange(hsvImage[2], IlowCh0, IHiCh0, ResultImage);
                }

                
                re_noise = int.Parse(comboBox2.Text);

                CvInvoke.cvErode(ResultImage, ResultImage, (IntPtr)null, re_noise);  
                CvInvoke.cvDilate(ResultImage, ResultImage, (IntPtr)null, re_noise);  

                Image<Gray, Byte> imgForContour = new Image<Gray, byte>(ResultImage.Width, ResultImage.Height);

                CvInvoke.cvCopy(ResultImage, imgForContour, System.IntPtr.Zero); 

                IntPtr storage = CvInvoke.cvCreateMemStorage(0);
                IntPtr contour = new IntPtr();
                CvInvoke.cvFindContours(imgForContour, storage, ref contour, System.Runtime.InteropServices.Marshal.SizeOf(typeof(MCvContour)), Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_EXTERNAL, Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_NONE, new Point(0, 0));
                Seq<Point> seq = new Seq<Point>(contour, null);

                for (; seq != null && seq.Ptr.ToInt32() != 0; seq = seq.HNext)
                {
                    Rectangle bndRec = CvInvoke.cvBoundingRect(seq, 1);

                    double areaC = CvInvoke.cvContourArea(seq, MCvSlice.WholeSeq, 1) * -1;
                    if (areaC >= pixcut_low && areaC <= pixcut_high) 
                    {
                        CvInvoke.cvRectangle(ImageFram, new Point(bndRec.X, bndRec.Y), new Point(bndRec.X + bndRec.Width, bndRec.Y + bndRec.Height), new MCvScalar(0, 0, 255), 2, LINE_TYPE.CV_AA, 0);
                        flash = Convert.ToInt32(areaC);           //////
                        x_position = bndRec.X + bndRec.Width / 2; //////
                        y_position = bndRec.Y + bndRec.Height / 2;//////
                                                                  //  XPos.Text = xFace.ToString();
                                                                  //  YPos.Text = yFace.ToString();
                                                                  /*/
                                                                                          time_collect[i] = time_index;    // เก็บค่าเวลาที่เกิดการกระพริบ
                                                                                          x_pos[i] = x_position;           // เก็บพิกัด x ของการกระพริบ
                                                                                          y_pos[i] = y_position;           // เก็บพิกัด y ของการกระพริบ

                                                                  /*/
                        error_position = int.Parse(error_area_comboBox.Text);

                        if (areaC > 0)
                        {

                            if (y_position >= 0)
                            {
                                y_chart = 1080 - y_position;   //////////  fix convert position 26/8/2018 from 720-->1080
                                this.chart2.Series["position"].Points.AddXY(x_position, y_chart);  ////////////////////////////////  chart plot
                            }

                            for (count_no_fire = 1; count_no_fire <= data_collection.GetUpperBound(0); count_no_fire++)
                            {
                                if (data_collection[count_no_fire, 2, 2] == 1 | data_collection[count_no_fire, 2, 2] == 2)   ////  sss
                                {
                                    x_compare = Convert.ToInt32(data_collection[count_no_fire, 1, 1]);
                                    y_compare = Convert.ToInt32(data_collection[count_no_fire, 2, 1]);
                                    x_result = Math.Abs(x_compare - x_position);
                                    y_result = Math.Abs(y_compare - y_position);
                                    if (x_result <= error_position & y_result <= error_position)
                                    {
                                        last_list = Convert.ToInt32(data_collection[count_no_fire, 1, 2]);
                                        if (time_index == data_collection[count_no_fire, last_list - 1, 1])
                                        {
                                            data_collection[count_no_fire, 1, 1] = x_position;
                                            data_collection[count_no_fire, 2, 1] = y_position;
                                            data_collection[count_no_fire, last_list - 1, 2] = areaC + data_collection[count_no_fire, last_list - 1, 2];   ///  **new edit
                                            data_collection[count_no_fire, 2, 2] = 2;

                                            break;
                                        }
                                        else
                                        {
                                            last_list = Convert.ToInt32(data_collection[count_no_fire, 1, 2]);
                                            data_collection[count_no_fire, 1, 1] = x_position;
                                            data_collection[count_no_fire, 2, 1] = y_position;
                                            data_collection[count_no_fire, last_list, 1] = time_index;
                                            data_collection[count_no_fire, last_list, 2] = areaC;
                                            last_list++;
                                            data_collection[count_no_fire, 1, 2] = last_list;
                                            data_collection[count_no_fire, 2, 2] = 2;
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    position_count = 3;
                                    last_list = 3;
                                    data_collection[count_no_fire, 1, 1] = x_position;
                                    data_collection[count_no_fire, 2, 1] = y_position;
                                    data_collection[count_no_fire, last_list, 1] = time_index;
                                    data_collection[count_no_fire, last_list, 2] = areaC;
                                    last_list++;
                                    data_collection[count_no_fire, 1, 2] = last_list;
                                    data_collection[count_no_fire, 2, 2] = 2;    ///////////  status  ***new edit


                                    position_collection[count_no_fire, position_count, 0] = Convert.ToInt32(data_collection[count_no_fire, 1, 1]);
                                    position_collection[count_no_fire, position_count, 1] = Convert.ToInt32(data_collection[count_no_fire, 2, 1]);

                                    //position_count++;               //  fixing   27/8/2018
                                    position_collection[count_no_fire, 1, 2] = position_count;


                                    break;
                                }
                            }
                        }

                    }

                }

                for (count_no_fire = 1; count_no_fire <= data_collection.GetUpperBound(0); count_no_fire++)
                {
                    last_list = Convert.ToInt32(data_collection[count_no_fire, 1, 2]);

                    if (data_collection[count_no_fire, 2, 2] == 1)   ////  sss
                    {
                        data_collection[count_no_fire, last_list, 1] = time_index;
                        data_collection[count_no_fire, last_list, 2] = 0;

                        last_list++;
                        data_collection[count_no_fire, 1, 2] = last_list;
                    }
                    if (data_collection[count_no_fire, 2, 2] == 2)   ////  sss
                    {

                        position_count = position_collection[count_no_fire, 1, 2];
                        position_collection[count_no_fire, position_count, 0] = Convert.ToInt32(data_collection[count_no_fire, 1, 1]);
                        position_collection[count_no_fire, position_count, 1] = Convert.ToInt32(data_collection[count_no_fire, 2, 1]);
                        position_count++;
                        position_collection[count_no_fire, 1, 2] = position_count;


                        data_collection[count_no_fire, 2, 2] = 1;
                    }

                }

                pictureBox1.Image = ImageFram.ToBitmap(pictureBox1.Width, pictureBox1.Height);  //นำผลการคิ่วรี่เฟรมมาแสดงยัง ImageBox
                pictureBox2.Image = ResultImage.ToBitmap(pictureBox2.Width, pictureBox2.Height);

                CvInvoke.cvReleaseMemStorage(ref storage);  // คืนหน่วยความจำ

                total_frame_count++;
                present_frame.Text = total_frame_count.ToString();
            }
        }

        private void chart_showing(object sender, EventArgs e)
        {

            this.chart1.Series["flash"].Points.AddXY(time_index, flash);  ////////////////////////////////  chart plot
            //this.chart1.Series.Add("aa");
        }

        private void save_data(object sender, EventArgs e)
        {
            excelCell = excelWorkSheet.UsedRange;

            for (count_no_fire = 1; count_no_fire <= data_collection.GetUpperBound(0); count_no_fire++)
            {
                if (data_collection[count_no_fire, 2, 2] != 1)
                {
                    break;
                }
                excelWorkSheet.Cells[1, excelrun_first] = "หิ่งห้อยตัวที่ " + count_no_fire;
                excelWorkSheet.Cells[2, excelrun_first] = "X position";
                excelWorkSheet.Cells[2, excelrun_second] = "Y position";
                excelWorkSheet.Cells[3, excelrun_first] = data_collection[count_no_fire, 1, 1];
                excelWorkSheet.Cells[3, excelrun_second] = data_collection[count_no_fire, 2, 1];
                excelWorkSheet.Cells[2, excelrun_first + 2] = "X collect";
                excelWorkSheet.Cells[2, excelrun_second + 2] = "Y collect";
                excelWorkSheet.Cells[4, excelrun_first] = "last list";
                excelWorkSheet.Cells[4, excelrun_second] = "Status";
                excelWorkSheet.Cells[5, excelrun_first] = data_collection[count_no_fire, 1, 2];
                excelWorkSheet.Cells[5, excelrun_second] = data_collection[count_no_fire, 2, 2];

                excelWorkSheet.Cells[5, excelrun_first + 2] = position_collection[count_no_fire, 1, 2];


                for (count_no_flash = 3; count_no_flash <= data_collection.GetUpperBound(1); count_no_flash++)
                {
                    if (data_collection[count_no_fire, count_no_flash, 1] != 0)
                    {
                        excelWorkSheet.Cells[count_no_flash + 3, excelrun_first] = data_collection[count_no_fire, count_no_flash, 1];
                        excelWorkSheet.Cells[count_no_flash + 3, excelrun_second] = data_collection[count_no_fire, count_no_flash, 2];

                        excelWorkSheet.Cells[count_no_flash + 3, excelrun_first + 2] = position_collection[count_no_fire, count_no_flash, 0];
                        excelWorkSheet.Cells[count_no_flash + 3, excelrun_first + 3] = position_collection[count_no_fire, count_no_flash, 1];


                    }
                }
                excelrun_first += 4;
                excelrun_second += 4;

            }

            Application.Idle -= save_data;
            status.Text = "save complete";

            Array.Clear(data_collection, 0, 4500000);                   //////  add for fixing position save error  26/8/2018
            Array.Clear(position_collection, 0, 4500000);               //////  add for fixing position save error  26/8/2018

            /////////////////////////////////////////////////////////////////////////////
            if (stock_file_run.Checked == true && stop_multi_run == false)
            {
                excelWorkbook.SaveAs(list_save_address + "/" + list_filename + ".xlsx");
                status_listBox1.Items[array_list_count - 1] = "Finish";
                Application.Idle += browse_file_Click;
                Application.Idle -= save_data;
                status.Text = "save complete";
            }

        }





        private void start_video_Click(object sender, EventArgs e)
        {
            CamCapture = new Capture(list_address);
            TotalFrame = CamCapture.GetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FRAME_COUNT);
            total_frame.Text = TotalFrame.ToString();
            F_count = Convert.ToInt16(TotalFrame);
            Application.Idle += Flash_detector;
            Application.Idle += chart_showing;
            Application.Idle -= start_video_Click;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            ll = trackBar1.Value;
            textBox1.Text = ll.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            hl = trackBar2.Value;
            textBox2.Text = hl.ToString();
        }

        private void trackBar8_Scroll(object sender, EventArgs e)
        {
            pixcut_low = trackBar8.Value;
            textBox7.Text = pixcut_low.ToString() + " to " + pixcut_high.ToString();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            pixcut_high = trackBar4.Value;
            textBox7.Text = pixcut_low.ToString() + " to " + pixcut_high.ToString();
        }



        private void stop_Click(object sender, EventArgs e)
        {
            Application.Idle -= Flash_detector;
            Application.Idle -= chart_showing;

        }

        private void clear_data_Click(object sender, EventArgs e)
        {
            this.chart1.Series["flash"].Points.Clear();
            this.chart2.Series["position"].Points.Clear();

            Array.Clear(data_collection, 0, 4500000);


            total_frame_count = 0;
        }

        private void save_buttom_Click(object sender, EventArgs e)
        {

            Application.Idle += save_data;


        }


        private void browse_file_Click(object sender, EventArgs e)
        {
            excelrun_first = 1;
            excelrun_second = 2;
            this.chart1.Series["flash"].Points.Clear();
            this.chart2.Series["position"].Points.Clear();

            Array.Clear(data_collection, 0, 4500000);

            total_frame_count = 0;

            try
            {
                excelWorkbook.Close();

                excelWorkbook = excelApp.Workbooks.Add();
                excelSheets = excelWorkbook.Worksheets;
                excelWorkSheet = excelSheets.get_Item("Sheet1");
                excelCell = excelWorkSheet.UsedRange;
            }
            catch
            {
                excelWorkbook = excelApp.Workbooks.Add();
                excelSheets = excelWorkbook.Worksheets;
                excelWorkSheet = excelSheets.get_Item("Sheet1");
                excelCell = excelWorkSheet.UsedRange;
            }

            if (stock_file_run.Checked == false)
            {
                openFileDialog1.Filter = "Video Files|*.avi;*.mp4;*.mpg";
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    open_destination.Text = openFileDialog1.FileName.ToString();
                    list_address = openFileDialog1.FileName.ToString();
                    status.Text = "Video was Selected";
                    start_video.Enabled = true;
                    stop.Enabled = true;
                    clear_data.Enabled = true;
                    save_buttom.Enabled = true;

                }
            }
            else
            {

                status.Text = "Video was Selected";
                start_video.Enabled = true;
                stop.Enabled = true;
                clear_data.Enabled = true;
                save_buttom.Enabled = true;

                if (array_list_count <= list_box_bound - 1)
                {
                    list_address = address_file_listBox.Items[array_list_count].ToString();
                    list_filename = file_name_listBox.Items[array_list_count].ToString();
                    status_listBox1.Items.Add("Running");
                    array_list_count++;
                    Application.Idle += start_video_Click;
                    Application.Idle -= browse_file_Click;
                }
                else
                {
                    Application.Idle -= browse_file_Click;
                    stock_file_run.Checked = true;
                    run_stock_file.Enabled = true;
                    clear_listbox.Enabled = true;
                    address_file_listBox.Enabled = true;
                    status.Text = "Stock run finish";
                }

            }


        }

        private void close_Click(object sender, EventArgs e)
        {
            excelApp.Quit();
            this.Close();
        }

        private void run_stock_file_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                list_save_address = folderBrowserDialog1.SelectedPath.ToString();
                textBox3.Text = address_file_listBox.Items.Count.ToString();
                save_folder_textBox.Text = list_save_address;
                list_box_bound = int.Parse(textBox3.Text);
                Application.Idle += browse_file_Click;
                stop_multiple_run.Enabled = true;
                clear_listbox.Enabled = false;
                stock_file_run.Enabled = false;
                address_file_listBox.Enabled = false;
            }
        }

        private void stock_file_run_CheckedChanged(object sender, EventArgs e)
        {
            if (stock_file_run.Checked == true)
            {
                run_stock_file.Enabled = true;
                clear_listbox.Enabled = true;
                address_file_listBox.Enabled = true;

            }
            else
            {
                run_stock_file.Enabled = false;
                stop_multiple_run.Enabled = false;
                clear_listbox.Enabled = false;
                address_file_listBox.Enabled = false;
            }
        }

        private void stop_multiple_run_Click(object sender, EventArgs e)
        {
            array_list_count = list_box_bound;
            stop_multi_run = true;
            status.Text = "Please waiting processes";
        }

        private void clear_listbox_Click(object sender, EventArgs e)
        {
            address_file_listBox.Items.Clear();
            file_name_listBox.Items.Clear();
            status_listBox1.Items.Clear();
        }

        
    }
}
