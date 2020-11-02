using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AToolPlus
{
    public class DelegateControls
    {
        #region 跨线程设置Label的值
        private delegate void MyEventHandles1(Form frm, Label txt, string str);
        public static void SetLblTxt(Form frm, Label txt, string str)
        {
            try
            {
                frm.Invoke(new MyEventHandles1(SetLabBox), new object[] { frm, txt, str });
            }
            catch (Exception ex)
            {
                //MessageBox.Show("SetStatusLblText" + ex.Message.ToString());
            }

        }
        /// <summary>
        /// 显示提示
        /// </summary>
        private static void SetLabBox(Form frm, Label txt, string str)
        {
            try
            {
                txt.Text = str;
                //frm.Cursor = Cursors.WaitCursor;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("SetStatusLblText" + ex.Message.ToString());
            }

        }
        #endregion

        #region 跨线程设置RichTextBox的值
        private delegate void MyEventHandles(Form frm, RichTextBox txt, Color col, string str, bool bApend, bool bClear);
        public static void SetRichText(Form frm, RichTextBox txt, Color col, string str, bool bApend, bool bClear)
        {
            try
            {
                frm.Invoke(new MyEventHandles(SetTextBox), new object[] { frm, txt, col, str, bApend, bClear });
            }
            catch (Exception ex)
            {
                //MessageBox.Show("SetStatusLblText" + ex.Message.ToString());
            }

        }
        /// <summary>
        /// 显示提示
        /// </summary>
        private static void SetTextBox(Form frm, RichTextBox txt, Color col, string str, bool bApend, bool bClear)
        {
            try
            {

                if (bClear)
                {
                    txt.Clear();
                    txt.BackColor = Color.White;
                    return;
                }
                if (bApend)
                {
                    txt.SelectionColor = col;
                    //txt.Font = new Font("Tahoma", 16, FontStyle.Bold);
                    txt.AppendText(str + "\r");
                    txt.ScrollToCaret();

                }
                else
                {
                    txt.BackColor = col;
                    txt.Text = str;
                    txt.SelectionAlignment = HorizontalAlignment.Center;
                    //txt.Font = new Font("Tahoma", 16, FontStyle.Bold);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("SetStatusLblText" + ex.Message.ToString());
            }

        }
        #endregion


        //这是根据需要改写的，用于给ListView指定列赋值的
        delegate void SetGridViewControlValueCallbackEx(DataGridView oControl, string str1, string str2, string str3, string str4);

        public static void SetGridViewControlPropertyValueEx(DataGridView oControl, string str1, string str2, string str3, string str4)
        {
            try
            {
                if (oControl.InvokeRequired)
                {

                    SetGridViewControlValueCallbackEx d = new SetGridViewControlValueCallbackEx(SetGridViewControlPropertyValueEx);

                    oControl.Invoke(d, new object[] { oControl, str1, str2, str3, str4 });

                }
                else
                {
                    oControl.Rows.Insert(0, str1, str2, str3, str4);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        #region 跨线程设置Label的值
        private delegate void MyEventHandlesTextBox(Form frm, TextBox txt, string str);
        public static void SetTextBoxTxt(Form frm, TextBox txt, string str)
        {
            try
            {
                frm.Invoke(new MyEventHandlesTextBox(SetTextBox), new object[] { frm, txt, str });
            }
            catch (Exception ex)
            {
                //MessageBox.Show("SetStatusLblText" + ex.Message.ToString());
            }

        }
        /// <summary>
        /// 显示提示
        /// </summary>
        private static void SetTextBox(Form frm, TextBox txt, string str)
        {
            try
            {
                txt.Text = str;
                //frm.Cursor = Cursors.WaitCursor;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("SetStatusLblText" + ex.Message.ToString());
            }

        }
        #endregion
    }
}
