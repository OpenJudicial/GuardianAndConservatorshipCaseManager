using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace API_UI
{
    public partial class Form1 : Form
    {
        Label lastSelected = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void MouseEnter(object sender, EventArgs e)
        {
            ((Label)sender).BackColor = SystemColors.ControlDarkDark;
        }

        private void MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).BackColor = Color.Black;
        }

        private void Click(object sender, EventArgs e)
        {
            Label menu = (Label)sender;
            if (lastSelected != null) {
                lastSelected.BorderStyle = BorderStyle.FixedSingle;
                lastSelected.Font = new Font("Microsoft YaHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            }
            lastSelected = menu;
            menu.BorderStyle = BorderStyle.Fixed3D;
            menu.Font = new Font("Microsoft YaHei UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            lblSelection.Text = menu.Text.Substring(5);
            switch (menu.Name)
            {
                case "lblMenuProtectionOrders": break;
            }
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.I4)]
        static extern int SendMessage(
            IntPtr hWnd,
            [param: MarshalAs(UnmanagedType.U4)]
        uint Msg,
            [param: MarshalAs(UnmanagedType.U4)]
        uint wParam,
            [param: MarshalAs(UnmanagedType.I4)]
        int lParam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ReleaseCapture();

        private void lblFormTop_MouseDown(object sender, MouseEventArgs e)
        {   // Standard Form Move
            ReleaseCapture();
            SendMessage(Handle, (uint)0xA1, (uint)2, 0);
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            if (lblSelection.Text == "Protection Orders")
            {
                lblResult.Text = ProtectionOrder.query(txtCaseID.Text);
            }
        }
    }
}
