using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ScalerCalc
{
    public static class glob
    {
        public static int parseScaler(string scaler)
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
    }

    public class TimerCalc
    {
        public double fosc { get; private set; }
        public double target { get; private set; }
        public double minTick { get; private set; }
        public string logv { get; private set; }
        public int scaler { get; private set; }
        public double trueScaler { get; private set; }
        public double timerTick { get; private set; }
        public double minOverflow { get; private set; }
        public double ticks { get; private set; }
        public double preload { get; private set; }
        public double actualTicks { get; private set; }
        public double actual { get; private set; }
        public double timerOverflow { get; private set; }
        public double deviation { get; private set; }
        public double accuracy { get; private set; }
        public string timerCode { get; private set; }

        public TimerCalc(string foscStr, string periodStr, ComboBox prescaler, ComboBox postscaler, 
            string scalerOverride, string tmrCode, bool calcScalers = true)
        {
            fosc = Convert.ToDouble(foscStr);
            target = Convert.ToDouble(periodStr);
            minTick = 4 / fosc;

            log("Mode: Calculate Timer");

            log($"min-tick: {minTick}");
            minOverflow = minTick * 256;
            log($"min-overflow: {minOverflow}");
            trueScaler = target / minOverflow;
            log($"true-Scaler: {trueScaler}");

            calculatePrescaler(Convert.ToInt32(trueScaler), prescaler, postscaler, calcScalers);
            scaler = getScaler(scalerOverride, prescaler.Text, postscaler.Text);
            log($"scaler: {scaler}");
            timerTick = minTick * scaler;
            log($"timer-tick: {timerTick}");
            timerOverflow = timerTick * 256;
            log($"timer-overflow: {timerOverflow}");

            ticks = target / timerTick - 1;
            log($"ticks: {ticks}");
            preload = 255 - ticks;
            log($"preload: {preload}");

            actualTicks = Math.Ceiling(ticks);
            actualTicks = actualTicks > 255.0 ? 255.0 : actualTicks;
            actual = actualTicks * timerTick;

            log($"actual: {actual}");
            deviation = Math.Abs(target - actual);
            log($"deviation: {deviation}");
            accuracy = 100.0 / target * actual;
            log($"accuracy: {accuracy}");

            log("------------------------------------");

            timerCode = getTimerCode(tmrCode, prescaler, postscaler, prescaler.SelectedIndex, postscaler.SelectedIndex, (int)Math.Ceiling(ticks), (int)Math.Ceiling(preload));
        }

        private string getTimerCode(string timer, ComboBox prescaler, ComboBox postscaler, int prescalerIndex, int postscalerIndex, int ticks, int preload)
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

        public static string getTimerCode(string timer)
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

        private int getScaler(string scalerOverride, string prescaler, string postscaler)
        {
            if (scalerOverride != "")
            {
                return glob.parseScaler(scalerOverride);
            }

            return glob.parseScaler(prescaler) * glob.parseScaler(postscaler);
        }

        private void calculatePrescaler(int trueScaler, ComboBox prescaler, ComboBox postscaler, bool calcScalers = true)
        {
            if (!calcScalers)
                return;

            List<int> prescalers = new List<int>();
            List<int> postscalers = new List<int>();

            foreach (object item in prescaler.Items)
            {
                prescalers.Add(glob.parseScaler(item as string));
            }

            foreach (object item in postscaler.Items)
            {
                postscalers.Add(glob.parseScaler(item as string));
            }

            int bestPrescaler = 0;
            int bestPostscaler = 0;
            int bestDiff = 999;

            foreach (int pstscaler in postscalers)
            {
                foreach (int prscaler in prescalers)
                {
                    int scaler = pstscaler * prscaler;

                    if (scaler >= trueScaler)
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

        private void log(string l)
        {
            logv = l + "\r\n" + logv;
        }
    }
}
