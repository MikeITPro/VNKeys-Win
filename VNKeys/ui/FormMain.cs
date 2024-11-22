using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VNKeys.model;

namespace VNKeys.ui
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.Text = MyGlobal.APPLICATION_NAME;

            var list = new List<KieuGo>();
            var kieuGo = new KieuGo();
            kieuGo.name = "AUTO";
            kieuGo.mapString = "'=' `=` ?=? ~=~ .=. ^=^ *=* +=* (=( -=- d=- 1=' 2=` 5=. 3=? 4=~ 7=* 8=( 6=^ s=' f=` j=. r=? x=~ w=* w=(";
            list.Add(kieuGo);

            kieuGo = new KieuGo();
            kieuGo.name = "VIQR";
            kieuGo.mapString = "'=' `=` ?=? ~=~ .=. ^=^ *=* +=* (=( -=- d=-";
            list.Add(kieuGo);

            kieuGo = new KieuGo();
            kieuGo.name = "VNI";
            kieuGo.mapString = "1=' 2=` 5=. 3=? 4=~ 7=* 8=( 6=^ d=-";
            list.Add(kieuGo);

            kieuGo = new KieuGo();
            kieuGo.name = "TELEX";
            kieuGo.mapString = "s=' f=` j=. r=? x=~ w=* 9=( 6=^ d=-";
            list.Add(kieuGo);


            ddlCurrentKieuGo.DataSource = list;
            ddlCurrentKieuGo.DisplayMember = "name";

        }

        private void lblLink_Click(object sender, EventArgs e)
        {

        }
    }
}
