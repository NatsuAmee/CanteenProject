﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Entity;

namespace COS_DesktopApp
{
    public partial class ucAccountDetails : DevExpress.XtraEditors.XtraUserControl
    {
        COS_DesktopApp.CanteenOrderingSystemEntities dbContext;

        private static ucAccountDetails _instance;

        public static ucAccountDetails Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ucAccountDetails();
                }

                return _instance;
            }
        }

        public ucAccountDetails()
        {

            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard
            // Instantiate a new DBContext
            dbContext = new COS_DesktopApp.CanteenOrderingSystemEntities();
            // Call the LoadAsync method to asynchronously get the data for the given DbSet from the database.
            dbContext.accounts.LoadAsync().ContinueWith(loadTask =>
            {
                // Bind data to control when loading complete
                accountsBindingSource1.DataSource = dbContext.accounts.Local.ToBindingList();
            }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
        }

        public void ucAccountRefresh()
        {
            gridControl1.RefreshDataSource();
            gridView1.RefreshData();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.ucAccountRefresh();
        }

    }
}
