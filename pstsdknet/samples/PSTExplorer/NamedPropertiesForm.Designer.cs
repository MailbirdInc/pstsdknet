namespace PSTExplorer
{
    partial class NamedPropertiesForm
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
            this.namedPropertiesList = new System.Windows.Forms.ListView();
            this.propertyIdColumn = new System.Windows.Forms.ColumnHeader();
            this.idColumn = new System.Windows.Forms.ColumnHeader();
            this.guidColumn = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // namedPropertiesList
            // 
            this.namedPropertiesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.propertyIdColumn,
            this.idColumn,
            this.guidColumn});
            this.namedPropertiesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.namedPropertiesList.Location = new System.Drawing.Point(0, 0);
            this.namedPropertiesList.Name = "namedPropertiesList";
            this.namedPropertiesList.Size = new System.Drawing.Size(576, 284);
            this.namedPropertiesList.TabIndex = 1;
            this.namedPropertiesList.UseCompatibleStateImageBehavior = false;
            this.namedPropertiesList.View = System.Windows.Forms.View.Details;
            // 
            // propertyIdColumn
            // 
            this.propertyIdColumn.Text = "Property ID";
            this.propertyIdColumn.Width = 100;
            // 
            // idColumn
            // 
            this.idColumn.Text = "Name/ID";
            this.idColumn.Width = 100;
            // 
            // guidColumn
            // 
            this.guidColumn.Text = "Guid:";
            this.guidColumn.Width = 100;
            // 
            // NamedPropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 284);
            this.Controls.Add(this.namedPropertiesList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NamedPropertiesForm";
            this.Text = "Name To ID Map/Properties";
            this.Load += new System.EventHandler(this.NamedPropertiesForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView namedPropertiesList;
        private System.Windows.Forms.ColumnHeader propertyIdColumn;
        private System.Windows.Forms.ColumnHeader idColumn;
        private System.Windows.Forms.ColumnHeader guidColumn;

    }
}