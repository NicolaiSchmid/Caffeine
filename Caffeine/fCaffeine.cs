using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caffeine
{
    public partial class fCaffeine : Form
    {
        NotifyIcon caffeineNotifyIcon;
        Icon caffeineIcon;
        MenuItem activeMenuItem;
        bool activeMenuItemCheckedBool = false;


        public fCaffeine()
        {
            InitializeComponent();


            sendKeysTimer.Enabled = false;
            caffeineIcon = new Icon("Logo.ico");

            caffeineNotifyIcon = new NotifyIcon();
            caffeineNotifyIcon.Icon = caffeineIcon;
            caffeineNotifyIcon.Visible = true;



            MenuItem aboutMenuItem = new MenuItem("Caffeine by Nicolai Schmid © 2016");
            MenuItem quitMenuItem = new MenuItem("Quit");
            activeMenuItem = new MenuItem("Active");
            
            ContextMenu contextMenu = new ContextMenu();
            contextMenu.MenuItems.Add(aboutMenuItem);
            contextMenu.MenuItems.Add(quitMenuItem);
            contextMenu.MenuItems.Add(activeMenuItem);

            caffeineNotifyIcon.ContextMenu = contextMenu;

            // Wire actions
            quitMenuItem.Click += quitMenuItem_Click;
            activeMenuItem.Click += activeMenuItem_Click;



            // Hide Windows Form
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;


        }

        void quitMenuItem_Click(object sender, EventArgs e)
        {
            caffeineNotifyIcon.Dispose();
            sendKeysTimer.Stop();
            this.Close();
        }
        void activeMenuItem_Click(object sender, EventArgs e)
        {
            if (activeMenuItemCheckedBool)
            {
                activeMenuItem.Checked = false;
                activeMenuItemCheckedBool = false;
                sendKeysTimer.Enabled = false;
            }
            else
            {
                activeMenuItem.Checked = true;
                activeMenuItemCheckedBool = true;
                sendKeysTimer.Enabled = true;
                // Send first Key Stroke
                SendKeys.Send("{^}");
            }
        }

        private void sendKeysTimer_Tick(object sender, EventArgs e)

        {
            if (activeMenuItem.Checked)
            { sendKeys(); }
        }
        private void sendKeys()
        {
            SendKeys.Send("{^}");
        }

    }
}
