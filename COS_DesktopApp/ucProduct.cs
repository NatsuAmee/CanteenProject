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
    public partial class ucProduct : DevExpress.XtraEditors.XtraUserControl
    {
        private static ucProduct _instance;
        public static ucProduct Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ucProduct();

                }
                return _instance;
            }
        }

        public ucProduct()
        {
            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard
            // Instantiate a new DBContext
            COS_DesktopApp.CanteenOrderingSystemEntities dbContext = new COS_DesktopApp.CanteenOrderingSystemEntities();
            // Call the LoadAsync method to asynchronously get the data for the given DbSet from the database.
            dbContext.products.LoadAsync().ContinueWith(loadTask =>
            {
    // Bind data to control when loading complete
    productsBindingSource.DataSource = dbContext.products.Local.ToBindingList();
            }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}