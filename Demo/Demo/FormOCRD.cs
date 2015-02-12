using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinessEntity;
using BusinessObject;

namespace Demo
{
    public partial class FormOCRD : Form
    {
        public FormOCRD()
        {
            InitializeComponent();
        }
        
        private void FormOCRD_Load(object sender, EventArgs e)
        {
            BE_OCRD be = new BE_OCRD();
            gridControlOCRD.DataSource = be.showOCRD(); 
        }

        public string cardCode = null;
        private void gridControlOCRD_DoubleClick(object sender, EventArgs e)
        {
            var obj = gridViewOCRD.GetRowCellValue(gridViewOCRD.FocusedRowHandle, gridViewOCRD.Columns["CardCode"]);
            cardCode = obj == null ? string.Empty : obj.ToString();
            MessageBox.Show(obj.ToString());
            this.Close();
        }
    }
}
