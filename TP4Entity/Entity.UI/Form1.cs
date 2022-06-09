using Entity.logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entity.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateList();
        }
        public void UpdateList()
        {
            ShippersLogic oShipperL = new ShippersLogic();
            DgvListar.DataSource = oShipperL.GetAll();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormTerritories frmT = new FormTerritories();
            frmT.ShowDialog();
            UpdateList();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                FormMultipase frmM = new FormMultipase();
                frmM.ShowDialog();
                UpdateList();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ups, we have a problem: " + ex.Message);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if (id != null)
            {
                try
                {
                    FormMultipase frmM = new FormMultipase(id);
                    frmM.ShowDialog();
                    UpdateList();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ups!! We have a problem");
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            ShippersLogic oShippersL = new ShippersLogic();
            int? id = GetId();
            try
            {
                DialogResult resul = MessageBox.Show("Are you sure to delete this item?", "Confirm Delete!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resul == DialogResult.Yes)
                {                                  
                    oShippersL.Delete((int)id);
                    UpdateList();
                    MessageBox.Show("Deleted Item!!", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    MessageBox.Show("be careful!!, no conventional deletion was done");
                    oShippersL.LogicDelete((int)id);
                    UpdateList();
                    MessageBox.Show("Error with delete operation, however the system looked for a way to solve it");
                }
                else
                {
                    MessageBox.Show("unexpected error");
                }
            }
        }
        private int? GetId()
        {
            try
            {
                return int.Parse(DgvListar.Rows[DgvListar.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch (Exception)
            {
               return null;
            }
        }
    }
}
