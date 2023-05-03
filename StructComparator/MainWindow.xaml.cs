using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StructComparator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Read("C:\\Users\\gadzhiev\\Documents\\out.txt");
            
        }

        public void Read(string path)
        {
            StreamReader stream = null;
            try
            {
                stream = new StreamReader(path);
                while (!stream.EndOfStream)
                {
                    var s = stream.ReadLine();
                    string[] stringArray = s.Split('%');
                    TechFileTreeViewItem viewItem = new TechFileTreeViewItem()
                    {
                        Header = stringArray.First(),
                        Name = stringArray.First()
                    };

                    if (stringArray.Length == 1)
                    {
                        this.treeStruct.Items.Add(viewItem);
                    }
                    else
                    {
                        TechFileTreeViewItem parentItem = null;

                        try
                        {
                            parentItem = SearchTreeView(treeStruct, stringArray.Last()) as TechFileTreeViewItem;
                            parentItem.Items.Add(viewItem);
                        }catch(Exception ex) { }
                    }
                }

            }
            catch (FileNotFoundException)
            {

            }
            finally
            {
                stream.Close();
            }
        }

        private TreeViewItem SearchTreeView(ItemsControl item, string header)
        {
            TreeViewItem foundItem = null;
            foreach (TreeViewItem subItem in item.Items)
                foundItem = subItem.Header.ToString().Contains(header) ? subItem : SearchTreeView(subItem, header);
            return foundItem;
        }



    }
}
