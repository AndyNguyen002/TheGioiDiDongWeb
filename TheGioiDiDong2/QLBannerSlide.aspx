﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QLBannerSlide.aspx.cs" Inherits="TheGioiDiDong2.QLBannerSlide" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="QuanLySanPham.css" />
    <title></title>
    <style>
        body{
            display:flex;
            justify-content:center;
            align-items:center;
            background-image:url(../Theme/backgrounglogin.jpg);
            
        }
        .container{
            margin-top:10px;
            text-align:center;
        }
        .container span{
            color:white;
            
            font-size:20px
        }
        .DImg{
            width:400px;
            height:100px
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="Container">
        <div class="Header">
            Xin chào 
        </div>

        <div class="Content" style="display: flex; flex-direction: row;">
            <div class="left">
                <h4>Chào mừng quay trở lại trang quản lý</h4>
                <ul>
                    <a href="default.aspx"><li>Quay lại trang chủ</li></a>

                    <a href="QuanLySanPham.aspx"><li>Quản lý sản phẩm</li></a>

                    <a href="QLVivoWeek.aspx"><li>Quản lý sự kiện Vivo</li> </a>

                    <a href="QLBannerSlide.aspx"><li>Quản lý Slider</li></a>
                </ul>
            </div>
            <div class="right">
                Tìm kiếm <asp:TextBox ID="tbIDsearch" runat="server"></asp:TextBox>
            <asp:Button ID="bSearch" runat="server" Text="Search" OnClick="bSearch_Click" />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" PageSize="5" Width="1300px" CellPadding="4" EnableViewState="false" 
                DataKeyNames="ID" ForeColor="White" GridLines="Both" 
                OnRowDeleting="GridView1_RowDeleting" 
                OnRowEditing="GridView1_RowEditing" 
                OnPageIndexChanging="GridView1_PageIndexChanging"
                 AllowPaging="true" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" style="margin-top:10px"
                >
                
                <Columns>
                    <asp:TemplateField HeaderText="ID" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%#Eval("ID") %>
                        </ItemTemplate>

                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                    

                    <asp:TemplateField HeaderText="Ảnh" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Image runat="server" CssClass="DImg" ImageUrl='<%#"SqlLoadimg/SliderF/"+Eval("Anh")%>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Thao tác" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                           <a href="QuanLy/BannerSlideSua.aspx?id=<%#Eval("ID") %>" 
                               style="text-decoration:none; color:black; padding:1px 10px; background-color:#efefef">Sửa</a>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:CommandField ControlStyle-CssClass="input_delete" ShowDeleteButton="True" ButtonType="Button" HeaderText="Thao tác" HeaderStyle-HorizontalAlign="Left">
                        <ControlStyle CssClass="input_edit"></ControlStyle>

                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:CommandField>
                </Columns>
            </asp:GridView>
                        <asp:Button style="margin-top:15px; padding:5px" ID="btnThem" class="btn-them" runat="server" Text="Them nhan vien" OnClick="btnThem_Click" />

            </div>
        </div>
    </div>
    </form>
</body>
</html>
