using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
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
        private List<NodeTree> nodeTrees;
        private List<NodeTree> nodeTrees1;
        public MainWindow()
        {
            InitializeComponent();
            nodeTrees = new List<NodeTree>();
            nodeTrees1 = new List<NodeTree>();
            Read("C:\\Users\\gadzhiev\\Documents\\out.txt", treeStruct, ref nodeTrees);
            Read("C:\\Users\\gadzhiev\\Documents\\out1.txt", treeStructNew, ref nodeTrees1);
            analizing(nodeTrees, nodeTrees1);
        }

        private void Read(string path, TreeView treeView, ref List<NodeTree> nodeTrees)
        {
            StreamReader stream = null;
            try
            {
                stream = new StreamReader(path);
                while (!stream.EndOfStream)
                {
                    try
                    {
                        var s = stream.ReadLine();
                        string[] stringArray = s.Split('%');
                        TechFileTreeViewItem techFile = new TechFileTreeViewItem() { NameText = stringArray[0] };
                        if (stringArray.Length > 1)
                        {
                            var parent = FindParent(ref nodeTrees, stringArray[1]);
                            
                            NodeTree nodeTree = new NodeTree(techFile, parent, stringArray[0]);
                            parent.TreeViewItem.Items.Add(techFile);
                            nodeTrees.Add(nodeTree);
                        }
                        else
                        {
                            treeView.Items.Add(techFile);

                            NodeTree nodeTree = new NodeTree(techFile, null, stringArray[0]);
                            nodeTrees.Add(nodeTree);
                        }
                    }catch(Exception ex) { }
                    
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

        private NodeTree FindParent(ref List<NodeTree> nodeTrees, string parent)
        {
            return nodeTrees.Where(n => n.Name == parent).First();
        }

        private void analizing(List<NodeTree> oneTrees, List<NodeTree> twoTrees)
        {
            foreach(NodeTree nodeTree in oneTrees)
            {
                var findedNodeInTwo = twoTrees.Where(node => node.Name.Equals(nodeTree.Name)).FirstOrDefault();
                if(findedNodeInTwo != null)
                {
                    if (findedNodeInTwo.Parent != null && nodeTree.Parent != null)
                    {
                        if (findedNodeInTwo.Parent.Name.Equals(nodeTree.Parent.Name))
                        {
                            findedNodeInTwo.TreeViewItem.setNoAction();
                            //nodeTree.TreeViewItem.setNoAction();
                        }
                    }
                }
                else
                {
                    nodeTree.TreeViewItem.setDelete();
                }

                
            }

            foreach(NodeTree nodeTree in twoTrees)
            {
                var findedNodeInOne = oneTrees.Where(node => node.Name.Equals(nodeTree.Name)).FirstOrDefault();
                if(findedNodeInOne!= null)
                {
                    if(findedNodeInOne.Parent != null && nodeTree.Parent != null)
                    {
                        if(findedNodeInOne.Parent.Name.Equals(nodeTree.Parent.Name)) {
                            findedNodeInOne.TreeViewItem.setNoAction();
                        }
                    }
                }
                else
                {
                    nodeTree.TreeViewItem.setAdded();
                }
            }
        }
    }
}
