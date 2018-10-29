using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSharpProfessional.Part1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BaseClass c = new ChildClass();
            int i = c.M();

            ChildClass c1 = new ChildClass();
            int j = c1.M();
        }
    }

    public class BaseClass
    {
        public int M()
        {
            return 1;
        }
    }

    public class ChildClass : BaseClass
    {
        public new int M()
        {
            return 2;
        }
    }
}
