using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructComparator
{
    internal class NodeTree
    {
        private TechFileTreeViewItem treeViewItem;
        private String name;
        private TechFileTreeViewItem parentTreeViewItem;

        public NodeTree(TechFileTreeViewItem treeViewItem, TechFileTreeViewItem parent, String name)
        {
            this.treeViewItem = treeViewItem;
            this.parentTreeViewItem = parent;
            this.name = name;
        }

        public TechFileTreeViewItem TreeViewItem
        {
            get { return treeViewItem;}
            set { treeViewItem = value;}
        }

        public TechFileTreeViewItem Parent
        {
            get { return parentTreeViewItem; }
            set { parentTreeViewItem = value;}
        }

        public String Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }
    }
}
