<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="TaoKhaoSat.aspx.cs" Inherits="WebSurvey.TaoKhaoSat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id ="noidungtrang">
        <form id="taokhaosat" runat="server">
        <div id="noidungchude">
            <label id="chude">Chủ đề khảo sát: </label>
            <input type="text" id ="txtchude" name ="txtchude" runat ="server"/>
        </div>
    
        <div id="noidungkhaosat">
                <input type ="text" id ="txtsocauhoi" name ="txtsocauhoi" runat="server" />
        </div>
            <div id ="nut">
                <input type="button" id ="btnthem" name ="btnthem" onclick ="btnthem_click()"  value ="Thêm"/>
                <input type="button" id ="btnxoa" name ="btnxoa" onclick ="btnxoa_click()" runat="server" value ="Xóa"/>
                <input type="button" id ="btnluu" name ="btnluu" onserverclick="btnluu_click" runat="server" value ="Lưu"/>
                <label id="lbltest" name ="lbltest" runat ="server"></label>
            </div>
        </form>
    </div>
</asp:Content>
