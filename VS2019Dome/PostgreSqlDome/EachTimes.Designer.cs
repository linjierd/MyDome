
namespace PostgreSqlDome
{
    partial class EachTimes
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_Times = new System.Windows.Forms.TextBox();
            this.btn_confrom = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "你要循环执行几次";
            // 
            // tbx_Times
            // 
            this.tbx_Times.Location = new System.Drawing.Point(124, 13);
            this.tbx_Times.Name = "tbx_Times";
            this.tbx_Times.Size = new System.Drawing.Size(58, 23);
            this.tbx_Times.TabIndex = 1;
            // 
            // btn_confrom
            // 
            this.btn_confrom.Location = new System.Drawing.Point(189, 13);
            this.btn_confrom.Name = "btn_confrom";
            this.btn_confrom.Size = new System.Drawing.Size(75, 23);
            this.btn_confrom.TabIndex = 2;
            this.btn_confrom.Text = "确认";
            this.btn_confrom.UseVisualStyleBackColor = true;
            this.btn_confrom.Click += new System.EventHandler(this.btn_confrom_Click);
            // 
            // EachTimes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 50);
            this.Controls.Add(this.btn_confrom);
            this.Controls.Add(this.tbx_Times);
            this.Controls.Add(this.label1);
            this.Name = "EachTimes";
            this.Text = "EachTimes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbx_Times;
        private System.Windows.Forms.Button btn_confrom;
    }
}