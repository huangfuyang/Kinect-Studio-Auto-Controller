using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinectStudioControllerCSharp
{

    public partial class Form1 : Form
    {
        System.Timers.Timer timer;
        bool IsSaving = false;
        private bool _isConnected;
        public bool IsConnected
        {
            get
            {
                return _isConnected;
            }
            set
            {
                _isConnected = value;
                if (_isConnected)
                {
                    lbl_connect.Text = "Connected";
                }
                else
                {
                    lbl_connect.Text = "Not Connected";
                }
            }
        }

        private string _timestampFile;

        public string TimestampFile
        {
            get { return _timestampFile; }
            set
            {
                lbl_Timestamp.Text = value;
                _timestampFile = value;
            }
        }

        private IntPtr hWnd = IntPtr.Zero;
        private IntPtr hMenu = IntPtr.Zero;
        private static int p_processid = 0;
        private int firstFrame = 0;

        public int FirstFrame
        {
            get {
                firstFrame = Convert.ToInt32(tbx_FirstFrame.Text);
                return firstFrame; 

            }
            set 
            { 
                firstFrame = value;
                tbx_FirstFrame.Text = firstFrame.ToString();
            }
        }
        public Form1()
        {
            InitializeComponent();
            ConsoleManager.Show();
            timer = new System.Timers.Timer(100);
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            IntPtr savingWnd = win32API.FindWindow(null, "Saving selected range");
            if (savingWnd != IntPtr.Zero)
            {
                IsSaving = true;
            }
            else
            {
                IsSaving = false;
            }
        }

        private unsafe bool Connect()
        {
            FindKinectStudioWindowHandler();
            if (hWnd == IntPtr.Zero)
            {
                return false;
            }

            return true;
        }



        public static int ReadMemoryValue(IntPtr baseAddress, int pid)
        {
            try
            {
                byte[] buffer = new byte[4];
                IntPtr byteAddress = Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0); //获取缓冲区地址
                IntPtr hProcess = win32API.OpenProcess(0x1F0FFF, false, pid);
                win32API.ReadProcessMemory(hProcess, (IntPtr)baseAddress, byteAddress, 4, IntPtr.Zero); //将制定内存中的值读入缓冲区
                win32API.CloseHandle(hProcess);
                return Marshal.ReadInt32(byteAddress);
            }
            catch
            {
                return 0;
            }
        }



        private void btn_Start_Click(object sender, EventArgs e)
        {
            String path = "C:\\Program Files\\Microsoft SDKs\\Kinect\\Developer Toolkit v1.7.0\\Tools\\KinectStudio\\KinectStudio.exe";
            Process.Start(path);
            Thread.Sleep(1000);
            IsConnected = Connect();
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            IsConnected = Connect();
        }
        /// <summary>
        /// split xed file
        /// </summary>
        /// <param name="start">start time (ms)</param>
        /// <param name="duration">duration time (ms)</param>
        /// <param name="fileName">file name of new xed file</param>
        /// <returns></returns>
        private bool SplitXED(int start, int duration, string fileName)
        {
            IntPtr hMenuStrip = win32API.FindWindowEx(hWnd, IntPtr.Zero, null, "menuStrip1");
            if (!IsConnected || hMenuStrip == IntPtr.Zero)
            {
                return false;
            }
            Console.WriteLine("menuStrip:" + Convert.ToString(hMenuStrip.ToInt32(), 16));
            win32API.GetWindowThreadProcessId(hWnd, out p_processid);
            Thread.Sleep(1000);
            //click timeline
            Console.WriteLine("click timeline");
            Console.WriteLine("-----------------");
            int x = 128, y = 10;
            win32API.SendMessage(hMenuStrip, win32API.WM_LBUTTONDOWN, 0, (y << 16) + x);
            win32API.SendMessage(hMenuStrip, win32API.WM_LBUTTONUP, 0, (y << 16) + x);
            Thread.Sleep(1000);
            // find menu 
            win32API.EnumWindows(new win32API.EnumWindowsProc(EnumWindowsFunc), p_processid);
            if (hMenu == hWnd)
            {
                Console.WriteLine("click menu fail");
                return false;
            }
            Console.WriteLine("menu1:" + Convert.ToString(hMenu.ToInt32(), 16));
            // click menu
            Console.WriteLine("click select range");
            Console.WriteLine("-----------------");
            int x1 = 20, y1 = 10;
            Thread.Sleep(300);
            win32API.PostMessage(hMenu, win32API.WM_LBUTTONDOWN, 0, (y1 << 16) + x1);
            win32API.PostMessage(hMenu, win32API.WM_LBUTTONUP, 0, (y1 << 16) + x1);
            Thread.Sleep(1000);
            // send range
            string edit = "WindowsForms10.EDIT.app.0.2bf8098_r18_ad1";
            IntPtr hSelectRange = win32API.FindWindow(null, "Select Range");
            IntPtr hDuration = win32API.FindWindowEx(hSelectRange, IntPtr.Zero, edit, null);
            IntPtr hStart = win32API.FindWindowEx(hSelectRange, hDuration, edit, null);
            win32API.SendMessage(hStart, win32API.WM_SETTEXT, IntPtr.Zero, start.ToString());
            win32API.SendMessage(hDuration, win32API.WM_SETTEXT, IntPtr.Zero, duration.ToString());
            IntPtr hOK = win32API.FindWindowEx(hSelectRange, IntPtr.Zero, null, "OK");
            win32API.SendMessage(hOK, win32API.BM_CLICK, 0, 0);
            // save range
            Thread.Sleep(1000);
            // click timeline
            Console.WriteLine("menuStrip:" + Convert.ToString(hMenuStrip.ToInt32(), 16));
            Console.WriteLine("click timeline");
            Console.WriteLine("-----------------");

            win32API.SendMessage(hMenuStrip, win32API.WM_LBUTTONDOWN, 0, (y << 16) + x);
            win32API.SendMessage(hMenuStrip, win32API.WM_LBUTTONUP, 0, (y << 16) + x);
            // click save range
            int x2 = 20, y2 = 55;
            Thread.Sleep(1000);
            win32API.EnumWindows(new win32API.EnumWindowsProc(EnumWindowsFunc), p_processid);
            if (hMenu == hWnd)
            {
                Console.WriteLine("click menu fail");
                return false;
            }
            Console.WriteLine("menu2:" + Convert.ToString(hMenu.ToInt32(), 16));
            Console.WriteLine("click save range");
            Console.WriteLine("-----------------");
            win32API.PostMessage(hMenu, win32API.WM_LBUTTONDOWN, 0, (y2 << 16) + x2);
            win32API.PostMessage(hMenu, win32API.WM_LBUTTONUP, 0, (y2 << 16) + x2);
            // wait save dialog
            Thread.Sleep(2000);
            win32API.EnumWindows(new win32API.EnumWindowsProc(EnumWindowsFunc), p_processid);
            Console.WriteLine("save as:" + Convert.ToString(hMenu.ToInt32(), 16));
            IntPtr hdialog = hMenu;
            Thread.Sleep(1000);

            // find file path text edit
            IntPtr hfileName = GetWindowChildDFSByDepth(hdialog, 5);
            // send filename
            Console.WriteLine("fileName:" + hfileName);
            win32API.SendMessage(hfileName, win32API.WM_SETTEXT, IntPtr.Zero, fileName);
            // find save button
            IntPtr hsave = GetWindowChildBFSByIndex(hdialog, 2);
            Console.WriteLine("save:" + hsave);
            // click save
            win32API.SendMessage(hsave, win32API.BM_CLICK, 0, 0);
            Thread.Sleep(3000);
            IsSaving = true;
            Console.WriteLine("-----------------");
            return true;
        }

        private bool SplitByFrame(int start, int duration, string name)
        {
            start = Frame2Timestamp(start);
            duration = (int)((float)duration * 33.33);
            bool r = SplitXED(start, duration, name);

            return r;
        }

        private int Frame2Timestamp(int frame)
        {
            if (firstFrame == 0)
            {
                Console.WriteLine("plz find first frame");
                return 0;
            }
            return (int)((float)(frame - firstFrame) * 33.33);
        }

        private IntPtr GetWindowChildDFSByDepth(IntPtr window, int index)
        {
            IntPtr child = window;
            for (int i = 0; i < index; i++)
            {
                child = win32API.FindWindowEx(child, IntPtr.Zero, null, null);
                if (child == IntPtr.Zero)
                {
                    return child;
                }
            }
            return child;

        }
        private IntPtr GetWindowChildBFSByIndex(IntPtr window, int index)
        {
            IntPtr child = win32API.FindWindowEx(window, IntPtr.Zero, null, null); ;
            for (int i = 0; i < index; i++)
            {
                child = win32API.FindWindowEx(window, child, null, null);
                if (child == IntPtr.Zero)
                {
                    return child;
                }
            }
            return child;

        }
        private void btn_Run_Click(object sender, EventArgs e)
        {
            if (hWnd == IntPtr.Zero || !IsConnected)
            {
                MessageBox.Show("Open and Connect Kinect Studio first");
                return;
            }
            if (segList.Count == 0)
            {
                MessageBox.Show("select time stamp file first");
                return;
            }
            // check if kinect studio open a file.
            IntPtr t = win32API.FindWindow(null, "Kinect Studio");
            if (t != IntPtr.Zero)
            {
                MessageBox.Show("Open a file in Kinect Studio first");
                return;
            }
            for (int i = 0; i < segList.Count(); i++)
            {
                Segment item = segList[i];
                bool r = false;
                if (rdb_frame.Checked)
                {
                    r = SplitByFrame(item.start, item.end - item.start, item.name);
                }
                else
                {
                    r = SplitXED(item.start, item.end - item.start, item.name);

                }


                while (r && IsSaving)
                {
                    Console.WriteLine("wait saving");
                    Thread.Sleep(1000);
                }
                if (!r)
                {
                    Console.WriteLine("fail start again");
                    i--;

                }
                else
                {
                    Console.WriteLine("suceed save {0}", item.name);
                }
                Console.WriteLine("================================================");
                Thread.Sleep(3000);
            }



        }

        public bool EnumWindowsFunc(IntPtr hWnd, int lParam)
        {
            int ProcessId;
            if (hWnd == IntPtr.Zero)
                return true;		// Not a window
            if (!win32API.IsWindowVisible(hWnd))
                return true;
            win32API.GetWindowThreadProcessId(hWnd, out ProcessId);
            if (lParam == ProcessId)
            {
                hMenu = hWnd;
                return false;
            }
            return true;
        }

        public bool TestEnumWindowsFunc(IntPtr hWnd, int lParam)
        {
            int ProcessId;
            if (hWnd == IntPtr.Zero)
                return true;		// Not a window
            if (!win32API.IsWindowVisible(hWnd))
                return true;

            win32API.GetWindowThreadProcessId(hWnd, out ProcessId);
            if (lParam == ProcessId)
            {
                hMenu = hWnd;
                Console.WriteLine(Convert.ToString(hWnd.ToInt32(), 16));
                return true;
            }
            return true;
        }

        public bool EnumWindowsFindKinectStudio(IntPtr hWnd, int lParam)
        {

            if (hWnd == IntPtr.Zero)
                return true;		// Not a window
            int buffer = win32API.GetWindowTextLength(hWnd);
            if (buffer == 0)
            {
                return true;
            }
            StringBuilder title = new StringBuilder(buffer + 1);
            win32API.GetWindowText(hWnd, title, title.Capacity);
            if (title == null)
            {
                return true;
            }
            if (title.ToString().Contains("Kinect Studio"))
            {
                this.hWnd = hWnd;
                return false;
            }
            return true;
        }

        public void FindKinectStudioWindowHandler()
        {
            win32API.EnumWindows(new win32API.EnumWindowsProc(EnumWindowsFindKinectStudio), 0);
            if (hWnd != IntPtr.Zero)
            {
                win32API.GetWindowThreadProcessId(hWnd, out p_processid);
            }
        }

        private void btn_OpenXedFile_Click(object sender, EventArgs e)
        {
            //win32API.SendMessage(hWnd, win32API.WM_KEYDOWN, win32API.VK_MENU, 1);
            FirstFrame = 0;
            IntPtr hToolStrip = win32API.FindWindowEx(hWnd, IntPtr.Zero, null, "toolStrip1");
            if (!IsConnected || hToolStrip == IntPtr.Zero)
            {
                return;
            }
            int p_processid;
            win32API.GetWindowThreadProcessId(hWnd, out p_processid);
            //click open
            int x = 28, y = 10;
            win32API.PostMessage(hToolStrip, win32API.WM_LBUTTONDOWN, 0, (y << 16) + x);
            win32API.PostMessage(hToolStrip, win32API.WM_LBUTTONUP, 0, (y << 16) + x);
        }

        struct Segment
        {
            public int start;
            public int end;
            public string name;
        }

        private List<Segment> segList = new List<Segment>();

        private void btn_LoadTimestamp_Click(object sender, EventArgs e)
        {
            if (cbb_name.Text == "")
            {
                MessageBox.Show("plz select signer name");
                return;
            }
            OpenFileDialog ofd = new OpenFileDialog();
            StreamReader sr = null;
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                sr = new StreamReader(new FileStream(ofd.FileName, FileMode.Open));
                TimestampFile = ofd.FileName;
            }
            if (sr != null)
            {
                string line = sr.ReadLine();
                line = sr.ReadLine();
                segList.Clear();
                while (line != null && line != "")
                {
                    string[] cells = line.Split();
                    int start = Convert.ToInt32(cells[7]);
                    int end = Convert.ToInt32(cells[8]);
                    string fileName = cells[1] + ' ' + cbb_name.Text + ' ' + cells[0] + cells[3];
                    segList.Add(new Segment()
                    {
                        start = start,
                        end = end,
                        name = fileName
                    });

                    line = sr.ReadLine();
                }
                sr.Close();

            }



        }

        private void lbl_Timestamp_Click(object sender, EventArgs e)
        {

        }

        private void btn_Test_Click(object sender, EventArgs e)
        {

            win32API.EnumWindows(new win32API.EnumWindowsProc(TestEnumWindowsFunc), p_processid);
            Console.WriteLine("save as:" + Convert.ToString(hMenu.ToInt32(), 16));
            Console.WriteLine("main:" + Convert.ToString(hWnd.ToInt32(), 16));
            IntPtr p = IntPtr.Zero;
            p = win32API.FindWindowEx(hWnd, IntPtr.Zero, null, null);
            while (p != IntPtr.Zero)
            {
                Console.WriteLine(Convert.ToString(p.ToInt32(), 16));
                p = win32API.FindWindowEx(hWnd, p, null, null);

            }


        }

        private void btn_ReadFrame_Click(object sender, EventArgs e)
        {
            IntPtr dllEntry = IntPtr.Zero;
            Process[] pros = Process.GetProcessesByName("KinectStudio");
            Process pro = pros[0];
            if (pro.ProcessName == "KinectStudio")
            {
                for (int i = 0; i < pro.Modules.Count; i++)
                {
                    if (pro.Modules[i].ModuleName == "KinectStudioNative.dll")
                    {
                        dllEntry = pro.Modules[i].EntryPointAddress;
                        Console.WriteLine("KinectNative.dll addr: {0}",dllEntry.ToString("x8"));
                        dllEntry += Convert.ToInt32("208fbf", 16);
                        Console.WriteLine("Frame addr:" + dllEntry.ToString("x8"));                       

                    }

                }
            }

            IntPtr tool = win32API.FindWindowEx(hWnd, IntPtr.Zero, null, "toolStrip1");
            int x = 340, y = 10;
            int min = int.MaxValue;
            for (int i = 0; i < 4; i++)
            {
                
                int tempValue = ReadMemoryValue(dllEntry, pro.Id);
                Console.WriteLine("candidate Frame value:" + tempValue);
                if (tempValue != 0 && tempValue< min)
                {
                    min = tempValue;
                }
                win32API.SendMessage(tool, win32API.WM_LBUTTONDOWN, 0, (y << 16) + x);
                win32API.SendMessage(tool, win32API.WM_LBUTTONUP, 0, (y << 16) + x);
                Thread.Sleep(200);
            }
            FirstFrame = min;

        }



    }
}
