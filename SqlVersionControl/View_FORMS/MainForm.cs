using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Telerik.WinControls.UI;
using View_FORMS.Data;

namespace View_FORMS
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SetImages();
            this.Text += "  ";

        }

        void UpdateListChanges(string objectType)
        {
            var lst = DataAccess.GetLastChanges(objectType);
            RadTreeView tree;
            switch (objectType)
            {
                case "table": tree = tb_treeview; break;
                case "procedure": tree = sp_treeview; break;
                case "view": tree = vw_treeview; break;
                case "function": tree = fn_treeview; break;
                case "trigger": tree = tr_treeview; break;
                default: throw new Exception("Не верно указан тип объекта базы данных");
            }

            FillTreeView(lst, tree);
        }
        void SearchListChanges(string objectType, TextBox control)
        {

            RadTreeView tree;
            switch (objectType)
            {
                case "table": tree = tb_treeview; break;
                case "procedure": tree = sp_treeview; break;
                case "view": tree = vw_treeview; break;
                case "function": tree = fn_treeview; break;
                case "trigger": tree = tr_treeview; break;
                default: throw new Exception("Не верно указан тип объекта базы данных");
            }


            var lst = DataAccess.GetLastChanges(objectType, control.Text);

            if (lst.Count > 0)
                control.BackColor = Color.Aquamarine;
            else
            {
                control.BackColor = Color.DarkSalmon;
                return;
            }

            FillTreeView(lst, tree);
        }
        void FillTreeView(IEnumerable data, RadTreeView treeView)
        {
            treeView.Nodes.Clear();
            foreach (var item in data)
            {
                var nodes = treeView.Nodes.Add(item.ToString(), item.ToString(), 1);
                nodes.CheckType = CheckType.None;
                foreach (var itemData in DataAccess.GetLastChangesData(item.ToString()))
                {
                    nodes.Nodes.Add(new RadTreeNode()
                    {
                        Value = itemData,
                        Text = itemData.EventTime.ToString()
                    });
                }
            }
        }
        void SetImages()
        {
            sp_treeview.ImageList = new ImageList();
            sp_treeview.ImageList.Images.Add(View_FORMS.Properties.Resources._2620532___calendar_employee_job_seeker_unemployee_work);
            sp_treeview.ImageList.Images.Add(View_FORMS.Properties.Resources._2620517___employee_idea_job_seeker_unemployee_work);

            fn_treeview.ImageList = new ImageList();
            fn_treeview.ImageList.Images.Add(View_FORMS.Properties.Resources._2620532___calendar_employee_job_seeker_unemployee_work);
            fn_treeview.ImageList.Images.Add(View_FORMS.Properties.Resources._1918___book_contents);

            vw_treeview.ImageList = new ImageList();
            vw_treeview.ImageList.Images.Add(View_FORMS.Properties.Resources._2620532___calendar_employee_job_seeker_unemployee_work);
            vw_treeview.ImageList.Images.Add(View_FORMS.Properties.Resources._103828___blackboard);

            tb_treeview.ImageList = new ImageList();
            tb_treeview.ImageList.Images.Add(View_FORMS.Properties.Resources._2620532___calendar_employee_job_seeker_unemployee_work);
            tb_treeview.ImageList.Images.Add(View_FORMS.Properties.Resources._30475___chart_spreadsheet);

            tr_treeview.ImageList = new ImageList();
            tr_treeview.ImageList.Images.Add(View_FORMS.Properties.Resources._2620532___calendar_employee_job_seeker_unemployee_work);
            tr_treeview.ImageList.Images.Add(View_FORMS.Properties.Resources._897238___communicate_connectio);

            tabControl1.ImageList = new ImageList();
            tabControl1.ImageList.Images.Add(View_FORMS.Properties.Resources._2620517___employee_idea_job_seeker_unemployee_work);
            tabControl1.ImageList.Images.Add(View_FORMS.Properties.Resources._1918___book_contents);
            tabControl1.ImageList.Images.Add(View_FORMS.Properties.Resources._103828___blackboard);
            tabControl1.ImageList.Images.Add(View_FORMS.Properties.Resources._30475___chart_spreadsheet);
            tabControl1.ImageList.Images.Add(View_FORMS.Properties.Resources._897238___communicate_connectio);
            tabControl1.ImageList.Images.Add(View_FORMS.Properties.Resources._1320807___chart_diagram_graph_p);

            int i = 0;
            foreach (TabPage tab in tabControl1.TabPages)
            {
                tab.ImageIndex = i;
                i++;
            }
        }

        private void update_sp_btn_Click(object sender, EventArgs e)
        {
            UpdateListChanges("procedure");
        }
        private void update_fn_btn_Click(object sender, EventArgs e)
        {
            UpdateListChanges("function");
        }
        private void update_vw_btn_Click(object sender, EventArgs e)
        {
            UpdateListChanges("view");
        }
        private void update_tb_btn_Click(object sender, EventArgs e)
        {
            UpdateListChanges("table");
        }
        private void update_tr_btn_Click(object sender, EventArgs e)
        {
            UpdateListChanges("trigger");
        }

        private void radTreeView_SelectedNodeChanged(object sender, RadTreeViewEventArgs e)
        {
            var treeElement = sender as RadTreeViewElement;
            if (treeElement.SelectedNode == null)
            {
                return;

            }
            var tree = treeElement.SelectedNode.TreeView;
            StringBuilder sb = new StringBuilder();
            string commandText = string.Empty;

            if (e.Node != null && e.Node.Selected)
            {
                if (tree.SelectedNode.Parent == null)
                {
                    var spinfo = DataAccess.GetLastChangesData(tree.SelectedNode.Text).FirstOrDefault();

                    XElement xmlTree;
                    using (TextReader sr = new StringReader(spinfo.XMLChange))
                    {
                        xmlTree = XElement.Load(sr);
                    }

                    var elemets = xmlTree.Elements();
                    var db = elemets.FirstOrDefault(x => x.Name == "DatabaseName");
                    var TargetObjectName = elemets.FirstOrDefault(x => x.Name == "TargetObjectName");
                    var TargetObjectType = elemets.FirstOrDefault(x => x.Name == "TargetObjectType");
                    sb = new StringBuilder();
                    sb.AppendLine(string.Format("DataBase:  \t\t\t{0}", db.Value));

                    if (TargetObjectName != null)
                        sb.AppendLine(string.Format("Target Object Name:\t{0}", TargetObjectName.Value));
                    if (TargetObjectType != null)
                        sb.AppendLine(string.Format("Target Object Type: \t{0}", TargetObjectType.Value));
                }
                else if (e.Node != null)
                {
                    var spinfoNode = tree.SelectedNode;
                    var change = spinfoNode.Value as tbl_ListChange;
                    XElement xmlTree;

                    using (TextReader sr = new StringReader(change.XMLChange))
                    {
                        xmlTree = XElement.Load(sr);
                    }

                    var elemets = xmlTree.Elements();
                    var db = elemets.FirstOrDefault(x => x.Name == "DatabaseName");
                    var login = elemets.FirstOrDefault(x => x.Name == "LoginName");
                    var eventtype = elemets.FirstOrDefault(x => x.Name == "EventType");
                    var postTme = elemets.FirstOrDefault(x => x.Name == "PostTime");
                    var commandNode = elemets.FirstOrDefault(x => x.Name == "TSQLCommand");
                    commandText = commandNode.Elements().FirstOrDefault(x => x.Name == "CommandText").Value;
                    var TargetObjectName = elemets.FirstOrDefault(x => x.Name == "TargetObjectName");
                    var TargetObjectType = elemets.FirstOrDefault(x => x.Name == "TargetObjectType");

                    sb = new StringBuilder();
                    sb.AppendLine(string.Format("DataBase:  \t\t\t{0}", db.Value));
                    sb.AppendLine(string.Format("LoginName:\t\t\t{0}", login.Value));
                    sb.AppendLine(string.Format("EventType: \t\t\t{0}", eventtype.Value));

                    if (TargetObjectName != null)
                        sb.AppendLine(string.Format("Target Object Name:\t{0}", TargetObjectName.Value));
                    if (TargetObjectType != null)
                        sb.AppendLine(string.Format("Target Object Type: \t{0}", TargetObjectType.Value));

                    sb.AppendLine(string.Format("PostTme:    \t\t\t{0}", postTme.Value));
                    sb.AppendLine(string.Format("IP:        \t\t\t\t{0}", change.IP_address));


                }

                switch (tree.Name)
                {
                    case "sp_treeview":
                        {
                            sp_info_txbx.Text = sb.ToString();
                            sp_text_txbx.Text = commandText;
                        }
                        break;
                    case "fn_treeview":
                        {
                            fn_info_txbx.Text = sb.ToString();
                            fn_text_txbx.Text = commandText;
                        }
                        break;
                    case "vw_treeview":
                        {
                            view_info_txbx.Text = sb.ToString();
                            view_tetx_txbx.Text = commandText;
                        }
                        break;
                    case "tb_treeview":
                        {
                            tb_info_txbx.Text = sb.ToString();
                            tb_text_txbx.Text = commandText;
                        }
                        break;
                    case "tr_treeview":
                        {
                            tr_info_txbx.Text = sb.ToString();
                            tr_text_txbx.Text = commandText;
                        }
                        break;
                }
            }
        }

        private void compare_btn_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView2.Items.Clear();
            var btn = sender as Button;
            CheckedTreeNodeCollection select_list = null;
            switch (btn.Name)
            {
                case "compare_sp_btn": select_list = sp_treeview.CheckedNodes; break;
                case "compare_fn_btn": select_list = fn_treeview.CheckedNodes; break;
                case "compare_vw_btn": select_list = vw_treeview.CheckedNodes; break;
                case "compare_tb_btn": select_list = tb_treeview.CheckedNodes; break;
                case "compare_tr_btn": select_list = tr_treeview.CheckedNodes; break;

            }
            if (select_list.Count == 2)
            {
                tbl_ListChange sp1, sp2;
                sp1 = select_list[0].Value as tbl_ListChange;
                sp2 = select_list[1].Value as tbl_ListChange;

                var ex1 = sp1.Lines.Except(sp2.Lines, new CommandLinesComparer()).Select(x => x.LineNumber);
                var ex2 = sp2.Lines.Except(sp1.Lines, new CommandLinesComparer()).Select(x => x.LineNumber);

                foreach (var s in sp1.Lines)
                {

                    var i = listView1.Items.Add(s.LineNumber.ToString());
                    i.SubItems.Add(s.LineString);
                    if (ex1.Contains(s.LineNumber))
                    {
                        i.BackColor = Color.LightPink;
                    }
                }

                foreach (var s in sp2.Lines)
                {

                    var i = listView2.Items.Add(s.LineNumber.ToString());
                    i.SubItems.Add(s.LineString);
                    if (ex2.Contains(s.LineNumber))
                    {
                        i.BackColor = Color.LightPink;
                    }
                }

                tabControl1.SelectedTab = tabPage2;
            }
            else MessageBox.Show("Необходимо выбрать 2 объекта для сравнения друг с другом"
                , "Упс.."
                , MessageBoxButtons.OK
                , MessageBoxIcon.Warning);
        }
        private void search_txbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            var control = sender as TextBox;
            string objectType = string.Empty;
            switch (control.Name)
            {
                case "search_sp_txbx": objectType = "procedure";
                    break;
                case "search_fn_txbx": objectType = "function";
                    break;
                case "search_vw_txbx": objectType = "view";
                    break;
                case "tb_search_txbx": objectType = "table";
                    break;
                case "tr_search_txbx": objectType = "trigger";
                    break;
                default: throw new Exception("Не верно указан тип объекта базы данных");
            }

            if (e.KeyChar == '\r')
            {
                if (control.Text.Trim().Length == 0)
                {
                    control.BackColor = Color.White;
                    UpdateListChanges(objectType);
                    return;
                }

                SearchListChanges(objectType, control);
            }
        }
        private void radTreeView_NodeCheckedChanging(object sender, RadTreeViewCancelEventArgs e)
        {
            var checkedNodes = e.TreeView.CheckedNodes;
            var checkedNodeThisParent = checkedNodes.Where(x => x.Parent == e.Node.Parent).ToList();
            if (!e.Node.Checked)
            {
                var checkedOtherItems = checkedNodes.Where(x => x.Parent != e.Node.Parent).ToList();
                foreach (var node in checkedOtherItems)
                {
                    node.Checked = false;
                }

                if (checkedNodeThisParent.Count >= 2)
                {
                    e.Cancel = true;
                }
            }
        }

        async private void MainForm_Load(object sender, EventArgs e)
        {
            Action act = new Action(() => DataAccess.GetChanges(1));
            await Task.Run(act);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RadAboutBox1 about = new RadAboutBox1();
            about.ShowDialog();
        }
    }
}
