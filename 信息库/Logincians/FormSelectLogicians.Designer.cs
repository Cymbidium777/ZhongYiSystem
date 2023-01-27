
namespace 中医信息管理系统.Logincians
{
    partial class FormSelectLogicians
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.livSelectLogicians = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dynasty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbAchievement = new System.Windows.Forms.RadioButton();
            this.rdbWork = new System.Windows.Forms.RadioButton();
            this.rdbDynasty = new System.Windows.Forms.RadioButton();
            this.rdbName = new System.Windows.Forms.RadioButton();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.livSelectLogicians);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 0;
            // 
            // livSelectLogicians
            // 
            this.livSelectLogicians.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.livSelectLogicians.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.livSelectLogicians.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.dynasty});
            this.livSelectLogicians.Dock = System.Windows.Forms.DockStyle.Fill;
            this.livSelectLogicians.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.livSelectLogicians.FullRowSelect = true;
            this.livSelectLogicians.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.livSelectLogicians.HideSelection = false;
            this.livSelectLogicians.Location = new System.Drawing.Point(0, 0);
            this.livSelectLogicians.Margin = new System.Windows.Forms.Padding(2);
            this.livSelectLogicians.MultiSelect = false;
            this.livSelectLogicians.Name = "livSelectLogicians";
            this.livSelectLogicians.Size = new System.Drawing.Size(266, 450);
            this.livSelectLogicians.TabIndex = 2;
            this.livSelectLogicians.UseCompatibleStateImageBehavior = false;
            this.livSelectLogicians.View = System.Windows.Forms.View.Details;
            this.livSelectLogicians.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.livSelectLogicians_MouseDoubleClick);
            // 
            // name
            // 
            this.name.Text = "姓名";
            this.name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.name.Width = 62;
            // 
            // dynasty
            // 
            this.dynasty.Text = "朝代";
            this.dynasty.Width = 200;
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
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(530, 450);
            this.splitContainer2.SplitterDistance = 356;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbAchievement);
            this.groupBox1.Controls.Add(this.rdbWork);
            this.groupBox1.Controls.Add(this.rdbDynasty);
            this.groupBox1.Controls.Add(this.rdbName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(530, 356);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "请选择相应的条件查询";
            // 
            // rdbAchievement
            // 
            this.rdbAchievement.AutoSize = true;
            this.rdbAchievement.Location = new System.Drawing.Point(325, 204);
            this.rdbAchievement.Name = "rdbAchievement";
            this.rdbAchievement.Size = new System.Drawing.Size(100, 18);
            this.rdbAchievement.TabIndex = 3;
            this.rdbAchievement.TabStop = true;
            this.rdbAchievement.Text = "按成就查询";
            this.rdbAchievement.UseVisualStyleBackColor = true;
            // 
            // rdbWork
            // 
            this.rdbWork.AutoSize = true;
            this.rdbWork.Location = new System.Drawing.Point(92, 204);
            this.rdbWork.Name = "rdbWork";
            this.rdbWork.Size = new System.Drawing.Size(100, 18);
            this.rdbWork.TabIndex = 2;
            this.rdbWork.TabStop = true;
            this.rdbWork.Text = "按著作查询";
            this.rdbWork.UseVisualStyleBackColor = true;
            // 
            // rdbDynasty
            // 
            this.rdbDynasty.AutoSize = true;
            this.rdbDynasty.Location = new System.Drawing.Point(325, 105);
            this.rdbDynasty.Name = "rdbDynasty";
            this.rdbDynasty.Size = new System.Drawing.Size(100, 18);
            this.rdbDynasty.TabIndex = 1;
            this.rdbDynasty.TabStop = true;
            this.rdbDynasty.Text = "按朝代查询";
            this.rdbDynasty.UseVisualStyleBackColor = true;
            // 
            // rdbName
            // 
            this.rdbName.AutoSize = true;
            this.rdbName.Location = new System.Drawing.Point(92, 105);
            this.rdbName.Name = "rdbName";
            this.rdbName.Size = new System.Drawing.Size(100, 18);
            this.rdbName.TabIndex = 0;
            this.rdbName.TabStop = true;
            this.rdbName.Text = "按姓名查询";
            this.rdbName.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.txtContent);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.btnSelect);
            this.splitContainer3.Size = new System.Drawing.Size(530, 90);
            this.splitContainer3.SplitterDistance = 254;
            this.splitContainer3.TabIndex = 0;
            // 
            // txtContent
            // 
            this.txtContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContent.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtContent.Location = new System.Drawing.Point(0, 0);
            this.txtContent.Margin = new System.Windows.Forms.Padding(2);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(254, 90);
            this.txtContent.TabIndex = 1;
            // 
            // btnSelect
            // 
            this.btnSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSelect.FlatAppearance.BorderSize = 0;
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelect.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelect.Location = new System.Drawing.Point(0, 0);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(272, 90);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "查询";
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // FormSelectLogicians
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSelectLogicians";
            this.Text = "查询各代名家";
            this.Load += new System.EventHandler(this.FormSelectLogicians_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView livSelectLogicians;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbName;
        private System.Windows.Forms.RadioButton rdbDynasty;
        private System.Windows.Forms.RadioButton rdbWork;
        private System.Windows.Forms.RadioButton rdbAchievement;
        private System.Windows.Forms.ColumnHeader dynasty;
    }
}