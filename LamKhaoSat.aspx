<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="LamKhaoSat.aspx.cs" Inherits="WebSurvey.LamKhaoSat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="noidunglam">
        <form id ="timkhaosat" runat ="server">
        <div id="timtenkhaosat">
            <label id ="lbltenkhaosat">Nhập tên khảo sát: </label>
            <input type="text" id ="txttenkhaosat" name ="txttenkhaosat" runat="server"/>
        </div>
        <div id="timnguoitaokhaosat">
            <label id ="lblnguoitaokhaosat">Nhập tên người tạo khảo sát: </label>
            <input type="text" id ="txtnguoitaokhaosat" name ="txtnguoitaokhaosat" runat="server"/>
        </div>
        <div id ="timkiem" name ="timkiem">
            <input type ="button" id ="btntim" name ="btntim" runat ="server" onserverclick ="btntim_click" value="Tìm kiếm"/>
            <label id="lblthongbao" name ="lblthongbao" runat="server"></label>
        </div>
        <div id="noidungkhaosat" name ="noidungkhaosat" runat="server">
        </div>
        <div id ="gui" name ="gui">
            <input type ="button" id ="btngui" name ="btngui" runat ="server" onserverclick ="btngui_click" value="Gửi"/>
        </div>
    </form>
    </div>
    
</asp:Content>
