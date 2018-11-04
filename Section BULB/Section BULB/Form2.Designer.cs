namespace Section_BULB
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.next_file_button = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.show_freq_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.address_file_listBox = new System.Windows.Forms.ListBox();
            this.no_listBox = new System.Windows.Forms.ListBox();
            this.file_name_listBox = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.checkBox_multiple_run = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.Multiple_button = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.save_name = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.start_column_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.no_data_comboBox = new System.Windows.Forms.ComboBox();
            this.start_row_textBox = new System.Windows.Forms.TextBox();
            this.save_excel = new System.Windows.Forms.Button();
            this.close_excel = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.classify = new System.Windows.Forms.Button();
            this.Close = new System.Windows.Forms.Button();
            this.open_excel = new System.Windows.Forms.Button();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.show_freq_chart)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // next_file_button
            // 
            this.next_file_button.Location = new System.Drawing.Point(8, 68);
            this.next_file_button.Name = "next_file_button";
            this.next_file_button.Size = new System.Drawing.Size(84, 23);
            this.next_file_button.TabIndex = 24;
            this.next_file_button.Text = "next file";
            this.next_file_button.UseVisualStyleBackColor = true;
            this.next_file_button.Click += new System.EventHandler(this.next_file_button_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.show_freq_chart);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(442, 269);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Analysis Chart";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // show_freq_chart
            // 
            chartArea1.AxisX.Title = "frame number";
            chartArea1.AxisY.Title = "freq";
            chartArea1.Name = "ChartArea1";
            this.show_freq_chart.ChartAreas.Add(chartArea1);
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            this.show_freq_chart.Legends.Add(legend1);
            this.show_freq_chart.Location = new System.Drawing.Point(12, 9);
            this.show_freq_chart.Name = "show_freq_chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Flash period + Dark period";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Flash period";
            this.show_freq_chart.Series.Add(series1);
            this.show_freq_chart.Series.Add(series2);
            this.show_freq_chart.Size = new System.Drawing.Size(408, 254);
            this.show_freq_chart.TabIndex = 1;
            this.show_freq_chart.Text = "chart1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.address_file_listBox);
            this.tabPage2.Controls.Add(this.no_listBox);
            this.tabPage2.Controls.Add(this.file_name_listBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(442, 269);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Multiple file input";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // address_file_listBox
            // 
            this.address_file_listBox.AllowDrop = true;
            this.address_file_listBox.FormattingEnabled = true;
            this.address_file_listBox.Location = new System.Drawing.Point(107, 6);
            this.address_file_listBox.Name = "address_file_listBox";
            this.address_file_listBox.ScrollAlwaysVisible = true;
            this.address_file_listBox.Size = new System.Drawing.Size(276, 251);
            this.address_file_listBox.TabIndex = 13;
            this.address_file_listBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBoxFiles_DragDrop);
            this.address_file_listBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBoxFiles_DragEnter);
            // 
            // no_listBox
            // 
            this.no_listBox.FormattingEnabled = true;
            this.no_listBox.Location = new System.Drawing.Point(389, 6);
            this.no_listBox.Name = "no_listBox";
            this.no_listBox.ScrollAlwaysVisible = true;
            this.no_listBox.Size = new System.Drawing.Size(42, 251);
            this.no_listBox.TabIndex = 14;
            // 
            // file_name_listBox
            // 
            this.file_name_listBox.FormattingEnabled = true;
            this.file_name_listBox.Location = new System.Drawing.Point(6, 6);
            this.file_name_listBox.Name = "file_name_listBox";
            this.file_name_listBox.ScrollAlwaysVisible = true;
            this.file_name_listBox.Size = new System.Drawing.Size(94, 251);
            this.file_name_listBox.TabIndex = 15;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(98, 10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(450, 295);
            this.tabControl1.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(560, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "remaining data";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(559, 126);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(83, 20);
            this.textBox1.TabIndex = 33;
            // 
            // checkBox_multiple_run
            // 
            this.checkBox_multiple_run.AutoSize = true;
            this.checkBox_multiple_run.Location = new System.Drawing.Point(566, 32);
            this.checkBox_multiple_run.Name = "checkBox_multiple_run";
            this.checkBox_multiple_run.Size = new System.Drawing.Size(65, 17);
            this.checkBox_multiple_run.TabIndex = 32;
            this.checkBox_multiple_run.Text = "multi-run";
            this.checkBox_multiple_run.UseVisualStyleBackColor = true;
            this.checkBox_multiple_run.CheckedChanged += new System.EventHandler(this.checkBox_multiple_run_CheckedChanged);
            // 
            // Multiple_button
            // 
            this.Multiple_button.Enabled = false;
            this.Multiple_button.Location = new System.Drawing.Point(558, 64);
            this.Multiple_button.Name = "Multiple_button";
            this.Multiple_button.Size = new System.Drawing.Size(83, 23);
            this.Multiple_button.TabIndex = 31;
            this.Multiple_button.Text = "Multiple run";
            this.Multiple_button.UseVisualStyleBackColor = true;
            this.Multiple_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(560, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "fliename";
            // 
            // save_name
            // 
            this.save_name.Location = new System.Drawing.Point(558, 185);
            this.save_name.Name = "save_name";
            this.save_name.Size = new System.Drawing.Size(81, 20);
            this.save_name.TabIndex = 30;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.start_column_textBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.no_data_comboBox);
            this.groupBox1.Controls.Add(this.start_row_textBox);
            this.groupBox1.Location = new System.Drawing.Point(9, 152);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(83, 95);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Begin";
            // 
            // start_column_textBox
            // 
            this.start_column_textBox.Location = new System.Drawing.Point(49, 37);
            this.start_column_textBox.Name = "start_column_textBox";
            this.start_column_textBox.Size = new System.Drawing.Size(26, 20);
            this.start_column_textBox.TabIndex = 4;
            this.start_column_textBox.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Row";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "No.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Column";
            // 
            // no_data_comboBox
            // 
            this.no_data_comboBox.FormattingEnabled = true;
            this.no_data_comboBox.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79",
            "80",
            "81",
            "82",
            "83",
            "84",
            "85",
            "86",
            "87",
            "88",
            "89",
            "90",
            "91",
            "92",
            "93",
            "94",
            "95",
            "96",
            "97",
            "98",
            "99",
            "100",
            "101",
            "102",
            "103",
            "104",
            "105",
            "106",
            "107",
            "108",
            "109",
            "110",
            "111",
            "112",
            "113",
            "114",
            "115",
            "116",
            "117",
            "118",
            "119",
            "120",
            "121",
            "122",
            "123",
            "124",
            "125",
            "126",
            "127",
            "128",
            "129",
            "130",
            "131",
            "132",
            "133",
            "134",
            "135",
            "136",
            "137",
            "138",
            "139",
            "140",
            "141",
            "142",
            "143",
            "144",
            "145",
            "146",
            "147",
            "148",
            "149",
            "150",
            "151",
            "152",
            "153",
            "154",
            "155",
            "156",
            "157",
            "158",
            "159",
            "160",
            "161",
            "162",
            "163",
            "164",
            "165",
            "166",
            "167",
            "168",
            "169",
            "170",
            "171",
            "172",
            "173",
            "174",
            "175",
            "176",
            "177",
            "178",
            "179",
            "180",
            "181",
            "182",
            "183",
            "184",
            "185",
            "186",
            "187",
            "188",
            "189",
            "190",
            "191",
            "192",
            "193",
            "194",
            "195",
            "196",
            "197",
            "198",
            "199",
            "200",
            "201",
            "202",
            "203",
            "204",
            "205",
            "206",
            "207",
            "208",
            "209",
            "210",
            "211",
            "212",
            "213",
            "214",
            "215",
            "216",
            "217",
            "218",
            "219",
            "220",
            "221",
            "222",
            "223",
            "224",
            "225",
            "226",
            "227",
            "228",
            "229",
            "230",
            "231",
            "232",
            "233",
            "234",
            "235",
            "236",
            "237",
            "238",
            "239",
            "240",
            "241",
            "242",
            "243",
            "244",
            "245",
            "246",
            "247",
            "248",
            "249",
            "250",
            "251",
            "252",
            "253",
            "254",
            "255",
            "256",
            "257",
            "258",
            "259",
            "260",
            "261",
            "262",
            "263",
            "264",
            "265",
            "266",
            "267",
            "268",
            "269",
            "270",
            "271",
            "272",
            "273",
            "274",
            "275",
            "276",
            "277",
            "278",
            "279",
            "280",
            "281",
            "282",
            "283",
            "284",
            "285",
            "286",
            "287",
            "288",
            "289",
            "290",
            "291",
            "292",
            "293",
            "294",
            "295",
            "296",
            "297",
            "298",
            "299",
            "300"});
            this.no_data_comboBox.Location = new System.Drawing.Point(36, 63);
            this.no_data_comboBox.Name = "no_data_comboBox";
            this.no_data_comboBox.Size = new System.Drawing.Size(41, 21);
            this.no_data_comboBox.TabIndex = 8;
            this.no_data_comboBox.Text = "1";
            // 
            // start_row_textBox
            // 
            this.start_row_textBox.Location = new System.Drawing.Point(49, 12);
            this.start_row_textBox.Name = "start_row_textBox";
            this.start_row_textBox.Size = new System.Drawing.Size(26, 20);
            this.start_row_textBox.TabIndex = 4;
            this.start_row_textBox.Text = "1";
            // 
            // save_excel
            // 
            this.save_excel.Location = new System.Drawing.Point(9, 95);
            this.save_excel.Name = "save_excel";
            this.save_excel.Size = new System.Drawing.Size(83, 23);
            this.save_excel.TabIndex = 27;
            this.save_excel.Text = "Save";
            this.save_excel.UseVisualStyleBackColor = true;
            this.save_excel.Click += new System.EventHandler(this.save_excel_Click);
            // 
            // close_excel
            // 
            this.close_excel.Location = new System.Drawing.Point(8, 123);
            this.close_excel.Name = "close_excel";
            this.close_excel.Size = new System.Drawing.Size(83, 23);
            this.close_excel.TabIndex = 26;
            this.close_excel.Text = "Close excel";
            this.close_excel.UseVisualStyleBackColor = true;
            this.close_excel.Click += new System.EventHandler(this.close_excel_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(8, 282);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(83, 23);
            this.progressBar.TabIndex = 25;
            // 
            // classify
            // 
            this.classify.Location = new System.Drawing.Point(8, 41);
            this.classify.Name = "classify";
            this.classify.Size = new System.Drawing.Size(83, 23);
            this.classify.TabIndex = 23;
            this.classify.Text = "Classify";
            this.classify.UseVisualStyleBackColor = true;
            this.classify.Click += new System.EventHandler(this.classify_Click);
            // 
            // Close
            // 
            this.Close.Location = new System.Drawing.Point(8, 253);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(82, 23);
            this.Close.TabIndex = 29;
            this.Close.Text = "Close program";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // open_excel
            // 
            this.open_excel.Location = new System.Drawing.Point(8, 11);
            this.open_excel.Name = "open_excel";
            this.open_excel.Size = new System.Drawing.Size(83, 23);
            this.open_excel.TabIndex = 22;
            this.open_excel.Text = "Open excel";
            this.open_excel.UseVisualStyleBackColor = true;
            this.open_excel.Click += new System.EventHandler(this.open_excel_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 314);
            this.Controls.Add(this.next_file_button);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBox_multiple_run);
            this.Controls.Add(this.Multiple_button);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.save_name);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.save_excel);
            this.Controls.Add(this.close_excel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.classify);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.open_excel);
            this.Name = "Form2";
            this.Text = "Section GEMINI";
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.show_freq_chart)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button next_file_button;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataVisualization.Charting.Chart show_freq_chart;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox address_file_listBox;
        private System.Windows.Forms.ListBox no_listBox;
        private System.Windows.Forms.ListBox file_name_listBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.CheckBox checkBox_multiple_run;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button Multiple_button;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox save_name;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox start_column_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox no_data_comboBox;
        private System.Windows.Forms.TextBox start_row_textBox;
        private System.Windows.Forms.Button save_excel;
        private System.Windows.Forms.Button close_excel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button classify;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Button open_excel;
    }
}