using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Collections.Generic;


namespace FovChanger
{
    public partial class Form1 : Form
    {
        // Base address value for pointers.
        int baseAddress = 0x00400000;

        // Other variables.
        System.Text.Encoding enc = System.Text.Encoding.UTF8;
        Process[] myProcess;
        string processNameDX9, processNameDX11;

        bool isDX11 = false;
        int useAlternativePointer = 0;
     
        float fov=1.3f;

        float readFov = 0;
        float readCurrentDisplayedFOV = 0;
        int fovAddress = 0x0082E128;
        int[] offsetCurrentFOV = new int[] { 0x200, 0x0, 0x28, 0x80 };
        int[] offsetCurrentDisplayedFOV = new int[] { 0x200, 0x0, 0x28, 0xC };
        int[] offsetCurrentFOVAlternative = new int[] { 0x200, 0x4, 0x0, 0x28, 0x80 };               //Alternative pointers DX9
        int[] offsetCurrentDisplayedFOVAlternative = new int[] { 0x200, 0x4, 0x0, 0x28, 0xC };

        int fovAddressAlternative2 = 0x00823F00;
        int[] offsetCurrentFOVAlternative2 = new int[] { 0x158, 0xCC, 0x64, 0x28, 0x80 };
        int[] offsetCurrentDisplayedFOVAlternative2 = new int[] { 0x158, 0xCC, 0x64, 0x28, 0xC };


        int fovAddressDX11 = 0x0066DA28;
        int[] offsetCurrentFOVDX11 = new int[] { 0x200, 0x0, 0x28, 0x80 };
        int[] offsetCurrentDisplayFOVDX11 = new int[] { 0x200, 0x0, 0x28, 0xC };
        int[] offsetCurrentFOVDX11Alternative = new int[] { 0x200, 0x4, 0x0, 0x28, 0x80  };       //Alternative pointers DX11
        int[] offsetCurrentDisplayFOVDX11Alternative = new int[] { 0x200, 0x4, 0x0, 0x28, 0xC };

        int fovAddressDX11Alternative2 = 0x005EA2F0;
        int[] offsetCurrentFOVDX11Alternative2 = new int[] { 0x30, 0x0, 0x10, 0x28, 0x80 };
        int[] offsetCurrentDisplayFOVDX11Alternative2= new int[] { 0x30, 0x0, 0x10, 0x28, 0xC };

        Keys Key = Keys.F11;

        bool autoMode;
        
        bool settingInputKey;

        string labelUrl = "www.pcgamingwiki.com";


        /*------------------
        -- INITIALIZATION --
        ------------------*/
        public Form1()
        {
            InitializeComponent();
            processNameDX9 = "AvP";
            processNameDX11 = "AvP_DX11";
        }

        bool foundProcess = false;

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (isDX11 == false)
                myProcess = Process.GetProcessesByName(processNameDX9);
            else
                myProcess = Process.GetProcessesByName(processNameDX11);

            if (myProcess.Length > 0)
            {
                if(foundProcess==false)
                    System.Threading.Thread.Sleep(1000);        //A lazy way of preventing unhandled exception error
                foundProcess = true;
            }
            else
                foundProcess = false;

            if (foundProcess)
            {
                // The game is running, ready for memory reading.
                LB_Running.Text = "AvP is running";
                LB_Running.ForeColor = Color.Green;
                
                if(isDX11==false)
                {
                    readFov = Trainer.ReadPointerFloat(processNameDX9, baseAddress + fovAddress, offsetCurrentFOV);
                    readCurrentDisplayedFOV = Trainer.ReadPointerFloat(processNameDX9, baseAddress + fovAddress, offsetCurrentDisplayedFOV);
                    useAlternativePointer = 0;

                    if ((Single.IsNaN(readFov) || readFov < 0.013 || readFov > 2.99) && useAlternativePointer == 0) //if FOV is NaN / lower than 1 / higher than 170 -> use alternative pointer
                    {
                        useAlternativePointer = 1;
                        readFov = Trainer.ReadPointerFloat(processNameDX9, baseAddress + fovAddress, offsetCurrentFOVAlternative);
                        readCurrentDisplayedFOV = Trainer.ReadPointerFloat(processNameDX9, baseAddress + fovAddress, offsetCurrentDisplayedFOVAlternative);
                    }
                    if ((Single.IsNaN(readFov) || readFov < 0.013 || readFov > 2.99) && useAlternativePointer == 1)
                    {
                        useAlternativePointer = 2;
                        readFov = Trainer.ReadPointerFloat(processNameDX9, baseAddress + fovAddressAlternative2, offsetCurrentFOVAlternative2);
                        readCurrentDisplayedFOV = Trainer.ReadPointerFloat(processNameDX9, baseAddress + fovAddressAlternative2, offsetCurrentDisplayedFOVAlternative2);
                    }
                }
                else
                { 
                    readFov = Trainer.ReadPointerFloat(processNameDX11, baseAddress + fovAddressDX11, offsetCurrentFOVDX11);
                    readCurrentDisplayedFOV = Trainer.ReadPointerFloat(processNameDX11, baseAddress + fovAddressDX11, offsetCurrentDisplayFOVDX11);
                    useAlternativePointer = 0;

                    if ((Single.IsNaN(readFov) || readFov < 0.013 || readFov > 2.99) && useAlternativePointer == 0)         //Yes, I know, this is a terrible way of doing it :|
                    {
                        useAlternativePointer = 1;
                        readFov = Trainer.ReadPointerFloat(processNameDX11, baseAddress + fovAddressDX11, offsetCurrentFOVDX11Alternative);
                        readCurrentDisplayedFOV = Trainer.ReadPointerFloat(processNameDX11, baseAddress + fovAddressDX11, offsetCurrentDisplayFOVDX11Alternative);
                    }
                    else if ((Single.IsNaN(readFov) || readFov < 0.013 || readFov > 2.99) && useAlternativePointer == 1)
                    {
                        useAlternativePointer = 2;
                        readFov = Trainer.ReadPointerFloat(processNameDX11, baseAddress + fovAddressDX11Alternative2, offsetCurrentFOVDX11Alternative2);
                        readCurrentDisplayedFOV = Trainer.ReadPointerFloat(processNameDX9, baseAddress + fovAddress, offsetCurrentFOVAlternative2);
                    }
                }
                
                L_fov.Text = VerticalRadiansToHorizontalFOV(readFov).ToString();

                if (autoMode)
                {
                    ChangeFov();
                }
            }
            else
            {
                // The game process has not been found, reseting values.
                LB_Running.Text = "AvP is not running";
                LB_Running.ForeColor = Color.Red;
                ResetValues();
            }
        }

        // Called when the game is not running or no mission is active.
        // Used to reset all the values.
        private void ResetValues()
        {
            L_fov.Text = "0";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitHotkey();
            Timer.Start();
        }

        public void InitHotkey()
        {
            if (!KeyGrabber.Hooked)
            {
                KeyGrabber.key.Clear();
                KeyGrabber.keyPressEvent += KeyGrabber_KeyPress;
                if (Key != Keys.None)
                    KeyGrabber.key.Add(Key);

                KeyGrabber.SetHook();
            }
            else
            {
                if (Key != Keys.None)
                    KeyGrabber.key.Add(Key);
            }

        }

        public void UnHook()
        {
            KeyGrabber.UnHook();
        }


        private void KeyGrabber_KeyPress(object sender, EventArgs e)
        {
            ChangeDisplayedFOV();
        }

        void ChangeFov()
        {
            if (fovAddress != 0x0000000 || fovAddressDX11 != 0x0000000 && foundProcess)
            {
                if(isDX11==false)
                {
                    if (readFov != fov)
                    {
                        if (useAlternativePointer == 1)
                            Trainer.WritePointerFloat(processNameDX9, baseAddress + fovAddress, offsetCurrentFOVAlternative, fov);
                        else if (useAlternativePointer == 2)
                            Trainer.WritePointerFloat(processNameDX9, baseAddress + fovAddressAlternative2, offsetCurrentFOVAlternative2, fov);
                        else
                            Trainer.WritePointerFloat(processNameDX9, baseAddress + fovAddress, offsetCurrentFOV, fov); 

                        L_fov.Text = VerticalRadiansToHorizontalFOV(fov).ToString();
                    }
                }
                else
                {
                    if (readFov != fov)
                    {
                        if (useAlternativePointer == 1)
                            Trainer.WritePointerFloat(processNameDX11, baseAddress + fovAddressDX11, offsetCurrentFOVDX11Alternative, fov);
                        else if (useAlternativePointer == 2)
                            Trainer.WritePointerFloat(processNameDX11, baseAddress + fovAddressDX11Alternative2, offsetCurrentFOVDX11Alternative2, fov);
                        else
                            Trainer.WritePointerFloat(processNameDX11, baseAddress + fovAddressDX11, offsetCurrentFOVDX11, fov);
                        
                        L_fov.Text = VerticalRadiansToHorizontalFOV(fov).ToString();
                    }
                }
            }
        }

        void ChangeDisplayedFOV()
        {
            if (fovAddress != 0x0000000 || fovAddressDX11 != 0x0000000 && foundProcess)
            {
                if(isDX11==false)
                {
                    if (readCurrentDisplayedFOV != fov)
                    {
                        if (useAlternativePointer == 1)
                            Trainer.WritePointerFloat(processNameDX9, baseAddress + fovAddress, offsetCurrentDisplayedFOVAlternative, fov);
                        else if (useAlternativePointer == 2)
                            Trainer.WritePointerFloat(processNameDX9, baseAddress + fovAddressAlternative2, offsetCurrentDisplayedFOVAlternative2, fov);
                        else
                            Trainer.WritePointerFloat(processNameDX9, baseAddress + fovAddress, offsetCurrentDisplayedFOV, fov);
                    }
                }
                else
                {
                    if (readCurrentDisplayedFOV != fov)
                    {
                        if (useAlternativePointer == 1)
                            Trainer.WritePointerFloat(processNameDX11, baseAddress + fovAddressDX11, offsetCurrentDisplayFOVDX11Alternative, fov);
                        else if (useAlternativePointer == 2)
                            Trainer.WritePointerFloat(processNameDX11, baseAddress + fovAddressDX11Alternative2, offsetCurrentDisplayFOVDX11Alternative2, fov);
                        else
                            Trainer.WritePointerFloat(processNameDX11, baseAddress + fovAddressDX11, offsetCurrentDisplayFOVDX11, fov);
                    }
                }

            }
        }
        //////////////////////////
        // Calculator functions //
        //////////////////////////
        public double ConvertToDegrees(double angle)
        {
            return angle * (180.0 / Math.PI);
        }

        public double ConvertToRadians(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        public float VerticalRadiansToHorizontalFOV(float angle)
        {
            double dHorizontalRadians, dHorizontalFOV;

            dHorizontalRadians = 2 * Math.Atan(Math.Tan(Convert.ToDouble(angle) / 2) * (4 * 1.0 / 3 * 1.0));
            dHorizontalFOV = ConvertToDegrees(dHorizontalRadians);
            return Convert.ToSingle(Math.Round(dHorizontalFOV, 3));

        }

        public float HorizontalFOVToVerticalRadians(float angle)
        {
            double dHorizontalRadians, dVertialRadians;

            dHorizontalRadians = ConvertToRadians(Convert.ToDouble(angle));
            dVertialRadians = 2 * Math.Atan(Math.Tan(dHorizontalRadians / 2) * (3 * 1.0 / 4 * 1.0));
            return Convert.ToSingle(Math.Round(dVertialRadians, 3));
        }
        /////////////////////////////////
        // End of calculator functions //
        /////////////////////////////////


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (settingInputKey)
            {
                Key = keyData;
                B_Key.Text = Key.ToString();
                B_Key.Checked = false;
                InitHotkey();
                return true;
            }
                
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void B_Key_CheckedChanged(object sender, EventArgs e)
        {
            if (B_Key.Checked)
            {
                settingInputKey = true;
                B_Key.Text = "";
            }
            else
            {
                settingInputKey = false;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnHook();
        }


        // Lazy way to do it i know, it would be better with events

        private void C_AutoMode_CheckedChanged(object sender, EventArgs e)
        {
            if (C_AutoMode.Checked)
            {
                autoMode = true;
                B_Key.Enabled = true;
                InitHotkey();
            }
            else
            {
                autoMode = false;
                UnHook();
            }
        }

        private void B_set_Click(object sender, EventArgs e)
        {
            var res = 0f;
            if (float.TryParse(T_Input.Text, out res))
            {
                if(res<1)
                {
                    res = 1;
                    T_Input.Text = "1";
                }
                if(res>170)
                {
                    res = 170;
                    T_Input.Text = "170";
                }
                fov = HorizontalFOVToVerticalRadians(res);
            }
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(labelUrl);
        }

        private void RButton_DX9_CheckedChanged(object sender, EventArgs e)
        {
            if (RButton_DX9.Checked)
            {
                RButton_DX11.Checked = false;
                isDX11 = false;
            }
        }

        private void RButton_DX11_CheckedChanged(object sender, EventArgs e)
        {
            if (RButton_DX11.Checked)
            {
                RButton_DX9.Checked = false;
                isDX11 = true;
            }
        }
    }
}
