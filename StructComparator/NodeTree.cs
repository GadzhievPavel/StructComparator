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
        private NodeTree parentNode;

        public NodeTree(TechFileTreeViewItem treeViewItem, NodeTree parent, String name)
        {
            this.treeViewItem = treeViewItem;
            this.parentNode = parent;
            this.name = name;
        }

        public TechFileTreeViewItem TreeViewItem
        {
            get { return treeViewItem;}
            set { treeViewItem = value;}
        }

        public NodeTree Parent
        {
            get { return parentNode; }
            set { parentNode = value;}
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
