using MBMS_APP.Business.Purchase;
using MBMS_APP.Framework.Helper;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MBMS_APP.WebUI.Purchsase
{
    public partial class Orders : Page
    {
        #region Properties
        private PurchaseService purchaseService;
        #endregion Properties

        #region Contructors
        public Orders()
        {
            purchaseService = new PurchaseService();
        }
        #endregion Contructors

        #region Methods
        public void BindOrdersGrid()
        {
            try
            {
                DataSet dataSet = purchaseService.GetPurchaseRequest(0, 0, 1);
                DataTable ordersDT = new DataTable();
                ordersDT = dataSet.Tables[0];
                if (ordersDT.Rows.Count > 0)
                {
                    gvPurchaseOrders.DataSource = ordersDT;
                    gvPurchaseOrders.DataBind();
                }
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
        }
        #endregion Methods

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindOrdersGrid();
            }
        }
        #endregion Events

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvPurchaseOrders.PageSize = ConversionHelper.ToInt32(ddlPageSize.SelectedValue);
            BindOrdersGrid();
        }

        protected void gvPurchaseOrders_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (e.NewPageIndex > 0)
            {
                gvPurchaseOrders.PageIndex = e.NewPageIndex;
                BindOrdersGrid();
                GridViewRow pagerRow = gvPurchaseOrders.BottomPagerRow;
                if (pagerRow != null)
                {
                    Label lblCurrentPage = (Label)pagerRow.FindControl("lblCurrentPage");
                    if (lblCurrentPage != null)
                    {
                        lblCurrentPage.Text = (e.NewPageIndex + 1).ToString();
                    }
                }
            }
        }

        protected void gvPurchaseOrders_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
    {
        string status = DataBinder.Eval(e.Row.DataItem, "Status").ToString();
        
        // Find the cell that contains the status (assuming it's the first cell)
        TableCell statusCell = e.Row.Cells[0];
        
        // Clear existing controls
        statusCell.Controls.Clear();
        
        // Create a new span element
        var badge = new HtmlGenericControl("span");
        badge.Attributes.Add("class", GetBadgeClass(status));
        badge.InnerText = status;
        
        // Add the badge to the cell
        statusCell.Controls.Add(badge);
    }
        }
        protected string GetBadgeClass(string status)
        {
            switch (status)
            {
                case "Draft":
                    return "badge bg-label-secondary text-dark me-1";
                case "Requested":
                    return "badge bg-label-primary text-dark me-1";
                case "Approved":
                    return "badge bg-label-success text-dark me-1";
                case "Purchased":
                    return "badge bg-label-info text-dark me-1";
                case "Received":
                    return "badge bg-label-warning text-dark me-1";
                case "Rejected":
                    return "badge bg-label-danger text-dark me-1";
                default:
                    return "badge bg-label-secondary text-dark me-1";
            }
        }

    }
}