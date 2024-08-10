<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin.Master" CodeBehind="Orders.aspx.cs" Inherits="MBMS_APP.WebUI.Purchsase.Orders" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>
        <div class="container-xxl flex-grow-1 container-p-y">
            <h5 class="fw-bold py-2 mb-4"><span class="text-muted fw-light">Purchases Details/</span> Orders</h5>
            <!-- Basic Bootstrap Table -->
            <div class="row mb-3">
                <div class="col-md-2">
                    <asp:DropDownList ID="ddlPageSize" runat="server" CssClass="form-select" AutoPostBack="True" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                        <asp:ListItem Value="10">10 rows</asp:ListItem>
                        <asp:ListItem Value="15">15 rows</asp:ListItem>
                        <asp:ListItem Value="20">20 rows</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="card">
                <div class="table-responsive text-nowrap">
                    <asp:GridView runat="server" ID="gvPurchaseOrders" ClientIDMode="Static" AutoGenerateColumns="false" CssClass="table text-center"
                        OnRowDataBound="gvPurchaseOrders_RowDataBound"
                        HeaderStyle-CssClass="thead table-header thead-bg-color"
                        AllowPaging="True" PageSize="10"
                        OnPageIndexChanging="gvPurchaseOrders_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="RequestId" HeaderText="ID" Visible="false" />
                            <asp:BoundField DataField="RequestName" HeaderText="Request Name" />
                            <asp:BoundField DataField="NoOfItems" HeaderText="No Of Items" />
                            <asp:BoundField DataField="StatusId" Visible="false" />
                            <asp:BoundField DataField="RequestedDate" HeaderText="Requested Date" DataFormatString="{0:dd-MM-yyyy}"/>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>

                                    <span class='<%# GetBadgeClass(Eval("Status").ToString()) %>'>
                                        <%# Eval("Status") %>
                                        </span>

                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Amount" HeaderText="Amount">
                                <ItemStyle CssClass="text-end"/>
                            </asp:BoundField>

                            <asp:TemplateField HeaderText="Actions">
                                <ItemTemplate>
                                    <div class="dropdown">
                                        <button type="button" class="btn p-0 dropdown-toggle hide-arrow" data-bs-toggle="dropdown">
                                            <i class="bx bx-dots-vertical-rounded"></i>
                                        </button>
                                        <div class="dropdown-menu">
                                            <a class="dropdown-item" href="javascript:void(0);"><i class="bx bx-edit-alt me-1"></i>Edit</a>
                                            <a class="dropdown-item" href="javascript:void(0);"><i class="bx bx-trash me-1"></i>Delete</a>
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <ItemStyle CssClass="table-border-bottom-0" />
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle CssClass="table-alt-row table-border-bottom-0" />
                        <PagerTemplate>
                            <nav aria-label="Page navigation">
                                <ul class="pagination" style="justify-content: end;">
                                    <li class="page-item">
                                        <asp:LinkButton runat="server" CommandName="Page" CommandArgument="Prev" CssClass="page-link" Text="<i class='bx bx-chevron-left'></i>" />
                                    </li>
                                    <li class="page-item">
                                        <asp:Label ID="lblCurrentPage" Text="1" runat="server" CssClass="bx page-link" />
                                    </li>
                                    <li class="page-item">
                                        <asp:LinkButton runat="server" CommandName="Page" CommandArgument="Next" CssClass="page-link" Text="<i class='bx bx-chevron-right'></i>" />
                                    </li>
                                </ul>
                            </nav>
                        </PagerTemplate>
                    </asp:GridView>
                </div>
            </div>
            <!--/ Basic Bootstrap Table -->
        </div>
    </main>

</asp:Content>

