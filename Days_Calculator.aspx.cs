using System;
using System.DirectoryServices.AccountManagement;

namespace HELPA
{
    public partial class Days_Calculator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Gets Current user and Displays the Name
            //DCUserLabel.Text = UserPrincipal.Current.GivenName + " " + UserPrincipal.Current.Surname;
            //DCUserLabel.Text = UserPrincipal.Current.DisplayName;

            //If calendar/business days is selected it sets the background color
            if (CalendarDaySelector.Checked == true)
            {
                //Sets background color of table to green
                DaysCountTable.BgColor = "#96C864";
            }
            else if (BusinessDaySelector.Checked == true)
            {
                //Sets background color of table to blue
                DaysCountTable.BgColor = "B0E0E6";
            }
        }

        protected void InstructionButton_Click(object sender, EventArgs e)
        {
            //when the button is clicked it will check to see if needs to make it visible or hide it
            if (InstructionPanel.Visible == true)
            {
                InstructionPanel.Visible = false;
            }
            else if (InstructionPanel.Visible == false)
            {
                InstructionPanel.Visible = true;
            }
        }    

        protected void DateTextbox_TextChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(DateTextbox.Text, out DateTime dateTime))
            {
                DateTime userEnteredDate = DateTime.Parse(DateTextbox.Text);

                DateTextbox.Text = userEnteredDate.ToString("MM/dd/yy");
                DateShortformat.Text = userEnteredDate.ToString("MM / dd / yy");
                DateLongformat.Text = userEnteredDate.ToString("MMMM dd, yyyy");
                Datedayofweek.Text = userEnteredDate.ToString("(dddd)");

                AddDaystoDate();
                AddWeekstoDate();
                AddMonthstoDate();
            }
            else
            {
                DateTextbox.Text = "";
                return;
            }
        }

        protected void FirstDayOfPreviousMonthButton_Click(object sender, EventArgs e)
        {
            //Gets the First day of the prior month
            DateTime firstDayLastMonth = DateTime.Now.AddDays(1 - DateTime.Now.Day).AddMonths(-1);

            //Sets the text for the different date string formats
            DateTextbox.Text = firstDayLastMonth.ToString("MM/dd/yy");
            DateShortformat.Text = firstDayLastMonth.ToString("MM / dd / yy");
            DateLongformat.Text = firstDayLastMonth.ToString("MMMM dd, yyyy");
            Datedayofweek.Text = firstDayLastMonth.ToString("(dddd)");

            AddDaystoDate();
            AddWeekstoDate();
            AddMonthstoDate();

        }

        protected void LastDayofPreviousMonthButton_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            DateTime lastDayLastMonth = new DateTime(today.Year, today.Month, 1);
            lastDayLastMonth = lastDayLastMonth.AddDays(-1);

            DateTextbox.Text = lastDayLastMonth.ToString("MM/dd/yy");
            DateShortformat.Text = lastDayLastMonth.ToString("MM / dd / yy");
            DateLongformat.Text = lastDayLastMonth.ToString("MMMM dd, yyyy");
            Datedayofweek.Text = lastDayLastMonth.ToString("(dddd)");

            AddDaystoDate();
            AddWeekstoDate();
            AddMonthstoDate();
        }

        protected void TodaysDateButton_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;

            DateTextbox.Text = today.AddDays(0).ToString("MM/dd/yy");
            DateShortformat.Text = today.AddDays(0).ToString("MM / dd / yy");
            DateLongformat.Text = today.AddDays(0).ToString("MMMM dd, yyyy");
            Datedayofweek.Text = today.AddDays(0).ToString("(dddd)");

            AddDaystoDate();
            AddWeekstoDate();
            AddMonthstoDate();
        }

        protected void FirstDayofNextMonthButton_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            var firstDayOfNextMonth = today.AddDays(-today.Day + 1).AddMonths(1);

            DateTextbox.Text = firstDayOfNextMonth.ToString("MM/dd/yy");
            DateShortformat.Text = firstDayOfNextMonth.ToString("MM / dd / yy");
            DateLongformat.Text = firstDayOfNextMonth.ToString("MMMM dd, yyyy");
            Datedayofweek.Text = firstDayOfNextMonth.ToString("(dddd)");

            AddDaystoDate();
            AddWeekstoDate();
            AddMonthstoDate();
        }

        protected void LastDayofNextMonth_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            //DateTime lastDayOfThisMonth = new DateTime(today.Year, today.Month, 1).AddMonths(1).AddDays(-1);            
            DateTime LastDayOfNextMonth = new DateTime(today.Year, today.Month +1, DateTime.DaysInMonth(today.Year, today.Month + 1));

            DateTextbox.Text = LastDayOfNextMonth.ToString("MM/dd/yy");
            DateShortformat.Text = LastDayOfNextMonth.ToString("MM / dd / yy");
            DateLongformat.Text = LastDayOfNextMonth.ToString("MMMM dd, yyyy");
            Datedayofweek.Text = LastDayOfNextMonth.ToString("(dddd)");

            AddDaystoDate();
            AddWeekstoDate();
            AddMonthstoDate();
        }

        protected void DateFormatDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddDaystoDate();
            AddWeekstoDate();
            AddMonthstoDate();
        }

        protected void DaySelector_CheckedChanged(object sender, EventArgs e)
        {
            AddDaystoDate();
            if (CalendarDaySelector.Checked == true)
            {
                //Sets background color to green
                DaysCountTable.BgColor = "#96C864";
            }
            else if (BusinessDaySelector.Checked == true)
            {
                //Sets background color to blue
                DaysCountTable.BgColor = "#B0E0E6";
            }
        }        

        protected void RandomDaysInputTextBox1_TextChanged(object sender, EventArgs e)
        {
            //checks if User input a value into the textbox
            if (String.IsNullOrEmpty(RandomDaysInputTextBox1.Text))
            {
                //if the textbox is blank it sets the label to blank
                addrandomDaysInput1DayLabel.Text = "";
            }
            else
            {
                //if the textbox is not blank it checks if the date textbox is empty
                if (DateTime.TryParse(DateTextbox.Text, out DateTime dateTime))
                {
                    //if the date textbox is not empty then it gets the date value
                    DateTime userEnteredDate = DateTime.Parse(DateTextbox.Text);
                    String DateSpecifiedFormat = "";

                    if (DateFormatDropDownList.SelectedItem.Value == "mediumdate")
                    {
                        DateSpecifiedFormat = "MM / dd / yy";
                    }
                    else if (DateFormatDropDownList.SelectedItem.Value == "shortdate")
                    {
                        DateSpecifiedFormat = "M / d / yy";
                    }
                    else if (DateFormatDropDownList.SelectedItem.Value == "longdate")
                    {
                        DateSpecifiedFormat = "MMM dd, yyyy";
                    }
                    else if (DateFormatDropDownList.SelectedItem.Value == "medlongdate")
                    {
                        DateSpecifiedFormat = "MM / dd / yyyy";
                    }
                    else if (DateFormatDropDownList.SelectedItem.Value == "longestdate")
                    {
                        DateSpecifiedFormat = "MMMM dd, yyyy";
                    }
                    else if (DateFormatDropDownList.SelectedItem.Value == "shortdatelongyear")
                    {
                        DateSpecifiedFormat = "M / d / yyyy";
                    }
                    else if (DateFormatDropDownList.SelectedItem.Value == "shortdaymonthyeardate")
                    {
                        DateSpecifiedFormat = "dd / MM / yy";
                    }
                    else if (DateFormatDropDownList.SelectedItem.Value == "meddaymonthyeardate")
                    {
                        DateSpecifiedFormat = "dd / MMM / yy";
                    }
                    else if (DateFormatDropDownList.SelectedItem.Value == "longdaymonthyeardate")
                    {
                        DateSpecifiedFormat = "dd / MMM / yyyy";
                    }
                    else if (DateFormatDropDownList.SelectedItem.Value == "longestdaymonthyeardate")
                    {
                        DateSpecifiedFormat = "dd / MMMM / yyyy";
                    }

                    //checks if the radio button for calendar days is selected
                    if (CalendarDaySelector.Checked == true)
                    {
                        //checks to make sure the user input a valid integer
                        bool isValidNumber = Int32.TryParse(RandomDaysInputTextBox1.Text, out int result);
                        if (isValidNumber)
                        {
                            //if it is valid then it sets the label to the date with the number of days added
                            addrandomDaysInput1DayLabel.Text = userEnteredDate.AddDays(result).ToString(DateSpecifiedFormat);
                        }
                        else if (!isValidNumber)
                        {
                            //if it is not valid then it sets everything to blank and returns
                            RandomDaysInputTextBox1.Text = "";
                            addrandomDaysInput1DayLabel.Text = "";
                            return;
                        }
                    }
                    //checks if the radio button for business days is selected
                    else if (BusinessDaySelector.Checked == true)
                    {
                        //checks to make sure the user input a valid integer
                        bool isValidNumber = Int32.TryParse(RandomDaysInputTextBox1.Text, out int result);
                        if (isValidNumber)
                        {
                            //if it is valid then it sets the label to the date with the number of days added
                            addrandomDaysInput1DayLabel.Text = userEnteredDate.AddBusinessDays(result).ToString(DateSpecifiedFormat);
                        }
                        else if (!isValidNumber)
                        {
                            //if it is not valid then it sets everything to blank and returns
                            RandomDaysInputTextBox1.Text = "";
                            addrandomDaysInput1DayLabel.Text = "";
                            return;
                        }
                    }
                }
                else
                {
                    //if the date textbox is null or blank it sets everything to empty
                    RandomDaysInputTextBox1.Text = "";
                    addrandomDaysInput1DayLabel.Text = "";
                    return;
                }
            }
        }

        protected void RandomDaysInputTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(RandomDaysInputTextBox2.Text))
            {
                addrandomDaysInput2DayLabel.Text = "";
            }
            else
            {
                //if the textbox is not blank it checks if the date textbox is empty
                if (DateTime.TryParse(DateTextbox.Text, out DateTime dateTime))
                {
                    //if the date textbox is not empty then it gets the date value
                    DateTime userEnteredDate = DateTime.Parse(DateTextbox.Text);
                    String DateSpecifiedFormat = "";

                    if (DateFormatDropDownList.SelectedItem.Value == "mediumdate")
                    {
                        DateSpecifiedFormat = "MM / dd / yy";
                    }
                    else if (DateFormatDropDownList.SelectedItem.Value == "shortdate")
                    {
                        DateSpecifiedFormat = "M / d / yy";
                    }
                    else if (DateFormatDropDownList.SelectedItem.Value == "longdate")
                    {
                        DateSpecifiedFormat = "MMM dd, yyyy";
                    }
                    else if (DateFormatDropDownList.SelectedItem.Value == "medlongdate")
                    {
                        DateSpecifiedFormat = "MM / dd / yyyy";
                    }
                    else if (DateFormatDropDownList.SelectedItem.Value == "longestdate")
                    {
                        DateSpecifiedFormat = "MMMM dd, yyyy";
                    }
                    else if (DateFormatDropDownList.SelectedItem.Value == "shortdatelongyear")
                    {
                        DateSpecifiedFormat = "M / d / yyyy";
                    }
                    else if (DateFormatDropDownList.SelectedItem.Value == "shortdaymonthyeardate")
                    {
                        DateSpecifiedFormat = "dd / MM / yy";
                    }
                    else if (DateFormatDropDownList.SelectedItem.Value == "meddaymonthyeardate")
                    {
                        DateSpecifiedFormat = "dd / MMM / yy";
                    }
                    else if (DateFormatDropDownList.SelectedItem.Value == "longdaymonthyeardate")
                    {
                        DateSpecifiedFormat = "dd / MMM / yyyy";
                    }
                    else if (DateFormatDropDownList.SelectedItem.Value == "longestdaymonthyeardate")
                    {
                        DateSpecifiedFormat = "dd / MMMM / yyyy";
                    }

                    if (CalendarDaySelector.Checked == true)
                    {
                        bool isValidNumber = Int32.TryParse(RandomDaysInputTextBox2.Text, out int result);
                        if (isValidNumber)
                        {
                            addrandomDaysInput2DayLabel.Text = userEnteredDate.AddDays(result).ToString(DateSpecifiedFormat);
                        }
                        else
                        {
                            RandomDaysInputTextBox2.Text = "";
                            addrandomDaysInput2DayLabel.Text = "";
                            return;
                        }
                    }
                    else if (BusinessDaySelector.Checked == true)
                    {
                        bool isValidNumber = Int32.TryParse(RandomDaysInputTextBox2.Text, out int result);
                        if (isValidNumber)
                        {
                            addrandomDaysInput2DayLabel.Text = userEnteredDate.AddBusinessDays(result).ToString(DateSpecifiedFormat);
                        }
                        else
                        {
                            RandomDaysInputTextBox2.Text = "";
                            addrandomDaysInput2DayLabel.Text = "";
                            return;
                        }
                    }
                }
                else
                {
                    //if the date textbox is null or blank it sets everything to empty
                    RandomDaysInputTextBox2.Text = "";
                    addrandomDaysInput2DayLabel.Text = "";
                    return;
                }
            }
        }

        protected void RandomDaysInputTextBox3_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(RandomDaysInputTextBox3.Text))
            {
                addrandomDaysInput3DayLabel.Text = "";
            }
            else
            {
                //if the textbox is not blank it checks if the date textbox is empty
                if (DateTime.TryParse(DateTextbox.Text, out DateTime dateTime))
                {
                    //if the date textbox is not empty then it gets the date value
                    DateTime userEnteredDate = DateTime.Parse(DateTextbox.Text);
                    String DateSpecifiedFormat = "";

                    if (DateFormatDropDownList.SelectedItem.Value == "mediumdate")
                    {
                        DateSpecifiedFormat = "MM / dd / yy";
                    }
                    else if (DateFormatDropDownList.SelectedItem.Value == "shortdate")
                    {
                        DateSpecifiedFormat = "M / d / yy";
                    }
                    else if (DateFormatDropDownList.SelectedItem.Value == "longdate")
                    {
                        DateSpecifiedFormat = "MMM dd, yyyy";
                    }
                    else if (DateFormatDropDownList.SelectedItem.Value == "medlongdate")
                    {
                        DateSpecifiedFormat = "MM / dd / yyyy";
                    }
                    else if (DateFormatDropDownList.SelectedItem.Value == "longestdate")
                    {
                        DateSpecifiedFormat = "MMMM dd, yyyy";
                    }
                    else if (DateFormatDropDownList.SelectedItem.Value == "shortdatelongyear")
                    {
                        DateSpecifiedFormat = "M / d / yyyy";
                    }
                    else if (DateFormatDropDownList.SelectedItem.Value == "shortdaymonthyeardate")
                    {
                        DateSpecifiedFormat = "dd / MM / yy";
                    }
                    else if (DateFormatDropDownList.SelectedItem.Value == "meddaymonthyeardate")
                    {
                        DateSpecifiedFormat = "dd / MMM / yy";
                    }
                    else if (DateFormatDropDownList.SelectedItem.Value == "longdaymonthyeardate")
                    {
                        DateSpecifiedFormat = "dd / MMM / yyyy";
                    }
                    else if (DateFormatDropDownList.SelectedItem.Value == "longestdaymonthyeardate")
                    {
                        DateSpecifiedFormat = "dd / MMMM / yyyy";
                    }

                    if (CalendarDaySelector.Checked == true)
                    {
                        bool isValidNumber = Int32.TryParse(RandomDaysInputTextBox3.Text, out int result);
                        if (isValidNumber)
                        {
                            addrandomDaysInput3DayLabel.Text = userEnteredDate.AddDays(result).ToString(DateSpecifiedFormat);
                        }
                        else
                        {
                            RandomDaysInputTextBox3.Text = "";
                            addrandomDaysInput3DayLabel.Text = "";
                            return;
                        }

                    }
                    else if (BusinessDaySelector.Checked == true)
                    {
                        bool isValidNumber = Int32.TryParse(RandomDaysInputTextBox3.Text, out int result);
                        if (isValidNumber)
                        {
                            addrandomDaysInput3DayLabel.Text = userEnteredDate.AddBusinessDays(result).ToString(DateSpecifiedFormat);
                        }
                        else
                        {
                            RandomDaysInputTextBox3.Text = "";
                            addrandomDaysInput3DayLabel.Text = "";
                            return;
                        }
                    }
                }
                else
                {
                    //if the date textbox is null or blank it sets everything to empty
                    RandomDaysInputTextBox3.Text = "";
                    addrandomDaysInput3DayLabel.Text = "";
                    return;
                }
            }
        }


        protected void RandomDaysInputTextBox4_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(RandomDaysInputTextBox4.Text))
            {
                addrandomDaysInput4DayLabel.Text = "";
            }
            else
            {
                //if the textbox is not blank it checks if the date textbox is empty
                if (DateTime.TryParse(DateTextbox.Text, out DateTime dateTime))
                {
                    //if the date textbox is not empty then it gets the date value
                    DateTime userEnteredDate = DateTime.Parse(DateTextbox.Text);
                    String DateSpecifiedFormat = "";

                    if (DateFormatDropDownList.SelectedItem.Value == "mediumdate")
                    {
                        DateSpecifiedFormat = "MM / dd / yy";
                    }
                    else if (DateFormatDropDownList.SelectedItem.Value == "shortdate")
                    {
                        DateSpecifiedFormat = "M / d / yy";
                    }
                    else if (DateFormatDropDownList.SelectedItem.Value == "longdate")
                    {
                        DateSpecifiedFormat = "MMM dd, yyyy";
                    }
                    else if (DateFormatDropDownList.SelectedItem.Value == "medlongdate")
                    {
                        DateSpecifiedFormat = "MM / dd / yyyy";
                    }
                    else if (DateFormatDropDownList.SelectedItem.Value == "longestdate")
                    {
                        DateSpecifiedFormat = "MMMM dd, yyyy";
                    }
                    else if (DateFormatDropDownList.SelectedItem.Value == "shortdatelongyear")
                    {
                        DateSpecifiedFormat = "M / d / yyyy";
                    }
                    else if (DateFormatDropDownList.SelectedItem.Value == "shortdaymonthyeardate")
                    {
                        DateSpecifiedFormat = "dd / MM / yy";
                    }
                    else if (DateFormatDropDownList.SelectedItem.Value == "meddaymonthyeardate")
                    {
                        DateSpecifiedFormat = "dd / MMM / yy";
                    }
                    else if (DateFormatDropDownList.SelectedItem.Value == "longdaymonthyeardate")
                    {
                        DateSpecifiedFormat = "dd / MMM / yyyy";
                    }
                    else if (DateFormatDropDownList.SelectedItem.Value == "longestdaymonthyeardate")
                    {
                        DateSpecifiedFormat = "dd / MMMM / yyyy";
                    }

                    if (CalendarDaySelector.Checked == true)
                    {
                        bool isValidNumber = Int32.TryParse(RandomDaysInputTextBox4.Text, out int result);
                        if (isValidNumber)
                        {
                            addrandomDaysInput4DayLabel.Text = userEnteredDate.AddDays(result).ToString(DateSpecifiedFormat);
                        }
                        else
                        {
                            RandomDaysInputTextBox4.Text = "";
                            addrandomDaysInput4DayLabel.Text = "";
                            return;
                        }
                    }
                    else if (BusinessDaySelector.Checked == true)
                    {
                        bool isValidNumber = Int32.TryParse(RandomDaysInputTextBox4.Text, out int result);
                        if (isValidNumber)
                        {
                            addrandomDaysInput4DayLabel.Text = userEnteredDate.AddBusinessDays(result).ToString(DateSpecifiedFormat);
                        }
                        else
                        {
                            RandomDaysInputTextBox4.Text = "";
                            addrandomDaysInput4DayLabel.Text = "";
                            return;
                        }
                    }
                }
                else
                {
                    //if the date textbox is null or blank it sets everything to empty
                    RandomDaysInputTextBox4.Text = "";
                    addrandomDaysInput4DayLabel.Text = "";
                    return;
                }
            }
        }

        protected void RandomWeeksInputTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(RandomWeeksInputTextBox1.Text))
            {        
                AddRandomWeeksLabel1.Text = "";
            }
            else
            {
                //if the textbox is not blank it checks if the date textbox is empty
                if (DateTime.TryParse(DateTextbox.Text, out DateTime dateTime))
                {
                    //if the date textbox is not empty then it gets the date value
                    DateTime userEnteredDate = DateTime.Parse(DateTextbox.Text);

                    bool isValidNumber = Int32.TryParse(RandomWeeksInputTextBox1.Text, out int result);
                    if (isValidNumber)
                    {
                        String DateSpecifiedFormat = "";

                        if (DateFormatDropDownList.SelectedItem.Value == "mediumdate")
                        {
                            DateSpecifiedFormat = "MM / dd / yy";
                        }
                        else if (DateFormatDropDownList.SelectedItem.Value == "shortdate")
                        {
                            DateSpecifiedFormat = "M / d / yy";
                        }
                        else if (DateFormatDropDownList.SelectedItem.Value == "longdate")
                        {
                            DateSpecifiedFormat = "MMM dd, yyyy";
                        }
                        else if (DateFormatDropDownList.SelectedItem.Value == "medlongdate")
                        {
                            DateSpecifiedFormat = "MM / dd / yyyy";
                        }
                        else if (DateFormatDropDownList.SelectedItem.Value == "longestdate")
                        {
                            DateSpecifiedFormat = "MMMM dd, yyyy";
                        }
                        else if (DateFormatDropDownList.SelectedItem.Value == "shortdatelongyear")
                        {
                            DateSpecifiedFormat = "M / d / yyyy";
                        }
                        else if (DateFormatDropDownList.SelectedItem.Value == "shortdaymonthyeardate")
                        {
                            DateSpecifiedFormat = "dd / MM / yy";
                        }
                        else if (DateFormatDropDownList.SelectedItem.Value == "meddaymonthyeardate")
                        {
                            DateSpecifiedFormat = "dd / MMM / yy";
                        }
                        else if (DateFormatDropDownList.SelectedItem.Value == "longdaymonthyeardate")
                        {
                            DateSpecifiedFormat = "dd / MMM / yyyy";
                        }
                        else if (DateFormatDropDownList.SelectedItem.Value == "longestdaymonthyeardate")
                        {
                            DateSpecifiedFormat = "dd / MMMM / yyyy";
                        }

                        AddRandomWeeksLabel1.Text = userEnteredDate.AddDays(result * 7).ToString(DateSpecifiedFormat);
                    }
                    else
                    {
                        RandomWeeksInputTextBox1.Text = "";
                        AddRandomWeeksLabel1.Text = "";
                        return;
                    }
                }
                else
                {
                    RandomWeeksInputTextBox1.Text = "";
                    AddRandomWeeksLabel1.Text = "";
                    return;
                }
            }
        }

        protected void RandomWeeksInputTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(RandomWeeksInputTextBox2.Text))
            {
                AddRandomWeeksLabel2.Text = "";
            }
            else
            {
                //if the textbox is not blank it checks if the date textbox is empty
                if (DateTime.TryParse(DateTextbox.Text, out DateTime dateTime))
                {
                    //if the date textbox is not empty then it gets the date value
                    DateTime userEnteredDate = DateTime.Parse(DateTextbox.Text);

                    bool isValidNumber = Int32.TryParse(RandomWeeksInputTextBox2.Text, out int result);
                    if (isValidNumber)
                    {
                        String DateSpecifiedFormat = "";

                        if (DateFormatDropDownList.SelectedItem.Value == "mediumdate")
                        {
                            DateSpecifiedFormat = "MM / dd / yy";
                        }
                        else if (DateFormatDropDownList.SelectedItem.Value == "shortdate")
                        {
                            DateSpecifiedFormat = "M / d / yy";
                        }
                        else if (DateFormatDropDownList.SelectedItem.Value == "longdate")
                        {
                            DateSpecifiedFormat = "MMM dd, yyyy";
                        }
                        else if (DateFormatDropDownList.SelectedItem.Value == "medlongdate")
                        {
                            DateSpecifiedFormat = "MM / dd / yyyy";
                        }
                        else if (DateFormatDropDownList.SelectedItem.Value == "longestdate")
                        {
                            DateSpecifiedFormat = "MMMM dd, yyyy";
                        }
                        else if (DateFormatDropDownList.SelectedItem.Value == "shortdatelongyear")
                        {
                            DateSpecifiedFormat = "M / d / yyyy";
                        }
                        else if (DateFormatDropDownList.SelectedItem.Value == "shortdaymonthyeardate")
                        {
                            DateSpecifiedFormat = "dd / MM / yy";
                        }
                        else if (DateFormatDropDownList.SelectedItem.Value == "meddaymonthyeardate")
                        {
                            DateSpecifiedFormat = "dd / MMM / yy";
                        }
                        else if (DateFormatDropDownList.SelectedItem.Value == "longdaymonthyeardate")
                        {
                            DateSpecifiedFormat = "dd / MMM / yyyy";
                        }
                        else if (DateFormatDropDownList.SelectedItem.Value == "longestdaymonthyeardate")
                        {
                            DateSpecifiedFormat = "dd / MMMM / yyyy";
                        }

                        AddRandomWeeksLabel2.Text = userEnteredDate.AddDays(result * 7).ToString(DateSpecifiedFormat);
                    }
                    else
                    {
                        RandomWeeksInputTextBox2.Text = "";
                        AddRandomWeeksLabel2.Text = "";
                        return;
                    }
                }
                else
                {
                    RandomWeeksInputTextBox2.Text = "";
                    AddRandomWeeksLabel2.Text = "";
                    return;
                }
            }
        }

        protected void RandomMonthsInputTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(RandomMonthsInputTextBox1.Text))
            {
                AddRandomMonthsLabel1.Text = "";
            }
            else
            {
                //if the textbox is not blank it checks if the date textbox is empty
                if (DateTime.TryParse(DateTextbox.Text, out DateTime dateTime))
                {
                    //if the date textbox is not empty then it gets the date value
                    DateTime userEnteredDate = DateTime.Parse(DateTextbox.Text);

                    bool isValidNumber = Int32.TryParse(RandomMonthsInputTextBox1.Text, out int result);
                    if (isValidNumber)
                    {
                        String DateSpecifiedFormat = "";

                        if (DateFormatDropDownList.SelectedItem.Value == "mediumdate")
                        {
                            DateSpecifiedFormat = "MM / dd / yy";
                        }
                        else if (DateFormatDropDownList.SelectedItem.Value == "shortdate")
                        {
                            DateSpecifiedFormat = "M / d / yy";
                        }
                        else if (DateFormatDropDownList.SelectedItem.Value == "longdate")
                        {
                            DateSpecifiedFormat = "MMM dd, yyyy";
                        }
                        else if (DateFormatDropDownList.SelectedItem.Value == "medlongdate")
                        {
                            DateSpecifiedFormat = "MM / dd / yyyy";
                        }
                        else if (DateFormatDropDownList.SelectedItem.Value == "longestdate")
                        {
                            DateSpecifiedFormat = "MMMM dd, yyyy";
                        }
                        else if (DateFormatDropDownList.SelectedItem.Value == "shortdatelongyear")
                        {
                            DateSpecifiedFormat = "M / d / yyyy";
                        }
                        else if (DateFormatDropDownList.SelectedItem.Value == "shortdaymonthyeardate")
                        {
                            DateSpecifiedFormat = "dd / MM / yy";
                        }
                        else if (DateFormatDropDownList.SelectedItem.Value == "meddaymonthyeardate")
                        {
                            DateSpecifiedFormat = "dd / MMM / yy";
                        }
                        else if (DateFormatDropDownList.SelectedItem.Value == "longdaymonthyeardate")
                        {
                            DateSpecifiedFormat = "dd / MMM / yyyy";
                        }
                        else if (DateFormatDropDownList.SelectedItem.Value == "longestdaymonthyeardate")
                        {
                            DateSpecifiedFormat = "dd / MMMM / yyyy";
                        }

                        AddRandomMonthsLabel1.Text = userEnteredDate.AddMonths(result).ToString(DateSpecifiedFormat);
                    }
                    else
                    {
                        RandomMonthsInputTextBox1.Text = "";
                        AddRandomMonthsLabel1.Text = "";
                        return;
                    }
                }
                else
                {
                    RandomMonthsInputTextBox1.Text = "";
                    AddRandomMonthsLabel1.Text = "";
                    return;
                }
            }
        }

        protected void RandomMonthsInputTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(RandomMonthsInputTextBox2.Text))
            {
                AddRandomMonthsLabel2.Text = "";
            }
            else
            {
                //if the textbox is not blank it checks if the date textbox is empty
                if (DateTime.TryParse(DateTextbox.Text, out DateTime dateTime))
                {
                    //if the date textbox is not empty then it gets the date value
                    DateTime userEnteredDate = DateTime.Parse(DateTextbox.Text);

                    bool isValidNumber = Int32.TryParse(RandomMonthsInputTextBox2.Text, out int result);
                    if (isValidNumber)
                    {
                        String DateSpecifiedFormat = "";

                        if (DateFormatDropDownList.SelectedItem.Value == "mediumdate")
                        {
                            DateSpecifiedFormat = "MM / dd / yy";
                        }
                        else if (DateFormatDropDownList.SelectedItem.Value == "shortdate")
                        {
                            DateSpecifiedFormat = "M / d / yy";
                        }
                        else if (DateFormatDropDownList.SelectedItem.Value == "longdate")
                        {
                            DateSpecifiedFormat = "MMM dd, yyyy";
                        }
                        else if (DateFormatDropDownList.SelectedItem.Value == "medlongdate")
                        {
                            DateSpecifiedFormat = "MM / dd / yyyy";
                        }
                        else if (DateFormatDropDownList.SelectedItem.Value == "longestdate")
                        {
                            DateSpecifiedFormat = "MMMM dd, yyyy";
                        }
                        else if (DateFormatDropDownList.SelectedItem.Value == "shortdatelongyear")
                        {
                            DateSpecifiedFormat = "M / d / yyyy";
                        }
                        else if (DateFormatDropDownList.SelectedItem.Value == "shortdaymonthyeardate")
                        {
                            DateSpecifiedFormat = "dd / MM / yy";
                        }
                        else if (DateFormatDropDownList.SelectedItem.Value == "meddaymonthyeardate")
                        {
                            DateSpecifiedFormat = "dd / MMM / yy";
                        }
                        else if (DateFormatDropDownList.SelectedItem.Value == "longdaymonthyeardate")
                        {
                            DateSpecifiedFormat = "dd / MMM / yyyy";
                        }
                        else if (DateFormatDropDownList.SelectedItem.Value == "longestdaymonthyeardate")
                        {
                            DateSpecifiedFormat = "dd / MMMM / yyyy";
                        }

                        AddRandomMonthsLabel2.Text = userEnteredDate.AddMonths(result).ToString(DateSpecifiedFormat);
                    }
                    else
                    {
                        RandomMonthsInputTextBox2.Text = "";
                        AddRandomMonthsLabel2.Text = "";
                        return;
                    }
                }
                else
                {
                    RandomMonthsInputTextBox2.Text = "";
                    AddRandomMonthsLabel2.Text = "";
                    return;
                }
            }
        }

        protected void AddDaystoDate()
        {
            if (DateTime.TryParse(DateTextbox.Text, out DateTime dateTime))
            {
                DateTime userEnteredDate = DateTime.Parse(DateTextbox.Text);
                String DateSpecifiedFormat = "";

                if (DateFormatDropDownList.SelectedItem.Value == "mediumdate")
                {
                    DateSpecifiedFormat = "MM / dd / yy";
                }
                else if (DateFormatDropDownList.SelectedItem.Value == "shortdate")
                {
                    DateSpecifiedFormat = "M / d / yy";
                }
                else if (DateFormatDropDownList.SelectedItem.Value == "longdate")
                {
                    DateSpecifiedFormat = "MMM dd, yyyy";
                }
                else if (DateFormatDropDownList.SelectedItem.Value == "medlongdate")
                {
                    DateSpecifiedFormat = "MM / dd / yyyy";
                }
                else if (DateFormatDropDownList.SelectedItem.Value == "longestdate")
                {
                    DateSpecifiedFormat = "MMMM dd, yyyy";
                }
                else if (DateFormatDropDownList.SelectedItem.Value == "shortdatelongyear")
                {
                    DateSpecifiedFormat = "M / d / yyyy";
                }
                else if (DateFormatDropDownList.SelectedItem.Value == "shortdaymonthyeardate")
                {
                    DateSpecifiedFormat = "dd / MM / yy";
                }
                else if (DateFormatDropDownList.SelectedItem.Value == "meddaymonthyeardate")
                {
                    DateSpecifiedFormat = "dd / MMM / yy";
                }
                else if (DateFormatDropDownList.SelectedItem.Value == "longdaymonthyeardate")
                {
                    DateSpecifiedFormat = "dd / MMM / yyyy";
                }
                else if (DateFormatDropDownList.SelectedItem.Value == "longestdaymonthyeardate")
                {
                    DateSpecifiedFormat = "dd / MMMM / yyyy";
                }

                if (CalendarDaySelector.Checked == true)
                {
                    addfiveDayLabel.Text = userEnteredDate.AddDays(5).ToString(DateSpecifiedFormat);
                    addsevenDayLabel.Text = userEnteredDate.AddDays(7).ToString(DateSpecifiedFormat);
                    addtenDayLabel.Text = userEnteredDate.AddDays(10).ToString(DateSpecifiedFormat);
                    addfifteenDayLabel.Text = userEnteredDate.AddDays(15).ToString(DateSpecifiedFormat);
                    addtwentyDayLabel.Text = userEnteredDate.AddDays(20).ToString(DateSpecifiedFormat);
                    addfortyfiveDayLabel.Text = userEnteredDate.AddDays(45).ToString(DateSpecifiedFormat);
                    addsixtyDayLabel.Text = userEnteredDate.AddDays(60).ToString(DateSpecifiedFormat);
                    addsixtyfiveDayLabel.Text = userEnteredDate.AddDays(65).ToString(DateSpecifiedFormat);
                    addseventyfiveDayLabel.Text = userEnteredDate.AddDays(75).ToString(DateSpecifiedFormat);
                    addninetyDayLabel.Text = userEnteredDate.AddDays(90).ToString(DateSpecifiedFormat);
                    addonehundredtwentyDayLabel.Text = userEnteredDate.AddDays(120).ToString(DateSpecifiedFormat);
                    addonehundredfiftyDayLabel.Text = userEnteredDate.AddDays(150).ToString(DateSpecifiedFormat);
                    addonehundredeightyDayLabel.Text = userEnteredDate.AddDays(180).ToString(DateSpecifiedFormat);
                    addtwohundredfortyDayLabel.Text = userEnteredDate.AddDays(240).ToString(DateSpecifiedFormat);
                    addthreehundredsixtyDayLabel.Text = userEnteredDate.AddDays(360).ToString(DateSpecifiedFormat);
                    addthreehundredsixtyfiveDayLabel.Text = userEnteredDate.AddDays(365).ToString(DateSpecifiedFormat);

                    if (String.IsNullOrEmpty(RandomDaysInputTextBox1.Text))
                    {
                        addrandomDaysInput1DayLabel.Text = "";
                    }
                    else
                    {
                        bool isValidNumber = Int32.TryParse(RandomDaysInputTextBox1.Text, out int result);
                        if (isValidNumber)
                        {
                            addrandomDaysInput1DayLabel.Text = userEnteredDate.AddDays(result).ToString(DateSpecifiedFormat);
                        }
                        else
                        {
                            RandomDaysInputTextBox1.Text = "";
                            addrandomDaysInput1DayLabel.Text = "";
                            return;
                        }                        
                    }

                    if (String.IsNullOrEmpty(RandomDaysInputTextBox2.Text))
                    {
                        addrandomDaysInput2DayLabel.Text = "";
                    }
                    else
                    {
                        bool isValidNumber = Int32.TryParse(RandomDaysInputTextBox2.Text, out int result);
                        if (isValidNumber)
                        {
                            addrandomDaysInput2DayLabel.Text = userEnteredDate.AddDays(result).ToString(DateSpecifiedFormat);
                        }
                        else
                        {
                            RandomDaysInputTextBox2.Text = "";
                            addrandomDaysInput2DayLabel.Text = "";
                            return;
                        }
                    }


                    if (String.IsNullOrEmpty(RandomDaysInputTextBox3.Text))
                    {
                        addrandomDaysInput3DayLabel.Text = "";
                    }
                    else
                    {
                        bool isValidNumber = Int32.TryParse(RandomDaysInputTextBox3.Text, out int result);
                        if (isValidNumber)
                        {
                            addrandomDaysInput3DayLabel.Text = userEnteredDate.AddDays(result).ToString(DateSpecifiedFormat);
                        }
                        else
                        {
                            RandomDaysInputTextBox3.Text = "";
                            addrandomDaysInput3DayLabel.Text = "";
                            return;
                        }
                    }

                    if (String.IsNullOrEmpty(RandomDaysInputTextBox4.Text))
                    {
                        addrandomDaysInput4DayLabel.Text = "";
                    }
                    else
                    {
                        bool isValidNumber = Int32.TryParse(RandomDaysInputTextBox4.Text, out int result);
                        if (isValidNumber)
                        {
                            addrandomDaysInput4DayLabel.Text = userEnteredDate.AddDays(result).ToString(DateSpecifiedFormat);
                        }
                        else
                        {
                            RandomDaysInputTextBox4.Text = "";
                            addrandomDaysInput4DayLabel.Text = "";
                            return;
                        }
                    }
                }
                else if (BusinessDaySelector.Checked == true)
                {
                    addfiveDayLabel.Text = userEnteredDate.AddBusinessDays(5).ToString(DateSpecifiedFormat);
                    addsevenDayLabel.Text = userEnteredDate.AddBusinessDays(7).ToString(DateSpecifiedFormat);
                    addtenDayLabel.Text = userEnteredDate.AddBusinessDays(10).ToString(DateSpecifiedFormat);
                    addfifteenDayLabel.Text = userEnteredDate.AddBusinessDays(15).ToString(DateSpecifiedFormat);
                    addtwentyDayLabel.Text = userEnteredDate.AddBusinessDays(20).ToString(DateSpecifiedFormat);
                    addfortyfiveDayLabel.Text = userEnteredDate.AddBusinessDays(45).ToString(DateSpecifiedFormat);
                    addsixtyDayLabel.Text = userEnteredDate.AddBusinessDays(60).ToString(DateSpecifiedFormat);
                    addsixtyfiveDayLabel.Text = userEnteredDate.AddBusinessDays(65).ToString(DateSpecifiedFormat);
                    addseventyfiveDayLabel.Text = userEnteredDate.AddBusinessDays(75).ToString(DateSpecifiedFormat);
                    addninetyDayLabel.Text = userEnteredDate.AddBusinessDays(90).ToString(DateSpecifiedFormat);
                    addonehundredtwentyDayLabel.Text = userEnteredDate.AddBusinessDays(120).ToString(DateSpecifiedFormat);
                    addonehundredfiftyDayLabel.Text = userEnteredDate.AddBusinessDays(150).ToString(DateSpecifiedFormat);
                    addonehundredeightyDayLabel.Text = userEnteredDate.AddBusinessDays(180).ToString(DateSpecifiedFormat);
                    addtwohundredfortyDayLabel.Text = userEnteredDate.AddBusinessDays(240).ToString(DateSpecifiedFormat);
                    addthreehundredsixtyDayLabel.Text = userEnteredDate.AddBusinessDays(360).ToString(DateSpecifiedFormat);
                    addthreehundredsixtyfiveDayLabel.Text = userEnteredDate.AddBusinessDays(365).ToString(DateSpecifiedFormat);

                    if (String.IsNullOrEmpty(RandomDaysInputTextBox1.Text))
                    {
                        addrandomDaysInput1DayLabel.Text = "";
                    }
                    else
                    {
                        bool isValidNumber = Int32.TryParse(RandomDaysInputTextBox1.Text, out int result);
                        if (isValidNumber)
                        {
                            addrandomDaysInput1DayLabel.Text = userEnteredDate.AddBusinessDays(result).ToString(DateSpecifiedFormat);
                        }
                        else
                        {
                            RandomDaysInputTextBox1.Text = "";
                            addrandomDaysInput1DayLabel.Text = "";
                            return;
                        }                        
                    }

                    if (String.IsNullOrEmpty(RandomDaysInputTextBox2.Text))
                    {
                        addrandomDaysInput2DayLabel.Text = "";
                    }
                    else
                    {
                        bool isValidNumber = Int32.TryParse(RandomDaysInputTextBox2.Text, out int result);
                        if (isValidNumber)
                        {
                            addrandomDaysInput2DayLabel.Text = userEnteredDate.AddBusinessDays(result).ToString(DateSpecifiedFormat);
                        }
                        else
                        {
                            RandomDaysInputTextBox2.Text = "";
                            addrandomDaysInput2DayLabel.Text = "";
                            return;
                        }
                    }


                    if (String.IsNullOrEmpty(RandomDaysInputTextBox3.Text))
                    {
                        addrandomDaysInput3DayLabel.Text = "";
                    }
                    else
                    {
                        bool isValidNumber = Int32.TryParse(RandomDaysInputTextBox3.Text, out int result);
                        if (isValidNumber)
                        {
                            addrandomDaysInput3DayLabel.Text = userEnteredDate.AddBusinessDays(result).ToString(DateSpecifiedFormat);
                        }
                        else
                        {
                            RandomDaysInputTextBox3.Text = "";
                            addrandomDaysInput3DayLabel.Text = "";
                            return;
                        }
                    }

                    if (String.IsNullOrEmpty(RandomDaysInputTextBox4.Text))
                    {
                        addrandomDaysInput4DayLabel.Text = "";
                    }
                    else
                    {
                        bool isValidNumber = Int32.TryParse(RandomDaysInputTextBox4.Text, out int result);
                        if (isValidNumber)
                        {
                            addrandomDaysInput4DayLabel.Text = userEnteredDate.AddBusinessDays(result).ToString(DateSpecifiedFormat);
                        }
                        else
                        {
                            RandomDaysInputTextBox4.Text = "";
                            addrandomDaysInput4DayLabel.Text = "";
                            return;
                        }
                    }
                }
            }
            else
            {
                DateTextbox.Text = "";
                return;
            }
        }

        protected void AddWeekstoDate()
        {
            if (DateTime.TryParse(DateTextbox.Text, out DateTime dateTime))
            {
                DateTime userEnteredDate = DateTime.Parse(DateTextbox.Text);
                String DateSpecifiedFormat = "";

                if (DateFormatDropDownList.SelectedItem.Value == "mediumdate")
                {
                    DateSpecifiedFormat = "MM / dd / yy";
                }
                else if (DateFormatDropDownList.SelectedItem.Value == "shortdate")
                {
                    DateSpecifiedFormat = "M / d / yy";
                }
                else if (DateFormatDropDownList.SelectedItem.Value == "longdate")
                {
                    DateSpecifiedFormat = "MMM dd, yyyy";
                }
                else if (DateFormatDropDownList.SelectedItem.Value == "medlongdate")
                {
                    DateSpecifiedFormat = "MM / dd / yyyy";
                }
                else if (DateFormatDropDownList.SelectedItem.Value == "longestdate")
                {
                    DateSpecifiedFormat = "MMMM dd, yyyy";
                }
                else if (DateFormatDropDownList.SelectedItem.Value == "shortdatelongyear")
                {
                    DateSpecifiedFormat = "M / d / yyyy";
                }
                else if (DateFormatDropDownList.SelectedItem.Value == "shortdaymonthyeardate")
                {
                    DateSpecifiedFormat = "dd / MM / yy";
                }
                else if (DateFormatDropDownList.SelectedItem.Value == "meddaymonthyeardate")
                {
                    DateSpecifiedFormat = "dd / MMM / yy";
                }
                else if (DateFormatDropDownList.SelectedItem.Value == "longdaymonthyeardate")
                {
                    DateSpecifiedFormat = "dd / MMM / yyyy";
                }
                else if (DateFormatDropDownList.SelectedItem.Value == "longestdaymonthyeardate")
                {
                    DateSpecifiedFormat = "dd / MMMM / yyyy";
                }

                AddOneWeekLabel.Text = userEnteredDate.AddDays(1 * 7).ToString(DateSpecifiedFormat);
                AddTwoWeeksLabel.Text = userEnteredDate.AddDays(2 * 7).ToString(DateSpecifiedFormat);
                AddThreeWeeksLabel.Text = userEnteredDate.AddDays(3 * 7).ToString(DateSpecifiedFormat);
                AddFourWeeksLabel.Text = userEnteredDate.AddDays(4 * 7).ToString(DateSpecifiedFormat);
                AddFiveWeeksLabel.Text = userEnteredDate.AddDays(5 * 7).ToString(DateSpecifiedFormat);
                AddSixWeeksLabel.Text = userEnteredDate.AddDays(6 * 7).ToString(DateSpecifiedFormat);
                AddSevenWeeksLabel.Text = userEnteredDate.AddDays(7 * 7).ToString(DateSpecifiedFormat);
                AddEightWeeksLabel.Text = userEnteredDate.AddDays(8 * 7).ToString(DateSpecifiedFormat);
                AddNineWeeksLabel.Text = userEnteredDate.AddDays(9 * 7).ToString(DateSpecifiedFormat);
                AddTenWeeksLabel.Text = userEnteredDate.AddDays(10 * 7).ToString(DateSpecifiedFormat);
                AddElevenWeeksLabel.Text = userEnteredDate.AddDays(11 * 7).ToString(DateSpecifiedFormat);
                AddTwelveWeeksLabel.Text = userEnteredDate.AddDays(12 * 7).ToString(DateSpecifiedFormat);
                AddThirteenWeeksLabel.Text = userEnteredDate.AddDays(13 * 7).ToString(DateSpecifiedFormat);
                AddFourteenWeeksLabel.Text = userEnteredDate.AddDays(14 * 7).ToString(DateSpecifiedFormat);
                AddFifteenWeeksLabel.Text = userEnteredDate.AddDays(15 * 7).ToString(DateSpecifiedFormat);
                AddSixteenWeeksLabel.Text = userEnteredDate.AddDays(16 * 7).ToString(DateSpecifiedFormat);
                AddSeventeenWeeksLabel.Text = userEnteredDate.AddDays(17 * 7).ToString(DateSpecifiedFormat);
                AddEighteenWeeksLabel.Text = userEnteredDate.AddDays(18 * 7).ToString(DateSpecifiedFormat);
                AddNineteenWeeksLabel.Text = userEnteredDate.AddDays(19 * 7).ToString(DateSpecifiedFormat);
                AddTwentyWeeksLabel.Text = userEnteredDate.AddDays(20 * 7).ToString(DateSpecifiedFormat);
                AddTwentyfiveWeeksLabel.Text = userEnteredDate.AddDays(25 * 7).ToString(DateSpecifiedFormat);
                AddThirtyWeeksLabel.Text = userEnteredDate.AddDays(30 * 7).ToString(DateSpecifiedFormat);
                AddThirtyfiveWeeksLabel.Text = userEnteredDate.AddDays(35 * 7).ToString(DateSpecifiedFormat);
                AddFortyWeeksLabel.Text = userEnteredDate.AddDays(40 * 7).ToString(DateSpecifiedFormat);
                AddFortyfiveWeeksLabel.Text = userEnteredDate.AddDays(45 * 7).ToString(DateSpecifiedFormat);
                AddFiftyWeeksLabel.Text = userEnteredDate.AddDays(50 * 7).ToString(DateSpecifiedFormat);

                if (String.IsNullOrEmpty(RandomWeeksInputTextBox1.Text))
                {
                    AddRandomWeeksLabel1.Text = "";
                }
                else
                {
                    bool isValidNumber = Int32.TryParse(RandomWeeksInputTextBox1.Text, out int result);
                    if (isValidNumber)
                    {
                        AddRandomWeeksLabel1.Text = userEnteredDate.AddDays(result * 7).ToString(DateSpecifiedFormat);
                    }
                    else
                    {
                        RandomWeeksInputTextBox1.Text = "";
                        AddRandomWeeksLabel1.Text = "";
                        return;
                    }                    
                }

                if (String.IsNullOrEmpty(RandomWeeksInputTextBox2.Text))
                {
                    AddRandomWeeksLabel2.Text = "";
                }
                else
                {
                    bool isValidNumber = Int32.TryParse(RandomWeeksInputTextBox2.Text, out int result);
                    if (isValidNumber)
                    {
                        AddRandomWeeksLabel2.Text = userEnteredDate.AddDays(result * 7).ToString(DateSpecifiedFormat);
                    }
                    else
                    {
                        RandomWeeksInputTextBox2.Text = "";
                        AddRandomWeeksLabel2.Text = "";
                        return;
                    }
                }
            }
            else
            {
                DateTextbox.Text = "";
                return;
            }
        }

        protected void AddMonthstoDate()
        {
            if (DateTime.TryParse(DateTextbox.Text, out DateTime dateTime))
            {
                DateTime userEnteredDate = DateTime.Parse(DateTextbox.Text);
                String DateSpecifiedFormat = "";

                if (DateFormatDropDownList.SelectedItem.Value == "mediumdate")
                {
                    DateSpecifiedFormat = "MM / dd / yy";
                }
                else if (DateFormatDropDownList.SelectedItem.Value == "shortdate")
                {
                    DateSpecifiedFormat = "M / d / yy";
                }
                else if (DateFormatDropDownList.SelectedItem.Value == "longdate")
                {
                    DateSpecifiedFormat = "MMM dd, yyyy";
                }
                else if (DateFormatDropDownList.SelectedItem.Value == "medlongdate")
                {
                    DateSpecifiedFormat = "MM / dd / yyyy";
                }
                else if (DateFormatDropDownList.SelectedItem.Value == "longestdate")
                {
                    DateSpecifiedFormat = "MMMM dd, yyyy";
                }
                else if (DateFormatDropDownList.SelectedItem.Value == "shortdatelongyear")
                {
                    DateSpecifiedFormat = "M / d / yyyy";
                }
                else if (DateFormatDropDownList.SelectedItem.Value == "shortdaymonthyeardate")
                {
                    DateSpecifiedFormat = "dd / MM / yy";
                }
                else if (DateFormatDropDownList.SelectedItem.Value == "meddaymonthyeardate")
                {
                    DateSpecifiedFormat = "dd / MMM / yy";
                }
                else if (DateFormatDropDownList.SelectedItem.Value == "longdaymonthyeardate")
                {
                    DateSpecifiedFormat = "dd / MMM / yyyy";
                }
                else if (DateFormatDropDownList.SelectedItem.Value == "longestdaymonthyeardate")
                {
                    DateSpecifiedFormat = "dd / MMMM / yyyy";
                }

                AddOneMonthLabel.Text = userEnteredDate.AddMonths(1).ToString(DateSpecifiedFormat);
                AddTwoMonthsLabel.Text = userEnteredDate.AddMonths(2).ToString(DateSpecifiedFormat);
                AddThreeMonthsLabel.Text = userEnteredDate.AddMonths(3).ToString(DateSpecifiedFormat);
                AddFourMonthsLabel.Text = userEnteredDate.AddMonths(4).ToString(DateSpecifiedFormat);
                AddFiveMonthsLabel.Text = userEnteredDate.AddMonths(5).ToString(DateSpecifiedFormat);
                AddSixMonthsLabel.Text = userEnteredDate.AddMonths(6).ToString(DateSpecifiedFormat);
                AddSevenMonthsLabel.Text = userEnteredDate.AddMonths(7).ToString(DateSpecifiedFormat);
                AddEightMonthsLabel.Text = userEnteredDate.AddMonths(8).ToString(DateSpecifiedFormat);
                AddNineMonthsLabel.Text = userEnteredDate.AddMonths(9).ToString(DateSpecifiedFormat);
                AddTenMonthsLabel.Text = userEnteredDate.AddMonths(10).ToString(DateSpecifiedFormat);
                AddElevenMonthsLabel.Text = userEnteredDate.AddMonths(11).ToString(DateSpecifiedFormat);
                AddTwelveMonthsLabel.Text = userEnteredDate.AddMonths(12).ToString(DateSpecifiedFormat);
                AddEighteenMonthsLabel.Text = userEnteredDate.AddMonths(18).ToString(DateSpecifiedFormat);
                AddTwentyfourMonthsLabel.Text = userEnteredDate.AddMonths(24).ToString(DateSpecifiedFormat);

                if (String.IsNullOrEmpty(RandomMonthsInputTextBox1.Text))
                {
                    AddRandomMonthsLabel1.Text = "";
                }
                else
                {
                    bool isValidNumber = Int32.TryParse(RandomMonthsInputTextBox1.Text, out int result);
                    if (isValidNumber)
                    {
                        AddRandomMonthsLabel1.Text = userEnteredDate.AddMonths(result).ToString(DateSpecifiedFormat);
                    }
                    else
                    {
                        RandomMonthsInputTextBox1.Text = "";
                        AddRandomMonthsLabel1.Text = "";
                        return;
                    }
                }

                if (String.IsNullOrEmpty(RandomMonthsInputTextBox2.Text))
                {
                    AddRandomMonthsLabel2.Text = "";
                }
                else
                {
                    bool isValidNumber = Int32.TryParse(RandomMonthsInputTextBox2.Text, out int result);
                    if (isValidNumber)
                    {
                        AddRandomMonthsLabel2.Text = userEnteredDate.AddMonths(result).ToString(DateSpecifiedFormat);
                    }
                    else
                    {
                        RandomMonthsInputTextBox2.Text = "";
                        AddRandomMonthsLabel2.Text = "";
                        return;
                    }
                }
            }
            else
            {
                DateTextbox.Text = "";
                return;
            }
        }
    }

    public static class BusinessDays
    {
        public static System.DateTime AddBusinessDays(this System.DateTime source, int businessDays)
        {
            var dayOfWeek = businessDays < 0
                                ? ((int)source.DayOfWeek - 12) % 7
                                : ((int)source.DayOfWeek + 6) % 7;

            switch (dayOfWeek)
            {
                case 6:
                    businessDays--;
                    break;
                case -6:
                    businessDays++;
                    break;
            }

            return source.AddDays(businessDays + ((businessDays + dayOfWeek) / 5) * 2);
        }
    }    
}