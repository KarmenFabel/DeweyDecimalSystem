
namespace DeweyDecimalSystem
{
    partial class MainPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblMain = new System.Windows.Forms.Label();
            this.picBoxReplaceBooks = new System.Windows.Forms.PictureBox();
            this.picBoxIdAreas = new System.Windows.Forms.PictureBox();
            this.picBoxFindCallNum = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxReplaceBooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxIdAreas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxFindCallNum)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(685, 476);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblMain
            // 
            this.lblMain.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblMain.AutoSize = true;
            this.lblMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(160)))), ((int)(((byte)(232)))));
            this.lblMain.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMain.ForeColor = System.Drawing.Color.White;
            this.lblMain.Location = new System.Drawing.Point(264, 44);
            this.lblMain.Name = "lblMain";
            this.lblMain.Size = new System.Drawing.Size(161, 36);
            this.lblMain.TabIndex = 1;
            this.lblMain.Text = "Main Page";
            // 
            // picBoxReplaceBooks
            // 
            this.picBoxReplaceBooks.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picBoxReplaceBooks.Image = ((System.Drawing.Image)(resources.GetObject("picBoxReplaceBooks.Image")));
            this.picBoxReplaceBooks.Location = new System.Drawing.Point(96, 170);
            this.picBoxReplaceBooks.Name = "picBoxReplaceBooks";
            this.picBoxReplaceBooks.Size = new System.Drawing.Size(126, 94);
            this.picBoxReplaceBooks.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxReplaceBooks.TabIndex = 2;
            this.picBoxReplaceBooks.TabStop = false;
            this.picBoxReplaceBooks.Click += new System.EventHandler(this.picBoxReplaceBooks_Click);
            // 
            // picBoxIdAreas
            // 
            this.picBoxIdAreas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picBoxIdAreas.Image = ((System.Drawing.Image)(resources.GetObject("picBoxIdAreas.Image")));
            this.picBoxIdAreas.Location = new System.Drawing.Point(270, 170);
            this.picBoxIdAreas.Name = "picBoxIdAreas";
            this.picBoxIdAreas.Size = new System.Drawing.Size(126, 94);
            this.picBoxIdAreas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxIdAreas.TabIndex = 3;
            this.picBoxIdAreas.TabStop = false;
            this.picBoxIdAreas.Click += new System.EventHandler(this.picBoxIdAreas_Click);
            // 
            // picBoxFindCallNum
            // 
            this.picBoxFindCallNum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picBoxFindCallNum.Image = ((System.Drawing.Image)(resources.GetObject("picBoxFindCallNum.Image")));
            this.picBoxFindCallNum.Location = new System.Drawing.Point(450, 170);
            this.picBoxFindCallNum.Name = "picBoxFindCallNum";
            this.picBoxFindCallNum.Size = new System.Drawing.Size(126, 94);
            this.picBoxFindCallNum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxFindCallNum.TabIndex = 4;
            this.picBoxFindCallNum.TabStop = false;
            this.picBoxFindCallNum.Click += new System.EventHandler(this.picBoxFindCallNum_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(685, 476);
            this.Controls.Add(this.picBoxFindCallNum);
            this.Controls.Add(this.picBoxIdAreas);
            this.Controls.Add(this.picBoxReplaceBooks);
            this.Controls.Add(this.lblMain);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MainPage";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxReplaceBooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxIdAreas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxFindCallNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblMain;
        private System.Windows.Forms.PictureBox picBoxReplaceBooks;
        private System.Windows.Forms.PictureBox picBoxIdAreas;
        private System.Windows.Forms.PictureBox picBoxFindCallNum;
    }
}

