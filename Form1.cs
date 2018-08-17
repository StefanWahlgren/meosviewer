using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Xml.Serialization;

namespace MeosViewer
{
    public partial class Form1 : Form
    {
        private string activeTab = "tabPage3";
        Timer timer = new Timer();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string baseUrl = "http://localhost:2009/meos";
            string str1radio = "?get=result&leg=1&to=41";
            string str1pre = "?get=result&leg=1&to=48";
            string str1change = "?get=result&leg=1&to=100";
            string str2radio = "?get=result&leg=2&to=41";
            string str2pre = "?get=result&leg=2&to=48";
            string str2change = "?get=result&leg=2&to=100";
            string str3pre = "?get=result&leg=3&to=48";
            string str3change = "?get=result&leg=3&to=100";
            string str4pre = "?get=result&leg=4&to=48";
            string str4goal = "?get=result&leg=4&to=100";

            if (File.Exists(@"c:\git\StefanWahlgren\MeosViewer\pathsFile.txt")) {
                var paths = File.ReadAllLines(@"c:\git\StefanWahlgren\MeosViewer\pathsFile.txt");
                if (paths.Length > 0)
                {
                    baseUrl = paths[0];
                    str1radio = paths[1];
                    str1pre = paths[2];
                    str1change = paths[3];
                    str2radio = paths[4];
                    str2pre = paths[5];
                    str2change = paths[6];
                    str3pre = paths[7];
                    str3change = paths[8];
                    str4pre = paths[9];
                    str4goal = paths[10];
                }
            }

            txtBox_base_str1radio.Text = baseUrl;
            txtBox_base_str1pre.Text = baseUrl;
            txtBox_base_str1change.Text = baseUrl;
            txtBox_base_str2radio.Text = baseUrl;
            txtBox_base_str2pre.Text = baseUrl;
            txtBox_base_str2change.Text = baseUrl;
            txtBox_base_str3pre.Text = baseUrl;
            txtBox_base_str3change.Text = baseUrl;
            txtBox_base_str4pre.Text = baseUrl;
            txtBox_base_str4goal.Text = baseUrl;

            txtBox_url_str1radio.Text = str1radio;
            txtBox_url_str1pre.Text = str1pre;
            txtBox_url_str1change.Text = str1change;
            txtBox_url_str2radio.Text = str2radio;
            txtBox_url_str2pre.Text = str2pre;
            txtBox_url_str2change.Text = str2change;
            txtBox_url_str3pre.Text = str3pre;
            txtBox_url_str3change.Text = str3change;
            txtBox_url_str4pre.Text = str4pre;
            txtBox_url_str4goal.Text = str4goal;
        }

        private void tab3_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage current = (sender as TabControl).SelectedTab;

            if (current.Name == "tabPage3") btnGoStr1Radio.PerformClick();
            if (current.Name == "tabPage4") btnGoStr1Pre.PerformClick();
            if (current.Name == "tabPage5") btnGoStr1Change.PerformClick();
            if (current.Name == "tabPage6") btnGoStr2Radio.PerformClick();
            if (current.Name == "tabPage7") btnGoStr2Pre.PerformClick();
            if (current.Name == "tabPage8") btnGoStr2Change.PerformClick();
            if (current.Name == "tabPage9") btnGoStr3Pre.PerformClick();
            if (current.Name == "tabPage10") btnGoStr3Change.PerformClick();
            if (current.Name == "tabPage11") btnGoStr4Pre.PerformClick();
            if (current.Name == "tabPage12") btnGoStr4Goal.PerformClick();

            activeTab = current.Name;
        }

        private void btnGoStr1Radio_Click(object sender, EventArgs e)
        {
            LoadResult(txtBox_base_str1radio.Text, txtBox_url_str1radio.Text);
        }

        private void btnGoStr1Pre_Click(object sender, EventArgs e)
        {
            LoadResult(txtBox_base_str1pre.Text, txtBox_url_str1pre.Text);
        }

        private void btnGoStr1Change_Click(object sender, EventArgs e)
        {
            LoadResult(txtBox_base_str1change.Text, txtBox_url_str1change.Text);
        }

        private void btnGoStr2Radio_Click(object sender, EventArgs e)
        {
            LoadResult(txtBox_base_str2radio.Text, txtBox_url_str2radio.Text);
        }

        private void btnGoStr2Pre_Click(object sender, EventArgs e)
        {
            LoadResult(txtBox_base_str2pre.Text, txtBox_url_str2pre.Text);
        }

        private void btnGoStr2Change_Click(object sender, EventArgs e)
        {
            LoadResult(txtBox_base_str2change.Text, txtBox_url_str2change.Text);
        }

        private void btnGoStr3Pre_Click(object sender, EventArgs e)
        {
            LoadResult(txtBox_base_str3pre.Text, txtBox_url_str3pre.Text);
        }

        private void btnGoStr3Change_Click(object sender, EventArgs e)
        {
            LoadResult(txtBox_base_str3change.Text, txtBox_url_str3change.Text);
        }

        private void btnGoStr4Pre_Click(object sender, EventArgs e)
        {
            LoadResult(txtBox_base_str4pre.Text, txtBox_url_str4pre.Text);
        }

        private void btnGoStr4Goal_Click(object sender, EventArgs e)
        {
            LoadResult(txtBox_base_str4goal.Text, txtBox_url_str4goal.Text);
        }

        private void LoadResult(string baseUrl, string extraPath) {
            try
            {
                SavePaths(baseUrl);

                var classList = GetClasses();
                var teamList = GetTeams();

                resultViewStr1Radio.Clear();
                resultViewStr1Radio.GridLines = true;
                resultViewStr1Radio.View = View.Details;
                resultViewStr1Radio.Columns.Add("Sträcka", 50);
                resultViewStr1Radio.Columns.Add("Kontroll", 50);
                resultViewStr1Radio.Columns.Add("Lagnr", 50);
                resultViewStr1Radio.Columns.Add("Klass", 50);
                resultViewStr1Radio.Columns.Add("Namn", 160);
                resultViewStr1Radio.Columns.Add("Lag", 260);
                resultViewStr1Radio.Columns.Add("Tid", 60);
                resultViewStr1Radio.Columns.Add("Diff", 60);
                resultViewStr1Radio.Columns.Add("RaceTime", 70);

                var client = new WebClient();
                var response = client.DownloadString(baseUrl + extraPath);

                if (string.IsNullOrEmpty(response))
                {
                    MessageBox.Show("No response.");
                    return;
                }

                response = response.Replace("Ã¶", "ö").Replace("Ã¤", "ä").Replace("Ã–", "Ö").Replace("Ã¼", "û");

                var serializer = new XmlSerializer(typeof(MOPComplete));
                var encoding = Encoding.GetEncoding("UTF-8");
                var buffer = encoding.GetBytes(response);
                using (var stream = new MemoryStream(buffer))
                {
                    var mopComplete = (MOPComplete)serializer.Deserialize(stream);

                    if (mopComplete.results.team == null)
                    {
                        lblInfoStr1Radio.Text = "No results";
                        return;
                    }

                    lblInfoStr1Radio.Text = "Sträcka: " + mopComplete.results.leg.ToString() + ". Kontroll: " + mopComplete.results.to.Replace("[", "").Replace("]", "");

                    var sortedList = new SortedList<ushort, MOPCompleteResultsTeam>();
                    foreach (var result in mopComplete.results.team)
                    {
                        var rt = result.person.rt;
                        while (sortedList.ContainsKey(rt)) rt++;
                        sortedList.Add(rt, result);
                    }

                    if (sortedList.Count > 0)
                    {
                        var bestTime = sortedList.Keys.First();
                        foreach (var item in sortedList.Values)
                        {
                            var resList = new List<string>();
                            resList.Add(item.person.leg.ToString());
                            resList.Add(mopComplete.results.to.Replace("[", "").Replace("]", ""));
                            resList.Add(teamList[item.name.id.ToString()]);
                            resList.Add(classList[item.person.cls.ToString()]);
                            resList.Add(item.person.name.Value);
                            resList.Add(item.name.Value);
                            resList.Add(FormatTime(item.person.rt));
                            if (item.person.rt > bestTime)
                            {
                                resList.Add("+" + FormatTime((ushort)(item.person.rt - bestTime)));
                            }
                            else
                            {
                                resList.Add(string.Empty);
                            }
                            resList.Add(item.person.rt.ToString());
                            resultViewStr1Radio.Items.Add(new ListViewItem(resList.ToArray()));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception: {ex.Message}, Stacktrace: {ex.StackTrace}");
                return;
            }
        }

        private void SavePaths(string baseUrl) {

            txtBox_base_str1radio.Text = baseUrl;
            txtBox_base_str1pre.Text = baseUrl;
            txtBox_base_str1change.Text = baseUrl;
            txtBox_base_str2radio.Text = baseUrl;
            txtBox_base_str2pre.Text = baseUrl;
            txtBox_base_str2change.Text = baseUrl;
            txtBox_base_str3pre.Text = baseUrl;
            txtBox_base_str3change.Text = baseUrl;
            txtBox_base_str4pre.Text = baseUrl;
            txtBox_base_str4goal.Text = baseUrl;

            List<string> paths = new List<string>();
            paths.Add(baseUrl);
            paths.Add(txtBox_url_str1radio.Text);
            paths.Add(txtBox_url_str1pre.Text);
            paths.Add(txtBox_url_str1change.Text);
            paths.Add(txtBox_url_str2radio.Text);
            paths.Add(txtBox_url_str2pre.Text);
            paths.Add(txtBox_url_str2change.Text);
            paths.Add(txtBox_url_str3pre.Text);
            paths.Add(txtBox_url_str3change.Text);
            paths.Add(txtBox_url_str4pre.Text);
            paths.Add(txtBox_url_str4goal.Text);

            File.WriteAllLines(@"c:\git\StefanWahlgren\MeosViewer\pathsFile.txt", paths.ToArray());
        }

        private Dictionary<string, string> GetClasses() {
            var classList = new Dictionary<string, string>();
            var client = new WebClient();
            var response = client.DownloadString(txtBox_base_str1radio.Text + "?get=class");

            if (string.IsNullOrEmpty(response))
            {
                return classList;
            }

            var serializer = new XmlSerializer(typeof(MOPComplete));
            var encoding = Encoding.GetEncoding("ISO-8859-1");
            var buffer = encoding.GetBytes(response);
            using (var stream = new MemoryStream(buffer))
            {
                var mopComplete = (MOPComplete)serializer.Deserialize(stream);

                foreach (var cls in mopComplete.cls)
                {
                    classList.Add(cls.id.ToString(), cls.Value);
                }
            }

            return classList;
        }

        private Dictionary<string, string> GetTeams() {
            var teamList = new Dictionary<string, string>();
            var client = new WebClient();
            var response = client.DownloadString(txtBox_base_str1radio.Text + "?get=team");

            if (string.IsNullOrEmpty(response))
            {
                return teamList;
            }

            var serializer = new XmlSerializer(typeof(MOPComplete));
            var encoding = Encoding.GetEncoding("ISO-8859-1");
            var buffer = encoding.GetBytes(response);
            using (var stream = new MemoryStream(buffer))
            {
                var mopComplete = (MOPComplete)serializer.Deserialize(stream);

                foreach (var tm in mopComplete.tm)
                {
                    teamList.Add(tm.id.ToString(), tm.@base.bib.ToString());
                }
            }

            return teamList;
        }

        private string FormatTime(ushort rt) {
            if (rt < 10) {
                return string.Empty;
            }

            var seconds = rt / 10;

            if (seconds >= 3600)
                return string.Format($"{seconds / 3600}:{((seconds / 60) % 60).ToString().PadLeft(2, '0')}:{(seconds % 60).ToString().PadLeft(2, '0')}");
            return string.Format($"{((seconds / 60) % 60).ToString().PadLeft(2, '0')}:{(seconds % 60).ToString().PadLeft(2, '0')}");
        }

        private void chkBoxAutoRefresh_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxAutoRefresh.Checked)
            {
                timer.Interval = 2000;
                timer.Tick += new EventHandler(timer_Tick);
                timer.Start();
            }
            else {
                timer.Stop();
            }
        }

        private void timer_Tick(object sender, EventArgs e) {
            if (activeTab == "tabPage3") btnGoStr1Radio.PerformClick();
            if (activeTab == "tabPage4") btnGoStr1Pre.PerformClick();
            if (activeTab == "tabPage5") btnGoStr1Change.PerformClick();
            if (activeTab == "tabPage6") btnGoStr2Radio.PerformClick();
            if (activeTab == "tabPage7") btnGoStr2Pre.PerformClick();
            if (activeTab == "tabPage8") btnGoStr2Change.PerformClick();
            if (activeTab == "tabPage9") btnGoStr3Pre.PerformClick();
            if (activeTab == "tabPage10") btnGoStr3Change.PerformClick();
            if (activeTab == "tabPage11") btnGoStr4Pre.PerformClick();
            if (activeTab == "tabPage12") btnGoStr4Goal.PerformClick();
        }
    }
}
