using MBMS_APP.Business.Users;
using MBMS_APP.Framework.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MBMS_APP.WebUI.Member
{
    public partial class Add_Member : System.Web.UI.Page
    {
        UserService userService = new UserService();
        public int UserId {  get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadRolesAndOrganizations();
        }
        #region Bind Member Data
        private void LoadRolesAndOrganizations()
        {
            try
            {
                DataSet dataSet = userService.GetRolesAndOrganization();
                DataTable roleTable = dataSet.Tables[0];
                DataTable organizationTable = dataSet.Tables[1];

                ddlRole.DataSource = roleTable;
                ddlRole.DataTextField = "RoleName";
                ddlRole.DataValueField = "RoleId";
                ddlRole.DataBind();
                ddlRole.SelectedIndex = 0;

                ddlOrganization.DataSource = organizationTable;
                ddlOrganization.DataTextField = "OrganizationName";
                ddlOrganization.DataValueField = "OrganizationId";
                ddlOrganization.DataBind();
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
        }
        private void LoadMemberDetails(int userId)
        {
            if (UserId > 0)
            {
                hfUser_Id.Value = UserId.ToString();
                DataTable dataTable = userService.GetUserDetails(UserId);

                if (dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];

                    txtFirstName.Text = row["FirstName"].ToString();
                    txtLastName.Text = row["LastName"].ToString();

                    // Ensure the date value is parsed correctly
                    DateTime dateOfBirth;
                    if (DateTime.TryParse(row["DateOfBirth"].ToString(), out dateOfBirth))
                    {
                        txtDateOfBirth.Text = dateOfBirth.ToString("yyyy-MM-dd");
                    }

                    ddlRole.SelectedValue = row["RoleId"].ToString();
                    ddlOrganization.SelectedValue = row["OrganizationId"].ToString();
                    txtPassword.Text = row["AadharNumber"].ToString();
                    chkHostel.Checked = true;
                    txtEmail.Text = row["UserName"].ToString();
                    txtPhoneNumber.Text = row["PhoneNumber"].ToString();

                    bool gender = Convert.ToBoolean(row["Gender"]);
                    rbMale.Checked = gender;
                    rbFemale.Checked = !gender;

                    UserId = Convert.ToInt32(row["UserId"]);
                }
            }
        }
        #endregion
        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/member");
        }
    }
}