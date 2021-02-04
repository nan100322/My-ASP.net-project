<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookList.aspx.cs" Inherits="WebApplication10.BookList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <meta charset="utf-8" />
    <div class="row">
        <div class="col" style="padding-top: 20px">
            <asp:GridView ID="gvBook" BorderWidth="0" GridLines="None" runat="server"
                AutoGenerateColumns="false" CssClass="table">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="Book ID" />
                    <asp:BoundField DataField="title" HeaderText="Book Title" />
                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                            <asp:image Height="80px" ID ="img" ImageUrl='<%# Eval("image") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="language" HeaderText="Language" />
                    <asp:BoundField DataField="Price" HeaderText="Price" />
                    <asp:BoundField DataField="Page" HeaderText="Page" />
                    <asp:BoundField DataField="FirstDate" HeaderText="First Date" />
                    <asp:TemplateField HeaderText="edit">
                       <ItemTemplate>
                            <asp:Button
                                CssClass="btn btn-primary"
                                OnClick="btnEdit_Click"
                                Text="Edit"
                                ID="btnEdit"
                                runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button
                                CssClass="btn btn-danger"
                                OnClientClick="return confirm('คุณต้องการลบข้อมูลรายการนี้ใช่หรือไม่ ?');"
                                OnClick="btnDelete_Click"
                                Text="Delete"
                                ID="btnDelete"
                                runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>