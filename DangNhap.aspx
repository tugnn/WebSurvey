<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="WebSurvey.DangNhap1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="noidungdangnhap">
        <form id="dangnhap" runat="server" >
            <h1>Đăng nhập Website</h1><br /><br />
            <div id="inputdangnhap">
            <h4>Tên đăng nhập:</h4>
            <input type="text" id="txtusername" name="txtusername" width="300" height="20" runat="server">
            <br/><br/>
            <h4>Mật khẩu:</h4>
            <input type="password" id="txtpassword" name="txtpassword" width="300" height="20"  runat="server">
            <br/><br/>
            <input type="button" id="btnlogin" name="btnlogin" runat="server" value="Đăng nhập" height="33px" width="141px" onserverclick="btnLogin_Click"/>
               
             <h4>
                <label id="lblthongbao" name ="lblthongbao" value="" runat="server"></label>
            </h4><br />
            </div>
        </form>
         
    </div>
    
</asp:Content>
