using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimerCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            treeView.TreeViewNodeSorter = new NodeSorter();

            string storage = Properties.Settings.Default.timers;
            if (storage != "")
            {
                try
                {
                    Timers obj = JsonConvert.DeserializeObject<Timers>(storage);

                    foreach (var timer in obj.nodes)
                    {
                        TreeNode treeNode = new TreeNode();
                        treeNode.Text = timer.Key;

                        foreach (var scaler in timer.Value)
                        {
                            TreeNode child = new TreeNode();
                            child.Text = scaler.Key;
                            
                            foreach (var scale in scaler.Value)
                            {
                                child.Nodes.Add(scale);
                            }

                            treeNode.Nodes.Add(child);
                        }

                        treeView.Nodes["root"].Nodes.Add(treeNode);
                    }

                    treeView.ExpandAll();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            double fosc = Convert.ToDouble(txtFosc.Text);
            double target = Convert.ToDouble(txtTarget.Text);
            double minTick = 4 / fosc;
            log($"min-tick: {minTick}");
            double minOverflow = minTick * 256;
            log($"min-overflow: {minOverflow}");
            double trueScaler = target / minOverflow;
            log($"true-Scaler: {trueScaler}");

            calculatePrescaler(Convert.ToInt32(trueScaler));
            int scaler = getScaler();
            log($"scaler: {scaler}");
            double timerTick = minTick * scaler;
            log($"timer-tick: {timerTick}");
            double timerOverflow = timerTick * 256;
            log($"timer-overflow: {timerOverflow}");

            double ticks = target / timerTick;
            log($"ticks: {ticks}");
            txtSteps.Text = Math.Ceiling(ticks).ToString();
            double preload = 255 - ticks;
            log($"preload: {preload}");
            txtPreload.Text = Math.Ceiling(preload).ToString();

            double actualTicks = Math.Ceiling(ticks);
            actualTicks = actualTicks > 255.0 ? 255.0 : actualTicks;
            double actual = actualTicks * timerTick;

            log($"actual: {actual}");
            txtActualPeriod.Text = actual.ToString();
            double deviation = Math.Abs(target - actual);
            log($"deviation: {deviation}");
            txtDeviation.Text = deviation.ToString();
            double accuracy = 100.0 / target * actual;
            log($"accuracy: {accuracy}");
            txtAccuracy.Text = accuracy.ToString();

            log("------------------------------------");

            txtFormattedCode.Text = getTimerCode(timer.Text, prescaler.SelectedIndex, postscaler.SelectedIndex, (int)Math.Ceiling(ticks), (int)Math.Ceiling(preload));
        }

        private void calculatePrescaler(int trueScaler)
        {
            if (!chckCalcScalers.Checked)
                return;

            List<int> prescalers = new List<int>();
            List<int> postscalers = new List<int>();

            foreach (var item in prescaler.Items)
            {
                prescalers.Add(parseScaler(item as string));
            }

            foreach (var item in postscaler.Items)
            {
                postscalers.Add(parseScaler(item as string));
            }

            int bestPrescaler = 0;
            int bestPostscaler = 0;
            int bestDiff = 999;

            foreach (var pstscaler in postscalers)
            {
                foreach (var prscaler in prescalers)
                {
                    int scaler = pstscaler * prscaler;

                    if (scaler > trueScaler)
                    {
                        if (bestDiff > scaler - trueScaler)
                        {
                            bestDiff = scaler - trueScaler;
                            bestPostscaler = pstscaler;
                            bestPrescaler = prscaler;
                        }
                    }
                }
            }

            postscaler.SelectedIndex = postscalers.IndexOf(bestPostscaler);
            prescaler.SelectedIndex = prescalers.IndexOf(bestPrescaler);

            prescaler.SelectedIndex = prescaler.SelectedIndex < 0 ? (prescaler.Items.Count - 1) : prescaler.SelectedIndex;
            postscaler.SelectedIndex = postscaler.SelectedIndex < 0 ? (postscaler.Items.Count - 1) : postscaler.SelectedIndex;
        }

        private int getScaler()
        {
            if (txtScalerOverride.Text != "")
            {
                return parseScaler(txtScalerOverride.Text);
            }

            return parseScaler(prescaler.Text) * parseScaler(postscaler.Text);
        }

        private int parseScaler(string scaler)
        {
            try
            {
                return Convert.ToInt32(scaler.Replace("1:", ""));
            }
            catch
            {
                return 1;
            }
        }

        private void log(string text)
        {
            txtLog.Text = $"{text}\r\n" + txtLog.Text;
        }

        private void btnAddTimer_Click(object sender, EventArgs e)
        {
            treeView.Nodes["root"].Nodes.Add(txtSettingsAdd.Text);
            treeView.Sort();
            treeView.Nodes["root"].Expand();
            txtSettingsAdd.Text = "";
        }

        private void button1_Click(object sender, EventArgs e) // addPrescaler
        {
            if (treeView.SelectedNode is null)
                return;

            var text = txtSettingsAdd.Text.Replace("1:", "");
            int scaler;

            try
            {
                scaler = Convert.ToInt32(text);
            }
            catch
            {
                log("NaN");
                return;
            }

            if (scaler <= 1)
            {
                log("invalid scaler");
                return;
            }

            if (treeView.SelectedNode.Parent.Name == "root")
            {
                if (treeView.SelectedNode.Nodes.Count == 0 || treeView.SelectedNode.Nodes.Count == 1 && treeView.SelectedNode.Nodes[0].Text == "Postscaler")
                {
                    treeView.SelectedNode.Nodes.Insert(0, "Prescaler");
                    treeView.SelectedNode.Nodes[0].Nodes.Add("1:1");

                    txtSettingsAdd.Text = "";
                }

                treeView.SelectedNode.Nodes[0].Nodes.Add("1:" + scaler);
                treeView.Sort();
            }
        }

        private void btnAddPostscaler_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode is null)
                return;

            var text = txtSettingsAdd.Text.Replace("1:", "");
            int scaler;

            try
            {
                scaler = Convert.ToInt32(text);
            }
            catch
            {
                log("NaN");
                return;
            }

            if (scaler <= 1)
            {
                log("invalid scaler");
                return;
            }

            TreeNode node;
            bool add = false;

            if (treeView.SelectedNode.Parent.Name == "root")
            {
                if (treeView.SelectedNode.Nodes.Count == 0 || treeView.SelectedNode.Nodes.Count == 1 && treeView.SelectedNode.Nodes[0].Text == "Prescaler")
                {
                    treeView.SelectedNode.Nodes.Add("Postscaler");
                    add = true;
                    txtSettingsAdd.Text = "";
                }

                if (treeView.SelectedNode.Nodes.Count == 1)
                {
                    node = treeView.SelectedNode.Nodes[0];
                }
                else
                {
                    node = treeView.SelectedNode.Nodes[1];
                }

                if (add)
                {
                    node.Nodes.Add("1:1");
                }

                node.Nodes.Add("1:" + scaler);
                treeView.Sort();
            }
        }

        private void btnRemoveNode_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode.Name == "root")
                return;

            treeView.SelectedNode.Remove();
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            Timers timers = new Timers();
            var n = treeView.Nodes["root"];

            foreach (TreeNode timer in n.Nodes)
            {
                List<KeyValuePair<string, List<string>>> timerr = new List<KeyValuePair<string, List<string>>>();

                foreach (TreeNode scaler in timer.Nodes)
                {
                    List<string> scales = new List<string>();

                    foreach (TreeNode scale in scaler.Nodes)
                    {
                        scales.Add(scale.Text);
                    }

                    timerr.Add(new KeyValuePair<string, List<string>>(scaler.Text, scales));
                }

                timers.nodes.Add(new KeyValuePair<string, List<KeyValuePair<string, List<string>>>>(timer.Text, timerr));
            }

            Properties.Settings.Default.timers = JsonConvert.SerializeObject(timers);

            if (timerCode.SelectedIndex >= 0)
            {
                Dictionary<string, string> timerCodes = JsonConvert.DeserializeObject<Dictionary<string, string>>(Properties.Settings.Default.timerCodes);

                if (timerCodes is null)
                {
                    timerCodes = new Dictionary<string, string>();
                }

                if (!timerCodes.ContainsKey(timerCode.Text))
                {
                    timerCodes.Add(timerCode.Text, txtTimerCode.Text);
                }
                else
                {
                    timerCodes[timerCode.Text] = txtTimerCode.Text;
                }

                Properties.Settings.Default.timerCodes = JsonConvert.SerializeObject(timerCodes);
            }

            Properties.Settings.Default.Save();
        }

        private void treeView_Validated(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (TreeNode node in treeView.Nodes["root"].Nodes)
            {
                if (!timer.Items.Contains(node.Text))
                {
                    timer.Items.Add(node.Text);
                    timerCode.Items.Add(node.Text);
                }
            }
        }

        private void timer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (timer.SelectedIndex < 0)
                return;

            prescaler.Items.Clear();
            postscaler.Items.Clear();

            foreach (TreeNode timer in treeView.Nodes["root"].Nodes)
            {
                if (timer.Text == this.timer.Text)
                {
                    foreach (TreeNode scaler in timer.Nodes)
                    {
                        if (scaler.Text == "Prescaler")
                        {
                            foreach (TreeNode prescale in scaler.Nodes)
                            {
                                prescaler.Items.Add(prescale.Text);
                            }
                        }
                        else if (scaler.Text == "Postscaler")
                        {
                            foreach (TreeNode postscale in scaler.Nodes)
                            {
                                postscaler.Items.Add(postscale.Text);
                            }
                        }
                    }

                    if (prescaler.Items.Count == 0)
                    {
                        prescaler.Items.Add("1:1");
                    }

                    if (postscaler.Items.Count == 0)
                    {
                        postscaler.Items.Add("1:1");
                    }

                    prescaler.SelectedIndex = 0;
                    postscaler.SelectedIndex = 0;

                    return;
                }                
            }
        }

        private void timerCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTimerCode.Text = getTimerCode(timerCode.Text);
        }

        private string getTimerCode(string timer, int prescalerIndex, int postscalerIndex, int ticks, int preload)
        {
            string ret = getTimerCode(timer);

            ret = ret.Replace("$PRESCALER_NAME", prescaler.Items[prescalerIndex].ToString());
            ret = ret.Replace("$POSTSCALER_NAME", postscaler.Items[postscalerIndex].ToString());

            ret = ret.Replace("$PRESCALER", $"0b{Convert.ToString(prescalerIndex, 2)}");
            ret = ret.Replace("$POSTSCALER", $"0b{Convert.ToString(postscalerIndex, 2)}");

            ret = ret.Replace("$TICKS", ticks.ToString());
            ret = ret.Replace("$PRELOAD", preload.ToString());

            return ret;
        }

        private string getTimerCode(string timer)
        {
            string sjson = Properties.Settings.Default.timerCodes;
            Dictionary<string, string> timerCodes = JsonConvert.DeserializeObject<Dictionary<string, string>>(sjson);

            if (timerCodes is null || !timerCodes.ContainsKey(timer))
            {
                return "";
            }
            else
            {
                return timerCodes[timer];
            }
        }
    }

    public class Timers
    {
        public List<KeyValuePair<string, List<KeyValuePair<string, List<string>>>>> nodes = new List<KeyValuePair<string, List<KeyValuePair<string, List<string>>>>>();
    }

    public class NodeSorter : System.Collections.IComparer
    {
        public NodeSorter() { }

        public int Compare(object x, object y)
        {
            try
            {
                TreeNode tx = x as TreeNode;
                TreeNode ty = y as TreeNode;

                string s1 = tx.Text;
                string s2 = ty.Text;

                if (s1.Contains("1:") && s2.Contains("1:"))
                {
                    s1 = s1.Replace("1:", "");
                    s2 = s2.Replace("1:", "");

                    return Convert.ToInt32(s1).CompareTo(Convert.ToInt32(s2));
                }
                else
                {
                    s1 = s1 == "Prescaler" ? "A" : s1;
                    s2 = s2 == "Prescaler" ? "A" : s2;

                    var r = s1.CompareTo(s2);
                    return r;
                }
            }
            catch
            {
                return -1;
            }
        }
    }
}
