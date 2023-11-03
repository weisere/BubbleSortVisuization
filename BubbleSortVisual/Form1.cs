using BubbleSortVisual.Entity;
using BubbleSortVisual.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BubbleSortVisual
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Graphics graphic;
        private List<Element> elements = new List< Element>();

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        
        private void pnlMonitor_Paint(object sender, PaintEventArgs e)
        {
            var rand = new Random();

            int padding = ArrayOptions.padding;

            //create random array
            for (int index = 0; index < ArrayOptions.Length; index++)
            {
                var start = new Point(padding, MonitorOptions.Height);
                int value = MonitorOptions.Height - rand.Next(50) * 10;
                var end = new Point(padding, value);
                var element = new Element(start, end, MonitorOptions.Height-value);

                elements.Add(element);
                padding += ArrayOptions.Width + ArrayOptions.Space;
            }

            //draw to panel
            elements.ForEach(c =>
            {
                c.Draw(graphic);
            });
        }

        private void btnBubbleSort_Click(object sender, EventArgs e)
        {
            //sort
            for (int i = 0; i < elements.Count - 1; i++)
            {
                for(int j = 0; j < elements.Count - 1; j++)
                {
                    if (elements[j].Value > elements[j + 1].Value)
                    {
                        ElementHelper.DrawSwap(elements[j], elements[j + 1], graphic);
                        ElementHelper.ElementSwap(elements, j, j + 1);
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            graphic = pnlMonitor.CreateGraphics();
        }
    }
}
