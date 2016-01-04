using System;
using System.Data.Odbc;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace WinFormsFBWintask
{
    public partial class FBWintask : Form
    {
        public FBWintask()
        {
            InitializeComponent();
        }

        private OdbcConnection _db = new OdbcConnection(_connectionString);

        private static string _connectionString =
            "DRIVER={MySQL ODBC 3.51 Driver};SERVER=x.x.x.x;UID=x;PWD=x;DATABASE=x;";

        private bool _connected;
        private bool _startStatus;
        private bool _checkStartingRecords = true; //to get the starting records only once at connect 

        private int _startingCount;
        private int _remainingCount;
        private int _resolvedCount;
        private int _oldResolvedCount;
        private int _newResolvedCount;
        private int _check_ban;
        private int _check_email;

        private int _totalTimeSeconds;
        private int _totalTimeMinutes;
        private int _totalTimeHours;

        Process proc = new Process();

        //Timer1 Tick
        private void timer1_Tick(object sender, EventArgs e)
        {
            LblTotalTime.Text = "Total Time: " + _totalTimeHours + " : " + _totalTimeMinutes + " : " + _totalTimeSeconds;

            //reset seconds
            if (_totalTimeSeconds >= 59)
            {
                _totalTimeSeconds = -1;
                _totalTimeMinutes = _totalTimeMinutes + 1;
            }
            //reset minutes
            if (_totalTimeMinutes >= 59)
            {
                _totalTimeMinutes = 0;
                _totalTimeHours = _totalTimeHours + 1;
            }

            _totalTimeSeconds = _totalTimeSeconds + 1;
        }
        //Timer2 Tick
        private void timer2_Tick(object sender, EventArgs e)
        {
            //check all stuff every 10 seconds
            CheckRemainingRecords();
            CheckProcess();

            //Get _newResolvedCount 
            _newResolvedCount = _resolvedCount;
        }
        //Timer3 Tick every 2 minutes kill Task and restart it
        private void timer3_Tick(object sender, EventArgs e)
        {
            CheckBan(); //check database for new values

            if (_oldResolvedCount == _newResolvedCount)
            {
                //kill Task
                try
                {
                    foreach (Process proc in Process.GetProcessesByName("TaskExec"))
                    {
                        proc.Kill();
                        _startStatus = false;
                    }
                    foreach (Process proc in Process.GetProcessesByName("firefox"))
                    {
                        proc.Kill();
                        _startStatus = false;
                    }
                    if (_startStatus == false)
                    {
                        timer1.Stop();
                        timer2.Stop();
                        timer3.Stop();
                        ListBoxArchive.Items.Add("Stopped: " + DateTime.Now);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not kill! " + ex.ToString());
                }

                ////////////Restart Task
                Thread.Sleep(5000);
                //start timers
                timer1.Start();
                timer2.Start();
                timer3.Start();
                try
                {
                    //start Rob
                    proc.StartInfo.FileName = @"D:\GoogleDrive\Wintask\Facebook\facebook_profiles.rob";
                    proc.StartInfo.UseShellExecute = true;
                    proc.Start();
                    _startStatus = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not start Rob! " + ex.ToString());
                }
            }

            _oldResolvedCount = _resolvedCount;
        }

        //BtnConnect
        private void BtnConnect_Click(object sender, EventArgs e)
        {
            //connect
            if (_connected == false)
            {
                try
                {
                    _db.Open();
                    _connected = true;

                    LblConnection.Text = "Connected";
                    LblConnection.ForeColor = Color.White;
                    BtnConnect.Text = "Disconnect";

                    BtnStart.Enabled = true;
                    BtnConnect.Enabled = false;
                    ListBoxArchive.Items.Add("Connected at: " + DateTime.Now);

                    //get the starting records only once
                    if (_checkStartingRecords == true)
                    {
                        CheckStartingRecords();
                        _checkStartingRecords = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to Connenct!" + ex.ToString());
                }
            }
            //disconnect
            else if (_connected == true)
            {
                _db.Close();
                _connected = false;
                LblConnection.Text = "Disconnected";
                LblConnection.ForeColor = Color.Gray;
                BtnConnect.Text = "Connect";

                //disable Start Button
                BtnStart.Enabled = false;

                //stop timers
                timer1.Stop();
                timer2.Stop();
                timer3.Stop();
                ListBoxArchive.Items.Add("Disconnected: " + DateTime.Now);

            }
        }

        //BtnSart
        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (TextBoxFb_Table.Text == "")
            {
                MessageBox.Show("Enter database table name!", "Can't Start!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (_startStatus == false)
                {
                    BtnStart.Text = "Kill Task";
                    //start timers
                    timer1.Start();
                    timer2.Start();
                    timer3.Start();
                    try
                    {
                        //start Rob
                        proc.StartInfo.FileName = @"D:\GoogleDrive\Wintask\Facebook\facebook_profiles.rob";
                        proc.StartInfo.UseShellExecute = true;
                        proc.Start();
                        _startStatus = true;
                        ListBoxArchive.Items.Add("Task Started at: " + DateTime.Now);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Could not start Rob! " + ex.ToString());
                    }
                }

                else if (_startStatus == true)
                {
                    BtnStart.Text = "Start Task";
                    try
                    {
                        foreach (Process proc in Process.GetProcessesByName("TaskExec"))
                        {
                            proc.Kill();
                            _startStatus = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Could not kill! " + ex.ToString());
                    }
                }
            }

        }


        //Check Process
        public void CheckProcess()
        {
            Process[] pname = Process.GetProcessesByName("TaskExec");
            if (pname.Length == 0)
            {
                BtnStart.Text = "Start Task";
                LblTask.Text = "Rob Off";
                LblTask.ForeColor = Color.Gray;
                _startStatus = false;
            }
            else
            {
                BtnStart.Text = "Kill Task";
                LblTask.Text = "Rob On";
                LblTask.ForeColor = Color.White;
                _startStatus = true;
            }
        }

        //Check Starting records when i click Start
        public void CheckStartingRecords()
        {
            string fbTable = TextBoxFb_Table.Text;
            string strQuery = "SELECT COUNT(*) AS TimeCheck FROM " + fbTable + " WHERE Finished = 0";
            try
            {
                OdbcCommand cmd = new OdbcCommand(strQuery, _db);
                _startingCount = Convert.ToInt32(cmd.ExecuteScalar());
                LblStartingRecords.Text = "Starting Records: " + _startingCount;
            }
            catch (Exception)
            {
                //Btn_StartTimers.Content = "Start Timers";
            }
        }
        //Check Remaining Records every secods
        public void CheckRemainingRecords()
        {
            string fbTable = TextBoxFb_Table.Text;
            string strQuery = "SELECT COUNT(*) AS TimeCheck FROM " + fbTable + " WHERE Finished = 0";

            try
            {
                //execute query for remaining count
                OdbcCommand cmd = new OdbcCommand(strQuery, _db);
                _remainingCount = Convert.ToInt32(cmd.ExecuteScalar());
                LblRemainingRecords.Text = "Remaining Records: " + _remainingCount;
            }
            catch (Exception)
            {
                //Btn_StartTimers.Content = "Start Timers";
            }

            //End of Program
            if (_remainingCount == 0)
            {
                timer1.Stop();
                timer2.Stop();
                timer3.Stop();
                ListBoxArchive.Items.Add("All Records Finished!");
                ListBoxArchive.Items.Add("Finished at: " + DateTime.Now);
                MessageBox.Show("All Records Finished!");
                _startStatus = false;
            }
            //Check Resolved Records
            _resolvedCount = _startingCount - _remainingCount;
            LblResolvedRecords.Text = "Resolved Records: " + _resolvedCount;
        }

        //Check Database every 2 minutes
        public void CheckBan()
        {
            string fbTable = TextBoxFb_Table.Text;
            string check_if_ban = "SELECT COUNT(*) AS TimeCheck FROM " + fbTable + " WHERE Finished = 2";
            string check_email = "SELECT COUNT(*) AS TimeCheck FROM " + fbTable + " WHERE Finished = 3";

            //execute query to see if any field has the value 2
            OdbcCommand check_ban_query = new OdbcCommand(check_if_ban, _db);
            _check_ban = Convert.ToInt32(check_ban_query.ExecuteScalar());
            //execute query to see if any field has the value 3
            OdbcCommand check_email_query = new OdbcCommand(check_email, _db);
            _check_email = Convert.ToInt32(check_email_query.ExecuteScalar());

            //Verify in Databse if Account is banned
            if (_check_ban >= 1)
            {
                timer1.Stop(); //pause timer
                timer2.Stop();
                ListBoxArchive.Items.Add("Stopped at: " + DateTime.Now);
                ListBoxArchive.Items.Add("Change the Facebook Account!");
                BtnStart.Text = "Restart Task";
                _startStatus = false;
            }
            else
            {
                timer1.Start();
                timer2.Start();
                _startStatus = true;
            }

            //Verify in Databse if email is not verified
            if (_check_email >= 1)
            {
                timer1.Stop(); //pause timer
                timer2.Stop();
                ListBoxArchive.Items.Add("Stopped at: " + DateTime.Now);
                ListBoxArchive.Items.Add("Email check detected!");
                BtnStart.Text = "Restart Task";
                _startStatus = false;
            }
            else
            {
                timer1.Start();
                timer2.Start();
                _startStatus = true;
            }
        }
    }
}