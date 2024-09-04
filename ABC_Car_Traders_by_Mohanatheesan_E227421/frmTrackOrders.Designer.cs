namespace ABC_Car_Traders_by_Mohanatheesan_E227421
{
    partial class frmTrackOrders
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataMyOrders = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataOrderItems = new System.Windows.Forms.DataGridView();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.txtOrderDateTime = new System.Windows.Forms.TextBox();
            this.txtOrderValue = new System.Windows.Forms.TextBox();
            this.txtOrderStatus = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataMyOrders)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataOrderItems)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(317, 406);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(317, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(317, 406);
            this.panel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataMyOrders);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 406);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "My Orders";
            // 
            // dataMyOrders
            // 
            this.dataMyOrders.AllowUserToAddRows = false;
            this.dataMyOrders.AllowUserToDeleteRows = false;
            this.dataMyOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataMyOrders.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataMyOrders.Location = new System.Drawing.Point(3, 16);
            this.dataMyOrders.Name = "dataMyOrders";
            this.dataMyOrders.ReadOnly = true;
            this.dataMyOrders.Size = new System.Drawing.Size(311, 269);
            this.dataMyOrders.TabIndex = 0;
            this.dataMyOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataMyOrders_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtOrderStatus);
            this.groupBox2.Controls.Add(this.txtOrderValue);
            this.groupBox2.Controls.Add(this.txtOrderDateTime);
            this.groupBox2.Controls.Add(this.txtOrderID);
            this.groupBox2.Controls.Add(this.dataOrderItems);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(317, 406);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Order Details";
            // 
            // dataOrderItems
            // 
            this.dataOrderItems.AllowUserToAddRows = false;
            this.dataOrderItems.AllowUserToDeleteRows = false;
            this.dataOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataOrderItems.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataOrderItems.Location = new System.Drawing.Point(3, 16);
            this.dataOrderItems.Name = "dataOrderItems";
            this.dataOrderItems.ReadOnly = true;
            this.dataOrderItems.Size = new System.Drawing.Size(311, 269);
            this.dataOrderItems.TabIndex = 0;
            // 
            // txtOrderID
            // 
            this.txtOrderID.Location = new System.Drawing.Point(3, 291);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.ReadOnly = true;
            this.txtOrderID.Size = new System.Drawing.Size(56, 20);
            this.txtOrderID.TabIndex = 1;
            // 
            // txtOrderDateTime
            // 
            this.txtOrderDateTime.Location = new System.Drawing.Point(65, 291);
            this.txtOrderDateTime.Name = "txtOrderDateTime";
            this.txtOrderDateTime.ReadOnly = true;
            this.txtOrderDateTime.Size = new System.Drawing.Size(126, 20);
            this.txtOrderDateTime.TabIndex = 2;
            // 
            // txtOrderValue
            // 
            this.txtOrderValue.Location = new System.Drawing.Point(197, 291);
            this.txtOrderValue.Name = "txtOrderValue";
            this.txtOrderValue.ReadOnly = true;
            this.txtOrderValue.Size = new System.Drawing.Size(117, 20);
            this.txtOrderValue.TabIndex = 3;
            // 
            // txtOrderStatus
            // 
            this.txtOrderStatus.Location = new System.Drawing.Point(3, 317);
            this.txtOrderStatus.Name = "txtOrderStatus";
            this.txtOrderStatus.ReadOnly = true;
            this.txtOrderStatus.Size = new System.Drawing.Size(117, 20);
            this.txtOrderStatus.TabIndex = 4;
            // 
            // frmTrackOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 406);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTrackOrders";
            this.Text = "frmTrackOrders";
            this.Load += new System.EventHandler(this.frmTrackOrders_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataMyOrders)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataOrderItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataMyOrders;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataOrderItems;
        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.TextBox txtOrderDateTime;
        private System.Windows.Forms.TextBox txtOrderValue;
        private System.Windows.Forms.TextBox txtOrderStatus;
    }
}