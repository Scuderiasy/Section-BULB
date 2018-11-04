using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xc = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Runtime.InteropServices;

namespace Section_BULB
{
    public partial class Form2 : Form
    {
        xc.Application excelApp;
        xc.Workbook excelWorkbook;
        xc.Worksheet excelWorkSheet;
        xc.Sheets excelSheets;
        xc.Range excelCell;

        xc.Application excelApp1;
        xc.Workbook excelWorkbook1;
        xc.Worksheet excelWorkSheet1;
        xc.Sheets excelSheets1;
        xc.Range excelCell1;

        OpenFileDialog Open_file = new OpenFileDialog();
        OpenFileDialog Open_for_save = new OpenFileDialog();


        int aa, freq = 0, start_column_save, list_box_bound, array_list_count;
        double input_column, row_count, no_data, number_check;
        string ref_name, ref_save_column, sv_name;
        double[,] box = new double[501, 3];    /////  first range ของ data,second ค่า range(1) ค่าจำนวนความถี่ของข้อมูล (2)
        int[] status = new int[5];
        string save_file_name, list_save_address, list_address, list_filename;

        int flash_duration = 0;



        int no_item = 1;

        public Form2()
        {
            InitializeComponent();
        }

        private void next_file_button_Click(object sender, EventArgs e)
        {
            excelWorkbook.Close(null, null, null);                
            excelApp.Quit();

            Marshal.ReleaseComObject(excelApp);
            excelApp = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Application.Idle += multiple_file_run;
        }

        private void checkBox_multiple_run_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_multiple_run.Checked)
            {
                Multiple_button.Enabled = true;
            }
            else
            { Multiple_button.Enabled = false; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Open_for_save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                list_save_address = folderBrowserDialog1.SelectedPath.ToString();
                list_save_address = Open_for_save.FileName;
                list_box_bound = address_file_listBox.Items.Count;
                Application.Idle += multiple_file_run;
            }
        }

        private void multiple_file_run(object sender, EventArgs e)
        {


            if (array_list_count <= list_box_bound - 1)
            {
                list_address = address_file_listBox.Items[array_list_count].ToString();
                list_filename = file_name_listBox.Items[array_list_count].ToString();
                array_list_count++;

                textBox1.Text = (list_box_bound - array_list_count).ToString();

                progressBar.Value = 15;
                excelApp = new xc.Application();
                excelApp.Visible = true;
                excelWorkbook = excelApp.Workbooks.Open(list_address);
                excelSheets = excelWorkbook.Worksheets;
                excelWorkSheet = excelSheets.get_Item("Sheet1");
                excelCell = excelWorkSheet.UsedRange;
                progressBar.Value = 100;
                save_file_name = Path.GetFileNameWithoutExtension(list_filename);
                save_name.Text = save_file_name;

                classify.BackColor = Color.IndianRed;
            }
            else
            {
                MessageBox.Show("Section GERMINI : Multiple run FINISH");
            }


            Application.Idle -= multiple_file_run;
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

        private void open_excel_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;

            if (Open_file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                progressBar.Value = 15;
                excelApp = new xc.Application();
                excelApp.Visible = true;
                excelWorkbook = excelApp.Workbooks.Open(Open_file.FileName);
                excelSheets = excelWorkbook.Worksheets;
                excelWorkSheet = excelSheets.get_Item("Sheet1");
                excelCell = excelWorkSheet.UsedRange;
                progressBar.Value = 100;
                save_file_name = Path.GetFileNameWithoutExtension(Open_file.FileName);
                save_name.Text = save_file_name;
            }

        }

        private void classify_Click(object sender, EventArgs e)
        {
            classify.BackColor = SystemColors.Control;

            progressBar.Value = 33;

            input_column = double.Parse(start_column_textBox.Text);
            row_count = double.Parse(start_row_textBox.Text);
            no_data = double.Parse(no_data_comboBox.Text);

            progressBar.Value = 33;

            for (aa = 0; aa <= no_data; aa++)
            {
                box[aa, 0] = 0;
                box[aa, 1] = 0;
            }

            ref_name = excelCell[input_column, row_count].Value.ToString();

            progressBar.Value = 83;

            status[0] = 0;
            status[3] = 0;

            while (ref_name != null)
            {


                number_check = Convert.ToDouble(excelCell[input_column, row_count].Value);

                if (status[0] == 0)     // เช็คสถานะว่าเป็นตัวแรกของข้อมูลที่เปรียบเทียบ
                {
                    status[0] = 1;      // กำหนดสถานะเป็นเปรียบเทียบแล้ว
                    if (number_check > 0)   // เช็คค่า area เพื่อระบุค่า อดีต ว่าเป็นสว่างหรือมืด
                    {
                        status[1] = 1;  //สว่าง = 1
                    }
                    else
                    {
                        status[1] = 0;  //มืด  = 0
                    }

                }
                else                    // สถานะที่มีการเปรียบเทียบแล้ว
                {

                    if (number_check > 0) // เช็คค่า area เพื่อระบุค่า ปัจจุบัน ว่าเป็นสว่างหรือมืด
                    {
                        status[2] = 1;  //สว่าง = 1
                    }
                    else
                    {
                        status[2] = 0;  //มืด  = 0
                    }

                    if (status[1] == status[2])  // เปรียบเทียบ ค่า อดีตกับปัจจุบัน
                    {
                        status[3]++;             // ถ้าเป็นค่าเดียวกันเพิ่มความถี่ของความสว่างหรือมืดที่ติดกัน (นับ duration)
                    }
                    else                        // ถ้าไม่เหมือนกัน เพิ่มค่าความถี่ของ array ที่เก็บ ค่า duration โดย
                    {
                        if (status[1] > 0)      // ถ้าค่าที่นับอยู่เป็น สว่าง
                        {
                            freq = status[3];   // เทียบค่าความถี่ ( หรือ duration )
                            flash_duration = freq;   // เก็บค่า flash duration
                            box[freq, 1]++;     // เพิ่มค่าถี่ของ duration ที่นับได้ ที่ มิติที่สอง (1) เนื่องจากไว้เก็บ duration ของช่วงสว่าง
                            status[1] = status[2];  // กำหนดค่า ปัจจุบัน ให้เป็นอดีตเพื่อเปรียบเทียบ
                            this.show_freq_chart.Series["Flash period"].Points.AddXY(freq + 1, box[freq, 1]);
                            status[3] = 0;      // คืนค่า array สำหรับนับความถี่
                            freq = 0;           // เซ็ตค่า freq เป็น 0 เพื่อรอการเปรียบเทียบ


                        }
                        else                    // ถ้าไม่ใช่ 
                        {
                            freq = status[3];       // เทียบค่าความถี่ ( หรือ duration )
                            freq = freq + flash_duration + 1;
                            box[freq, 0]++;         // เพิ่มค่าถี่ของ duration ที่นับได้ ที่ มิติที่สอง (0) เนื่องจากไว้เก็บ duration ของช่วงสว่าง
                            status[1] = status[2];  // กำหนดค่า ปัจจุบัน ให้เป็นอดีตเพื่อเปรียบเทียบ
                            this.show_freq_chart.Series["Flash period + Dark period"].Points.AddXY(freq + 1, box[freq, 0]);
                            status[3] = 0;      // คืนค่า array สำหรับนับความถี่
                            freq = 0;           // เซ็ตค่า freq เป็น 0 เพื่อรอการเปรียบเทียบ
                            flash_duration = 0;
                        }

                    }

                }

                input_column++;

                ref_name = Convert.ToString(excelCell.Cells[input_column, row_count].Value2);
            }

            /*////////

            if (save_status == 0)
            {
                if (status[1] > 0)      // ถ้าค่าที่นับอยู่เป็น สว่าง
                {
                    freq = status[3];   // เทียบค่าความถี่ ( หรือ duration )
                    box[freq, 1]++;     // เพิ่มค่าถี่ของ duration ที่นับได้ ที่ มิติที่สอง (1) เนื่องจากไว้เก็บ duration ของช่วงสว่าง
                    status[1] = status[2];  // กำหนดค่า ปัจจุบัน ให้เป็นอดีตเพื่อเปรียบเทียบ
                    freq = 0;           // เซ็ตค่า freq เป็น 0 เพื่อรอการเปรียบเทียบ
                    this.show_freq_chart.Series["Flash period"].Points.AddXY(freq, box[freq, 1]);
                }
                else                    // ถ้าไม่ใช่ 
                {
                    freq = status[3];       // เทียบค่าความถี่ ( หรือ duration )
                    box[freq, 0]++;         // เพิ่มค่าถี่ของ duration ที่นับได้ ที่ มิติที่สอง (0) เนื่องจากไว้เก็บ duration ของช่วงสว่าง
                    status[1] = status[2];  // กำหนดค่า ปัจจุบัน ให้เป็นอดีตเพื่อเปรียบเทียบ
                    freq = 0;           // เซ็ตค่า freq เป็น 0 เพื่อรอการเปรียบเทียบ
                    this.show_freq_chart.Series["Dark period"].Points.AddXY(freq, box[freq, 0]);
                }
            }

            /*/////////

            progressBar.Value = 100;

            if (checkBox_multiple_run.Checked)
            {
                Application.Idle += save_excel_Click;
            }

        }

        private void close_excel_Click(object sender, EventArgs e)
        {
            excelApp.Quit();

            Marshal.ReleaseComObject(excelApp);
            excelApp = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            try
            {
                excelApp.Quit();

                Marshal.ReleaseComObject(excelApp);
                excelApp = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();

                this.Close();
            }
            catch (Exception)
            {
                this.Close();
            }
        }

        private void save_excel_Click(object sender, EventArgs e)
        {
            excelWorkbook.Close(null, null, null);                 
            excelApp.Quit();

            Marshal.ReleaseComObject(excelApp);
            excelApp = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();

            sv_name = save_name.Text;

            if (checkBox_multiple_run.Checked)
            {
                excelApp1 = new xc.Application();
                excelApp1.Visible = true;
                excelWorkbook1 = excelApp1.Workbooks.Open(Open_for_save.FileName);
                excelSheets1 = excelWorkbook1.Worksheets;
                excelWorkSheet1 = excelSheets1.get_Item("Sheet1");
                excelCell1 = excelWorkSheet1.UsedRange;



                for (int cc = 1; cc <= 16383; cc++)
                {
                    ref_save_column = Convert.ToString(excelCell1.Cells[2, cc].Value2);

                    if (ref_save_column == null)
                    {
                        start_column_save = cc;
                        excelWorkSheet1.Cells[1, cc] = sv_name;
                        excelWorkSheet1.Cells[2, cc] = "Frame No.";
                        excelWorkSheet1.Cells[2, cc + 1] = "Flash period + Dark period";
                        excelWorkSheet1.Cells[2, cc + 2] = "Flash period";
                        break;
                    }

                }


                for (int bb = 1; bb <= box.GetUpperBound(0); bb++)
                {
                    excelWorkSheet1.Cells[bb + 2, start_column_save] = (bb - 1) + 1;
                    excelWorkSheet1.Cells[bb + 2, start_column_save + 1] = box[bb - 1, 0];
                    excelWorkSheet1.Cells[bb + 2, start_column_save + 2] = box[bb - 1, 1];
                }

                excelWorkbook1.Save();
                excelWorkbook1.Close(null, null, null);


                excelApp1.Quit();
                Marshal.ReleaseComObject(excelApp1);
                excelApp1 = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();

                Array.Clear(box, 1, 51);
                Array.Clear(box, 2, 2);
                foreach (var series in show_freq_chart.Series)
                {
                    series.Points.Clear();
                }
                Application.Idle += multiple_file_run;
                Application.Idle -= save_excel_Click;
            }

            else
            {
                if (Open_for_save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    excelApp1 = new xc.Application();
                    excelApp1.Visible = true;
                    excelWorkbook1 = excelApp1.Workbooks.Open(Open_for_save.FileName);
                    excelSheets1 = excelWorkbook1.Worksheets;
                    excelWorkSheet1 = excelSheets1.get_Item("Sheet1");
                    excelCell1 = excelWorkSheet1.UsedRange;



                    for (int cc = 1; cc <= 16383; cc++)
                    {
                        ref_save_column = Convert.ToString(excelCell1.Cells[2, cc].Value2);

                        if (ref_save_column == null)
                        {
                            start_column_save = cc;
                            excelWorkSheet1.Cells[1, cc] = sv_name;
                            excelWorkSheet1.Cells[2, cc] = "Frame No.";
                            excelWorkSheet1.Cells[2, cc + 1] = "Flash period + Dark period";
                            excelWorkSheet1.Cells[2, cc + 2] = "Flash period";
                            break;
                        }

                    }


                    for (int bb = 1; bb <= box.GetUpperBound(0); bb++)
                    {
                        excelWorkSheet1.Cells[bb + 2, start_column_save] = (bb - 1) + 1;
                        excelWorkSheet1.Cells[bb + 2, start_column_save + 1] = box[bb - 1, 0];
                        excelWorkSheet1.Cells[bb + 2, start_column_save + 2] = box[bb - 1, 1];
                    }

                    excelWorkbook1.Save();
                    excelWorkbook1.Close(null, null, null);


                    excelApp1.Quit();


                    Marshal.ReleaseComObject(excelApp1);
                    excelApp1 = null;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    

                    Array.Clear(box, 1, 51);
                    Array.Clear(box, 2, 2);
                    foreach (var series in show_freq_chart.Series)
                    {
                        series.Points.Clear();
                    }
                }

                Application.Idle -= save_excel_Click;

            }
        }

    }

}

