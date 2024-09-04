namespace ABC_Car_Traders_by_Mohanatheesan_E227421
{
    partial class frmManageOrders
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
            this.dataOrders = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtOrderStatus = new System.Windows.Forms.TextBox();
            this.txtOrderValue = new System.Windows.Forms.TextBox();
            this.dataOrderItems = new System.Windows.Forms.DataGridView();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtOrderBy = new System.Windows.Forms.TextBox();
            this.txtOrderDateTime = new System.Windows.Forms.TextBox();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.radioPending = new System.Windows.Forms.RadioButton();
            this.radioConfirmed = new System.Windows.Forms.RadioButton();
            this.radioDelivered = new System.Windows.Forms.RadioButton();
            this.radioCancelled = new System.Windows.Forms.RadioButton();
            this.btnUpdateOrder = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataOrders)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataOrderItems)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataOrders);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(634, 190);
            this.panel1.TabIndex = 0;
            // 
            // dataOrders
            // 
            this.dataOrders.AllowUserToAddRows = false;
            this.dataOrders.AllowUserToDeleteRows = false;
            this.dataOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataOrders.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataOrders.Location = new System.Drawing.Point(0, 36);
            this.dataOrders.Name = "dataOrders";
            this.dataOrders.ReadOnly = true;
            this.dataOrders.Size = new System.Drawing.Size(634, 154);
            this.dataOrders.TabIndex = 2;
            this.dataOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataOrders_CellClick);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(60, 10);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(270, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 190);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(634, 216);
            this.panel2.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnUpdateOrder);
            this.groupBox2.Controls.Add(this.radioCancelled);
            this.groupBox2.Controls.Add(this.radioDelivered);
            this.groupBox2.Controls.Add(this.radioConfirmed);
            this.groupBox2.Controls.Add(this.radioPending);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(465, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(169, 216);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtOrderStatus);
            this.groupBox1.Controls.Add(this.txtOrderValue);
            this.groupBox1.Controls.Add(this.dataOrderItems);
            this.groupBox1.Controls.Add(this.txtPhone);
            this.groupBox1.Controls.Add(this.txtOrderBy);
            this.groupBox1.Controls.Add(this.txtOrderDateTime);
            this.groupBox1.Controls.Add(this.txtOrderID);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 216);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Order Details";
            // 
            // txtOrderStatus
            // 
            this.txtOrderStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderStatus.Location = new System.Drawing.Point(370, 17);
            this.txtOrderStatus.Name = "txtOrderStatus";
            this.txtOrderStatus.ReadOnly = true;
            this.txtOrderStatus.Size = new System.Drawing.Size(89, 20);
            this.txtOrderStatus.TabIndex = 9;
            // 
            // txtOrderValue
            // 
            this.txtOrderValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderValue.ForeColor = System.Drawing.Color.Maroon;
            this.txtOrderValue.Location = new System.Drawing.Point(247, 17);
            this.txtOrderValue.Name = "txtOrderValue";
            this.txtOrderValue.ReadOnly = true;
            this.txtOrderValue.Size = new System.Drawing.Size(117, 20);
            this.txtOrderValue.TabIndex = 8;
            this.txtOrderValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataOrderItems
            // 
            this.dataOrderItems.AllowUserToAddRows = false;
            this.dataOrderItems.AllowUserToDeleteRows = false;
            this.dataOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataOrderItems.Location = new System.Drawing.Point(6, 69);
            this.dataOrderItems.Name = "dataOrderItems";
            this.dataOrderItems.ReadOnly = true;
            this.dataOrderItems.Size = new System.Drawing.Size(453, 141);
            this.dataOrderItems.TabIndex = 7;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(172, 43);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size(115, 20);
            this.txtPhone.TabIndex = 6;
            // 
            // txtOrderBy
            // 
            this.txtOrderBy.Location = new System.Drawing.Point(6, 43);
            this.txtOrderBy.Name = "txtOrderBy";
            this.txtOrderBy.ReadOnly = true;
            this.txtOrderBy.Size = new System.Drawing.Size(160, 20);
            this.txtOrderBy.TabIndex = 5;
            // 
            // txtOrderDateTime
            // 
            this.txtOrderDateTime.Location = new System.Drawing.Point(90, 17);
            this.txtOrderDateTime.Name = "txtOrderDateTime";
            this.txtOrderDateTime.ReadOnly = true;
            this.txtOrderDateTime.Size = new System.Drawing.Size(151, 20);
            this.txtOrderDateTime.TabIndex = 3;
            this.txtOrderDateTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtOrderID
            // 
            this.txtOrderID.Location = new System.Drawing.Point(6, 17);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.ReadOnly = true;
            this.txtOrderID.Size = new System.Drawing.Size(78, 20);
            this.txtOrderID.TabIndex = 1;
            this.txtOrderID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // radioPending
            // 
            this.radioPending.AutoSize = true;
            this.radioPending.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioPending.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.radioPending.Location = new System.Drawing.Point(22, 19);
            this.radioPending.Name = "radioPending";
            this.radioPending.Size = new System.Drawing.Size(87, 19);
            this.radioPending.TabIndex = 0;
            this.radioPending.TabStop = true;
            this.radioPending.Text = "PENDING";
            this.radioPending.UseVisualStyleBackColor = true;
            // 
            // radioConfirmed
            // 
            this.radioConfirmed.AutoSize = true;
            this.radioConfirmed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioConfirmed.ForeColor = System.Drawing.Color.Green;
            this.radioConfirmed.Location = new System.Drawing.Point(22, 44);
            this.radioConfirmed.Name = "radioConfirmed";
            this.radioConfirmed.Size = new System.Drawing.Size(107, 19);
            this.radioConfirmed.TabIndex = 1;
            this.radioConfirmed.TabStop = true;
            this.radioConfirmed.Text = "CONFIRMED";
            this.radioConfirmed.UseVisualStyleBackColor = true;
            // 
            // radioDelivered
            // 
            this.radioDelivered.AutoSize = true;
            this.radioDelivered.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioDelivered.ForeColor = System.Drawing.Color.Navy;
            this.radioDelivered.Location = new System.Drawing.Point(22, 69);
            this.radioDelivered.Name = "radioDelivered";
            this.radioDelivered.Size = new System.Drawing.Size(102, 19);
            this.radioDelivered.TabIndex = 2;
            this.radioDelivered.TabStop = true;
            this.radioDelivered.Text = "DELIVERED";
            this.radioDelivered.UseVisualStyleBackColor = true;
            // 
            // radioCancelled
            // 
            this.radioCancelled.AutoSize = true;
            this.radioCancelled.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioCancelled.ForeColor = System.Drawing.Color.Maroon;
            this.radioCancelled.Location = new System.Drawing.Point(22, 94);
            this.radioCancelled.Name = "radioCancelled";
            this.radioCancelled.Size = new System.Drawing.Size(105, 19);
            this.radioCancelled.TabIndex = 3;
            this.radioCancelled.TabStop = true;
            this.radioCancelled.Text = "CANCELLED";
            this.radioCancelled.UseVisualStyleBackColor = true;
            // 
            // btnUpdateOrder
            // 
            this.btnUpdateOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateOrder.Location = new System.Drawing.Point(22, 135);
            this.btnUpdateOrder.Name = "btnUpdateOrder";
            this.btnUpdateOrder.Size = new System.Drawing.Size(107, 30);
            this.btnUpdateOrder.TabIndex = 4;
            this.btnUpdateOrder.Text = "&UPDATE";
            this.btnUpdateOrder.UseVisualStyleBackColor = true;
            this.btnUpdateOrder.Click += new System.EventHandler(this.btnUpdateOrder_Click);
            // 
            // frmManageOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 406);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmManageOrders";
            this.Text = "frmManageOrders";
            this.Load += new System.EventHandler(this.frmManageOrders_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataOrders)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataOrderItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataOrders;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtOrderBy;
        private System.Windows.Forms.TextBox txtOrderDateTime;
        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.TextBox txtOrderStatus;
        private System.Windows.Forms.TextBox txtOrderValue;
        private System.Windows.Forms.DataGridView dataOrderItems;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.RadioButton radioCancelled;
        private System.Windows.Forms.RadioButton radioDelivered;
        private System.Windows.Forms.RadioButton radioConfirmed;
        private System.Windows.Forms.RadioButton radioPending;
        private System.Windows.Forms.Button btnUpdateOrder;
    }
}