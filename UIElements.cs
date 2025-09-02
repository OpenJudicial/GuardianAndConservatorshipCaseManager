using GnC.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GnC
{
    internal class UIElements
    {
        public static int SEARCHRESULTLABELHEIGHT = 80;

        public static Control FindControlByName(Control container, string name)
        {
            foreach (Control child in container.Controls) if (child.Name == name) return child;
            return null;
        }

        public static int AttrValueWidth(TabPage tabPage) { return tabPage.Width < 600 ? tabPage.Width - 300 : tabPage.Width / 2; }

        public static Label CreateLabel(int yPosition, int width)
        {
            Label label = new Label();

            label.Location = new Point(10, yPosition);
            label.AutoSize = false;
            label.Size = new Size(width, SEARCHRESULTLABELHEIGHT); // Fixed height for consistent appearance
            label.BorderStyle = BorderStyle.FixedSingle;
            label.ImageAlign = ContentAlignment.TopLeft;
            label.BackColor = Color.FromArgb(45, 45, 48);
            label.ForeColor = Color.White;
            label.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            label.Padding = new Padding(8);
            label.TextAlign = ContentAlignment.TopLeft;

            // Add hover effect
            label.MouseEnter += (s, e) => { label.BackColor = Color.FromArgb(55, 55, 58); };
            label.MouseLeave += (s, e) => { label.BackColor = Color.FromArgb(45, 45, 48); };

            return label;
        }

        public static Label CreateResultLabel(SearchResult result, int yPosition, int width)
        {
            Label label = CreateLabel(yPosition, width);

            string labelText = "Click To See More Records";
            if (result != null)
            {
                if (result.IsParty) labelText = $"{result.FirstName} {result.LastName}\nAge {result.Age}\nCreated Date: {result.CreatedDate}";
                else labelText = $"{result.CaseNo}    {result.CaseStyle}\nDistrict {result.District}, Date Filed: {result.DateFiled}\nCase Type: [{result.CaseType}], Case Category: [{result.CaseCategory}], Security Groups: [{result.SecurityGroups}]";
            }
            label.Text = labelText;
            label.Size = new Size(width, result == null ? 40 : SEARCHRESULTLABELHEIGHT); // Fixed height for consistent appearance
            if (result != null && Program.StarredCases.ContainsKey("" + result.ID))
            { // starred
                label.Text = "    " + label.Text;
                label.Image = Resources.star16;
            }
            label.ForeColor = (result == null) ? Color.FromArgb(88, 184, 254) : Color.White;
            if (result == null)
            {
                label.Cursor = Cursors.Hand;
                label.Name = "seymour";
            }

            return label;
        }

        public static Label CreateAttributeLabel(int ID, string txt, int yPosition, int left)
        {
            Label label = new Label();
            label.Text = txt;
            label.Location = new Point(0, yPosition);
            label.AutoSize = false;
            label.Size = new Size(300, 25); // Fixed height for consistent appearance
            label.BorderStyle = BorderStyle.FixedSingle;
            label.BackColor = Color.FromArgb(45, 45, 48);
            label.ForeColor = Color.White;
            label.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            label.Tag = ID;
            label.Padding = new Padding(2);

            // Handle text wrapping and vertical alignment
            label.TextAlign = ContentAlignment.TopLeft;

            // Add hover effect
            label.MouseEnter += (s, e) => { label.BackColor = Color.FromArgb(55, 55, 58); };
            label.MouseLeave += (s, e) => { label.BackColor = Color.FromArgb(45, 45, 48); };

            // Add click event for selection
            label.Click += (s, e) =>
            {
                MessageBox.Show($"Selected #{label.Tag}:", "Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            return label;
        }

        public static Label CreateAttributeValueLabel(int ID, string txt, int yPosition, int left, TabPage parent, string value = null)
        {
            Label label = new Label();
            label.Text = txt;
            label.Location = new Point(300, yPosition);
            label.AutoSize = false;
            label.Size = new Size(AttrValueWidth(parent), 25); // Fixed height for consistent appearance
            label.BorderStyle = BorderStyle.FixedSingle;
            label.BackColor = Color.FromArgb(45, 45, 48);
            label.ForeColor = Color.White;
            label.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            label.Tag = ID;
            label.Name = "AttributeValue_" + ID;
            label.Padding = new Padding(2);

            // Handle text wrapping and vertical alignment
            label.TextAlign = ContentAlignment.TopLeft;

            // Add hover effect
            label.MouseEnter += (s, e) => { label.BackColor = Color.FromArgb(55, 55, 58); };
            label.MouseLeave += (s, e) => { label.BackColor = Color.FromArgb(45, 45, 48); };

            // Add click event for selection
            label.Click += (s, e) =>
            {
                MessageBox.Show($"Selected #{label.Tag}:", "Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            return label;
        }

        public static TextBox CreateAttributeValueTextBox(int ID, string txt, int yPosition, TabPage parent, string value = null)
        {
            TextBox textBox = new TextBox();
            textBox.Text = txt;
            textBox.Location = new Point(300, yPosition);
            textBox.Size = new Size(AttrValueWidth(parent), 25); // width
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.BackColor = Color.FromArgb(45, 45, 48);
            textBox.ForeColor = Color.White;
            textBox.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            textBox.Tag = ID;
            textBox.Name = "AttributeValue_" + ID;
            textBox.Padding = new Padding(2);
            return textBox;
        }
        public static ComboBox CreateAttributeValueComboBox(int ID, string txt, int yPosition, TabPage parent, Dictionary<int, string> possibleValues)
        {
            ComboBox comboBox = new ComboBox();
            comboBox.Location = new Point(300, yPosition);
            comboBox.Size = new Size(AttrValueWidth(parent), 25);
            comboBox.FlatStyle = FlatStyle.Flat;
            comboBox.BackColor = Color.FromArgb(45, 45, 48);
            comboBox.ForeColor = Color.White;
            comboBox.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            comboBox.Tag = ID;
            comboBox.Name = "AttributeValue_" + ID;
            comboBox.Padding = new Padding(2);
            return comboBox;
        }

    }
}
