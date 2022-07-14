
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
            this.tbn_Proc = new System.Windows.Forms.Button();
            this.btn_Proc_Result = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
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
            this.tbx_Result.Location = new System.Drawing.Point(12, 71);
            this.tbx_Result.Multiline = true;
            this.tbx_Result.Name = "tbx_Result";
            this.tbx_Result.Size = new System.Drawing.Size(483, 250);
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
            this.btn_InsertData.Click += new System.EventHandler(this.btn_InsertData_Click);
            // 
            // tbn_Proc
            // 
            this.tbn_Proc.Location = new System.Drawing.Point(12, 41);
            this.tbn_Proc.Name = "tbn_Proc";
            this.tbn_Proc.Size = new System.Drawing.Size(75, 23);
            this.tbn_Proc.TabIndex = 3;
            this.tbn_Proc.Text = "存储过程分页";
            this.tbn_Proc.UseVisualStyleBackColor = true;
            this.tbn_Proc.Click += new System.EventHandler(this.tbn_Proc_Click);
            // 
            // btn_Proc_Result
            // 
            this.btn_Proc_Result.Location = new System.Drawing.Point(94, 40);
            this.btn_Proc_Result.Name = "btn_Proc_Result";
            this.btn_Proc_Result.Size = new System.Drawing.Size(170, 23);
            this.btn_Proc_Result.TabIndex = 4;
            this.btn_Proc_Result.Text = "执行存储过程返回基本类型";
            this.btn_Proc_Result.UseVisualStyleBackColor = true;
            this.btn_Proc_Result.Click += new System.EventHandler(this.btn_Proc_Result_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(270, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "函数 output";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(373, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "过程Output";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 326);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_Proc_Result);
            this.Controls.Add(this.tbn_Proc);
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
        private System.Windows.Forms.Button tbn_Proc;
        private System.Windows.Forms.Button btn_Proc_Result;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

