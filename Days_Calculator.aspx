<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Days_Calculator.aspx.cs" Inherits="HELPA.Days_Calculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Days Calculator</title>
    <link href="/Default.css" rel="stylesheet" type="text/css" />   
    
    
    <style type="text/css">
        .floatLeft {
            float:left;
        }

        .floatRight {
            float:right;
        }
        
        .fontsize_Large{
            font-size:large;
        }             
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManagerAddRandomInput" runat="server" EnablePartialRendering="true" />
        <asp:Panel ID="TitlePanel" runat="server">        
            <table id="TitleTable" style="width:100%; border-collapse:collapse; background-repeat:no-repeat; padding: 0px;">
            <tr class="background-aquablue">          
                <td class="fontsize_Large" style="text-align:center"><b>Days Calculator</b></td>
                <%--<td class="textalign-right">Currently logged in as:
                    <asp:Label ID="DCUserLabel" runat="server"></asp:Label>                
                </td>--%>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="InstructionButton" runat="server" CssClass="wrap" OnClick="InstructionButton_Click" Text="Instructions" />  click to show/hide Instructions
                </td>
            </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="InstructionPanel" runat="server" Visible="False">
            <table id="InstructionTable" style="background-color:aquamarine; font-weight:bold; border:solid; border-collapse:collapse">
                <tr>                
                    <td style="width:25%; vertical-align:top; border:solid; border-width:thin; padding-right:10px">To begin enter a date to calculate from in the text box located below, Or Click one of the buttons listed below the top teal box to automatically populate the appropriate date.</td>
                
                    <td style="width:26%; vertical-align:top; border:solid; border-width:thin; padding-right:10px">Select the radio button next to Calendar days to count the number of Calendar days from the specified date, or Select the radio button next to Business days to count the number of Business days from the specified date.</td>

                    <td style="width:12%; vertical-align:top; border:solid; border-width:thin; padding-right:10px">Select the format that you wish to see the dates in from the dropdown list box.</td>
                
                    <td style="width:25%; vertical-align:top; border:solid; border-width:thin; padding-right:10px">To calculate specific number of days, weeks, or months from the specified date, enter the days, weeks or months to calculate from in a text box located in a turquoise cell on the right side of each section.</td>
                
                    <td style="width:12%; vertical-align:top; border:solid; border-width:thin; padding-right:10px">To count backward from the specified date, enter a negative number into one of the turquoise cells.</td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="DatesPanel" runat="server">
            <table id="DateInputTable"style="width:100%; border-collapse:collapse;">
                <tr style="Height:30px; background-color:turquoise">
                    <td class= "textalign-right" style="width:45%">
                        <asp:Label ID="DateInstructionLabel" runat="server" CssClass="Textbox-centermedium" Text="Enter a Date in MM/DD/YY format: --&gt;"></asp:Label>
                        </td>
                    <td class="textalign-left" style="width:55%">
                        <asp:TextBox ID="DateTextbox" runat="server" CssClass="Textbox-centermedium" Height="25px" Width="106px" OnTextChanged="DateTextbox_TextChanged" AutoPostBack="true"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table id="DateTable"style="width:100%; border-collapse:collapse;">
                <tr class="background-teal" style="Height:30px">
                    <td class="textalign-right" style="Width:30%">
                        <asp:Label ID="DateShortformat" runat="server" CssClass="Textbox-centermedium" Text=""></asp:Label>
                    </td>
                    <td class="textalign-center" style="Width:40%">
                        <asp:Label ID="DateLongformat" runat="server" CssClass="Textbox-centermedium" Text=""></asp:Label>
                    </td>
                    <td class="textalign-left" style="Width:30%">
                        <asp:Label ID="Datedayofweek" runat="server" CssClass="Textbox-centermedium" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <table id="ButtonTable"style="width:100%">
                <tr>
                    <td class="textalign-center" style="width:10%">
                        <asp:Button ID="FirstDayOfPreviousMonthButton" runat="server" CssClass="wrap" Height="40px" OnClick="FirstDayOfPreviousMonthButton_Click" Text="First Day Of Previous Month" Width="110px" />
                    </td>
                    <td class="textalign-center" style="width:10%">
                        <asp:Button ID="LastDayofPreviousMonthButton" runat="server" CssClass="wrap" Height="40px" OnClick="LastDayofPreviousMonthButton_Click" Text="Last Day of Previous Month" Width="110px" />
                    </td>
                    <td class="textalign-center" style="width:10%">
                        <asp:Button ID="TodaysDateButton" runat="server" CssClass="wrap" Height="40px" Text="Today's Date" Width="110px" OnClick="TodaysDateButton_Click" />
                    </td>
                    <td class="textalign-center" style="width:10%">
                        <asp:Button ID="FirstDayofNextMonthButton" runat="server" CssClass="wrap" Height="40px" OnClick="FirstDayofNextMonthButton_Click" Text="First Day of Next Month" Width="110px" />
                    </td>
                    <td class="textalign-center" style="width:10%">
                        <asp:Button ID="LastDayofNextMonth" runat="server" CssClass="wrap" Height="40px" OnClick="LastDayofNextMonth_Click" Text="Last Day of Next Month" Width="110px" />
                    </td>
                    <td class="textalign-left" style="width:10%">
                        <asp:RadioButton ID="CalendarDaySelector" runat="server" BackColor="#96C864" Checked="True" GroupName="DaySelector" Text="Calendar Days" ViewStateMode="Enabled" OnCheckedChanged="DaySelector_CheckedChanged" AutoPostBack="true" />
                        <br />
                        <asp:RadioButton ID="BusinessDaySelector" runat="server" BackColor="#B0E0E6" GroupName="DaySelector" Text="Business Days" OnCheckedChanged="DaySelector_CheckedChanged" AutoPostBack="true" />
                    </td>
                    <td class="textalign-right" style="width:25%">Select the date format from the drop down: </td>
                    <td class="textalign-left" style="width:15%">
                        <asp:DropDownList ID="DateFormatDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DateFormatDropDownList_SelectedIndexChanged">
                            <asp:ListItem Value="shortdate">1 / 31 / 19</asp:ListItem>
                            <asp:ListItem Value="shortdatelongyear">1 / 31 / 2019</asp:ListItem>
                            <asp:ListItem Value="mediumdate">01 / 31 / 19</asp:ListItem>                                                        
                            <asp:ListItem Value="medlongdate">01 / 31 / 2019</asp:ListItem>
                            <asp:ListItem Value="longdate">Jan 31, 2019</asp:ListItem>
                            <asp:ListItem Value="longestdate">January 31, 2019</asp:ListItem>
                            <asp:ListItem Value="shortdaymonthyeardate">31 / 01 / 19</asp:ListItem>
                            <asp:ListItem Value="meddaymonthyeardate">31 / Jan / 19</asp:ListItem>
                            <asp:ListItem Value="longdaymonthyeardate">31 / Jan / 2019</asp:ListItem>
                            <asp:ListItem Value="longestdaymonthyeardate">31 / January / 2019</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
<%--            <table id="TypeofDayCountTable" runat="server" style="width:100%; border-collapse:collapse">
                <tr>
                    <td class="textalign-center" style="border-top:solid; border-left:solid; border-right:solid; border-width:thin; border-color:black">
                        
                    </td>
                </tr>
                <tr>
                    <td class="textalign-center" style="border-bottom:solid; border-left:solid; border-right:solid; border-width:thin; border-color:black">
                        
                    </td>
                </tr>
                <tr>
                    <td class="column-widthauto_text-center">&nbsp;</td>
                </tr>
            </table>--%>
            <table id="DaysCountTable" runat="server" style="width:100%; border-collapse:collapse">
                <tr class="background-teal">                    
                    <td class="textalign-center"  colspan="12" style="border:solid; border-width:thin; border-color:black">Days from Specified Date</td>
                </tr>                                          
                <tr>
                    <td class="textalign-center" style="width: 5%; border:solid; border-width:thin; border-color:black">5</td>
                    <td class="textalign-center" style="width: 7%; border:solid; border-width:thin; border-color:black">Days</td>
                    <td class="textalign-center" style="width:13%; border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="addfiveDayLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="textalign-center" style="width: 5%; border:solid; border-width:thin; border-color:black">45</td>
                    <td class="textalign-center" style="width: 7%; border:solid; border-width:thin; border-color:black">Days</td>
                    <td class="textalign-center" style="width:13%; border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="addfortyfiveDayLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="textalign-center" style="width: 5%; border:solid; border-width:thin; border-color:black">120</td>
                    <td class="textalign-center" style="width: 7%; border:solid; border-width:thin; border-color:black">Days</td>
                    <td class="textalign-center" style="width:13%; border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="addonehundredtwentyDayLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="textalign-center" style="width: 5%; border:solid; border-width:thin; border-color:black">365</td>
                    <td class="textalign-center" style="width: 7%; border:solid; border-width:thin; border-color:black">Days</td>
                    <td class="textalign-center" style="width:13%; border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="addthreehundredsixtyfiveDayLabel" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">7</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Days</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="addsevenDayLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        60</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Days</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="addsixtyDayLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        150</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Days</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="addonehundredfiftyDayLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black; background-color:turquoise">
                        <asp:TextBox ID="RandomDaysInputTextBox1" runat="server" Width="30px" OnTextChanged="RandomDaysInputTextBox1_TextChanged" AutoPostBack="true"></asp:TextBox>
                       <%-- <asp:Button ID="RandomDaysInputTextBox1UpdateButton" runat="server" CssClass="wrap" OnClick="RandomDaysInputTextBox1UpdateButton_Click" Text="Update" Width="55px" />--%>
                    </td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Days</td>
                    <%--<asp:ScriptManager ID="ScriptManagerAddRandomInput" runat="server" EnablePartialRendering="true" />--%>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:UpdatePanel ID="UpdatePanelAddRandomDaysInput1" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="addrandomDaysInput1DayLabel" runat="server" Text=""></asp:Label>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="RandomDaysInputTextBox1" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">10</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Days</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="addtenDayLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        65</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Days</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="addsixtyfiveDayLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        180</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Days</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="addonehundredeightyDayLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black; background-color:turquoise">
                        <asp:TextBox ID="RandomDaysInputTextBox2" runat="server" Width="30px" OnTextChanged="RandomDaysInputTextBox2_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <%--<asp:Button ID="RandomDaysInputTextBox2UpdateButton" runat="server" CssClass="wrap" OnClick="RandomDaysInputTextBox2UpdateButton_Click" Text="Update" Width="55px" />--%>
                    </td>                    
                    <td style="border:solid; border-width:thin; border-color:black" class="column-widthauto_text-center">                        
                        Days</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:UpdatePanel ID="UpdatePanelAddRandomDaysInput2" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="addrandomDaysInput2DayLabel" runat="server" Text=""></asp:Label>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="RandomDaysInputTextBox2" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">15</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Days</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="addfifteenDayLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        75</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Days</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="addseventyfiveDayLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        240</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Days</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="addtwohundredfortyDayLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black; background-color:turquoise">
                        <asp:TextBox ID="RandomDaysInputTextBox3" runat="server" Width="30px" OnTextChanged="RandomDaysInputTextBox3_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <%--<asp:Button ID="RandomDaysInputTextBox3UpdateButton" runat="server" CssClass="wrap" OnClick="RandomDaysInputTextBox3UpdateButton_Click" Text="Update" Width="55px" />--%>
                    </td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        Days</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:UpdatePanel ID="UpdatePanelAddRandomDaysInput3" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="addrandomDaysInput3DayLabel" runat="server" Text=""></asp:Label>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="RandomDaysInputTextBox3" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                 </tr>
                <tr>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">20</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Days</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="addtwentyDayLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        90</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Days</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="addninetyDayLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        360</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Days</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="addthreehundredsixtyDayLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black; background-color:turquoise">
                        <asp:TextBox ID="RandomDaysInputTextBox4" runat="server" Width="30px" OnTextChanged="RandomDaysInputTextBox4_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <%--<asp:Button ID="RandomDaysInputTextBox4UpdateButton" runat="server" CssClass="wrap" OnClick="RandomDaysInputTextBox4UpdateButton_Click" Text="Update" Width="55px" />--%>
                    </td>
                    <td style="border:solid; border-width:thin; border-color:black" class="column-widthauto_text-center">
                        Days</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:UpdatePanel ID="UpdatePanelAddRandomDaysInput4" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="addrandomDaysInput4DayLabel" runat="server" Text=""></asp:Label>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="RandomDaysInputTextBox4" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
<%--                <tr>
                    <td class="column-widthauto_text-center" colspan="12">&nbsp;</td>
         
                </tr>--%>
             </table>
             <table id="WeeksCountTable"style="width:100%; border-collapse:collapse">
                <tr class="background-teal">
                    <td colspan="12" class="textalign-center" style="border:solid; border-width:thin; border-color:black">Weeks from Specified Date</td>
                </tr>
                <tr>
                    <td class="textalign-center" style="width: 5%; border:solid; border-width:thin; border-color:black">1</td>
                    <td class="textalign-center" style="width: 7%; border:solid; border-width:thin; border-color:black">Week</td>
                    <td class="textalign-center" style="width:13%; border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="AddOneWeekLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="textalign-center" style="width: 5%; border:solid; border-width:thin; border-color:black">8</td>
                    <td class="textalign-center" style="width: 7%; border:solid; border-width:thin; border-color:black">Weeks</td>
                    <td class="textalign-center" style="width:13%; border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="AddEightWeeksLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="textalign-center" style="width: 5%; border:solid; border-width:thin; border-color:black">15</td>
                    <td class="textalign-center" style="width: 7%; border:solid; border-width:thin; border-color:black">Weeks</td>
                    <td class="textalign-center" style="width:13%; border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="AddFifteenWeeksLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="textalign-center" style="width: 5%; border:solid; border-width:thin; border-color:black">30</td>
                    <td class="textalign-center" style="width: 7%; border:solid; border-width:thin; border-color:black">Weeks</td>
                    <td class="textalign-center" style="width:13%; border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="AddThirtyWeeksLabel" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">2</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Weeks</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="AddTwoWeeksLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">9</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Weeks</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="AddNineWeeksLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">16</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Weeks</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="AddSixteenWeeksLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">35</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Weeks</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="AddThirtyfiveWeeksLabel" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">3</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Weeks</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="AddThreeWeeksLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">10</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Weeks</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="AddTenWeeksLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">17</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Weeks</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="AddSeventeenWeeksLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">40</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Weeks</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="AddFortyWeeksLabel" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">4</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Weeks</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="AddFourWeeksLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">11</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Weeks</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="AddElevenWeeksLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">18</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Weeks</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="AddEighteenWeeksLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">45</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Weeks</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="AddFortyfiveWeeksLabel" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">5</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Weeks</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="AddFiveWeeksLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">12</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Weeks</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="AddTwelveWeeksLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">19</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Weeks</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="AddNineteenWeeksLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">50</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Weeks</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="AddFiftyWeeksLabel" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">6</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Weeks</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="AddSixWeeksLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">13</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Weeks</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="AddThirteenWeeksLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">20</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Weeks</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="AddTwentyWeeksLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="column-widthauto_text-center" style="background-color:turquoise; border:solid; border-width:thin; border-color:black">
                        <asp:TextBox ID="RandomWeeksInputTextBox1" runat="server" Width="30px" OnTextChanged="RandomWeeksInputTextBox1_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <%--<asp:Button ID="RandomWeeksInputTextBox1UpdateButton" runat="server" CssClass="wrap" OnClick="RandomWeeksInputTextBox1UpdateButton_Click" Text="Update" Width="55px" />--%>
                    </td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Weeks</td>
	                <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:UpdatePanel ID="UpdatePanelAddRandomWeeksInput1" runat="server">
        	                <ContentTemplate>                            
                                <asp:Label ID="AddRandomWeeksLabel1" runat="server" Text=""></asp:Label>                            
                            </ContentTemplate>
                            <Triggers>
                	            <asp:AsyncPostBackTrigger ControlID="RandomWeeksInputTextBox1" />
                            </Triggers>
	                    </asp:UpdatePanel> 
                    </td>
                </tr>
                <tr>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">7</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Weeks</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="AddSevenWeeksLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">14</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Weeks</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="AddFourteenWeeksLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">25</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Weeks</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="AddTwentyfiveWeeksLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="column-widthauto_text-center" style="background-color:turquoise; border:solid; border-width:thin; border-color:black">
                        <asp:TextBox ID="RandomWeeksInputTextBox2" runat="server" Width="30px" OnTextChanged="RandomWeeksInputTextBox2_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <%--<asp:Button ID="RandomWeeksInputTextBox2UpdateButton" runat="server" CssClass="wrap" OnClick="RandomWeeksInputTextBox2UpdateButton_Click" Text="Update" Width="55px" />--%>
                    </td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Weeks</td>
	                <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:UpdatePanel ID="UpdatePanelAddRandomWeeksInput2" runat="server">
        	                <ContentTemplate>                            
                                <asp:Label ID="AddRandomWeeksLabel2" runat="server" Text=""></asp:Label>                            
                            </ContentTemplate>
                            <Triggers>
                	            <asp:AsyncPostBackTrigger ControlID="RandomWeeksInputTextBox2" />
                            </Triggers>
	                    </asp:UpdatePanel>
                    </td>
                </tr>
<%--                <tr>
                    <td class="column-widthauto_text-center" colspan="12">&nbsp;</td>

                </tr>--%>
            </table>
            <table id="MonthsCountTable" style="width:100%; border-collapse:collapse">
                <tr class="background-teal">
                    <td colspan="12" class="textalign-center" style="border:solid; border-width:thin; border-color:black">Months from Specified Date</td>
                </tr>
                <tr>
                    <td class="textalign-center" style="width: 5%; border:solid; border-width:thin; border-color:black">1</td>
                    <td class="textalign-center" style="width: 7%; border:solid; border-width:thin; border-color:black">Month</td>
                    <td class="textalign-center" style="width:13%; border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="AddOneMonthLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="textalign-center" style="width: 5%; border:solid; border-width:thin; border-color:black">5</td>
                    <td class="textalign-center" style="width: 7%; border:solid; border-width:thin; border-color:black">Months</td>
                    <td class="textalign-center" style="width:13%; border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="AddFiveMonthsLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="textalign-center" style="width: 5%; border:solid; border-width:thin; border-color:black">9</td>
                    <td class="textalign-center" style="width: 7%; border:solid; border-width:thin; border-color:black">Months</td>
                    <td class="textalign-center" style="width:13%; border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="AddNineMonthsLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="textalign-center" style="width: 5%; border:solid; border-width:thin; border-color:black">18</td>
                    <td class="textalign-center" style="width: 7%; border:solid; border-width:thin; border-color:black">Months</td>
                    <td class="textalign-center" style="width:13%; border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="AddEighteenMonthsLabel" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">2</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Months</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="AddTwoMonthsLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">6</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Months</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="AddSixMonthsLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">10</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Months</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="AddTenMonthsLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">24</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Months</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="AddTwentyfourMonthsLabel" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">3</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Months</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="AddThreeMonthsLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">7</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Months</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="AddSevenMonthsLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">11</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Months</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="AddElevenMonthsLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="column-widthauto_text-center" style="background-color:turquoise; border:solid; border-width:thin; border-color:black">
                        <asp:TextBox ID="RandomMonthsInputTextBox1" runat="server" Width="30px" OnTextChanged="RandomMonthsInputTextBox1_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <%--<asp:Button ID="RandomMonthsInputTextBox1UpdateButton" runat="server" CssClass="wrap" OnClick="RandomMonthsInputTextBox1UpdateButton_Click" Text="Update" Width="55px" />--%>
                    </td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Months</td>
	                <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:UpdatePanel ID="UpdatePanelAddRandomMonthsInput1" runat="server">
        	                <ContentTemplate>                            
                                <asp:Label ID="AddRandomMonthsLabel1" runat="server" Text=""></asp:Label>                            
                            </ContentTemplate>
                            <Triggers>
                	            <asp:AsyncPostBackTrigger ControlID="RandomMonthsInputTextBox1" />
                            </Triggers>
	                    </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">4</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Months</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="AddFourMonthsLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">8</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Months</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="AddEightMonthsLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">12</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Months</td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:Label ID="AddTwelveMonthsLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="column-widthauto_text-center" style="background-color:turquoise; border:solid; border-width:thin; border-color:black">
                        <asp:TextBox ID="RandomMonthsInputTextBox2" runat="server" Width="30px" OnTextChanged="RandomMonthsInputTextBox2_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <%--<asp:Button ID="RandomMonthsInputTextBox2UpdateButton" runat="server" CssClass="wrap" OnClick="RandomMonthsInputTextBox2UpdateButton_Click" Text="Update" Width="55px" />--%>
                    </td>
                    <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">Months</td>
	                <td class="column-widthauto_text-center" style="border:solid; border-width:thin; border-color:black">
                        <asp:UpdatePanel ID="UpdatePanelAddRandomMonthsInput2" runat="server">
        	                <ContentTemplate>                            
                                <asp:Label ID="AddRandomMonthsLabel2" runat="server" Text=""></asp:Label>                            
                            </ContentTemplate>
                            <Triggers>
                	            <asp:AsyncPostBackTrigger ControlID="RandomMonthsInputTextBox2" />
                            </Triggers>
	                    </asp:UpdatePanel>
                    </td>
                </tr>
<%--                <tr>
                    <td class="column-widthauto_text-center" colspan="12">&nbsp;</td>                    
                </tr>--%>
            </table>           
        </asp:Panel>
    </form>
</body>
</html>
