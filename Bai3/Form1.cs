using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai3
{
    public partial class Form1 : Form
    {
        private class VatTu
        {
            public string Ma { get; set; }
            public string Ten { get; set; }
            public string DVT { get; set; }
            public decimal DonGia { get; set; }
        }

        private List<VatTu> items = new List<VatTu>();
        private int selectedIndex = -1; // index in items of selected row
        public Form1()
        {
            InitializeComponent();
            // initial states
            cboDVT.SelectedIndex = 0;
            btnUpdate.Enabled = false;
            btnDeleteRow.Enabled = false;
        }

        private void RefreshListView()
        {
            lvItems.BeginUpdate();
            lvItems.Items.Clear();
            foreach (var it in items)
            {
                var lvi = new ListViewItem(it.Ma);
                lvi.SubItems.Add(it.Ten);
                lvi.SubItems.Add(it.DVT);
                lvi.SubItems.Add(it.DonGia.ToString("N0"));
                lvItems.Items.Add(lvi);
            }
            lvItems.EndUpdate();
        }

        private void ClearInput()
        {
            txtMa.Text = "";
            txtTen.Text = "";
            txtDonGia.Text = "";
            cboDVT.SelectedIndex = 0;
            selectedIndex = -1;
            btnUpdate.Enabled = false;
            btnDeleteRow.Enabled = false;
            lvItems.SelectedItems.Clear();
        }

        private int FindIndexByMa(string ma)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (string.Equals(items[i].Ma, ma, StringComparison.OrdinalIgnoreCase)) return i;
            }
            return -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var ma = txtMa.Text.Trim();
            var ten = txtTen.Text.Trim();
            var dvt = cboDVT.SelectedItem?.ToString() ?? "";
            if (string.IsNullOrEmpty(ma))
            {
                MessageBox.Show("Mã vật tư không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (FindIndexByMa(ma) != -1)
            {
                MessageBox.Show("Mã vật tư đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Tên vật tư không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(txtDonGia.Text.Trim(), out decimal dg) || dg < 0)
            {
                MessageBox.Show("Đơn giá không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            items.Add(new VatTu { Ma = ma, Ten = ten, DVT = dvt, DonGia = dg });
            RefreshListView();
            ClearInput();
        }

        private void lvItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvItems.SelectedItems.Count == 0)
            {
                ClearInput();
                return;
            }
            var ma = lvItems.SelectedItems[0].Text;
            selectedIndex = FindIndexByMa(ma);
            if (selectedIndex == -1) return;
            var it = items[selectedIndex];
            txtMa.Text = it.Ma;
            txtTen.Text = it.Ten;
            cboDVT.SelectedItem = it.DVT;
            txtDonGia.Text = it.DonGia.ToString();
            btnUpdate.Enabled = true;
            btnDeleteRow.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedIndex < 0 || selectedIndex >= items.Count)
            {
                MessageBox.Show("Chưa chọn mục để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var newMa = txtMa.Text.Trim();
            var newTen = txtTen.Text.Trim();
            var newDVT = cboDVT.SelectedItem?.ToString() ?? "";
            if (string.IsNullOrEmpty(newMa))
            {
                MessageBox.Show("Mã vật tư không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // If changed Ma, ensure uniqueness
            var existing = FindIndexByMa(newMa);
            if (existing != -1 && existing != selectedIndex)
            {
                MessageBox.Show("Mã vật tư đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(newTen))
            {
                MessageBox.Show("Tên vật tư không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(txtDonGia.Text.Trim(), out decimal newDg) || newDg < 0)
            {
                MessageBox.Show("Đơn giá không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var it = items[selectedIndex];
            it.Ma = newMa;
            it.Ten = newTen;
            it.DVT = newDVT;
            it.DonGia = newDg;
            RefreshListView();
            ClearInput();
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            if (selectedIndex < 0 || selectedIndex >= items.Count)
            {
                MessageBox.Show("Chưa chọn dòng để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var it = items[selectedIndex];
            var res = MessageBox.Show($"Bạn có chắc muốn xóa Mã '{it.Ma}' ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                items.RemoveAt(selectedIndex);
                RefreshListView();
                ClearInput();
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Bạn có chắc muốn xóa toàn bộ danh sách?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                items.Clear();
                RefreshListView();
                ClearInput();
            }
        }
    }
}
