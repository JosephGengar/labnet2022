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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void BtnEx8_Click(object sender, EventArgs e)
        {
            CustomersLogic oCustL = new CustomersLogic();
            var Data = oCustL.GetCustomers3R();
            DgvQuery2.DataSource = Data;
            MessageBox.Show($"This Query contains: {Data.Count()} registers");
        }
        private void BtnEx9_Click(object sender, EventArgs e)
        {
            ProductsLogic oProdL = new ProductsLogic();
            DgvQuery2.DataSource = oProdL.GetProductsOrder();
        }

        private void BtnEx10_Click(object sender, EventArgs e)
        {
            ProductsLogic oProdL = new ProductsLogic();
            DgvQuery2.DataSource = oProdL.GetProductsOrdMM();
        }
        private void BtnEx11_Click(object sender, EventArgs e)
        {
            ProductsLogic oProdL = new ProductsLogic();
            DgvQuery2.DataSource = oProdL.GetProduct_Category();
        }
        private void BtnEx12_Click(object sender, EventArgs e)
        {
            ProductsLogic oProdL = new ProductsLogic();
            DgvQuery2.DataSource = oProdL.GetProdFirstElement();
        }
        private void BtnEx13_Click(object sender, EventArgs e)
        {
            CustomersLogic oCustL = new CustomersLogic();
            var Data = oCustL.GetCust_Order();
            DgvQuery2.DataSource = Data;
            MessageBox.Show($"This Query contains: {Data.Count()} registers");
        }
    }
}
