using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using Be.Windows.Forms;
using PropertyInfoDataProvider;
using pstsdk.definition.ltp;
using pstsdk.definition.util.primitives;
using pstsdk.mcpp.util.prop;

namespace PSTExplorer
{
    public partial class PropertiesForm : Form
    {
        public delegate void PropertyPopulator(IPropertyObject propertyBag, MessageClass objectType);
        public PropertyPopulator PopulatePropertyList;

        private PropertyInfoProvider _dataProvider = new PropertyInfoProvider();
        private IPropertyObject _propertyObject;

        public PropertiesForm()
        {
            InitializeComponent();
            PopulatePropertyList = PopulateProperties;
        }

        private string GetFormattedStringFromProperty(Byte[] propertyBytes, PropertyType type)
        {
            string value = String.Empty;

            switch ((PropertyType.KnownValue)type)
            {
                case PropertyType.KnownValue.prop_type_apptime:
                    value = "App Time: " + PropertyHelper.GetFloatingTimeProperty(propertyBytes);
                    break;
                case PropertyType.KnownValue.prop_type_systime:
                    value =  "System Time: " + PropertyHelper.GetTimeProperty(propertyBytes);
                    break;
                case PropertyType.KnownValue.prop_type_boolean:
                    value = Convert.ToBoolean(propertyBytes[0]) ? "True" : "False";
                    break;
                case PropertyType.KnownValue.prop_type_currency:
                    value = "$" + PropertyHelper.GetDoubleProperty(propertyBytes);
                    break;
                case PropertyType.KnownValue.prop_type_guid:
                    value = "Guid: " + PropertyHelper.GetGuidProperty(propertyBytes).ToString("B");
                    break;
                case PropertyType.KnownValue.prop_type_double:
                    value = PropertyHelper.GetDoubleProperty(propertyBytes).ToString();
                    break;
                case PropertyType.KnownValue.prop_type_float:
                    value = PropertyHelper.GetFloatProperty(propertyBytes).ToString();
                    break;
                case PropertyType.KnownValue.prop_type_short:
                    value = PropertyHelper.GetInt16Property(propertyBytes).ToString();
                    break;
                case PropertyType.KnownValue.prop_type_long:
                    value = PropertyHelper.GetInt32Property(propertyBytes).ToString();
                    break;
                case PropertyType.KnownValue.prop_type_longlong:
                    value = PropertyHelper.GetInt64Property(propertyBytes).ToString();
                    break;
                case PropertyType.KnownValue.prop_type_error:
                    value = "Error Code: " + PropertyHelper.GetInt32Property(propertyBytes);
                    break;
                case PropertyType.KnownValue.prop_type_string:
                    value = Encoding.ASCII.GetString(propertyBytes);
                    break;
                case PropertyType.KnownValue.prop_type_wstring:
                    value = Encoding.Unicode.GetString(propertyBytes);
                    break;
                case PropertyType.KnownValue.prop_type_binary:
                    //value = String.Join(" ", Array.ConvertAll(propertyBytes, x => "0x" + x.ToString("X2")));
                    value = String.Join(" ", Array.ConvertAll(propertyBytes, x => x.ToString("X2")));
                    break;
                default:
                    value = "Null or Not Supported";
                    break;
            }

            return value;
        }

        private void PopulateProperties(IPropertyObject propertyBag, MessageClass objectType)
        {
            lvProperties.Items.Clear();
            hexBox1.ByteProvider = null;
            _propertyObject = propertyBag;

            foreach (PropId prop in propertyBag.Properties)
            {
                try
                {
                    var propertyItem = new ListViewItem();

                    var propertyInfo = _dataProvider.GetPropertyInformation(prop, objectType);
                    if(propertyInfo != null)
                    {
                        propertyItem.Tag = propertyInfo;
                        propertyItem.Text = propertyInfo.PropertyName;

                        var toolTipText = new StringBuilder();
                        toolTipText.AppendLine(string.Format("Value: 0x{0:X4}", propertyInfo.PropertyId));
                        toolTipText.AppendLine(string.Format("Type: {0}", propertyInfo.DataType));
                        toolTipText.AppendLine(string.Format("Description {0}", propertyInfo.Description));

                        propertyItem.ToolTipText = toolTipText.ToString();
                    }
                    else
                    {
                        //propertyItem.Tag = new PropertyInformation(prop);
                        propertyItem.Text = "0x" + prop.Value.ToString("X4");
                        propertyItem.Tag = prop;
                    }

                    var size = new ListViewItem.ListViewSubItem(propertyItem, propertyBag.PropertySize(prop).ToString());
                    propertyItem.SubItems.Add(size);

                    lvProperties.Items.Add(propertyItem);
                }
                catch (Exception)
                {
                    var id = new ListViewItem("0x" + prop.Value.ToString("X4"));

                    var size = new ListViewItem.ListViewSubItem(id, propertyBag.PropertySize(prop).ToString());
                    id.SubItems.Add(size);
                    id.Tag = prop;

                    lvProperties.Items.Add(id);
                }
            }
        }

        private void PropertiesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            lvProperties.Items.Clear();
            e.Cancel = true;
        }

        private void lvProperties_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvProperties.SelectedItems.Count < 1) return;
            try
            {


                try
                {
                    PropId prop = ((IPropertyInformation)lvProperties.SelectedItems[0].Tag).PropertyId;

                    var bytes = _propertyObject.ReadProperty(prop);

                    var byteProvider = new DynamicByteProvider(bytes);
                    hexBox1.ByteProvider = byteProvider;
                }
                catch (InvalidCastException)
                {
                    var prop = (PropId) lvProperties.SelectedItems[0].Tag;
                    var bytes = _propertyObject.ReadProperty(prop);

                    var byteProvider = new DynamicByteProvider(bytes);
                    hexBox1.ByteProvider = byteProvider;
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
