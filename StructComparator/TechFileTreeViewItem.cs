using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StructComparator
{
    internal class TechFileTreeViewItem : TreeViewItem
    {
        private TextBlock name = null;
        private TextBlock stage = null;

        public TechFileTreeViewItem()
        {
            StackPanel stack = new StackPanel();
            stack.Orientation = Orientation.Horizontal;

            name = new TextBlock();
            name.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            name.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            name.Margin = new System.Windows.Thickness(5);
            stack.Children.Add(name);

            stage = new TextBlock();
            stage.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            name.Margin = new System.Windows.Thickness(5);
            stack.Children.Add(stage);

            Header = stack;
        }
        public string Name
        {
            get { return name.Text; }
            set { name.Text = value; }
        }

        public string Stage
        {
            get { return stage.Text; }
            set { stage.Text = value; }
        }


    }
}
