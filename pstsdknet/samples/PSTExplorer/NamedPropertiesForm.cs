using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using pstsdk.layer.ltp.nameid;

namespace PSTExplorer
{
    public partial class NamedPropertiesForm : Form
    {
        private NameIdMap _nameIdMap;

        public NamedPropertiesForm(NameIdMap nameIdMap)
        {
            InitializeComponent();

            _nameIdMap = nameIdMap;
        }

        private void NamedPropertiesForm_Load(object sender, EventArgs e)
        {
            foreach(var prop in _nameIdMap.NamedProperties)
            {
                var item = new ListViewItem { Text = _nameIdMap.Lookup(prop).ToString() };

                item.SubItems.Add(prop.IsString ? prop.Name : ("0x" + prop.ID.ToString("X8")));
                item.SubItems.Add(prop.Guid.ToString());

                namedPropertiesList.Items.Add(item);
            }
        }
    }
}
