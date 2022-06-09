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

    }
}
