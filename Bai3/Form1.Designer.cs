namespace Bai3
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox groupBoxLeft;
        private System.Windows.Forms.GroupBox groupBoxRight;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.ComboBox cboDVT;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDeleteRow;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.ListView lvItems;

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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Quản lý Vật tư / Linh kiện";

            // Left group (input)
            this.groupBoxLeft = new System.Windows.Forms.GroupBox();
            this.groupBoxLeft.Text = "Nhập liệu";
            this.groupBoxLeft.SetBounds(10, 10, 360, 420);

            var lblMa = new System.Windows.Forms.Label();
            lblMa.Text = "Mã vật tư:";
            lblMa.SetBounds(10, 30, 80, 22);
            this.txtMa = new System.Windows.Forms.TextBox();
            this.txtMa.SetBounds(100, 30, 240, 22);

            var lblTen = new System.Windows.Forms.Label();
            lblTen.Text = "Tên vật tư:";
            lblTen.SetBounds(10, 70, 80, 22);
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtTen.SetBounds(100, 70, 240, 22);

            var lblDVT = new System.Windows.Forms.Label();
            lblDVT.Text = "Đơn vị tính:";
            lblDVT.SetBounds(10, 110, 80, 22);
            this.cboDVT = new System.Windows.Forms.ComboBox();
            this.cboDVT.SetBounds(100, 110, 240, 22);
            this.cboDVT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDVT.Items.AddRange(new object[] { "Cái", "Bộ", "Kg", "Mét" });

            var lblDonGia = new System.Windows.Forms.Label();
            lblDonGia.Text = "Đơn giá:";
            lblDonGia.SetBounds(10, 150, 80, 22);
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.txtDonGia.SetBounds(100, 150, 240, 22);

            // Buttons
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnAdd.Text = "Thêm mới";
            this.btnAdd.SetBounds(20, 200, 150, 30);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.SetBounds(190, 200, 150, 30);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            this.btnDeleteRow = new System.Windows.Forms.Button();
            this.btnDeleteRow.Text = "Xóa dòng";
            this.btnDeleteRow.SetBounds(20, 240, 150, 30);
            this.btnDeleteRow.Click += new System.EventHandler(this.btnDeleteRow_Click);

            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnClearAll.Text = "Xóa toàn bộ";
            this.btnClearAll.SetBounds(190, 240, 150, 30);
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);

            this.groupBoxLeft.Controls.Add(lblMa);
            this.groupBoxLeft.Controls.Add(this.txtMa);
            this.groupBoxLeft.Controls.Add(lblTen);
            this.groupBoxLeft.Controls.Add(this.txtTen);
            this.groupBoxLeft.Controls.Add(lblDVT);
            this.groupBoxLeft.Controls.Add(this.cboDVT);
            this.groupBoxLeft.Controls.Add(lblDonGia);
            this.groupBoxLeft.Controls.Add(this.txtDonGia);
            this.groupBoxLeft.Controls.Add(this.btnAdd);
            this.groupBoxLeft.Controls.Add(this.btnUpdate);
            this.groupBoxLeft.Controls.Add(this.btnDeleteRow);
            this.groupBoxLeft.Controls.Add(this.btnClearAll);

            // Right group (list)
            this.groupBoxRight = new System.Windows.Forms.GroupBox();
            this.groupBoxRight.Text = "Danh sách";
            this.groupBoxRight.SetBounds(380, 10, 410, 420);

            this.lvItems = new System.Windows.Forms.ListView();
            this.lvItems.SetBounds(10, 20, 390, 390);
            this.lvItems.View = System.Windows.Forms.View.Details;
            this.lvItems.FullRowSelect = true;
            this.lvItems.GridLines = true;
            this.lvItems.HideSelection = false;
            this.lvItems.MultiSelect = false;
            this.lvItems.Columns.Add("Mã VT", 90);
            this.lvItems.Columns.Add("Tên VT", 150);
            this.lvItems.Columns.Add("Đơn vị tính", 80);
            this.lvItems.Columns.Add("Đơn giá", 70, System.Windows.Forms.HorizontalAlignment.Right);
            this.lvItems.SelectedIndexChanged += new System.EventHandler(this.lvItems_SelectedIndexChanged);

            this.groupBoxRight.Controls.Add(this.lvItems);

            // Add groups to form
            this.Controls.Add(this.groupBoxLeft);
            this.Controls.Add(this.groupBoxRight);

            // Initialize in-memory list
            this.SuspendLayout();
        }

        #endregion
    }
}

