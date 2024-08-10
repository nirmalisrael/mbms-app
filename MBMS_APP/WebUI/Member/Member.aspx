<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin.Master" CodeBehind="Member.aspx.cs" Inherits="MBMS_APP.WebUI.Member.Member" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>
        <div class="container-xxl flex-grow-1 container-p-y">
            <h4 class="fw-bold py-3 mb-4"><span class="text-muted fw-light">Details /</span> Member Details</h4>

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
                <h5 class="card-header">Table Basic</h5>
                <div class="table-responsive text-nowrap">
                    <asp:GridView ID="gvMembers" runat="server" CssClass="table" ClientIDMode="Static"  AutoGenerateColumns="false"
                        AllowPaging="true" PageSize="10"   HeaderStyle-CssClass="thead table-header"
                        OnPageIndexChanging="gvMembers_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="UserId" HeaderText="User Id" Visible="false" />
                            <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                            <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                            <asp:TemplateField HeaderText="Gender">
                                <ItemTemplate>
                                    <asp:Label ID="lblGender" runat="server"
                                        Text='<%# Convert.ToBoolean(Eval("Gender")) ? "Male" : "Female" %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="DateOfBirth" HeaderText="Date Of Birth" />
                            <asp:BoundField DataField="UserName" HeaderText="Email ID" />
                            <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" />
                            <asp:BoundField DataField="OrganizationName" HeaderText="Organization Name" />
                            <asp:BoundField DataField="RoleName" HeaderText="Role Name" />
                            <asp:TemplateField HeaderText="Hostler?">
                                <ItemTemplate>
                                    <asp:Label ID="lblGender" runat="server"
                                        Text='<%# Convert.ToBoolean(Eval("IsHostel")) ? "Yes" : "No" %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Actions">
                                <ItemTemplate>
                                    <div class="dropdown">
                                        <button type="button" class="btn p-0 dropdown-toggle hide-arrow" data-bs-toggle="dropdown">
                                            <i class="bx bx-dots-vertical-rounded"></i>
                                        </button>
                                        <div class="dropdown-menu">
                                            <asp:LinkButton ID="btnEdit" class="dropdown-item" href="javascript:void(0);" runat="server" CommandArgument='<%# Eval("UserId") %>' OnClick="btnEdit_Click" ><i class="bx bx-edit-alt me-1"></i> Edit</asp:LinkButton>
                                            <asp:LinkButton ID="btnDelete" class="dropdown-item" href="javascript:void(0);" runat="server" CommandArgument='<%# Eval("UserId") %>' OnClick="btnDelete_Click" ><i class="bx bx-trash me-1"></i> Delete</asp:LinkButton>
                                        </div>
                                    </div>
                                </ItemTemplate>
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
