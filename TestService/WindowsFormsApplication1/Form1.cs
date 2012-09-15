using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ServiceReference1.Service1Client clnt = new ServiceReference1.Service1Client();
        private void button1_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            
            var str = clnt.GetData(Convert.ToInt32((numericUpDown1.Value))) + "\n";
            var ms = sw.ElapsedMilliseconds;

            this.textBox1.Text = "Executed 1 Request1 in " + sw.ElapsedMilliseconds + " ms " + str;
            this.chart1.Series[0].Points.Add(ms);
            this.Refresh();
        }

        private void RunTest()
        {
            int[] nums = Enumerable.Range(0, Convert.ToInt32(numericUpDown2.Value)).ToArray();
            long total = 0;
            Stopwatch sw = Stopwatch.StartNew();
            // Use type parameter to make subtotal a long, not an int
            Parallel.For<long>(0, nums.Length, () => 0, (j, loop, subtotal) =>
            {
                subtotal += nums[j];
                try
                {

                    clnt.GetData(nums[j]);

                }
                catch (Exception ex) { }
                return subtotal;
            },
                (x) => Interlocked.Add(ref total, x)

            );

            var ms = sw.ElapsedMilliseconds;

            this.textBox1.Text = "Executed " + nums.Length + " Requests in " + sw.ElapsedMilliseconds + " ms";
            this.chart1.Series[0].Points.Add(ms);
            this.Refresh();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            RunTest();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (var cnt = 0; cnt < numericUpDown3.Value; cnt++)
            {
                RunTest();
            }
        }
    }
}
