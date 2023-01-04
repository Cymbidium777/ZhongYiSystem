
namespace 中医信息管理系统.中医古籍
{
    partial class FormJingLuo
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
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lviXW = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.labTitle2 = new System.Windows.Forms.Label();
            this.rtbNR = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.labTitle1 = new System.Windows.Forms.Label();
            this.lviJM = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // columnHeader2
            // 
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 98;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 0;
            // 
            // lviXW
            // 
            this.lviXW.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.lviXW.BackColor = System.Drawing.SystemColors.Window;
            this.lviXW.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader6});
            this.lviXW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lviXW.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lviXW.FullRowSelect = true;
            this.lviXW.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lviXW.HideSelection = false;
            this.lviXW.Location = new System.Drawing.Point(0, 0);
            this.lviXW.MultiSelect = false;
            this.lviXW.Name = "lviXW";
            this.lviXW.ShowGroups = false;
            this.lviXW.Size = new System.Drawing.Size(120, 496);
            this.lviXW.TabIndex = 4;
            this.lviXW.UseCompatibleStateImageBehavior = false;
            this.lviXW.View = System.Windows.Forms.View.Details;
            this.lviXW.Click += new System.EventHandler(this.lviXW_Click);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Width = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.lviXW);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(544, 496);
            this.splitContainer3.SplitterDistance = 120;
            this.splitContainer3.SplitterWidth = 2;
            this.splitContainer3.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.labTitle2);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.rtbNR);
            this.splitContainer4.Size = new System.Drawing.Size(422, 496);
            this.splitContainer4.SplitterDistance = 29;
            this.splitContainer4.SplitterWidth = 2;
            this.splitContainer4.TabIndex = 0;
            // 
            // labTitle2
            // 
            this.labTitle2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labTitle2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labTitle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTitle2.Location = new System.Drawing.Point(0, 0);
            this.labTitle2.Name = "labTitle2";
            this.labTitle2.Size = new System.Drawing.Size(422, 29);
            this.labTitle2.TabIndex = 0;
            this.labTitle2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rtbNR
            // 
            this.rtbNR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbNR.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtbNR.Location = new System.Drawing.Point(0, 0);
            this.rtbNR.Name = "rtbNR";
            this.rtbNR.ReadOnly = true;
            this.rtbNR.Size = new System.Drawing.Size(422, 465);
            this.rtbNR.TabIndex = 1;
            this.rtbNR.Text = "";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(2, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(796, 496);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.labTitle1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lviJM);
            this.splitContainer2.Size = new System.Drawing.Size(250, 496);
            this.splitContainer2.SplitterDistance = 60;
            this.splitContainer2.SplitterWidth = 2;
            this.splitContainer2.TabIndex = 0;
            // 
            // labTitle1
            // 
            this.labTitle1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labTitle1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labTitle1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTitle1.Location = new System.Drawing.Point(0, 0);
            this.labTitle1.Margin = new System.Windows.Forms.Padding(3);
            this.labTitle1.Name = "labTitle1";
            this.labTitle1.Padding = new System.Windows.Forms.Padding(3);
            this.labTitle1.Size = new System.Drawing.Size(250, 60);
            this.labTitle1.TabIndex = 0;
            this.labTitle1.Text = "经 络 信 息";
            this.labTitle1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lviJM
            // 
            this.lviJM.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.lviJM.BackColor = System.Drawing.SystemColors.Window;
            this.lviJM.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lviJM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lviJM.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lviJM.FullRowSelect = true;
            this.lviJM.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lviJM.HideSelection = false;
            this.lviJM.Location = new System.Drawing.Point(0, 0);
            this.lviJM.MultiSelect = false;
            this.lviJM.Name = "lviJM";
            this.lviJM.ShowGroups = false;
            this.lviJM.Size = new System.Drawing.Size(250, 434);
            this.lviJM.TabIndex = 5;
            this.lviJM.UseCompatibleStateImageBehavior = false;
            this.lviJM.View = System.Windows.Forms.View.Details;
            this.lviJM.Click += new System.EventHandler(this.lviJM_Click);
            this.lviJM.DoubleClick += new System.EventHandler(this.lviJM_DoubleClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 0;
            // 
            // columnHeader4
            // 
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 245;
            // 
            // columnHeader5
            // 
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 0;
            // 
            // FormJingLuo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormJingLuo";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "经络信息";
            this.Load += new System.EventHandler(this.FormJingLuo_Load);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView lviXW;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label labTitle1;
        private System.Windows.Forms.ListView lviJM;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.RichTextBox rtbNR;
        private System.Windows.Forms.Label labTitle2;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}