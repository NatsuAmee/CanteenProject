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
    public partial class ucOrigin : DevExpress.XtraEditors.XtraUserControl
    {
        COS_DesktopApp.CanteenOrderingSystemEntities dbContext;

        private ucOrigin _instance;
        public ucOrigin Instance
        {
            get
            {

                if (_instance == null)
                {
                    _instance = new ucOrigin();

                }
                return _instance;
            }
        }
        public ucOrigin()
        {
            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard
            // Instantiate a new DBContext
           dbContext  = new COS_DesktopApp.CanteenOrderingSystemEntities();
            // Call the LoadAsync method to asynchronously get the data for the given DbSet from the database.
            dbContext.origins.LoadAsync().ContinueWith(loadTask =>
            {
                // Bind data to control when loading complete
                originsBindingSource.DataSource = dbContext.origins.Local.ToBindingList();
            }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void btn_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            if (e.Button == btn.Buttons[0])
            {
                gridView1.AddNewRow();
            }
            else if (e.Button == btn.Buttons[1])
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to Delete?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    gridView1.SetFocusedRowCellValue(gridView1.Columns[coldeletedAt.FieldName], DateTime.Now);
                    dbContext.SaveChanges();
                    if (gridView1.FocusedRowHandle != 0)
                    {
                        gridView1.FocusedRowHandle = 0;
                    }
                    else
                    {
                        gridView1.FocusedRowHandle = 1;
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                }
            }
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to update?", "Update", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    dbContext.SaveChanges();
                }
                else if (dialogResult == DialogResult.No)
                {
                    var changed = dbContext.ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged).ToList();
                    foreach (var obj in changed)
                    {

                        obj.CurrentValues.SetValues(obj.OriginalValues);

                        obj.State = EntityState.Unchanged;
                    }

                }
            }
            catch
            {

            }
        }
    }
}
