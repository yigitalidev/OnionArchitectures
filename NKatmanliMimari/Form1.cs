using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using DataAccessLayer;
using LogicLayer;
using System.Data.SqlClient;

namespace NKatmanliMimari
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void refresh()
        {
            List<EntityPersonal> PerList = LogicPersonal.LLPersonalList();
            dataGridView1.DataSource = PerList;
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            refresh();
        }

        EntityPersonal ent = new EntityPersonal();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ent.Name = txtName.Text;
                ent.Surname = txtSurname.Text;
                ent.City = txtCity.Text;
                ent.Mission = txtMission.Text;
                ent.Wage = short.Parse(txtWage.Text);
                var add = LogicPersonal.LLPersonalAdd(ent);
                if (add != -1)
                {
                    MessageBox.Show("Veri Girişi Başarılı", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh(); 
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bir Hata Oluştu", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ent.Id = Convert.ToInt32(txtİD.Text);
                var delete = LogicPersonal.LLPersonelDelete(ent.Id);
                if (Convert.ToInt32(delete) != -1)
                {
                    MessageBox.Show("Veri Silme İşlemi Başarılı", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bir Hata Oluştu", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ent.Id = Convert.ToInt32(txtİD.Text);
                ent.Name = txtName.Text;
                ent.Surname = txtSurname.Text;
                ent.City = txtCity.Text;
                ent.Mission = txtMission.Text;
                ent.Wage = short.Parse(txtWage.Text);
               var update = LogicPersonal.LLPersonelUpdate(ent);
                if (Convert.ToInt32(update) != -1)
                {
                    MessageBox.Show("Veri Güncelleme İşlemi Başarılı", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bir Hata Oluştu", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtİD.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSurname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtMission.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtCity.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtWage.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        }
    }
}
