using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContainerSearch
{
    public partial class MainForm : Form,IContainerView
    {
        public MainForm()
        {
            InitializeComponent();
            listView1.RetrieveVirtualItem += ListView1_RetrieveVirtualItem;
        }

        private void ListView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            var m = Presenter.GetItemAt(e.ItemIndex);
            e.Item = new ListViewItem(m.Code);
            e.Item.SubItems.Add(m.Type);
            e.Item.SubItems.Add(m.HireDate.ToShortDateString());

        }

        public IContainerPresenter Presenter { get; set; }

        private void MainForm_Load(object sender, EventArgs e)
        {
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            Presenter.Initialize();
        }

        public void SetItemsCount(int count)
        {
            listView1.VirtualListSize = count;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Presenter.Search(textBoxSearch.Text);
        }
    }
}
