namespace Section_BULB
{
    partial class main
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
            this.open_second_program_button = new System.Windows.Forms.Button();
            this.open_first_program_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // open_second_program_button
            // 
            this.open_second_program_button.Location = new System.Drawing.Point(157, 108);
            this.open_second_program_button.Name = "open_second_program_button";
            this.open_second_program_button.Size = new System.Drawing.Size(99, 44);
            this.open_second_program_button.TabIndex = 3;
            this.open_second_program_button.Text = "Section BULB";
            this.open_second_program_button.UseVisualStyleBackColor = true;
            this.open_second_program_button.Click += new System.EventHandler(this.button2_Click);
            // 
            // open_first_program_button
            // 
            this.open_first_program_button.Location = new System.Drawing.Point(29, 108);
            this.open_first_program_button.Name = "open_first_program_button";
            this.open_first_program_button.Size = new System.Drawing.Size(95, 44);
            this.open_first_program_button.TabIndex = 2;
            this.open_first_program_button.Text = "Section GEMINI";
            this.open_first_program_button.UseVisualStyleBackColor = true;
            this.open_first_program_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.open_second_program_button);
            this.Controls.Add(this.open_first_program_button);
            this.Name = "main";
            this.Text = "main";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button open_second_program_button;
        private System.Windows.Forms.Button open_first_program_button;
    }
}