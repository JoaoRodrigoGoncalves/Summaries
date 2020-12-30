namespace Summaries.codeResources
{
    partial class confirmByTyping
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(confirmByTyping));
            this.textBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.errorLB = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textToBeWritten = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(12, 101);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(371, 20);
            this.textBox.TabIndex = 0;
            this.textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(308, 140);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Confirm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // errorLB
            // 
            this.errorLB.AutoSize = true;
            this.errorLB.ForeColor = System.Drawing.Color.Red;
            this.errorLB.Location = new System.Drawing.Point(12, 124);
            this.errorLB.Name = "errorLB";
            this.errorLB.Size = new System.Drawing.Size(154, 13);
            this.errorLB.TabIndex = 2;
            this.errorLB.Text = "The typed text does not match!";
            this.errorLB.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(354, 36);
            this.label2.TabIndex = 3;
            this.label2.Text = "Before you continue, please write the following text in\r\nthe box";
            // 
            // textToBeWritten
            // 
            this.textToBeWritten.AutoSize = true;
            this.textToBeWritten.Location = new System.Drawing.Point(12, 61);
            this.textToBeWritten.Name = "textToBeWritten";
            this.textToBeWritten.Size = new System.Drawing.Size(35, 13);
            this.textToBeWritten.TabIndex = 4;
            this.textToBeWritten.Text = "label3";
            // 
            // confirmByTyping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 175);
            this.Controls.Add(this.textToBeWritten);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.errorLB);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "confirmByTyping";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Confirm ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label errorLB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label textToBeWritten;
    }
}