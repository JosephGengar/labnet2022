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
            try
            {
                CustomersLogic oCustL = new CustomersLogic();
                DgvQuerys.DataSource = oCustL.GetCustomers();
            }
            catch (Exception)
            {
                MessageBox.Show("Ups!! He have a problem...");
            }
          
        }
        private void BtnEjer2_Click(object sender, EventArgs e)
        {
            try
            {
                ProductsLogic oProdL = new ProductsLogic();
                var Data = oProdL.GetProductsOfStock();
                DgvQuerys.DataSource = Data;
                MessageBox.Show($"This Query contains: {Data.Count()} registers");
            }
            catch (Exception)
            { 
                MessageBox.Show("Ups!! We have a problem....");
            }
           
        }
        private void BtnEjer3_Click(object sender, EventArgs e)
        {
            try
            {
                ProductsLogic oProdL = new ProductsLogic();
                var Data = oProdL.GetProductsWStockM3();
                DgvQuerys.DataSource = Data;
                MessageBox.Show($"This Query contains: {Data.Count()} registers");
            }
            catch (Exception)
            {
                MessageBox.Show("Ups!! We have a problem....");
            }         
        }
        private void BtnEjer4_Click(object sender, EventArgs e)
        {
            try
            {
                CustomersLogic oCustL = new CustomersLogic();
                var Data = oCustL.GetCustomersWA();
                DgvQuerys.DataSource = Data;
                MessageBox.Show($"This Query contains: {Data.Count()} registers");
            }
            catch (Exception)
            {
                MessageBox.Show("Ups!! We have a problem...");
            }
        }
        private void BtnEjer5_Click(object sender, EventArgs e)
        {
            try
            {
                ProductsLogic oProdL = new ProductsLogic();
                var Data = oProdL.GetProduct789();
                DgvQuerys.DataSource = Data;
                if (Data[0] == null)
                {
                    MessageBox.Show("No found register!!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ups!! We have a problem...");
            }         
        }
        private void BtnEjer6_Click(object sender, EventArgs e)
        {
            try
            {
                CustomersLogic oCustL = new CustomersLogic();
                DgvQuerys.DataSource = oCustL.GetCustomersMM();
            }
            catch (Exception)
            {
                MessageBox.Show("Ups!! He have a problem...");
            }
        }

        private void BtnEjer7_Click(object sender, EventArgs e)
        {
            try
            {
                CustomersLogic oCustL = new CustomersLogic();
                var Data = oCustL.GetCustomers_Orders();
                DgvQuerys.DataSource = Data;
                MessageBox.Show($"This Query contains: {Data.Count()} registers");
            }
            catch (Exception)
            {
                MessageBox.Show("Ups!!! We have a problem...");
            }
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
