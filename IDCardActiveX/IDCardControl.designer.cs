namespace IDCardActiveX
{
    partial class IDCardControl
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.picbPhoto = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picbPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // picbPhoto
            // 
            this.picbPhoto.Location = new System.Drawing.Point(13, 14);
            this.picbPhoto.Name = "picbPhoto";
            this.picbPhoto.Size = new System.Drawing.Size(149, 186);
            this.picbPhoto.TabIndex = 0;
            this.picbPhoto.TabStop = false;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picbPhoto);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(185, 223);
            ((System.ComponentModel.ISupportInitialize)(this.picbPhoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picbPhoto;


    }
}
