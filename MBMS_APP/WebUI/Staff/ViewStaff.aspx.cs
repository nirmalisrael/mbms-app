using MBMS_APP.Business.Users;
using MBMS_APP.Framework.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MBMS_APP.WebUI.Staff
{
    public partial class ViewStaff : System.Web.UI.Page
    {
        UserService userService = new UserService();

        public int RoleId { get; set; } = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }

        public void BindData()
        {
            int roleId = 2;
            RoleId = roleId;
            try
            {
                DataTable dt = userService.GetUserDetails(0, RoleId);
                gvUsers.DataSource = dt;
                gvUsers.DataBind();
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
        }

        protected void gvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUsers.PageIndex = e.NewPageIndex;
            BindData();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                try
                {
                    string arg = ((LinkButton)sender).CommandArgument;
                    int userId = ConversionHelper.ToInt32(arg);
                    int result = userService.DeleteUserDetails(userId);

                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('User deleted successfully!');", true);
                    BindData();
                }
                catch (Exception ex)
                {
                    new ErrorLog().WriteLog(ex);
                }

            }
            else
            {
                BindData(); 
            }
        }
    }
}