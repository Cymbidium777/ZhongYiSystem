
namespace 中医信息管理系统.诊断报告
{
    partial class FormPrint
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPrintReport = new System.Windows.Forms.DataGridView();
            this.Preview = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Print = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Delete = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrintReport)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPrintReport
            // 
            this.dgvPrintReport.AllowUserToAddRows = false;
            this.dgvPrintReport.AllowUserToDeleteRows = false;
            this.dgvPrintReport.AllowUserToResizeColumns = false;
            this.dgvPrintReport.AllowUserToResizeRows = false;
            this.dgvPrintReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPrintReport.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPrintReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPrintReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrintReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Preview,
            this.Print,
            this.Delete});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPrintReport.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPrintReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPrintReport.Location = new System.Drawing.Point(0, 0);
            this.dgvPrintReport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvPrintReport.Name = "dgvPrintReport";
            this.dgvPrintReport.ReadOnly = true;
            this.dgvPrintReport.RowHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvPrintReport.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPrintReport.RowTemplate.Height = 23;
            this.dgvPrintReport.Size = new System.Drawing.Size(784, 411);
            this.dgvPrintReport.TabIndex = 0;
            // 
            // Preview
            // 
            dataGridViewCellStyle2.NullValue = "预览";
            this.Preview.DefaultCellStyle = dataGridViewCellStyle2;
            this.Preview.HeaderText = "预览";
            this.Preview.Name = "Preview";
            this.Preview.ReadOnly = true;
            this.Preview.Text = "预览";
            // 
            // Print
            // 
            dataGridViewCellStyle3.NullValue = "打印";
            this.Print.DefaultCellStyle = dataGridViewCellStyle3;
            this.Print.HeaderText = "打印";
            this.Print.Name = "Print";
            this.Print.ReadOnly = true;
            this.Print.Text = "打印";
            // 
            // Delete
            // 
            dataGridViewCellStyle4.NullValue = "删除";
            this.Delete.DefaultCellStyle = dataGridViewCellStyle4;
            this.Delete.HeaderText = "删除";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            // 
            // FormPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.dgvPrintReport);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormPrint";
            this.Text = "打印报告";
            this.Load += new System.EventHandler(this.FormPrint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrintReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPrintReport;
        private System.Windows.Forms.DataGridViewLinkColumn Preview;
        private System.Windows.Forms.DataGridViewLinkColumn Print;
        private System.Windows.Forms.DataGridViewLinkColumn Delete;
    }
}