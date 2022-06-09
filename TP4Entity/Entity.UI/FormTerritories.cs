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
    public partial class FormTerritories : Form
    {
        public FormTerritories()
        {
            InitializeComponent();
        }

        private void FormTerritories_Load(object sender, EventArgs e)
        {
            try
            {
                TerritoriesLogic oTerritoriesL = new TerritoriesLogic();
                DgvListarT.DataSource = oTerritoriesL.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Upss!! We Have a problem: " + ex.Message); ;
            }
        }
    }
}
