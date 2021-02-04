<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookListEdit.aspx.cs" Inherits="WebApplication10.BookListEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <meta charset="utf-8" />
     <div class="row">
        <div class="col-md-3"></div>
        <div class="col-md-5">
            <div class="panel panel-default">
                <div class="panel-heading">Book Edit Form
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label Text="Book Name" Font-Bold="true" runat="server" />
                        <asp:TextBox runat="server" ID="txtTitle" placeholder="Book Name" CssClass="form-control" />
                    </div>
                    
                    <div class="form-group">
                        <asp:Label Text="Language" Font-Bold="true" runat="server" />
                        <asp:DropDownList runat="server" ID="ddlLanguage" CssClass="form-control">
                            <asp:ListItem Text="C#" />
                            <asp:ListItem Text="Java" />
                            <asp:ListItem Text="Python" />
                            <asp:ListItem Text="SQL" />
                             <asp:ListItem Text="Htma/CSS/Javascript" />
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Label Text="Price" Font-Bold="true" runat="server" />
                        <asp:TextBox runat="server" ID="txtPrice" CssClass="form-control" />
                    </div>
                     <div class="form-group">
                        <asp:Label Text="Page" Font-Bold="true" runat="server" />
                        <asp:TextBox runat="server" ID="txtPage" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                        <asp:Label Text="Image" Font-Bold="true" runat="server" />
                        <asp:FileUpload ID="fuCoverImg" runat="server" CssClass="form-control" AllowMultiple="false" />
                         <asp:Image ID="Img" Height="100px" runat="server" Style="margin-top: 10px" />
                    </div>
                    <div class="form-group">
                        <asp:Label Text="First Date" Font-Bold="true" runat="server" />
                        <div class='input-group date' id='dtDate'>
                            <input type='text' class="form-control" id="txtDate" runat="server" style="background-color: unset;" readonly />
                            <span class="input-group-addon">
                                <span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                    </div>
                    <asp:Button 
                        Text="Submit" 
                        runat="server" 
                        class="btn btn-primary" 
                        ID="btnSubmit" 
                        OnClick="btnSubmit_Click" 
                        OnClientClick="return submitClick():" />
                </div>
            </div>
        </div>
        <div class="col-md-3"></div>
    </div>
    <script type="text/javascript">
        $(function () {
            $('#dtDate').datetimepicker({
                format: 'YYYY/MM/DD',
                ignoreReadonly: true,
                defaultDate: new Date()
            });
        });
        function submitClick() {
            if (!$('#MainContent_txtTitle').val()) {
                showAlertError('กรุณากรอกข้อมูลชื่อภาพยนต์');
                return false;
            }
            if (!$('#MainContent_ddlLanguage').val()) {
                showAlertError('กรุณาเลือกภาษาคอมพิวเตอร์');
                return false;
            }
            if (!$('#MainContent_txtPrice').val()) {
                showAlertError('กรุณากรอกราคาหนังสือ');
                return false;
            }
            if (isNaN($('#MainContent_txtPrice').val())) {
                showAlertError('กรุณากรอกราคาเป็นตัวเลขเท่านั้น');
                return false;
            }
            if (!$('#MainContent_txtPage').val()) {
                showAlertError('กรุณาระบุจำนวนหนังสือ');
                return false;
            }
            if (isNaN($('#MainContent_txtPage').val())) {
                showAlertError('กรุณาระบุจำนวนหน้าหนังสือ เป็นตัวเลขเท่านั้น');
                return false;
            }
            if (!$('#MainContent_fuCoverImg').val()) {
                showAlertError('กรุณาเลือกรูปภาพ');
                return false;
            }
        }
    </script>
</asp:Content>
