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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string baseUrl = "http://localhost:2009/meos";
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

            txtBox_url_str1radio.Text = "?get=result&leg=1&to=32";
            txtBox_url_str1pre.Text = "?get=result&to=41&leg=1";
            txtBox_url_str1change.Text = "?get=result&to=41&leg=1";
            txtBox_url_str2radio.Text = "?get=result&to=41&leg=1";
            txtBox_url_str2pre.Text = "?get=result&to=41&leg=1";
            txtBox_url_str2change.Text = "?get=result&to=41&leg=1";
            txtBox_url_str3pre.Text = "?get=result&to=41&leg=1";
            txtBox_url_str3change.Text = "?get=result&to=41&leg=1";
            txtBox_url_str4pre.Text = "?get=result&to=41&leg=1";
            txtBox_url_str4goal.Text = "?get=result&to=41&leg=1";
        }

        private void btnGoStr1Radio_Click(object sender, EventArgs e)
        {
            resultViewStr1Radio.Clear();
            resultViewStr1Radio.GridLines = true;
            resultViewStr1Radio.View = View.Details;
            resultViewStr1Radio.Columns.Add("Sträcka", 50);
            resultViewStr1Radio.Columns.Add("Kontroll", 50);
            resultViewStr1Radio.Columns.Add("Lagnr", 50);
            resultViewStr1Radio.Columns.Add("Namn", 160);
            resultViewStr1Radio.Columns.Add("Lag", 260);
            resultViewStr1Radio.Columns.Add("Tid", 50);
            resultViewStr1Radio.Columns.Add("Diff", 50);
            resultViewStr1Radio.Columns.Add("RaceTime", 50);

            var client = new WebClient();
            var response = client.DownloadString(txtBox_base_str1radio.Text + txtBox_url_str1radio.Text);

            if (string.IsNullOrEmpty(response)) {
                MessageBox.Show("No response.");
                return;
            }

            var serializer = new XmlSerializer(typeof(MOPComplete));
            var encoding = Encoding.GetEncoding("ISO-8859-1");
            var buffer = encoding.GetBytes(response);
            using (var stream = new MemoryStream(buffer))
            {
                var mopComplete = (MOPComplete)serializer.Deserialize(stream);

                if (mopComplete.results.team == null) {
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

                if (sortedList.Count > 0) {
                    var bestTime = sortedList.Keys.First();
                    foreach (var item in sortedList.Values)
                    {
                        var resList = new List<string>();
                        resList.Add(item.person.leg.ToString());
                        resList.Add(mopComplete.results.to.Replace("[", "").Replace("]", ""));
                        resList.Add(item.name.id.ToString());
                        resList.Add(item.person.name.Value);
                        resList.Add(item.name.Value);
                        resList.Add(FormatTime(item.person.rt));
                        if (item.person.rt > bestTime) {
                            resList.Add("+" + FormatTime((ushort)(item.person.rt - bestTime)));
                        }
                        else {
                            resList.Add(string.Empty);
                        }
                        resList.Add(item.person.rt.ToString());
                        resultViewStr1Radio.Items.Add(new ListViewItem(resList.ToArray()));
                    }
                }
            }
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
    }
}
