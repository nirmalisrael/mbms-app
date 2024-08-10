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
    public partial class Member : System.Web.UI.Page
    {
        UserService userService = new UserService();
        public int RoleId { get; set; } = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMembers();
            }
        }
        #region BindMembers
        private void BindMembers()
        {
            int roleId = 3;
            RoleId = roleId;
            try
            {
                DataTable dataTable = userService.GetUserDetails(0, RoleId);
                LoadMemberDetails(dataTable);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
        } 
        public void LoadMemberDetails(DataTable dataTable)
        {
            try
            {
                if (dataTable.Rows.Count > 0)
                {
                    gvMembers.DataSource = dataTable;
                    gvMembers.DataBind();
                }
                else
                {
                    gvMembers.DataSource = null;
                    gvMembers.DataBind();
                }
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
        }
        #endregion-BindMembers

        #region Page Index
        protected void gvMembers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMembers.PageIndex = e.NewPageIndex;
            BindMembers();
            GridViewRow pagerRow = gvMembers.BottomPagerRow;
            if (pagerRow != null)
            {
                Label lblCurrentPage = (Label)pagerRow.FindControl("lblCurrentPage");
                if (lblCurrentPage != null)
                {
                    lblCurrentPage.Text = (e.NewPageIndex + 1).ToString();
                }
            }
        }
        #endregion

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvMembers.PageSize = ConversionHelper.ToInt32(ddlPageSize.SelectedValue);
            BindMembers();
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}