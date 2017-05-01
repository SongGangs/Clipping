namespace ClippingDemo
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Panel_Tools = new System.Windows.Forms.Panel();
            this.button_polygon = new System.Windows.Forms.Button();
            this.button_polyline = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_clipping = new System.Windows.Forms.Button();
            this.Panel_Draw = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Panel_Tools.SuspendLayout();
            this.Panel_Draw.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel_Tools
            // 
            this.Panel_Tools.Controls.Add(this.button_polygon);
            this.Panel_Tools.Controls.Add(this.button_polyline);
            this.Panel_Tools.Controls.Add(this.button_cancel);
            this.Panel_Tools.Controls.Add(this.button_clipping);
            this.Panel_Tools.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Tools.Location = new System.Drawing.Point(0, 0);
            this.Panel_Tools.Name = "Panel_Tools";
            this.Panel_Tools.Size = new System.Drawing.Size(1239, 100);
            this.Panel_Tools.TabIndex = 0;
            // 
            // button_polygon
            // 
            this.button_polygon.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.button_polygon.Location = new System.Drawing.Point(963, 37);
            this.button_polygon.Name = "button_polygon";
            this.button_polygon.Size = new System.Drawing.Size(148, 47);
            this.button_polygon.TabIndex = 3;
            this.button_polygon.Text = "多边形";
            this.button_polygon.UseVisualStyleBackColor = true;
            this.button_polygon.Click += new System.EventHandler(this.button_polygon_Click);
            // 
            // button_polyline
            // 
            this.button_polyline.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.button_polyline.Location = new System.Drawing.Point(702, 37);
            this.button_polyline.Name = "button_polyline";
            this.button_polyline.Size = new System.Drawing.Size(148, 47);
            this.button_polyline.TabIndex = 2;
            this.button_polyline.Text = "画  线";
            this.button_polyline.UseVisualStyleBackColor = true;
            this.button_polyline.Click += new System.EventHandler(this.button_polyline_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.button_cancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_cancel.Location = new System.Drawing.Point(408, 37);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(148, 47);
            this.button_cancel.TabIndex = 1;
            this.button_cancel.Text = "清 除";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_clipping
            // 
            this.button_clipping.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.button_clipping.Location = new System.Drawing.Point(82, 25);
            this.button_clipping.Name = "button_clipping";
            this.button_clipping.Size = new System.Drawing.Size(148, 47);
            this.button_clipping.TabIndex = 0;
            this.button_clipping.Text = "裁  剪";
            this.button_clipping.UseVisualStyleBackColor = true;
            this.button_clipping.Click += new System.EventHandler(this.button_clipping_Click);
            // 
            // Panel_Draw
            // 
            this.Panel_Draw.Controls.Add(this.pictureBox1);
            this.Panel_Draw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Draw.Location = new System.Drawing.Point(0, 100);
            this.Panel_Draw.Name = "Panel_Draw";
            this.Panel_Draw.Size = new System.Drawing.Size(1239, 602);
            this.Panel_Draw.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1239, 602);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "sss");
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 702);
            this.Controls.Add(this.Panel_Draw);
            this.Controls.Add(this.Panel_Tools);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Panel_Tools.ResumeLayout(false);
            this.Panel_Draw.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel_Tools;
        private System.Windows.Forms.Button button_polygon;
        private System.Windows.Forms.Button button_polyline;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_clipping;
        private System.Windows.Forms.Panel Panel_Draw;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

