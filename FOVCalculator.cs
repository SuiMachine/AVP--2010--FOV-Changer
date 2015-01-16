using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FovChanger
{
    public partial class FOVCalculator : Form
    {
        System.Text.Encoding enc = System.Text.Encoding.UTF8;

        int ResWidth = 1024;
        int ResHeight = 768;
        float VerticalRadians = 0;
        float VerticalFOV = 0;
        float HoriozontalFOV = 0;

        public FOVCalculator()
        {
            InitializeComponent();
        }

        public double ConvertToDegrees(double angle)
        {
            return angle * (180.0 / Math.PI);
        }

        private double ConvertToRadians(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        private void BClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void B_SetResolution_Click(object sender, EventArgs e)
        {
            var res1 = 0;
            var res2 = 0;
            if (int.TryParse(TBResolutionWidth.Text, out res1))
            {
                ResWidth = res1;
            }
            if (int.TryParse(TBResolutionHeight.Text, out res2))
            {
                ResHeight= res2;
            }
        }

        private void BRadiansToDegrees_Click(object sender, EventArgs e)
        {
            double dVertialRadians, dHorizontalRadians, dHorizontalFOV, dVerticalFOV;
            var res = 0f;
            if (float.TryParse(TB_VerticalRadians.Text, out res))
            {
                VerticalRadians = res;
            }

            dVertialRadians = Convert.ToDouble(VerticalRadians);

            // VerticalRadians to Vertical FOV
            dVerticalFOV = ConvertToDegrees(dVertialRadians);
            VerticalFOV = Convert.ToSingle(Math.Round(dVerticalFOV, 3));
            TB_VerticalFOV.Text = VerticalFOV.ToString();

            //Vertical Radians to Horizontal Radians to Horizontal FOV
            dHorizontalRadians = 2 * Math.Atan(Math.Tan(dVertialRadians / 2) * (ResWidth*1.0 / ResHeight*1.0));
            dHorizontalFOV = ConvertToDegrees(dHorizontalRadians);
            HoriozontalFOV = Convert.ToSingle(Math.Round(dHorizontalFOV, 3));
            TB_HorizontalFOV.Text = HoriozontalFOV.ToString();
        }

        private void BVerticalFOVtoRadians_Click(object sender, EventArgs e)
        {
            double dVertialRadians, dHorizontalRadians, dHorizontalFOV, dVerticalFOV;
            var res = 0f;
            if (float.TryParse(TB_VerticalFOV.Text, out res))
            {
                VerticalFOV = res;
            }

            dVerticalFOV = Convert.ToDouble(VerticalFOV);

            // VerticalFOV to Vertical Radians
            dVertialRadians = ConvertToRadians(dVerticalFOV);
            dVerticalFOV = ConvertToDegrees(dVertialRadians);
            VerticalRadians = Convert.ToSingle(Math.Round(dVertialRadians, 3));
            TB_VerticalRadians.Text = VerticalRadians.ToString();

            // Vertical FOV to Horizontal FOV
            dHorizontalRadians = 2 * Math.Atan(Math.Tan(dVertialRadians / 2) * (ResWidth * 1.0 / ResHeight * 1.0));
            dHorizontalFOV = ConvertToDegrees(dHorizontalRadians);
            HoriozontalFOV = Convert.ToSingle(Math.Round(dHorizontalFOV, 3));
            TB_HorizontalFOV.Text = HoriozontalFOV.ToString();
        }

        private void BHorizontalFOVtoRadians_Click(object sender, EventArgs e)
        {
            double dVertialRadians, dHorizontalRadians, dHorizontalFOV, dVerticalFOV;
            var res = 0f;
            if (float.TryParse(TB_HorizontalFOV.Text, out res))
            {
                HoriozontalFOV = res;
            }

            dHorizontalFOV = Convert.ToDouble(HoriozontalFOV);

            // Horizontal FOV to Vertical Radians
            dHorizontalRadians = ConvertToRadians(dHorizontalFOV);
            dVertialRadians = 2 * Math.Atan(Math.Tan(dHorizontalRadians / 2) * (ResHeight * 1.0 / ResWidth * 1.0));
            VerticalRadians = Convert.ToSingle(Math.Round(dVertialRadians, 3));
            TB_VerticalRadians.Text = VerticalRadians.ToString();

            // Vertical Radians to Vertical FOV
            dVerticalFOV = ConvertToDegrees(dVertialRadians);
            VerticalFOV = Convert.ToSingle(Math.Round(dVerticalFOV, 3));
            TB_VerticalFOV.Text = VerticalFOV.ToString();
        }

    }
}
