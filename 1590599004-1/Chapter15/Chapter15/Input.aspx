<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Input.aspx.cs" 
Inherits="Input" MasterPageFile="~/Ch15MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" 
Runat="Server"><br />
    <asp:Label ID="Label1" runat="server" Text="Enter Name" 
    ForeColor=Blue  ></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
    Text="Submit" />
    <p>
        <asp:Label ID="Label2" runat="server" Font-Size=XX-Large></asp:Label>
    </p>
    </asp:Content>

