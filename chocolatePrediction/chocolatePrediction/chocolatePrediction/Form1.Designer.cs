namespace chocolatePrediction
{
    partial class Form1
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
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.txtCocoaPercent = new System.Windows.Forms.TextBox();
            this.txtBeanType = new System.Windows.Forms.TextBox();
            this.btn_predict = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Company";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Cocoa Percent";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Bean Type";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // txtCompany
            // 
            this.txtCompany.Location = new System.Drawing.Point(197, 6);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(100, 20);
            this.txtCompany.TabIndex = 9;
            // 
            // txtCocoaPercent
            // 
            this.txtCocoaPercent.Location = new System.Drawing.Point(197, 28);
            this.txtCocoaPercent.Name = "txtCocoaPercent";
            this.txtCocoaPercent.Size = new System.Drawing.Size(100, 20);
            this.txtCocoaPercent.TabIndex = 13;
            // 
            // txtBeanType
            // 
            this.txtBeanType.Location = new System.Drawing.Point(197, 50);
            this.txtBeanType.Name = "txtBeanType";
            this.txtBeanType.Size = new System.Drawing.Size(100, 20);
            this.txtBeanType.TabIndex = 15;
            this.txtBeanType.TextChanged += new System.EventHandler(this.txtBeanType_TextChanged);
            // 
            // btn_predict
            // 
            this.btn_predict.Location = new System.Drawing.Point(222, 76);
            this.btn_predict.Name = "btn_predict";
            this.btn_predict.Size = new System.Drawing.Size(75, 23);
            this.btn_predict.TabIndex = 17;
            this.btn_predict.Text = "Predict";
            this.btn_predict.UseVisualStyleBackColor = true;
            this.btn_predict.Click += new System.EventHandler(this.btn_predict_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 103);
            this.Controls.Add(this.btn_predict);
            this.Controls.Add(this.txtBeanType);
            this.Controls.Add(this.txtCocoaPercent);
            this.Controls.Add(this.txtCompany);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.TextBox txtCocoaPercent;
        private System.Windows.Forms.TextBox txtBeanType;
        private System.Windows.Forms.Button btn_predict;
    }
}

