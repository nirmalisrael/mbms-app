<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin.Master" CodeBehind="AddMember.aspx.cs" Inherits="MBMS_APP.WebUI.Member.Add_Member" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>
        <div class="container-xxl flex-grow-1 container-p-y">

            <h4 class="fw-bold py-3 mb-4"><span class="text-muted fw-light">Members /</span> Add Members</h4>

            <!-- Basic Layout -->
            <asp:HiddenField ID="hfUser_Id" runat="server" />
            <div class="row">
                <div class="col-xl">
                    <div class="card mb-4">
                        <div class="card-header d-flex justify-content-between align-items-center">
                            <h5 class="mb-0">Add New Member</h5>
                            <small class="text-muted float-end">Default label</small>
                        </div>
                        <div class="card-body">
                            <asp:Panel ID="Panel1" runat="server" CssClass="row">

                                <div class="col-md-6">
                                    <div class="mb-3">
                                        <asp:Label ID="lblFirstName" runat="server" Text="First Name" CssClass="form-label" AssociatedControlID="txtFirstName"></asp:Label>
                                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" Placeholder="John"></asp:TextBox>
                                    </div>
                                    <div class="mb-3">
                                        <asp:Label ID="lblDateOfBirth" runat="server" Text="Date" CssClass="form-label" AssociatedControlID="txtDate"></asp:Label>
                                        <asp:TextBox ID="txtDateOfBirth" runat="server" CssClass="form-control" TextMode="Date" Text="2021-06-18"></asp:TextBox>
                                    </div>
                                    <div class="mb-3">
                                        <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="form-label" AssociatedControlID="txtEmail"></asp:Label>
                                        <div class="input-group input-group-merge">
                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="john.doe" aria-label="john.doe"></asp:TextBox>
                                            <span class="input-group-text">@example.com</span>
                                        </div>
                                        <asp:Label ID="lblEmailHint" runat="server" Text="You can use letters, numbers & periods" CssClass="form-text"></asp:Label>
                                    </div>
                                    <div class="mb-3">
                                        <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone No" CssClass="form-label" AssociatedControlID="txtPhone"></asp:Label>
                                        <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control phone-mask" Placeholder="658 799 8941"></asp:TextBox>
                                    </div>
                                    <div class="mb-3">
                                        <asp:Label ID="lblRole" runat="server" Text="Role" CssClass="form-label" AssociatedControlID="ddlRole"></asp:Label>
                                        <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-select"/>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="mb-3">
                                        <asp:Label ID="lblLastName" runat="server" Text="Last Name" CssClass="form-label" AssociatedControlID="txtLastName"></asp:Label>
                                        <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" Placeholder="Doe"></asp:TextBox>
                                    </div>
                                    <br />
                                    <div class="mb-3">
                                        <small class="text-bold fw-bold d-block">GENDER</small>
                                        <div class="form-check-inline">
                                            <asp:RadioButton
                                                ID="rbMale"
                                                runat="server"
                                                GroupName="Gender"
                                                CssClass="margin-right:10px" />
                                            <asp:Label runat="server" AssociatedControlID="rdoMale" CssClass="form-check-label">Male</asp:Label>
                                        </div>
                                        <div class="form-check-inline">
                                            <asp:RadioButton
                                                ID="rbFemale"
                                                runat="server"
                                                GroupName="Gender"
                                                Css="margin-right:10px" />
                                            <asp:Label runat="server" AssociatedControlID="rdoFemale" CssClass="form-check-label">Female</asp:Label>
                                        </div>
                                    </div>
                                    <div class="mb-3">
                                        <asp:Label ID="lblPassword" runat="server" Text="Password" CssClass="form-label" AssociatedControlID="txtPassword"></asp:Label>
                                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Password123"></asp:TextBox>
                                    </div>
                                    <br />
                                    <br />
                                    <br />
                                    <div class="form-check mb-3">
                                        <asp:CheckBox ID="chkHostel" runat="server" Css="margin-left:-10px" Checked="True" />
                                        <asp:Label runat="server" AssociatedControlID="chkHostel" CssClass="form-check-label">Hostel</asp:Label>
                                    </div>
                                    <div class="mb-3">
                                        <asp:Label ID="lblOrganization" runat="server" Text="Organization" CssClass="form-label" AssociatedControlID="ddlOrganization"></asp:Label>
                                        <asp:DropDownList ID="ddlOrganization" runat="server" CssClass="form-select">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="mb-3 text-center">
                                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary" CausesValidation="False" OnClick="btnCancel_Click" />
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
