using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StructComparator
{
    internal class MyTreeView : TreeView
    {

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
                        Name = stringArray.First()
                    };

                    if (stringArray.Length == 1)
                    {
                        this.Items.Add(viewItem);
                    }
                    else
                    {
                        TechFileTreeViewItem parentItem = null;
                        
                        findItem(Items.GetItemAt(0) as TechFileTreeViewItem, stringArray.Last(), ref parentItem);
                        parentItem.Items.Add(viewItem);
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

        private TechFileTreeViewItem findItem(TechFileTreeViewItem itemCollection, string s, ref TechFileTreeViewItem outtechFile)
        {
            if (itemCollection.Name.Equals(s))
            {
                outtechFile = itemCollection;
                return itemCollection;
            }

            foreach (var item in itemCollection.Items)
            {
                findItem(item as TechFileTreeViewItem, s, ref outtechFile);
            }
            return null;
        }

        public void Load()
        {
            TechFileTreeViewItem viewItem = new TechFileTreeViewItem();
            viewItem.Name = "111";
            Items.Add(viewItem);
        }
    }
}
