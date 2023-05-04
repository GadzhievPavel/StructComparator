using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace StructComparator
{
    internal class TechFileTreeViewItem : TreeViewItem
    {
        private TextBlock name = null;
        private TextBlock stage = null;
        private Image imageIcon = null;
        private CheckBox checkSelect = null;

        public TechFileTreeViewItem()
        {
            StackPanel stack = new StackPanel();
            stack.Orientation = Orientation.Horizontal;

            checkSelect = new CheckBox();
            checkSelect.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            checkSelect.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            stack.Children.Add(checkSelect);

            imageIcon = new Image();
            imageIcon.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            imageIcon.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            imageIcon.Margin = new System.Windows.Thickness(2);
            imageIcon.Width = 16;
            imageIcon.Height = 16;
            BitmapImage bitmapImage = new BitmapImage();

            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(@"\res\add.png", UriKind.RelativeOrAbsolute);
            bitmapImage.EndInit();
            imageIcon.Source = bitmapImage;
            stack.Children.Add(imageIcon);

            name = new TextBlock();
            name.Width = 250;
            name.TextWrapping = System.Windows.TextWrapping.Wrap;
            //name.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            name.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            name.Margin = new System.Windows.Thickness(2);

            stack.Children.Add(name);

            stage = new TextBlock();
            stage.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            name.Margin = new System.Windows.Thickness(2);
            stack.Children.Add(stage);

           

            Header = stack;
        }
        public string NameText
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
