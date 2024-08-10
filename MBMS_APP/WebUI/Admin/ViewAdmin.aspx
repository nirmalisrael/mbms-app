<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin.Master" CodeBehind="ViewAdmin.aspx.cs" Inherits="MBMS_APP.WebUI.Admin.ViewAdmin" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>
        <div class="container-xxl flex-grow-1 container-p-y">
            <h4 class="fw-bold py-3 mb-4"><span class="text-muted fw-light">Users /</span> User Management</h4>
            <!-- User Data Table -->
            <div class="card">
                <h5 class="card-header">Admin Details</h5>
                <div class="table-responsive text-nowrap">
                    <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" CssClass="table" DataKeyNames="UserId"
                                    AllowPaging="true" PageSize="10" OnPageIndexChanging="gvUsers_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                            <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                            <asp:TemplateField HeaderText="Gender">
                                <ItemTemplate>
                                    <asp:Label ID="lblGender" runat="server"
                                        Text='<%# Convert.ToBoolean(Eval("Gender")) ? "Male" : "Female" %>'>
                                </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="DateOfBirth" HeaderText="Date of Birth" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="Username" HeaderText="Username" />
                            <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" />
                            <asp:BoundField DataField="AadharNumber" HeaderText="Aadhar Number" />
                            <asp:BoundField DataField="Address" HeaderText="Address" />
                            <asp:BoundField DataField="OrganizationName" HeaderText="Organization Name" />
                            <asp:BoundField DataField="RoleName" HeaderText="Role Name" />
                            <asp:TemplateField HeaderText="User Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserStatus" runat="server"
                                        Text='<%# Convert.ToBoolean(Eval("IsActive")) ?"Active" : "Inactive" %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                          <%--   <asp:TemplateField HeaderText="Toggle Status">
                                <ItemTemplate>
                                    <asp:Button ID="btnToggleStatus" runat="server" Text='<%# Convert.ToBoolean(Eval("IsActive")) ? "Deactivate" : "Activate" %>'
                                                CommandName="ToggleStatus" CommandArgument='<%# Eval("UserID") %>' CssClass="btn btn-sm" '<%# Convert.ToBoolean(Eval("UserStatus")) ? "btn-danger" : "btn-success" %>' />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Actions">
                                <ItemTemplate>
                                    <div class="dropdown">
                                        <button type="button" class="btn p-0 dropdown-toggle hide-arrow" data-bs-toggle="dropdown">
                                            <i class="bx bx-dots-vertical-rounded"></i>
                                        </button>
                                        <div class="dropdown-menu">
                                            <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CssClass="dropdown-item">
                                                <i class="bx bx-edit-alt me-2"></i> Edit
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" CssClass="dropdown-item" CommandArgument='<%#Eval("UserId") %>'
                                                                OnClick="btnDelete_Click" OnClientClick="Confirm()">
                                                <i class="bx bx-trash me-2"></i> Delete
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <!--/ User Data Table -->
        </div>
    </main>
</asp:Content>
