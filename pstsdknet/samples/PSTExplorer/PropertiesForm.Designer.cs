namespace PSTExplorer
{
    partial class PropertiesForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.hexBox1 = new Be.Windows.Forms.HexBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lvProperties = new System.Windows.Forms.ListView();
            this.propID = new System.Windows.Forms.ColumnHeader();
            this.propSize = new System.Windows.Forms.ColumnHeader();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.hexBox1);
            this.splitContainer1.Size = new System.Drawing.Size(649, 623);
            this.splitContainer1.SplitterDistance = 271;
            this.splitContainer1.TabIndex = 1;
            // 
            // hexBox1
            // 
            this.hexBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hexBox1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hexBox1.LineInfoForeColor = System.Drawing.Color.Empty;
            this.hexBox1.LineInfoVisible = true;
            this.hexBox1.Location = new System.Drawing.Point(0, 0);
            this.hexBox1.Name = "hexBox1";
            this.hexBox1.ReadOnly = true;
            this.hexBox1.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hexBox1.Size = new System.Drawing.Size(649, 348);
            this.hexBox1.StringViewVisible = true;
            this.hexBox1.TabIndex = 1;
            this.hexBox1.UseFixedBytesPerLine = true;
            this.hexBox1.VScrollBarVisible = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lvProperties);
            this.splitContainer2.Size = new System.Drawing.Size(649, 271);
            this.splitContainer2.SplitterDistance = 322;
            this.splitContainer2.TabIndex = 0;
            // 
            // lvProperties
            // 
            this.lvProperties.AllowColumnReorder = true;
            this.lvProperties.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.propID,
            this.propSize});
            this.lvProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvProperties.FullRowSelect = true;
            this.lvProperties.Location = new System.Drawing.Point(0, 0);
            this.lvProperties.Name = "lvProperties";
            this.lvProperties.ShowItemToolTips = true;
            this.lvProperties.Size = new System.Drawing.Size(322, 271);
            this.lvProperties.TabIndex = 1;
            this.lvProperties.UseCompatibleStateImageBehavior = false;
            this.lvProperties.View = System.Windows.Forms.View.Details;
            this.lvProperties.SelectedIndexChanged += new System.EventHandler(this.lvProperties_SelectedIndexChanged);
            // 
            // propID
            // 
            this.propID.Text = "ID";
            this.propID.Width = 127;
            // 
            // propSize
            // 
            this.propSize.Text = "Size";
            this.propSize.Width = 100;
            // 
            // PropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 623);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "PropertiesForm";
            this.Text = "Properties";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PropertiesForm_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Be.Windows.Forms.HexBox hexBox1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView lvProperties;
        private System.Windows.Forms.ColumnHeader propID;
        private System.Windows.Forms.ColumnHeader propSize;
    }
}