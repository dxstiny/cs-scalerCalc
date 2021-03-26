using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace ScalerCalc
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();

            treeView.TreeViewNodeSorter = new NodeSorter();

            string storage = Properties.Settings.Default.timers;
            if (storage != "")
            {
                try
                {
                    Timers obj = JsonConvert.DeserializeObject<Timers>(storage);

                    foreach (KeyValuePair<string, List<KeyValuePair<string, List<string>>>> timer in obj.nodes)
                    {
                        TreeNode treeNode = new TreeNode();
                        treeNode.Text = timer.Key;

                        foreach (KeyValuePair<string, List<string>> scaler in timer.Value)
                        {
                            TreeNode child = new TreeNode();
                            child.Text = scaler.Key;

                            foreach (string scale in scaler.Value)
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
            TimerCalc timerCalc = new TimerCalc(txtFosc.Text, txtTarget.Text, prescaler,
                postscaler, txtScalerOverride.Text, timer.Text, chckCalcScalers.Checked);

            log(timerCalc.logv);
            txtAccuracy.Text = timerCalc.accuracy.ToString();
            txtActualPeriod.Text = timerCalc.actual.ToString();
            txtPreload.Text = Math.Ceiling(timerCalc.preload).ToString();
            txtFormattedCode.Text = timerCalc.timerCode;
            txtSteps.Text = Math.Ceiling(timerCalc.ticks).ToString();
            txtDeviation.Text = timerCalc.deviation.ToString();
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

            string text = txtSettingsAdd.Text.Replace("1:", "");
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

            string text = txtSettingsAdd.Text.Replace("1:", "");
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
            TreeNode n = treeView.Nodes["root"];

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
            txtTimerCode.Text = TimerCalc.getTimerCode(timerCode.Text);
        }

        private void pgTimer_Click(object sender, EventArgs e)
        {

        }

        private void btnPWMCalc_Click(object sender, EventArgs e)
        {
            PWMCalc pWMCalc = new PWMCalc(txtFosc.Text, txtPWMInFreq.Text, (int)txtPWMDuty.Value, drpPWMPrescaler, chkPWMCalcScalers.Checked);
            
            txtPWMOutPR2.Text = pWMCalc.ticks.ToString();
            txtPWMOutDuty.Text = pWMCalc.duty.ToString();
            txtPWMOutFreq.Text = pWMCalc.actualFreq.ToString();
            txtPWMOutAccuracy.Text = pWMCalc.accuracy.ToString();
            txtPWMOutDeviation.Text = pWMCalc.deviation.ToString();
            txtPWMCode.Text = pWMCalc.initCode;
            log(pWMCalc.logv);
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

                    int r = s1.CompareTo(s2);
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
