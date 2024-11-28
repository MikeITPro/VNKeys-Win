using MouseKeyboardActivityMonitor.WinApi;
using MouseKeyboardActivityMonitor;
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
using VNKeys.service;
using static System.Net.Mime.MediaTypeNames;

namespace VNKeys.ui
{
    public partial class FormMain : Form
    {
        private KeyboardHookListener _keyHook;
        private string _lastCharString = string.Empty;
        private string _mapString = "'=' `=` ?=? ~=~ .=. ^=^ *=* +=* (=( -=- d=- 1=' 2=` 5=. 3=? 4=~ 7=* 8=( 6=^ s=' f=` j=. r=? x=~ w=* w=(";
        private bool _isReplacing = false;

        public FormMain()
        {
            InitializeComponent();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void resetLastWord()
        {
            _lastCharString = "";
        }

    
        private void keyboardKeyDown(object sender, KeyEventArgs e)
        {
            // MessageBox.Show($"Key pressed: {e.KeyCode}");
            if (_isReplacing) { return; }
            try
            {
                Keys key = e.KeyData;
                if (chkOn.Checked)
                {
                    if ((key == Keys.Space) || key == Keys.Enter) // new word
                    {
                        this.resetLastWord();
                    }
                    else if ((key != Keys.LShiftKey) && (key != Keys.RShiftKey))
                    {
                        string charString = MyGlobal.getKeyboardService().getCharFromKeyValue(e.KeyValue).ToString(); 
                        
                        //if (chkDauDoi.Checked)
                        //{
                        //    string ch = _lastWord.ToString().ToLower();
                        //    if (this.getIsVietKeyWithAccent(strKey))
                        //    {
                        //        if (strKey.ToLower() != "d")
                        //        {
                        //            if (strKey.ToLower() == ch)
                        //            {
                        //                isAccentMark = true;
                        //                strKey = "^";
                        //            }
                        //        }
                        //    }
                        //}

                        var accentType = getAccentType(charString);

                        if ((accentType != AccentType.NONE) && !string.IsNullOrEmpty(_lastCharString))
                        {
                            string data = this.getVietCharacterByDau(accentType); 
                            if (!string.IsNullOrEmpty(data))
                            {
                                _isReplacing = true;
                                MyGlobal.getKeyboardService().sendKey(Keys.Back);
                                MyGlobal.getKeyboardService().sendStringToCurrentCursor(data);
                                saveLastWord(data);
                                e.Handled = true;
                                _isReplacing = false;
                                return;
                            }
                        }
                        else if (this.isVietCharacter(charString))
                        {
                            saveLastWord(charString);
                        }
                        else
                        {
                            resetLastWord();
                            // MessageBox.Show(_lastCharString + " " + charString);
                        }
                    }
                }
            }
            catch (Exception ignored)
            {
                // You can log for debug
                // MessageBox.Show(ignored.ToString());
            }
        }

        private bool isVietCharacter(string key)
        {
            key = key.ToLower();
            string[] keys = new string[] { "a", "e", "i", "o", "u", "y", "d" };
            return Array.Exists<string>(keys, o => o == key);
        }

        private void saveLastWord(string keyCode)
        {
            _lastCharString = keyCode;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            _keyHook = new KeyboardHookListener(new GlobalHooker());
            _keyHook.KeyDown += keyboardKeyDown;
            chkOn.Checked = true;

            this.Text = MyGlobal.getAppName() + " " + MyGlobal.getAppVersion();
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
            MyGlobal.gotoUrl("https://vnkeys.net");
        }

        private AccentType getAccentType(string typedChar)
        {
            string[] accents = _mapString.Trim().Split(' ');
            string strKey = "";
            foreach (var item in accents)
            {
                if (item.StartsWith(typedChar))
                {
                    string[] info = item.Split('=');
                    strKey = info[1];
                    break;
                }
            }
            var result = AccentType.NONE;
            switch (strKey)
            {
                case "'":
                    result = AccentType.SAC;
                    break;
                case "`":
                    result = AccentType.HUYEN;
                    break;
                case "?":
                    result = AccentType.HOI;
                    break;
                case "~":
                    result = AccentType.NGA;
                    break;
                case ".":
                    result = AccentType.NANG;
                    break;
                case "^":
                    result = AccentType.MU;
                    break;
                case "*":
                    result = AccentType.MOC;
                    break;
                case "(":
                    result = AccentType.TRANG;
                    break;
                case "-":
                    result = AccentType.NGANG;
                    break;

            }
            return result;
        }

        private string getVietCharacterByDau(AccentType accentType)
        {
            string strMap = "", result = "";
            if (accentType == AccentType.HOI)
            {
                strMap = "a=ả A=Ả ă=ẳ Ă=Ẳ â=ẩ Â=Ẩ e=ẻ E=Ẻ ê=ể Ê=Ể i=ỉ I=Ỉ o=ỏ O=Ỏ ô=ổ Ô=Ổ ơ=ở Ơ=Ở u=ủ U=Ủ ư=ử Ư=Ử y=ỷ Y=Ỷ";
            }
            else if (accentType == AccentType.HUYEN)
            {
                strMap = "a=à A=À ă=ằ Ă=Ằ â=ầ Â=Ầ e=è E=È ê=ề Ê=Ề i=ì I=Ì o=ò O=Ò ô=ồ Ô=Ồ ơ=ờ Ơ=Ờ u=ù U=Ù ư=ừ Ư=Ừ y=ỳ Y=Ỳ";
            }
            else if (accentType == AccentType.MOC)
            {
                strMap = "o=ơ O=Ơ u=ư U=Ư";
            }
            else if (accentType == AccentType.MU)
            {
                strMap = "a=â A=Â o=ô O=Ô e=ê E=Ê";
            }
            else if (accentType == AccentType.NANG)
            {
                strMap = "a=ạ A=Ạ ă=ặ Ă=Ặ â=ậ Â=Ậ e=ẹ E=Ẹ ê=ệ Ê=Ệ i=ị I=Ị o=ọ O=Ọ ô=ộ Ô=Ộ ơ=ợ Ơ=Ợ u=ụ U=Ụ ư=ự Ư=Ự y=ỵ Y=Ỵ";
            }
            else if (accentType == AccentType.NGA)
            {
                strMap = "a=ã A=Ã ă=ẵ Ă=Ẵ â=ẫ Â=Ẫ e=ẽ E=Ẽ ê=ễ Ê=Ễ i=ĩ I=Ĩ o=õ O=Õ ô=ỗ Ô=Ỗ ơ=ỡ Ơ=Ỡ u=ũ U=Ũ ư=ữ Ư=Ữ y=ỹ Y=Ỹ";
            }
            else if (accentType == AccentType.NGANG)
            {
                strMap = "d=đ D=Đ";
            }
            else if (accentType == AccentType.SAC)
            {
                strMap = "a=á A=Á ă=ắ Ă=Ắ â=ấ Â=Ấ e=é E=É ê=ế Ê=Ế i=í I=Í o=ó O=Ó ô=ố Ô=Ố ơ=ớ Ơ=Ớ u=ú U=Ú ư=ứ Ư=Ứ y=ý Y=Ý";
            }
            else if (accentType == AccentType.TRANG)
            {
                strMap = "a=ă A=Ă";
            }
            var map = new Dictionary<string, string>();
            string[] items = strMap.Split(' ');
            string[] info;
            foreach (var item in items)
            {
                info = item.Split('=');
                map.Add(info[0], info[1]);
            }
            if (map.ContainsKey(_lastCharString))
            {
                result = map[_lastCharString];
            }
            map = null;
            return result;
        }

        private void chkOff_CheckedChanged(object sender, EventArgs e)
        {
            // updateVNKeysOnOff();
        }

        private void chkOn_CheckedChanged(object sender, EventArgs e)
        {
            updateVNKeysOnOff();
        }

        private void updateVNKeysOnOff()
        {
            if (chkOn.Checked)
            {
                // this.btnTurnOff.Visible = true;
                //  this.btnTurnOn.Visible = false;
                // this.notifyIcon.Icon = this.Icon;
                _keyHook.Enabled = true;
            }
            else
            {
                _keyHook.Enabled = false;
                //this.btnTurnOff.Visible = false;
                //this.btnTurnOn.Visible = true;
                //this.notifyIcon.Icon = Properties.Resources.logo_e;
                //if (chkAutoMinimizeOnOff.Checked)
                //{
                //    this.WindowState = FormWindowState.Minimized;
                //}
            }
        }

        private void ddlCurrentKieuGo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var kieuGo = ddlCurrentKieuGo.SelectedItem as KieuGo;
            if (kieuGo != null)
            {
                _mapString = kieuGo.mapString;               
            }
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = new FormAbout();
            form.ShowDialog();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (chkConfirmExit.Checked)
            {
                if (MessageBox.Show("Bạn muốn thoát ứng dụng?", MyGlobal.getAppName(), MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void menuReportBug_Click(object sender, EventArgs e)
        {
            MyGlobal.gotoUrl("https://vnfox.com/about-contact.htm?t=bug&n=" + MyGlobal.getAppName());            
        }

        private void menuReqFeature_Click(object sender, EventArgs e)
        {
            MyGlobal.gotoUrl("https://vnfox.com/about-contact.htm?t=feature&n=" + MyGlobal.getAppName());
        }
    }
}
