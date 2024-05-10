namespace LibraryViewer
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            tabComponents = new System.Windows.Forms.TabControl();
            tabSchLib = new System.Windows.Forms.TabPage();
            splitContainer3 = new System.Windows.Forms.SplitContainer();
            gridSchLibComponents = new System.Windows.Forms.DataGridView();
            gridSchLibComponentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            gridSchLibComponentDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            gridSchLibPrimitives = new System.Windows.Forms.DataGridView();
            gridSchLibPrimitiveDescriptor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            gridSchLibPrimitiveName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            gridSchLibPrimitiveType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            panelPart = new System.Windows.Forms.Panel();
            comboDisplayMode = new System.Windows.Forms.ComboBox();
            labelDisplayMode = new System.Windows.Forms.Label();
            labelPartTotal = new System.Windows.Forms.Label();
            editPart = new System.Windows.Forms.NumericUpDown();
            labelPart = new System.Windows.Forms.Label();
            pictureBox = new System.Windows.Forms.Panel();
            statusStrip = new System.Windows.Forms.StatusStrip();
            statusLocation = new System.Windows.Forms.ToolStripStatusLabel();
            statusProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            menuStrip = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openiocFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            centerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            zoom50ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            zoom100ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            zoom200ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            zoom400ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            exportFootprintToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            exportPrimitiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exportImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            processToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openFileDialog = new System.Windows.Forms.OpenFileDialog();
            saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            redrawTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tabComponents.SuspendLayout();
            tabSchLib.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridSchLibComponents).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridSchLibPrimitives).BeginInit();
            panelPart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)editPart).BeginInit();
            statusStrip.SuspendLayout();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.Location = new System.Drawing.Point(0, 24);
            splitContainer1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tabComponents);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(pictureBox);
            splitContainer1.Size = new System.Drawing.Size(1155, 599);
            splitContainer1.SplitterDistance = 383;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 0;
            // 
            // tabComponents
            // 
            tabComponents.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            tabComponents.Controls.Add(tabSchLib);
            tabComponents.Dock = System.Windows.Forms.DockStyle.Fill;
            tabComponents.Location = new System.Drawing.Point(0, 0);
            tabComponents.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabComponents.Name = "tabComponents";
            tabComponents.SelectedIndex = 0;
            tabComponents.Size = new System.Drawing.Size(383, 599);
            tabComponents.TabIndex = 0;
            // 
            // tabSchLib
            // 
            tabSchLib.Controls.Add(splitContainer3);
            tabSchLib.Location = new System.Drawing.Point(4, 4);
            tabSchLib.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabSchLib.Name = "tabSchLib";
            tabSchLib.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabSchLib.Size = new System.Drawing.Size(375, 571);
            tabSchLib.TabIndex = 2;
            tabSchLib.Text = "SCH Library";
            tabSchLib.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer3.Location = new System.Drawing.Point(4, 3);
            splitContainer3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            splitContainer3.Name = "splitContainer3";
            splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(gridSchLibComponents);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(gridSchLibPrimitives);
            splitContainer3.Panel2.Controls.Add(panelPart);
            splitContainer3.Size = new System.Drawing.Size(367, 565);
            splitContainer3.SplitterDistance = 277;
            splitContainer3.SplitterWidth = 5;
            splitContainer3.TabIndex = 1;
            // 
            // gridSchLibComponents
            // 
            gridSchLibComponents.AllowUserToAddRows = false;
            gridSchLibComponents.AllowUserToDeleteRows = false;
            gridSchLibComponents.AllowUserToResizeRows = false;
            gridSchLibComponents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridSchLibComponents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { gridSchLibComponentName, gridSchLibComponentDescription });
            gridSchLibComponents.Dock = System.Windows.Forms.DockStyle.Fill;
            gridSchLibComponents.Location = new System.Drawing.Point(0, 0);
            gridSchLibComponents.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gridSchLibComponents.MultiSelect = false;
            gridSchLibComponents.Name = "gridSchLibComponents";
            gridSchLibComponents.ReadOnly = true;
            gridSchLibComponents.RowHeadersVisible = false;
            gridSchLibComponents.RowTemplate.ReadOnly = true;
            gridSchLibComponents.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            gridSchLibComponents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            gridSchLibComponents.Size = new System.Drawing.Size(367, 277);
            gridSchLibComponents.TabIndex = 0;
            gridSchLibComponents.CellDoubleClick += GridComponents_CellDoubleClick;
            gridSchLibComponents.RowEnter += GridSchLibComponents_RowEnter;
            // 
            // gridSchLibComponentName
            // 
            gridSchLibComponentName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            gridSchLibComponentName.HeaderText = "Components";
            gridSchLibComponentName.MinimumWidth = 50;
            gridSchLibComponentName.Name = "gridSchLibComponentName";
            gridSchLibComponentName.ReadOnly = true;
            // 
            // gridSchLibComponentDescription
            // 
            gridSchLibComponentDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            gridSchLibComponentDescription.HeaderText = "Description";
            gridSchLibComponentDescription.MinimumWidth = 50;
            gridSchLibComponentDescription.Name = "gridSchLibComponentDescription";
            gridSchLibComponentDescription.ReadOnly = true;
            // 
            // gridSchLibPrimitives
            // 
            gridSchLibPrimitives.AllowUserToAddRows = false;
            gridSchLibPrimitives.AllowUserToDeleteRows = false;
            gridSchLibPrimitives.AllowUserToResizeRows = false;
            gridSchLibPrimitives.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridSchLibPrimitives.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { gridSchLibPrimitiveDescriptor, gridSchLibPrimitiveName, gridSchLibPrimitiveType });
            gridSchLibPrimitives.Dock = System.Windows.Forms.DockStyle.Fill;
            gridSchLibPrimitives.Location = new System.Drawing.Point(0, 33);
            gridSchLibPrimitives.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gridSchLibPrimitives.Name = "gridSchLibPrimitives";
            gridSchLibPrimitives.ReadOnly = true;
            gridSchLibPrimitives.RowHeadersVisible = false;
            gridSchLibPrimitives.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            gridSchLibPrimitives.Size = new System.Drawing.Size(367, 250);
            gridSchLibPrimitives.TabIndex = 0;
            gridSchLibPrimitives.RowEnter += GridSchLibPrimitives_RowEnter;
            gridSchLibPrimitives.RowPrePaint += gridSchLibPrimitives_RowPrePaint;
            gridSchLibPrimitives.DoubleClick += GridPrimitives_DoubleClick;
            // 
            // gridSchLibPrimitiveDescriptor
            // 
            gridSchLibPrimitiveDescriptor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            gridSchLibPrimitiveDescriptor.HeaderText = "Pins";
            gridSchLibPrimitiveDescriptor.MinimumWidth = 40;
            gridSchLibPrimitiveDescriptor.Name = "gridSchLibPrimitiveDescriptor";
            gridSchLibPrimitiveDescriptor.ReadOnly = true;
            // 
            // gridSchLibPrimitiveName
            // 
            gridSchLibPrimitiveName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            gridSchLibPrimitiveName.HeaderText = "Name";
            gridSchLibPrimitiveName.MinimumWidth = 50;
            gridSchLibPrimitiveName.Name = "gridSchLibPrimitiveName";
            gridSchLibPrimitiveName.ReadOnly = true;
            // 
            // gridSchLibPrimitiveType
            // 
            gridSchLibPrimitiveType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            gridSchLibPrimitiveType.HeaderText = "Type";
            gridSchLibPrimitiveType.MinimumWidth = 50;
            gridSchLibPrimitiveType.Name = "gridSchLibPrimitiveType";
            gridSchLibPrimitiveType.ReadOnly = true;
            // 
            // panelPart
            // 
            panelPart.Controls.Add(comboDisplayMode);
            panelPart.Controls.Add(labelDisplayMode);
            panelPart.Controls.Add(labelPartTotal);
            panelPart.Controls.Add(editPart);
            panelPart.Controls.Add(labelPart);
            panelPart.Dock = System.Windows.Forms.DockStyle.Top;
            panelPart.Location = new System.Drawing.Point(0, 0);
            panelPart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelPart.Name = "panelPart";
            panelPart.Size = new System.Drawing.Size(367, 33);
            panelPart.TabIndex = 1;
            // 
            // comboDisplayMode
            // 
            comboDisplayMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboDisplayMode.FormattingEnabled = true;
            comboDisplayMode.Location = new System.Drawing.Point(52, 5);
            comboDisplayMode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboDisplayMode.Name = "comboDisplayMode";
            comboDisplayMode.Size = new System.Drawing.Size(108, 23);
            comboDisplayMode.TabIndex = 1;
            comboDisplayMode.SelectedIndexChanged += comboDisplayMode_SelectedIndexChanged;
            // 
            // labelDisplayMode
            // 
            labelDisplayMode.AutoSize = true;
            labelDisplayMode.Location = new System.Drawing.Point(6, 8);
            labelDisplayMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelDisplayMode.Name = "labelDisplayMode";
            labelDisplayMode.Size = new System.Drawing.Size(38, 15);
            labelDisplayMode.TabIndex = 0;
            labelDisplayMode.Text = "Mode";
            // 
            // labelPartTotal
            // 
            labelPartTotal.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            labelPartTotal.AutoSize = true;
            labelPartTotal.Location = new System.Drawing.Point(315, 8);
            labelPartTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelPartTotal.Name = "labelPartTotal";
            labelPartTotal.Size = new System.Drawing.Size(33, 15);
            labelPartTotal.TabIndex = 4;
            labelPartTotal.Text = "of 10";
            // 
            // editPart
            // 
            editPart.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            editPart.Location = new System.Drawing.Point(247, 6);
            editPart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            editPart.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            editPart.Name = "editPart";
            editPart.Size = new System.Drawing.Size(61, 23);
            editPart.TabIndex = 3;
            editPart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            editPart.Value = new decimal(new int[] { 1, 0, 0, 0 });
            editPart.ValueChanged += editPart_ValueChanged;
            // 
            // labelPart
            // 
            labelPart.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            labelPart.AutoSize = true;
            labelPart.Location = new System.Drawing.Point(210, 8);
            labelPart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelPart.Name = "labelPart";
            labelPart.Size = new System.Drawing.Size(28, 15);
            labelPart.TabIndex = 2;
            labelPart.Text = "Part";
            // 
            // pictureBox
            // 
            pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            pictureBox.Location = new System.Drawing.Point(0, 0);
            pictureBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new System.Drawing.Size(767, 599);
            pictureBox.TabIndex = 0;
            pictureBox.Paint += PictureBox_Paint;
            pictureBox.MouseClick += PictureBox_MouseClick;
            pictureBox.MouseDoubleClick += PictureBox_MouseDoubleClick;
            pictureBox.MouseMove += PictureBox_MouseMove;
            pictureBox.Resize += PictureBox_Resize;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { statusLocation, statusProgressBar });
            statusStrip.Location = new System.Drawing.Point(0, 623);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            statusStrip.Size = new System.Drawing.Size(1155, 22);
            statusStrip.TabIndex = 0;
            // 
            // statusLocation
            // 
            statusLocation.Name = "statusLocation";
            statusLocation.Size = new System.Drawing.Size(0, 17);
            // 
            // statusProgressBar
            // 
            statusProgressBar.Name = "statusProgressBar";
            statusProgressBar.Size = new System.Drawing.Size(292, 18);
            statusProgressBar.Visible = false;
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, viewToolStripMenuItem, exportToolStripMenuItem1, processToolStripMenuItem });
            menuStrip.Location = new System.Drawing.Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            menuStrip.Size = new System.Drawing.Size(1155, 24);
            menuStrip.TabIndex = 1;
            menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { openiocFileToolStripMenuItem, saveAsToolStripMenuItem, toolStripMenuItem1, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // openiocFileToolStripMenuItem
            // 
            openiocFileToolStripMenuItem.Name = "openiocFileToolStripMenuItem";
            openiocFileToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            openiocFileToolStripMenuItem.Text = "Open .ioc File";
            openiocFileToolStripMenuItem.Click += openiocFileToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            saveAsToolStripMenuItem.Text = "Save As...";
            saveAsToolStripMenuItem.Click += SaveAsToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(143, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { centerToolStripMenuItem, toolStripMenuItem2, zoom50ToolStripMenuItem, zoom100ToolStripMenuItem, zoom200ToolStripMenuItem, zoom400ToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            viewToolStripMenuItem.Text = "View";
            // 
            // centerToolStripMenuItem
            // 
            centerToolStripMenuItem.Name = "centerToolStripMenuItem";
            centerToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Next;
            centerToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            centerToolStripMenuItem.Text = "Fit All Objects";
            centerToolStripMenuItem.Click += CenterToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new System.Drawing.Size(207, 6);
            // 
            // zoom50ToolStripMenuItem
            // 
            zoom50ToolStripMenuItem.Name = "zoom50ToolStripMenuItem";
            zoom50ToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            zoom50ToolStripMenuItem.Tag = "50";
            zoom50ToolStripMenuItem.Text = "50%";
            zoom50ToolStripMenuItem.Click += ZoomToolStripMenuItem_Click;
            // 
            // zoom100ToolStripMenuItem
            // 
            zoom100ToolStripMenuItem.Name = "zoom100ToolStripMenuItem";
            zoom100ToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            zoom100ToolStripMenuItem.Tag = "100";
            zoom100ToolStripMenuItem.Text = "100%";
            zoom100ToolStripMenuItem.Click += ZoomToolStripMenuItem_Click;
            // 
            // zoom200ToolStripMenuItem
            // 
            zoom200ToolStripMenuItem.Name = "zoom200ToolStripMenuItem";
            zoom200ToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            zoom200ToolStripMenuItem.Tag = "200";
            zoom200ToolStripMenuItem.Text = "200%";
            zoom200ToolStripMenuItem.Click += ZoomToolStripMenuItem_Click;
            // 
            // zoom400ToolStripMenuItem
            // 
            zoom400ToolStripMenuItem.Name = "zoom400ToolStripMenuItem";
            zoom400ToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            zoom400ToolStripMenuItem.Tag = "400";
            zoom400ToolStripMenuItem.Text = "400%";
            zoom400ToolStripMenuItem.Click += ZoomToolStripMenuItem_Click;
            // 
            // exportToolStripMenuItem1
            // 
            exportToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { exportFootprintToolStripMenuItem1, exportPrimitiveToolStripMenuItem, exportImageToolStripMenuItem, testToolStripMenuItem });
            exportToolStripMenuItem1.Name = "exportToolStripMenuItem1";
            exportToolStripMenuItem1.Size = new System.Drawing.Size(54, 20);
            exportToolStripMenuItem1.Text = "Debug";
            // 
            // exportFootprintToolStripMenuItem1
            // 
            exportFootprintToolStripMenuItem1.Name = "exportFootprintToolStripMenuItem1";
            exportFootprintToolStripMenuItem1.Size = new System.Drawing.Size(178, 22);
            exportFootprintToolStripMenuItem1.Text = "Export footprint";
            exportFootprintToolStripMenuItem1.Click += ExportFootprintToolStripMenuItem1_Click;
            // 
            // exportPrimitiveToolStripMenuItem
            // 
            exportPrimitiveToolStripMenuItem.Name = "exportPrimitiveToolStripMenuItem";
            exportPrimitiveToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            exportPrimitiveToolStripMenuItem.Text = "Export primitive";
            exportPrimitiveToolStripMenuItem.Click += ExportPrimitiveToolStripMenuItem_Click;
            // 
            // exportImageToolStripMenuItem
            // 
            exportImageToolStripMenuItem.Name = "exportImageToolStripMenuItem";
            exportImageToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            exportImageToolStripMenuItem.Text = "Export image";
            exportImageToolStripMenuItem.Click += ExportImageToolStripMenuItem_Click;
            // 
            // testToolStripMenuItem
            // 
            testToolStripMenuItem.Name = "testToolStripMenuItem";
            testToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            testToolStripMenuItem.Text = "Test SchLib creation";
            testToolStripMenuItem.Click += testToolStripMenuItem_Click;
            // 
            // processToolStripMenuItem
            // 
            processToolStripMenuItem.Name = "processToolStripMenuItem";
            processToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            processToolStripMenuItem.Text = "Process";
            // 
            // openFileDialog
            // 
            openFileDialog.Filter = "Supported files|*.pcblib;*.schlib;*.schdoc|PcbLib files|*.pcblib|SchLib files|*.schlib|SchDoc files|*.schdoc|All files|*.*";
            // 
            // saveFileDialog
            // 
            saveFileDialog.DefaultExt = "bin";
            saveFileDialog.Filter = "Schematic Library|*.schlib;";
            // 
            // redrawTimer
            // 
            redrawTimer.Interval = 500;
            redrawTimer.Tick += RedrawTimer_Tick;
            // 
            // Main
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1155, 645);
            Controls.Add(splitContainer1);
            Controls.Add(menuStrip);
            Controls.Add(statusStrip);
            MainMenuStrip = menuStrip;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "Main";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Library Viewer";
            Load += Main_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tabComponents.ResumeLayout(false);
            tabSchLib.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridSchLibComponents).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridSchLibPrimitives).EndInit();
            panelPart.ResumeLayout(false);
            panelPart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)editPart).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exportFootprintToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exportPrimitiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportImageToolStripMenuItem;
        private System.Windows.Forms.Panel pictureBox;
        private System.Windows.Forms.ToolStripStatusLabel statusLocation;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem centerToolStripMenuItem;
        private System.Windows.Forms.Timer redrawTimer;
        private System.Windows.Forms.TabControl tabComponents;
        private System.Windows.Forms.TabPage tabSchLib;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.DataGridView gridSchLibComponents;
        private System.Windows.Forms.DataGridView gridSchLibPrimitives;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridSchLibComponentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridSchLibComponentDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridSchLibPrimitiveDescriptor;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridSchLibPrimitiveName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridSchLibPrimitiveType;
        private System.Windows.Forms.ToolStripMenuItem zoom100ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem zoom50ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoom200ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoom400ToolStripMenuItem;
        private System.Windows.Forms.Panel panelPart;
        private System.Windows.Forms.NumericUpDown editPart;
        private System.Windows.Forms.Label labelPart;
        private System.Windows.Forms.Label labelPartTotal;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboDisplayMode;
        private System.Windows.Forms.Label labelDisplayMode;
        private System.Windows.Forms.ToolStripProgressBar statusProgressBar;
        private System.Windows.Forms.ToolStripMenuItem openiocFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processToolStripMenuItem;
    }
}

