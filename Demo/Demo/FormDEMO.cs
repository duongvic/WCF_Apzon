using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BussinessEntity;
using BusinessObject;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;


namespace Demo
{
    public partial class FormDEMO : Form
    {

        BE_ORDR beODRD = new BE_ORDR();
        BE_RDR1 beRDR1 = new BE_RDR1();
        BE_Logistic beLogistic = new BE_Logistic();
        DataTable dt = null;
        DataTable tbORDR;
        public FormDEMO()
        {
            InitializeComponent();
        }

        public void loadData()
        { 
            tbORDR = beODRD.ShowORDR();
            grdORDR.DataSource = tbORDR ;
           

            dt = beRDR1.ShowRDR1();
            grdRDR1.DataSource = dt;

            dt = beLogistic.showLogistic();
            gridControl3.DataSource = dt;
        }

   
        private void FormDEMO_Load(object sender, EventArgs e)
        {
            cbStatus.SelectedIndex = 0;           
            loadData();
        }  

        private void btRefresh_Click(object sender, EventArgs e)
        {
            bteBussinessP.ResetText();
            txtNoOfTrans.Text = null;
            fdate.Text = null;
            tdate.Text = null;
            fdate.Focus();           
            loadData(); 
        }

        private void btSearch_Click_1(object sender, EventArgs e)
        {
           string status = string.Empty ;

           if (cbStatus.SelectedItem.ToString() == "Open")
           {
               status = "O";
           }
           else if (cbStatus.SelectedItem.ToString() == "Close")
           {
               status = "C";
           }
           else if (cbStatus.SelectedItem.ToString() == "Cancel")
           {
               status = "c";
           }

            DataTable dt = beODRD.SearchDocumentAll(status,bteBussinessP.Text,  txtNoOfTrans.Text, fdate.DateTime, tdate.DateTime) ;
            grdORDR.DataSource = dt;
         
        }
                
        private void txtDocumentStatus_TextChanged(object sender, EventArgs e)
        {
            //if (txtDocumentStatus.Text == "")
            //{
            //    loadData();
            //}
        }

        private void txtNoOfTrans_TextChanged(object sender, EventArgs e)
        {
            if (txtNoOfTrans.Text == "")
            {
                loadData();
            }
            else
            {
                dt = beODRD.searchByNoOfTrans(txtNoOfTrans.Text);
                grdORDR.DataSource = dt;
            }
        }

        private void txtBussinessPartner_TextChanged_1(object sender, EventArgs e)
        {
            //if (txtBussinessPartner.Text == "")
            //{
            //    loadData();
            //}
            //else
            //{
            //    dt = beODRD.searchByBTrans(txtBussinessPartner.Text);
            //    gridControl1.DataSource = dt;
            //}
        }
          
     
        public void addClickORDR()
        {
            try
            {
                dt = (DataTable)grdORDR.DataSource;
                DataTable dtChange = dt.GetChanges();
                beODRD = new BE_ORDR();
                for (int i = 0; i < dtChange.Rows.Count; i++)
                {

                    BO_ORDR obj = new BO_ORDR();
                    obj.DocStatus = dtChange.Rows[i]["DocStatus"].ToString();
                    if (obj.DocStatus.Length > 1 || obj.DocStatus == "")
                    {
                        MessageBox.Show("DocStatus not null and only allowed to enter 1 character");

                        return;

                    }
                    else 
                    {


                        obj.DocEntry = int.Parse(dtChange.Rows[i]["DocNum"].ToString());
                        obj.CardCode = dtChange.Rows[i]["CardCode"].ToString();
                        obj.CardName = dtChange.Rows[i]["CardName"].ToString();
                        obj.CntctCode = int.Parse(dtChange.Rows[i]["CntctCode"].ToString());
                        //obj.DocStatus = dtChange.Rows[i]["DocStatus"].ToString();
                        obj.TaxDate = Convert.ToDateTime(dtChange.Rows[i]["TaxDate"].ToString());
                        obj.DocDueDate = Convert.ToDateTime(dtChange.Rows[i]["DocDueDate"].ToString());
                        obj.DocDate = Convert.ToDateTime(dtChange.Rows[i]["DocDate"].ToString());
                        obj.Comments = dtChange.Rows[i]["Comments"].ToString();
                        obj.DiscPrcnt = Convert.ToDouble(dtChange.Rows[i]["DiscPrcnt"].ToString());
                        obj.VatSum = Convert.ToDouble(dtChange.Rows[i]["VatSum"].ToString());
                        obj.DocTotal = Convert.ToDouble(dtChange.Rows[i]["DocTotal"].ToString());
                        obj.DocCur = dtChange.Rows[i]["DocCur"].ToString();
                        obj.DocRate = Convert.ToDouble(dtChange.Rows[i]["DocRate"].ToString());

                        obj.DocNum = dtChange.Rows[i]["DocNum"] == DBNull.Value ? 0 : Convert.ToInt32(dtChange.Rows[i]["DocNum"].ToString());
                        obj.CANCELED = dtChange.Rows[i]["CANCELED"] == DBNull.Value ? "0" : Convert.ToString(dtChange.Rows[i]["CANCELED"]);
                        obj.NumAtCard = dtChange.Rows[i]["NumAtCard"] == DBNull.Value ? "0" : Convert.ToString(dtChange.Rows[i]["NumAtCard"]);
                        obj.Series = dtChange.Rows[i]["Series"] == DBNull.Value ? 0 : Convert.ToInt32(dtChange.Rows[i]["Series"]);

                        bool exists = beODRD.CheckDoc(obj.DocEntry);
                        if (!exists)
                        {
                            
                            // insert   
                                beODRD.addORDR(obj);
                                
                           
                        }
                        else
                        {
                            if (MessageBox.Show("Do you want to update this information ?", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                           { //thuc hien update
                            beODRD.updateORDR(obj);
                            return;
                           }
                        }
                    }
                   
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        
        public void addClickRDR1()
        {
            try
            {
                dt  = (DataTable ) grdORDR.DataSource;
                DataTable dtChange = dt.GetChanges();
                beRDR1  = new BE_RDR1 ();
                for (int i = 0; i < dtChange.Rows.Count; i++)
                {
                    BO_RDR1 obj = new BO_RDR1 ();
                    obj.DocEntry = dtChange.Rows[i]["DocNum"] == DBNull.Value ? 0 : Convert.ToInt32(dtChange.Rows[i]["DocNum"].ToString ()  ) ;
                    bool exists = beODRD.CheckDoc(obj.DocEntry);
                    obj.ItemCode = dtChange.Rows[i]["ItemCode"].ToString();
                    obj.Quantity = dtChange.Rows[i]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtChange.Rows[i]["Quantity"].ToString());
                    obj.Price = dtChange.Rows[i]["Price"] == DBNull.Value ? 0 : Convert.ToInt32(dtChange.Rows[i]["Price"].ToString());
                    obj.DiscPrcnt = dtChange.Rows[i]["DiscPrcnt"] == DBNull.Value ? 0 : Convert.ToInt32(dtChange.Rows[i]["DiscPrcnt"].ToString());
                    obj.TaxCode = dtChange.Rows[i]["TaxCode"].ToString ();
                    obj.LineTotal = int.Parse ((dtChange.Rows[i]["LineTotal"].ToString ()));
                    obj.WhsCode = dtChange.Rows[i]["WhsCode"] == DBNull.Value ? "0" : Convert.ToString(dtChange.Rows[i]["WhsCode"].ToString());
                    obj.ShipDate = Convert.ToDateTime(dtChange.Rows[i]["DocDate"].ToString());
                    obj.FreeTxt = dtChange.Rows[i]["FreeTxt"].ToString();
                    obj.OpenQty = dtChange.Rows[i]["OpenQty"] == DBNull.Value ? 0 : Convert.ToDouble(dtChange.Rows[i]["OpenQty"]);
                    obj.Currency = dtChange.Rows[i]["Currency"] == DBNull.Value ? "0" : Convert.ToString(dtChange.Rows[i]["Currency"]);
                    obj.Rate = Convert.ToDouble(dtChange.Rows[i]["DocRate"].ToString());

                    obj.DocEntry = dtChange.Rows[i]["DocEntry"] == DBNull.Value ? 0 : Convert.ToInt32(dtChange.Rows[i]["DocEntry"].ToString()); // check null 
                    obj.LineNum = dtChange.Rows[i]["LineNum"] == DBNull.Value ? 0 : Convert.ToInt32(dtChange.Rows[i]["LineNum"]);
                    obj.BaseType = dtChange.Rows[i]["BaseType"] == DBNull.Value ? 0 : Convert.ToInt32 (dtChange.Rows[i]["BaseType"]);
                    obj.BaseEntry = dtChange.Rows[i]["BaseEntry"] == DBNull.Value ? 0 : Convert.ToInt32(dtChange.Rows[i]["BaseEntry"]);
                    obj.BaseLine = dtChange.Rows[i]["BaseLine"] == DBNull.Value ? 0 : Convert.ToInt32(dtChange.Rows[i]["BaseLine"]);
                    obj.AcctCode = dtChange.Rows[i]["AcctCode"] == DBNull.Value ? "0" : Convert.ToString(dtChange.Rows[i]["AcctCode"]);
                    if (exists)
                    {
                        //update
                       beRDR1.updateRDR1(obj);
                    }
                    else
                    { // insert                        
                        //thuc hien query
                        beRDR1.addRDR1(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
          
                        try
                        {
                            addClickORDR();
                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show("erro" + ex);
                            return;
                        }                
            
            }
            
        

        
       // show button delete on Gridview 
        private void gridView3_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            GridView view = (GridView)sender;
            GridHitInfo hitInfo = view.CalcHitInfo(e.Point);
            if (hitInfo.InRow)
            {
                view.FocusedRowHandle = hitInfo.RowHandle;
                contextMenu.Show(view.GridControl, e.Point);
            }
        }

        // thuc hien xoa
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(" Do you want to delete ?", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {                                        
                        beODRD = new BE_ORDR();                  
                        BO_ORDR obj = new BO_ORDR();
                        obj.DocEntry = Convert.ToInt32(gvORDR.GetRowCellValue(gvORDR.FocusedRowHandle, "DocNum"));  // lay ra file can thuc hien
                        beODRD.deleteORDR(obj.DocEntry);
                        gvORDR.DeleteRow(gvORDR.FocusedRowHandle); // del row 
                        return;
                }
            }
            catch (Exception ex )
            {
                MessageBox.Show("erro" + ex); 
            }
            
        }

  
        // search on gridview
        private void gridView3_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {          

                BO_RDR1 obj = new BO_RDR1();
               obj.DocEntry   = Convert.ToInt32(gvORDR.GetFocusedRowCellValue("DocNum"));
                DataTable dt = beRDR1.showRDR1ByDocEntry(obj.DocEntry);
                grdORDR.DataSource = dt;
                grdORDR.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
      
        private void cbBussinessP_SelectedValueChanged(object sender, EventArgs e)
        {
            //string key = cbBussinessP.Text;
            //gridControl1.DataSource = beODRD.searchByBTrans(key);  
        }

        private void cbBussinessP_TextChanged(object sender, EventArgs e)
        {
            //string key = cbBussinessP.Text;
            //gridControl1.DataSource = beODRD.searchByBTrans(key);
        }

        private void cbBussinessP_SelectedIndexChanged(object sender, EventArgs e)
        {

            //string key = cbBussinessP.Text;
            //gridControl1.DataSource = beODRD.searchByBTrans(key);
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
                                  
            
         gvORDR.AddNewRow();  
                                        
        }

        private void bteBussinessP_EditValueChanged(object sender, EventArgs e)
        {
            string keySearch = bteBussinessP.Text;
         grdORDR.DataSource= beODRD.searchByCardCode(keySearch);
        }

        // goi fromOCRD va lay gia tri
        private void bteBussinessP_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            FormOCRD frm = new FormOCRD();
            frm.ShowDialog();
            // gan gia trin vao bteBussinessP
            string cardCode = frm.cardCode;
            bteBussinessP.EditValue = cardCode;
            frm.Close();
        }

        private void gridViewORDR_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            //GridView view = sender as GridView;
            //view.SetRowCellValue(e.RowHandle, view.Columns["TaxDate"], DateTime.Today);
            //view.SetRowCellValue(e.RowHandle, view.Columns["DocDate"], DateTime.Today);
            //view.SetRowCellValue(e.RowHandle, view.Columns["DocDueDate"], DateTime.Today);
            //string item = repositoryItemComboBox_DocStatus.Items[0].ToString();
            //view.SetRowCellValue(e.RowHandle, view.Columns["DocStatus"], item);
        }

        private void gridViewORDR_RowClick(object sender, RowClickEventArgs e)
        {
           
        }

        private void dgvORDR_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            GridView view = (GridView)sender;
            GridHitInfo hitInfo = view.CalcHitInfo(e.Point);
            if (hitInfo.InRow)
            {
                view.FocusedRowHandle = hitInfo.RowHandle;
                contextMenu.Show(view.GridControl, e.Point);
            }
        }

        private void dgvORDR_RowClick(object sender, RowClickEventArgs e)
        {
            int docEntry = Convert.ToInt32(gvORDR.GetFocusedRowCellValue("DocNum") == DBNull.Value ? 0 : gvORDR.GetFocusedRowCellValue("DocNum"));
            DataTable dtORDR = new DataTable();
            grdRDR1.DataSource = beRDR1.showRDR1ByDocEntry(docEntry );
            grdRDR1.RefreshDataSource();
        }

      

        //private void gridView3_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        //{
        //    GridView view = sender as GridView;
        //    GridColumn cardCodeCol = view.Columns["CardCode"]; 
            
        //    string cardcode = string.Empty;
        //    if (view.GetRowCellValue(e.RowHandle, cardCodeCol)!=null)
        //    {
        //         view.SetColumnError(cardCodeCol, "Cardcode is not null");
        //    }
        //    else{
        //        view.SetColumnError(cardCodeCol, "Cardcode is not null");
        //}
        //   // GridColumn onOrderCol = view.Columns["UnitsOnOrder"];
        //}

        //private void gridView3_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        //{
        //    e.ExceptionMode = ExceptionMode.NoAction;
        //}
    }
}
