using System;
using System.Windows.Forms;

namespace ScalerCalc
{
    public class PWMCalc
    {
        // <TEMP>

        private readonly string tmplt = @"APFCON1bits.CCP1SEL = 1; // RB0
CCP1CONbits.CCP1M = 0b1100; // pwm mode

PR2 = $TICKS; // reset on value $TICKS
int duty = $DUTY; // duty cycle: $DUTY_PER %

CCP1CONbits.DC1B = duty & 0b11; // duty cycle LSB
CCPR1L = duty >> 2; // duty cycle MSB

// timer
T2CONbits.T2CKPS = $PRESCALER; // prescaler $PRESCALER_NAME
T2CONbits.TMR2ON = 1; // timer 2 enable
";

        // </TEMP>


        public string logv { get; private set; }
        public double fosc { get; private set; }
        public double period { get; private set; }
        public double minTick { get; private set; }
        public double minOverflow { get; private set; }
        public double trueScaler { get; private set; }
        public int freq { get; private set; }
        public int scaler { get; private set; }
        public double timerTick { get; private set; }
        public double timerOverflow { get; private set; }
        public int ticks { get; private set; }
        public int duty { get; private set; }
        public double actualTime { get; private set; }
        public double actualFreq { get; private set; }
        public double deviation { get; private set; }
        public double accuracy { get; private set; }
        public string initCode { get; private set; }

        private readonly int dutyPercentage;
        private readonly ComboBox prescaler;

        public PWMCalc(string foscStr, string freqStr, int iDuty, ComboBox iPrescaler, bool calcScalers = true)
        {
            prescaler = iPrescaler;

            fosc = Convert.ToDouble(foscStr);
            period = 1 / Convert.ToDouble(freqStr);
            minTick = 4 / fosc;

            log("Mode: Calculate PWM");
            log($"min-tick: {minTick}");
            minOverflow = minTick * 256;
            log($"min-overflow: {minOverflow}");
            trueScaler = period / minOverflow;
            log($"true-Scaler: {trueScaler}");

            freq = Convert.ToInt32(freqStr);
            scaler = getPWMScaler(freq, trueScaler, prescaler.Text, calcScalers);
            prescaler.SelectedIndex = prescaler.Items.IndexOf($"1:{scaler}");
            log($"scaler: {scaler}");
            timerTick = minTick * scaler;
            log($"timer-tick: {timerTick}");
            timerOverflow = timerTick * 256;
            log($"timer-overflow: {timerOverflow}");

            ticks = (int)Math.Round(period / timerTick) - 1;
            log($"ticks: {ticks}");

            duty = dutyPercentage = iDuty;
            duty *= 4 * (ticks + 1);
            duty /= 100;
            log($"duty-cycle: {duty}");

            actualTime = ticks * timerTick;
            log($"actual-time: {actualTime}");
            actualFreq = 1 / actualTime;
            log($"actual-freq: {1 / actualTime}");

            deviation = Math.Abs(actualFreq - freq);
            log($"deviation: {deviation}");

            accuracy = 100.0 / freq * actualFreq;
            log($"accuracy: {accuracy}");

            initCode = setInitCode(tmplt);

            log("------------------------------------");
        }

        private string setInitCode(string template)
        {
            string ret = template;

            ret = ret.Replace("$PRESCALER_NAME", prescaler.Text.ToString());
            ret = ret.Replace("$PRESCALER", $"0b{Convert.ToString(prescaler.SelectedIndex, 2)}");

            ret = ret.Replace("$TICKS", ticks.ToString());

            ret = ret.Replace("$DUTY_PER", dutyPercentage.ToString());
            ret = ret.Replace("$DUTY", duty.ToString());

            return ret;
        }

        private int getPWMScaler(int frequency, double trueScaler, string prescaler, bool calcScalers)
        {
            if (!calcScalers)
            {
                return glob.parseScaler(prescaler);
            }

            /*
            foreach (var scaler in drpPWMPrescaler.Items)
            {
                int prscaler = parseScaler(scaler as string);

                if (prscaler >= (int)(Math.Ceiling(trueScaler)))
                {
                    return prscaler;
                }
            }*/

            return getPrescaler(frequency);
        }

        private long calcPR2(int freq, int prescale)
        {
            long a = (long)fosc / (freq);
            a /= (4 * prescale);
            a--;

            return a;
        }

        private int getPR2(int freq, char prescale)
        {
            long pr2 = calcPR2(freq, prescale);

            return pr2 > 255 ? 255 : (int)pr2;
        }

        private int getPrescaler(int freq)
        {
            int i = 1;

            for (i = 1; i <= 64 && calcPR2(freq, i) > 255; i *= 4) ;

            return i > 64 ? i / 4 : i;
        }

        private void log(string l)
        {
            logv = l + "\r\n" + logv;
        }
    }
}
