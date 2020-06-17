namespace WhoIs
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
            this.addressBox = new System.Windows.Forms.TextBox();
            this.resultBox = new System.Windows.Forms.TextBox();
            this.seartchButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addressBox
            // 
            this.addressBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addressBox.Location = new System.Drawing.Point(12, 40);
            this.addressBox.Name = "addressBox";
            this.addressBox.Size = new System.Drawing.Size(272, 21);
            this.addressBox.TabIndex = 0;
            // 
            // resultBox
            // 
            this.resultBox.Location = new System.Drawing.Point(12, 93);
            this.resultBox.Multiline = true;
            this.resultBox.Name = "resultBox";
            this.resultBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultBox.Size = new System.Drawing.Size(484, 286);
            this.resultBox.TabIndex = 1;
            // 
            // seartchButton
            // 
            this.seartchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seartchButton.Location = new System.Drawing.Point(304, 40);
            this.seartchButton.Name = "seartchButton";
            this.seartchButton.Size = new System.Drawing.Size(59, 21);
            this.seartchButton.TabIndex = 2;
            this.seartchButton.Text = "Search";
            this.seartchButton.UseVisualStyleBackColor = true;
            this.seartchButton.Click += new System.EventHandler(this.seartchButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 411);
            this.Controls.Add(this.seartchButton);
            this.Controls.Add(this.resultBox);
            this.Controls.Add(this.addressBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox addressBox;
        private System.Windows.Forms.TextBox resultBox;
        private System.Windows.Forms.Button seartchButton;
    }
}

