using Linq.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Linq.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void BtnClear_Click(object sender, EventArgs e)
        {
            DgvQuerys.Columns.Clear();
        }
        private void BtnEjer1_Click(object sender, EventArgs e)
        {
            CustomersLogic oCustL = new CustomersLogic();
            DgvQuerys.DataSource = oCustL.GetCustomers();
        }
        private void BtnEjer2_Click(object sender, EventArgs e)
        {
            ProductsLogic oProdL = new ProductsLogic();
            var Data = oProdL.GetProductsOfStock();
            DgvQuerys.DataSource = Data;
            MessageBox.Show($"This Query contains: {Data.Count()} registers");
        }
        private void BtnEjer3_Click(object sender, EventArgs e)
        {
            ProductsLogic oProdL = new ProductsLogic();
            var Data = oProdL.GetProductsWStockM3();
            DgvQuerys.DataSource = Data;
            MessageBox.Show($"This Query contains: {Data.Count()} registers");
        }
        private void BtnEjer4_Click(object sender, EventArgs e)
        {
            CustomersLogic oCustL = new CustomersLogic();
            var Data = oCustL.GetCustomersWA();
            DgvQuerys.DataSource = Data;
            MessageBox.Show($"This Query contains: {Data.Count()} registers");
        }
        private void BtnEjer5_Click(object sender, EventArgs e)
        {
            ProductsLogic oProdL = new ProductsLogic();
            var Data = oProdL.GetProduct789();
            DgvQuerys.DataSource = Data;
            if (Data[0] == null)
            {
                MessageBox.Show("No found register!!");
            }
        }
        private void BtnEjer6_Click(object sender, EventArgs e)
        {
            CustomersLogic oCustL = new CustomersLogic();
            DgvQuerys.DataSource = oCustL.GetCustomersMM();

        }

        private void BtnEjer7_Click(object sender, EventArgs e)
        {
            CustomersLogic oCustL = new CustomersLogic();
            var Data = oCustL.GetCustomers_Orders();
            DgvQuerys.DataSource = Data;
            MessageBox.Show($"This Query contains: {Data.Count()} registers");
        }

        private void BtnSecondPage_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
