using Entity.Entities;
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
    public partial class FormMultipase : Form
    {
        private int? _id;
        public FormMultipase(int? id = null )
        {
            this._id = id;
            InitializeComponent();
            if (this._id != null)
            {
                this.Text = "Edit Shippers";
                LoadInfo();
            }
        }
        private void FormMultipase_Load(object sender, EventArgs e)
        {
          
        }
        private void LoadInfo()
        {
            try
            {
                ShippersLogic oShippersL = new ShippersLogic();
                var ShippersLoad = oShippersL.GetOne((int)_id);
                TxtCN.Text = ShippersLoad.CompanyName;
                TxtPN.Text = ShippersLoad.Phone;
            }
            catch (Exception)
            {
                MessageBox.Show("We have a problem connection");;
            }         
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TxtCN.Text) || string.IsNullOrEmpty(TxtPN.Text))
                {
                    TxtCN.Focus();
                    MessageBox.Show("Please complete all fields!!!", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    ShippersLogic oShippersL = new ShippersLogic();
                    if (_id == null)
                    {
                        oShippersL.Add(new Shippers { CompanyName = TxtCN.Text, Phone = TxtPN.Text });
                        MessageBox.Show("Add Shipper!!!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        oShippersL.Edit(new Shippers { CompanyName = TxtCN.Text, Phone = TxtPN.Text, ShipperID = (int)_id });
                        MessageBox.Show("Edit Shipper!!!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ups! We have a problem here");
            }
        }
    }
}
