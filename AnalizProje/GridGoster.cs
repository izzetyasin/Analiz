using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalizProje
{
    public partial class GridGoster : Form
    {
        Manager manager = new Manager();
        string analizConStr = "";
        string wolVoxConStr = "";

        public GridGoster()
        {
            InitializeComponent();

            analizConStr = manager.conStrAnaliz;
            wolVoxConStr = manager.conStrWolvox;
        }

        private void GridGoster_Load(object sender, EventArgs e)
        {
            dgvSonuc.DataSource = Manager.VeriTasi;
            dgvSonuc.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
        }
    }
}
