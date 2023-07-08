namespace Serial_Communication_Tools
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.MainSceneBtn = new System.Windows.Forms.ToolStripButton();
            this.ControllerBtn = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MainScene = new Serial_Communication_Tools.MainScene();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 670);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1386, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainSceneBtn,
            this.ControllerBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1386, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // MainSceneBtn
            // 
            this.MainSceneBtn.Image = ((System.Drawing.Image)(resources.GetObject("MainSceneBtn.Image")));
            this.MainSceneBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MainSceneBtn.Name = "MainSceneBtn";
            this.MainSceneBtn.Size = new System.Drawing.Size(54, 22);
            this.MainSceneBtn.Text = "Main";
            this.MainSceneBtn.Click += new System.EventHandler(this.MainSceneBtn_Click);
            // 
            // ControllerBtn
            // 
            this.ControllerBtn.Image = ((System.Drawing.Image)(resources.GetObject("ControllerBtn.Image")));
            this.ControllerBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ControllerBtn.Name = "ControllerBtn";
            this.ControllerBtn.Size = new System.Drawing.Size(48, 22);
            this.ControllerBtn.Text = "Info";
            this.ControllerBtn.Click += new System.EventHandler(this.ControllerBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.MainScene);
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1386, 664);
            this.panel1.TabIndex = 2;
            // 
            // MainScene
            // 
            this.MainScene.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainScene.Location = new System.Drawing.Point(0, 0);
            this.MainScene.Name = "MainScene";
            this.MainScene.Size = new System.Drawing.Size(1386, 664);
            this.MainScene.TabIndex = 0;
            this.MainScene.Load += new System.EventHandler(this.mainScene1_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 692);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton MainSceneBtn;
        private System.Windows.Forms.ToolStripButton ControllerBtn;
        private System.Windows.Forms.Panel panel1;
        private MainScene MainScene;
    }
}

