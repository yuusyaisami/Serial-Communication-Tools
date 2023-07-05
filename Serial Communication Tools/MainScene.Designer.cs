namespace Serial_Communication_Tools
{
    partial class MainScene
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Tab = new System.Windows.Forms.TabControl();
            this.SettingTab = new System.Windows.Forms.TabPage();
            this.ViewTab = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.SerialPortNames = new System.Windows.Forms.ComboBox();
            this.ConnectText = new System.Windows.Forms.Label();
            this.ClearText = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tab
            // 
            this.Tab.Controls.Add(this.SettingTab);
            this.Tab.Controls.Add(this.ViewTab);
            this.Tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tab.Location = new System.Drawing.Point(0, 0);
            this.Tab.Name = "Tab";
            this.Tab.SelectedIndex = 0;
            this.Tab.Size = new System.Drawing.Size(304, 861);
            this.Tab.TabIndex = 0;
            // 
            // SettingTab
            // 
            this.SettingTab.Location = new System.Drawing.Point(4, 22);
            this.SettingTab.Name = "SettingTab";
            this.SettingTab.Padding = new System.Windows.Forms.Padding(3);
            this.SettingTab.Size = new System.Drawing.Size(296, 835);
            this.SettingTab.TabIndex = 0;
            this.SettingTab.Text = "Setting";
            this.SettingTab.UseVisualStyleBackColor = true;
            // 
            // ViewTab
            // 
            this.ViewTab.Location = new System.Drawing.Point(4, 22);
            this.ViewTab.Name = "ViewTab";
            this.ViewTab.Padding = new System.Windows.Forms.Padding(3);
            this.ViewTab.Size = new System.Drawing.Size(296, 835);
            this.ViewTab.TabIndex = 1;
            this.ViewTab.Text = "View";
            this.ViewTab.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            this.splitContainer1.Panel1.Controls.Add(this.listView1);
            this.splitContainer1.Panel1.Controls.Add(this.ClearText);
            this.splitContainer1.Panel1.Controls.Add(this.ConnectText);
            this.splitContainer1.Panel1.Controls.Add(this.SerialPortNames);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Tab);
            this.splitContainer1.Size = new System.Drawing.Size(1106, 861);
            this.splitContainer1.SplitterDistance = 798;
            this.splitContainer1.TabIndex = 1;
            // 
            // SerialPortNames
            // 
            this.SerialPortNames.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SerialPortNames.FormattingEnabled = true;
            this.SerialPortNames.Location = new System.Drawing.Point(36, 22);
            this.SerialPortNames.Name = "SerialPortNames";
            this.SerialPortNames.Size = new System.Drawing.Size(213, 44);
            this.SerialPortNames.TabIndex = 0;
            // 
            // ConnectText
            // 
            this.ConnectText.AutoSize = true;
            this.ConnectText.BackColor = System.Drawing.Color.LightSlateGray;
            this.ConnectText.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectText.Location = new System.Drawing.Point(264, 25);
            this.ConnectText.Name = "ConnectText";
            this.ConnectText.Size = new System.Drawing.Size(128, 36);
            this.ConnectText.TabIndex = 1;
            this.ConnectText.Text = "Connect";
            this.ConnectText.Click += new System.EventHandler(this.ConnectText_Click);
            // 
            // ClearText
            // 
            this.ClearText.AutoSize = true;
            this.ClearText.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClearText.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearText.Location = new System.Drawing.Point(412, 25);
            this.ClearText.Name = "ClearText";
            this.ClearText.Size = new System.Drawing.Size(84, 36);
            this.ClearText.TabIndex = 2;
            this.ClearText.Text = "Clear";
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(36, 91);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(731, 381);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(36, 478);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(731, 29);
            this.textBox1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightSlateGray;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 518);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "Send";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightSlateGray;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(93, 518);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 22);
            this.label2.TabIndex = 7;
            // 
            // MainScene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainScene";
            this.Size = new System.Drawing.Size(1106, 861);
            this.Tab.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Tab;
        private System.Windows.Forms.TabPage SettingTab;
        private System.Windows.Forms.TabPage ViewTab;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label ClearText;
        private System.Windows.Forms.Label ConnectText;
        private System.Windows.Forms.ComboBox SerialPortNames;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
