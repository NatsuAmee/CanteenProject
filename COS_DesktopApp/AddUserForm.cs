﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Entity;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System.Text.RegularExpressions;

namespace COS_DesktopApp
{
    public partial class AddUserForm : DevExpress.XtraEditors.XtraForm
    {
        COS_DesktopApp.CanteenOrderingSystemEntities dbContext;
        GridView gv;
        int addNewStatus;

        public AddUserForm(GridView gv, int addNewStatus)
        {
            InitializeComponent();
            this.addNewStatus = addNewStatus;
            this.gv = gv;
            // This line of code is generated by Data Source Configuration Wizard
            // Instantiate a new DBContext
            dbContext = new COS_DesktopApp.CanteenOrderingSystemEntities();
            // Call the LoadAsync method to asynchronously get the data for the given DbSet from the database.
            dbContext.accounts.LoadAsync().ContinueWith(loadTask =>
            {
                this.loadRole();
                // Bind data to control when loading complete
                accountsBindingSource.DataSource = dbContext.accounts.Local.ToBindingList();
            }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());

        }

        private void loadRole()
        {
            // This line of code is generated by Data Source Configuration Wizard
            // Instantiate a new DBContext
            dbContext = new COS_DesktopApp.CanteenOrderingSystemEntities();
            // Call the LoadAsync method to asynchronously get the data for the given DbSet from the database.
            dbContext.account_role.LoadAsync().ContinueWith(loadTask =>
            {
                // Bind data to control when loading complete
                account_roleBindingSource.DataSource = dbContext.account_role.Local.ToBindingList();
            }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            String email = emailTextEdit.Text;
            String password = Utils.Utils.GetHash(passwordTextEdit.Text);
            String repassword = Utils.Utils.GetHash(repassTextEdit.Text);
            String phone = phonenumberTextEdit.Text;
            String fullname = fullnameTextEdit.Text;


            if (String.IsNullOrWhiteSpace(email))
            {
                XtraMessageBox.Show("Email must not be empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (String.IsNullOrWhiteSpace(password))
            {
                XtraMessageBox.Show("Password must not be empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (String.IsNullOrWhiteSpace(phone))
            {
                XtraMessageBox.Show("Phone must not be empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (String.IsNullOrWhiteSpace(fullname))
            {
                XtraMessageBox.Show("Fullname must not be empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (birthdayDateEdit.EditValue == null)
            {
                XtraMessageBox.Show("Birthday must not be empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (id_roleTextEdit.EditValue == null)
            {
                XtraMessageBox.Show("Role must not be empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!password.Equals(repassword))
            {
                XtraMessageBox.Show("Password and Re-Password not match.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (passwordTextEdit.Text.Length < 8)
                {
                    XtraMessageBox.Show("Password must > 8 characters.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Regex.IsMatch(passwordTextEdit.Text, @"[a-z]") && Regex.IsMatch(passwordTextEdit.Text, @"[A-Z]") && Regex.IsMatch(passwordTextEdit.Text, @"[0-9]") && Regex.IsMatch(passwordTextEdit.Text, @"[^a-zA-Z0-9]"))
                {
                    DateTime birthday = (DateTime)birthdayDateEdit.EditValue;
                    int role_id = (int)id_roleTextEdit.EditValue;

                    if (dbContext.accounts.Any(a => a.email.Equals(email)))
                    {
                        XtraMessageBox.Show("Email existed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } else if(dbContext.accounts.Any(a => a.phonenumber.Equals(phone)))
                    {
                        XtraMessageBox.Show("Phone existed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        try
                        {
                            account acc = new account();
                            acc.id_role = role_id;
                            acc.fullname = fullname;
                            acc.email = email;
                            acc.birthday = birthday;
                            acc.password = password;
                            acc.phonenumber = phone;

                            gv.AddNewRow();
                            gv.SetFocusedRowCellValue("email", email);
                            gv.SetFocusedRowCellValue("fullname", fullname);
                            gv.SetFocusedRowCellValue("birthday", birthday);
                            gv.SetFocusedRowCellValue("phonenumber", phone);
                            gv.SetFocusedRowCellValue("password", password);
                            gv.SetFocusedRowCellValue("id_role", role_id);
                            gv.FocusedRowHandle = 0;
                            addNewStatus = 1;
                            this.Dispose();
                        }
                        catch
                        {
                            XtraMessageBox.Show("An error has occurred.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("Password must contains A Normal, A Capitalize, A Number, and A Special Character.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

    }
}


