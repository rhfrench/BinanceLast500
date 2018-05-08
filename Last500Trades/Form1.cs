using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Last500Trades
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            APIService api = new APIService();
            List<TradeModel> modelList = await api.GetLast500(txtSymbol.Text);

            tradeListView.Items.Clear();
            foreach (TradeModel model in modelList)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.SubItems.Add(txtSymbol.Text);

                new DateTime();
                lvi.SubItems.Add(DateTime.Today.AddTicks(model.Time).ToString());
                lvi.SubItems.Add(model.Price.ToString());
                lvi.SubItems.Add(model.Qty.ToString());

                tradeListView.Items.Add(lvi);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        { 
            tradeListView.View = View.Details;
            tradeListView.GridLines = true;
            tradeListView.FullRowSelect = true;
            tradeListView.Columns.Add("Key", 0);
            tradeListView.Columns.Add("Symbol", 100);
            tradeListView.Columns.Add("LogTime", 200);
            tradeListView.Columns.Add("Price", 200);
            tradeListView.Columns.Add("Quantity", 200);
        }
    }
}
