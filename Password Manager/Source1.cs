using System.Security.Cryptography;

namespace Password_Manager
{
    public partial class MainForm : Form
    {
        private const string PWCHARS = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private const string PWCHARSSPECIAL = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz !\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";
        private string userPath;
        private string mode;
        private bool appEntered;
        private bool found;
        private int pwLength;
        private string generated;
        private int tempIndex;
        private char[] tempCharArray;
        private string? temp;
        private bool appExists;
        private string toEdit;
        private List<string> stored;

        public MainForm(string user)
        {
            InitializeComponent();

            userPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Pwm\\" + user + ".txt";
            mode = "N";
            appEntered = false;
            found = false;
            pwLength = 20;
            generated = "";
            tempIndex = 0;
            tempCharArray = new char[127];
            temp = "";
            appExists = false;
            toEdit = "";
            stored = new List<string>();

            NewRB.Checked = true;
            SearchRB.Checked = false;
            EditRB.Checked = false;
            GenRB.Checked = false;
            PwmBtn2.Text = "";
            PwmBtn2.Visible = false;
            PwmLbl.Text = "Enter application or site name";
            PwmBtn.Text = "Confirm";

            LengthTB.Text = "20";
            LengthTB.Visible = false;
            LengthLbl.Visible = false;
            SpecialCB.Checked = true;
            SpecialCB.Visible = false;
        }

        private void PwmBtn_Click(object sender, EventArgs e)
        {
            switch (mode)
            {
                case "N":
                    //Switch between app entry and password entry
                    if (appEntered)
                    {
                        //Enter password into user file
                        if (!String.IsNullOrEmpty(PwmTB.Text))
                        {
                            PwmLbl.Text = "Enter application or site name";
                            appEntered = false;
                            StreamWriter pwEntry = File.AppendText(userPath);
                            pwEntry.WriteLine(PwmTB.Text);
                            pwEntry.Close();
                            
                            SearchRB.Enabled = true;
                            EditRB.Enabled = true;
                            GenRB.Enabled = true;
                        }
                    }
                    else
                    {
                        //Enter app or site into user file and lock other controls so user has to enter password associated next
                        if (!String.IsNullOrEmpty(PwmTB.Text))
                        {
                            appExists = false;
                            StreamReader appCheck = new StreamReader(userPath);
                            while ((temp = appCheck.ReadLine()) != null)
                            {
                                if (temp == PwmTB.Text)
                                {
                                    MessageBox.Show("Application or site entered already exists", "Error", MessageBoxButtons.OK);
                                    appExists = true;
                                    break;
                                }
                            }
                            appCheck.Close();
                            if (!appExists)
                            {
                                PwmLbl.Text = "Enter password";
                                appEntered = true;
                                StreamWriter appEntry = File.AppendText(userPath);
                                appEntry.WriteLine(PwmTB.Text);
                                appEntry.Close();
                                
                                SearchRB.Enabled = false;
                                EditRB.Enabled = false;
                                GenRB.Enabled = false;
                            }
                        }
                    }
                    PwmTB.Text = "";
                    break;
                case "E":
                    //Switch between app entry and new password entry
                    if (appEntered)
                    {
                        //Overwrite user file with edited password
                        if (!String.IsNullOrEmpty(PwmTB.Text))
                        {
                            PwmLbl.Text = "Enter application or site name";
                            appEntered = false;

                            stored.Clear();
                            StreamReader lineReader = new StreamReader(userPath);
                            while ((temp = lineReader.ReadLine()) != null)
                            {
                                if (temp == toEdit)
                                {
                                    stored.Add(temp);
                                    stored.Add(PwmTB.Text);
                                    lineReader.ReadLine();
                                }
                                else
                                {
                                    stored.Add(temp);
                                }
                            }
                            lineReader.Close();
                            File.WriteAllLines(userPath, stored);
                            toEdit = "";

                            NewRB.Enabled = true;
                            SearchRB.Enabled = true;
                            GenRB.Enabled = true;
                        }
                    }
                    else
                    {
                        //Enter app or site into user file and lock other controls so user has to enter password associated next
                        if (!String.IsNullOrEmpty(PwmTB.Text))
                        {
                            appExists = false;
                            StreamReader appCheck = new StreamReader(userPath);
                            while ((temp = appCheck.ReadLine()) != null)
                            {
                                if (temp == PwmTB.Text)
                                {
                                    appExists = true;
                                    break;
                                }
                            }
                            appCheck.Close();
                            if (appExists)
                            {
                                PwmLbl.Text = "Enter new password";
                                appEntered = true;
                                toEdit = PwmTB.Text;
                                
                                NewRB.Enabled = false;
                                SearchRB.Enabled = false;
                                GenRB.Enabled = false;
                            } else
                            {
                                MessageBox.Show("Application or site not already entered", "Error", MessageBoxButtons.OK);
                            }
                        }
                    }
                    PwmTB.Text = "";
                    break;
                case "S":
                    //Search through user text file for app name entered and set PwmTB to the password associated
                    StreamReader searcher = new StreamReader(userPath);
                    found = false;
                    while ((temp = searcher.ReadLine()) != null)
                    {
                        if (temp == PwmTB.Text)
                        {
                            found = true;
                            PwmTB.Text = searcher.ReadLine();
                        }
                    }
                    searcher.Close();
                    if (!found)
                    {
                        PwmTB.Text = "";
                        MessageBox.Show("Password not found.", "Error", MessageBoxButtons.OK);
                    }
                    break;
                case "G":
                    //Generate new random password
                    //Password will always have at least 1 capital letter, 1 number, and if special chars is checked, at least 1 special char
                    LengthTB.Text = pwLength.ToString();
                    tempIndex = RandomNumberGenerator.GetInt32(1, pwLength - 1);
                    if (SpecialCB.Checked)
                    {
                        for (int i = 0; i < pwLength; i++)
                        {
                            generated += PWCHARSSPECIAL[RandomNumberGenerator.GetInt32(PWCHARSSPECIAL.Length)];
                        }
                        tempCharArray = generated.ToCharArray();
                        tempCharArray[tempIndex - 1] = PWCHARSSPECIAL[RandomNumberGenerator.GetInt32(PWCHARS.Length + 1, PWCHARSSPECIAL.Length)];
                    }
                    else
                    {
                        for (int i = 0; i < pwLength; i++)
                        {
                            generated += PWCHARS[RandomNumberGenerator.GetInt32(PWCHARS.Length)];
                        }
                        tempCharArray = generated.ToCharArray();
                    }
                    tempCharArray[tempIndex + 1] = PWCHARS[RandomNumberGenerator.GetInt32(0, 9)];
                    tempCharArray[tempIndex] = PWCHARS[RandomNumberGenerator.GetInt32(10, 36)];
                    generated = new String(tempCharArray);
                    
                    PwmTB.Text = generated;
                    generated = "";
                    break;
                case "A":
                    if (MessageBox.Show("Are you sure you want to delete all passwords associated with this user? This can not be undone.",
                        "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //Overwrite user file, deleting all contents
                        File.Create(userPath).Close();
                    }
                    break;
            }
        }

        private void PwmBtn2_Click(object sender, EventArgs e)
        {
            switch (mode)
            {
                case "S":
                case "G":
                    //Copy to clipboard
                    if (!String.IsNullOrEmpty(PwmTB.Text))
                    {
                        Clipboard.SetText(PwmTB.Text);
                    }
                    break;
                case "E":
                    if (MessageBox.Show("Are you sure you want to delete the password associated with the application or site entered?", 
                        "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //Overwrite user file without app name entered and password associated
                        stored.Clear();
                        StreamReader lineReader = new StreamReader(userPath);
                        while ((temp = lineReader.ReadLine()) != null)
                        {
                            if (temp == PwmTB.Text)
                            {
                                lineReader.ReadLine();
                            } else
                            {
                                stored.Add(temp);
                            }
                        }
                        lineReader.Close();
                        File.WriteAllLines(userPath, stored);
                    }
                    PwmTB.Text = "";
                    break;
            }
        }

        private void NewRB_CheckedChanged(object sender, EventArgs e)
        {
            mode = "N";
            PwmLbl.Text = "Enter application or site name";
            PwmBtn.Text = "Confirm";
            PwmTB.Text = "";
            appEntered = false;
            PwmBtn2.Visible = false;
            LengthLbl.Visible = false;
            LengthTB.Visible = false;
            SpecialCB.Visible = false;
        }

        private void SearchRB_CheckedChanged(object sender, EventArgs e)
        {
            mode = "S";
            PwmLbl.Text = "Enter application or site name";
            PwmBtn.Text = "Get Password";
            PwmBtn2.Text = "Copy to clipboard";
            PwmTB.Text = "";
            PwmBtn2.Visible = true;
            LengthLbl.Visible = false;
            LengthTB.Visible = false;
            SpecialCB.Visible = false;
        }

        private void EditRB_CheckedChanged(object sender, EventArgs e)
        {
            mode = "E";
            PwmLbl.Text = "Enter application or site name";
            PwmBtn.Text = "Confirm";
            PwmBtn2.Text = "Delete";
            PwmTB.Text = "";
            PwmBtn2.Visible = true;
            appEntered = false;
            LengthLbl.Visible = false;
            LengthTB.Visible = false;
            SpecialCB.Visible = false;
        }

        private void GenRB_CheckedChanged(object sender, EventArgs e)
        {
            mode = "G";
            PwmLbl.Text = "New random password";
            PwmBtn.Text = "Generate";
            PwmBtn2.Text = "Copy to clipboard";
            PwmTB.Text = "";
            PwmBtn2.Visible = true;
            LengthLbl.Visible = true;
            LengthTB.Visible = true;
            SpecialCB.Visible = true;
        }

        private void AccountRB_CheckedChanged(object sender, EventArgs e)
        {
            mode = "A";
            PwmLbl.Text = "User Account Settings";
            PwmBtn.Text = "Erase all user data";
            PwmTB.Text = "";
            PwmBtn2.Visible = false;
            LengthLbl.Visible = false;
            LengthTB.Visible = false;
            SpecialCB.Visible = false;
        }

        private void LengthTB_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(LengthTB.Text, out pwLength))
            {
                if (pwLength > 127)
                {
                    pwLength = 127;
                }
                if (pwLength < 8)
                {
                    pwLength = 8;
                }
            }
            else
            {
                LengthTB.Text = "";
            }
        }
    }
}