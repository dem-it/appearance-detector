namespace AppearanceDetector
{
    internal class TrayIconContextMenu
    {
        private readonly Form1 _form;
        private readonly ToolStripMenuItem _pauseMenuItem = new();
        private readonly ToolStripMenuItem _resumeMenuItem = new();

        internal TrayIconContextMenu(Form1 form)
        {
            _form = form;
        }

        internal ContextMenuStrip Construct()
        {
            //Add tray icon context menu
            var trayIconContextMenu = new ContextMenuStrip();
            var closeMenuItem = new ToolStripMenuItem();
            trayIconContextMenu.SuspendLayout();

            // 
            // TrayIconContextMenu
            // 
            trayIconContextMenu.Items.AddRange([_pauseMenuItem, _resumeMenuItem, closeMenuItem]);
            trayIconContextMenu.Name = "TrayIconContextMenu";
            trayIconContextMenu.Size = new Size(153, 70);
            // 
            // CloseMenuItem
            // 
            closeMenuItem.Name = "CloseMenuItem";
            closeMenuItem.Size = new Size(152, 22);
            closeMenuItem.Text = "Close appearance detector software";
            closeMenuItem.Click += new EventHandler(CloseMenuItem_Click);

            // 
            // PauseMenuItem
            // 
            _pauseMenuItem.Name = "PauseMenuItem";
            _pauseMenuItem.Size = new Size(152, 22);
            _pauseMenuItem.Text = "Pause detection";
            _pauseMenuItem.Click += new EventHandler(PauseMenuItem_Click);

            // 
            // ResumeMenuItem
            // 
            _resumeMenuItem.Name = "ResumeMenuItem";
            _resumeMenuItem.Size = new Size(152, 22);
            _resumeMenuItem.Text = "Resume detection";
            _resumeMenuItem.Click += new EventHandler(ResumeMenuItem_Click);
            _resumeMenuItem.Visible = false;

            trayIconContextMenu.ResumeLayout(false);
            return trayIconContextMenu;
        }

        internal void Pause()
        {
            _pauseMenuItem.Visible = false;
            _resumeMenuItem.Visible = true;
        }

        internal void Resume()
        {
            _pauseMenuItem.Visible = true;
            _resumeMenuItem.Visible = false;
        }

        private void PauseMenuItem_Click(object? sender, EventArgs e)
            => _form.Pause();

        private void ResumeMenuItem_Click(object? sender, EventArgs e)
            => _form.Resume();

        private void CloseMenuItem_Click(object? sender, EventArgs e)
        {
            _form._applicationIsExiting = true;
            Application.Exit();
        }
    }
}
