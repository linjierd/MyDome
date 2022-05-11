
namespace PostgreSqlDome
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_ExecPostgreSqlFunction = new System.Windows.Forms.Button();
            this.tbx_Result = new System.Windows.Forms.TextBox();
            this.btn_InsertData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_ExecPostgreSqlFunction
            // 
            this.btn_ExecPostgreSqlFunction.Location = new System.Drawing.Point(12, 12);
            this.btn_ExecPostgreSqlFunction.Name = "btn_ExecPostgreSqlFunction";
            this.btn_ExecPostgreSqlFunction.Size = new System.Drawing.Size(153, 23);
            this.btn_ExecPostgreSqlFunction.TabIndex = 0;
            this.btn_ExecPostgreSqlFunction.Text = "执行PostgreSql存储过程";
            this.btn_ExecPostgreSqlFunction.UseVisualStyleBackColor = true;
            this.btn_ExecPostgreSqlFunction.Click += new System.EventHandler(this.btn_ExecPostgreSqlFunction_Click);
            // 
            // tbx_Result
            // 
            this.tbx_Result.Location = new System.Drawing.Point(12, 41);
            this.tbx_Result.Multiline = true;
            this.tbx_Result.Name = "tbx_Result";
            this.tbx_Result.Size = new System.Drawing.Size(351, 280);
            this.tbx_Result.TabIndex = 1;
            // 
            // btn_InsertData
            // 
            this.btn_InsertData.Location = new System.Drawing.Point(172, 11);
            this.btn_InsertData.Name = "btn_InsertData";
            this.btn_InsertData.Size = new System.Drawing.Size(92, 23);
            this.btn_InsertData.TabIndex = 2;
            this.btn_InsertData.Text = "插入数据测试";
            this.btn_InsertData.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 326);
            this.Controls.Add(this.btn_InsertData);
            this.Controls.Add(this.tbx_Result);
            this.Controls.Add(this.btn_ExecPostgreSqlFunction);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ExecPostgreSqlFunction;
        private System.Windows.Forms.TextBox tbx_Result;
        private System.Windows.Forms.Button btn_InsertData;
    }
}

