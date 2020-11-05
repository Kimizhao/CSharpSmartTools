using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AToolPlus.Common;

namespace AToolPlus
{
    public partial class Form1 : Form
    {
        private List<CommandItem> cmdItemLst = new List<CommandItem>();

        private ConfigInfo configInfo = new ConfigInfo();

        private CancellationTokenSource cancellationTokenSource = null;
        private CancellationToken token;
        private Task sendCycleTask = null;

        private bool ManuCancel = false;
        public Form1()
        {
            InitializeComponent();

            LoadConfig();
            LoadCommandsJsonFile();

            this.MenuRecvShowTime.Checked = configInfo.RecvShowTime;
            this.MenuRecvAutoLine.Checked = configInfo.RecvAutoLine;
            this.MenuRecvShowHex.Checked = configInfo.RecvShowHex;
            this.MenuSendAppendRN.Checked = configInfo.SendAppendRN;
            this.MenuSendATString.Checked = configInfo.SendATString;
            this.MenuSendHex.Checked = configInfo.SendHex;

            //初始化listView控件
            this.listView1.Columns.Add("顺序", 40, HorizontalAlignment.Left);
            this.listView1.Columns.Add("字符串", 150, HorizontalAlignment.Left);
            this.listView1.Columns.Add("注释", 100, HorizontalAlignment.Left);
            this.listView1.Columns.Add("延时ms", 50, HorizontalAlignment.Left);

            this.listView1.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度

            for (int i = 0; i < cmdItemLst.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();

                lvi.Checked = cmdItemLst[i].Hex;
                lvi.Text = cmdItemLst[i].Order.ToString();
                lvi.Tag = cmdItemLst[i];
                
                lvi.SubItems.Add(cmdItemLst[i].CommandName);
                lvi.SubItems.Add(cmdItemLst[i].Description);
                lvi.SubItems.Add(cmdItemLst[i].DelayMicroSeconds.ToString());

                this.listView1.Items.Add(lvi);
            }

            this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。

            InitSerialCom();

            //任务
        }

        private void LoadConfig()
        {
            try
            {
                string fp = System.Windows.Forms.Application.StartupPath + "\\appSettings.json";

                if (File.Exists(fp))  // 判断是否已有相同文件
                {
                    configInfo = JsonConvert.DeserializeObject<ConfigInfo>(File.ReadAllText(fp));
                }

            }
            catch (Exception ex)
            {
                LogError($"配置文件解析错误：{ex.ToString()}");
            }
        }

        private void SaveConfig()
        {
            try
            {
                string fp = System.Windows.Forms.Application.StartupPath + "\\appSettings.json";
                if (!File.Exists(fp))  // 判断是否已有相同文件
                {
                    FileStream fs1 = new FileStream(fp, FileMode.Create, FileAccess.ReadWrite);
                    fs1.Close();
                }

                File.WriteAllText(fp, JsonConvert.SerializeObject(configInfo, Formatting.Indented));
            }
            catch (Exception ex)
            {
                LogError($"配置文件保存错误：{ex.ToString()}");
            }
        }

        /// <summary>
        /// 加载-反序列化，指令文件
        /// </summary>
        private void LoadCommandsJsonFile()
        {
            try
            {
                if (string.IsNullOrEmpty(configInfo.AtCommandFile))
                {
                    configInfo.AtCommandFile = System.Windows.Forms.Application.StartupPath + "\\at-command.json";
                }

                if (File.Exists(configInfo.AtCommandFile))
                { 
                    cmdItemLst = JsonConvert.DeserializeObject<List<CommandItem>>(File.ReadAllText(configInfo.AtCommandFile));
                }
            }
            catch (Exception ex)
            {
                LogError($"多字符串文件解析错误，请重新加载或检查文件格式。{ex.ToString()}");
                MessageBox.Show("多字符串文件解析错误，请重新加载或检查文件格式。", this.Text, MessageBoxButtons.OK);

            }
        }

        /// <summary>
        /// 保存-序列化，指令文件
        /// </summary>
        private void SaveCommandsJsonFile()
        {
            try
            {
                List<CommandItem> items = new List<CommandItem>();
                foreach (ListViewItem lvi in this.listView1.Items)
                {
                    items.Add((CommandItem)lvi.Tag);
                }

                if (items.Count == 0)
                {
                    LogHelper.Warn($"多字符串列表为空，不保存。");
                    return;
                }

                if (string.IsNullOrEmpty(configInfo.AtCommandFile))
                {
                    configInfo.AtCommandFile = System.Windows.Forms.Application.StartupPath + "\\at-command.json";
                }

                if (!File.Exists(configInfo.AtCommandFile))
                {
                    FileStream fs1 = new FileStream(configInfo.AtCommandFile, FileMode.Create, FileAccess.ReadWrite);
                    fs1.Close();
                }

                File.WriteAllText(configInfo.AtCommandFile, JsonConvert.SerializeObject(items, Formatting.Indented));
            }
            catch (Exception ex)
            {
                LogError($"多字符串文件保存错误：{ex.ToString()}");
            }
        }

        private void InitSerialCom()
        {
            this.toolStripCmbPort.Items.AddRange(SsComm.AllCom());

            if (this.toolStripCmbPort.Items.Count > 0)
            {
                this.toolStripCmbPort.SelectedIndex = 0;
            }
            if (this.toolStripCmbBaud.Items.Count > 0)
            {
                this.toolStripCmbBaud.SelectedIndex = 1;
            }
        }

        /// <summary>
        /// 双击编辑清单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count == 1)
            {
                ListViewItem item = this.listView1.SelectedItems[0];

                item.Checked = !item.Checked;

                ItemForm itemForm = new ItemForm(item.Tag);
                if(itemForm.ShowDialog(this.listView1) == DialogResult.OK)
                {
                    item.SubItems[0].Text = ((CommandItem)item.Tag).Order.ToString();
                    item.SubItems[1].Text = ((CommandItem)item.Tag).CommandName;
                    item.SubItems[2].Text = ((CommandItem)item.Tag).Description;
                    item.SubItems[3].Text = ((CommandItem)item.Tag).DelayMicroSeconds.ToString();
                }
            }
        }

        #region 日志-界面
        private void LogInformation(string content, int dir = AToolConstants.LOG_NONE)
        {
            StringBuilder outputSb = new StringBuilder();
            if (configInfo.RecvShowTime)
            {
                string dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                outputSb.Append("[");
                outputSb.Append(dateTime);
                outputSb.Append("]");
                if (dir == AToolConstants.LOG_RECV)
                {
                    outputSb.Append("收<-");
                }
                else if (dir == AToolConstants.LOG_SEND)
                {
                    outputSb.Append("发<-");
                }
                else if (dir == AToolConstants.LOG_NONE)
                {

                }
            }

            outputSb.Append(content);

            DelegateControls.SetRichText(this, this.richTextBox1, Color.Black, outputSb.ToString(), true, false);

            if (dir != AToolConstants.LOG_NONE)
            {
                outputSb.Remove(0, 25);
            }

            LogHelper.Info(outputSb.ToString());
        }

        private void LogWarning(string content)
        {
            DelegateControls.SetRichText(this, this.richTextBox1, Color.Yellow, content, true, false);
        }

        private void LogError(string content, int dir = AToolConstants.LOG_NONE)
        {
            StringBuilder outputSb = new StringBuilder();
            if (configInfo.RecvShowTime)
            {
                string dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                outputSb.Append("[");
                outputSb.Append(dateTime);
                outputSb.Append("]");
                if (dir == AToolConstants.LOG_RECV)
                {
                    outputSb.Append("收<-");
                }
                else if (dir == AToolConstants.LOG_SEND)
                {
                    outputSb.Append("发<-");
                }
                else if (dir == AToolConstants.LOG_NONE)
                {

                }
            }

            outputSb.Append(content);

            DelegateControls.SetRichText(this, this.richTextBox1, Color.Black, outputSb.ToString(), true, false);

            if (dir != AToolConstants.LOG_NONE)
            {
                outputSb.Remove(0, 25);
            }

            DelegateControls.SetRichText(this, this.richTextBox1, Color.Red, outputSb.ToString(), true, false);

            if (dir != AToolConstants.LOG_NONE)
            {
                outputSb.Remove(0, 25);
            }

            LogHelper.Error(outputSb.ToString());
        }

        private void LogSend(string content)
        {
            DelegateControls.SetRichText(this, this.richTextBox1, Color.Black, content, true, false);
        }

        private void LogRecv(string content)
        {
            DelegateControls.SetRichText(this, this.richTextBox1, Color.Black, content, true, false);
        }
        #endregion

        #region 工具栏事件

        private void toolStripBtnOpen_Click(object sender, EventArgs e)
        {
            OpenCom();
        }

        private void toolStripBtnMore_Click(object sender, EventArgs e)
        {

        }

        private void toolStripBtnAdd_Click(object sender, EventArgs e)
        {
            CommandItem cmdItem = new CommandItem();
            ItemForm itemForm = new ItemForm(cmdItem, ItemFormState.Add);
            if (itemForm.ShowDialog(this.listView1) == DialogResult.OK)
            {
                ListViewItem lvi = new ListViewItem();

                lvi.Checked = cmdItem.Hex;
                lvi.Text = cmdItem.Order.ToString();
                lvi.Tag = cmdItem;

                lvi.SubItems.Add(cmdItem.CommandName);
                lvi.SubItems.Add(cmdItem.Description);
                lvi.SubItems.Add(cmdItem.DelayMicroSeconds.ToString());

                this.listView1.Items.Add(lvi);
            }
        }
        private void toolStripBtnUp_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0 && listView1.SelectedItems[0].Index != 0)
            {
                listView1.BeginUpdate();
                foreach (ListViewItem lvi in listView1.SelectedItems)
                {
                    ListViewItem item = lvi;
                    int index = lvi.Index;
                    listView1.Items.RemoveAt(index);
                    listView1.Items.Insert(index - 1, item);
                }
                listView1.EndUpdate();
            }

            listView1.Focus();

            LogInformation("上移");
        }
        private void toolStripBtnDown_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0 && listView1.SelectedItems[listView1.SelectedItems.Count - 1].Index < (listView1.Items.Count - 1))
            {
                listView1.BeginUpdate();
                int count = listView1.SelectedItems.Count;
                foreach (ListViewItem lvi in listView1.SelectedItems)
                {
                    ListViewItem item = lvi;
                    int index = lvi.Index;
                    listView1.Items.RemoveAt(index);
                    listView1.Items.Insert(index + count, item);
                }
                listView1.EndUpdate();
            }

            listView1.Focus();

            LogInformation("下移");
        }

        /// <summary>
        /// 选择指令文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripBtnLoad_Click(object sender, EventArgs e)
        {
            //LoadCommandsJsonFile();

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = System.Windows.Forms.Application.StartupPath;
                openFileDialog.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    configInfo.AtCommandFile = openFileDialog.FileName;

                    LoadCommandsJsonFile();

                    //列表更新
                    this.listView1.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度

                    this.listView1.Items.Clear();

                    for (int i = 0; i < cmdItemLst.Count; i++)
                    {
                        ListViewItem lvi = new ListViewItem();

                        lvi.Checked = cmdItemLst[i].Hex;
                        lvi.Text = cmdItemLst[i].Order.ToString();
                        lvi.Tag = cmdItemLst[i];

                        lvi.SubItems.Add(cmdItemLst[i].CommandName);
                        lvi.SubItems.Add(cmdItemLst[i].Description);
                        lvi.SubItems.Add(cmdItemLst[i].DelayMicroSeconds.ToString());

                        this.listView1.Items.Add(lvi);
                    }

                    this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。
                }
            }

            //MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);
        }

        private void toolStripBtnSave_Click(object sender, EventArgs e)
        {
            SaveCommandsJsonFile();
        }

        #endregion

        #region 串口操作

        private void OpenCom()
        {
            try
            {
                bool b = SerialConnection.Instance.Initialize(this.toolStripCmbPort.Text, this.toolStripCmbBaud.Text);
                if (b)
                {
                    SerialConnection.Instance.GetSsComApp().Handlers += new SsCommApp.HandleCommData(HandleData);
                    this.toolStripBtnOpen.Text = "关闭";
                    this.toolStripCmbPort.Enabled = false;
                    this.toolStripCmbBaud.Enabled = false;
                    LogInformation($"串口{this.toolStripCmbPort.Text}打开");
                    toolStripStatusLabelCom.Text = $"串口{this.toolStripCmbPort.Text}打开";
                }
                else
                {
                    this.toolStripBtnOpen.Text = "打开";
                    this.toolStripCmbPort.Enabled = true;
                    this.toolStripCmbBaud.Enabled = true;
                    LogInformation($"串口{this.toolStripCmbPort.Text}关闭");
                    toolStripStatusLabelCom.Text = $"串口{this.toolStripCmbPort.Text}关闭";
                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                LogError(ex.ToString());
            }
            catch (Exception ex)
            {
                LogError(ex.ToString());
            }
        }

        public void HandleData(byte[] data)
        {
            if (configInfo.RecvShowHex)
            {
                LogInformation(data.ToHexString(), AToolConstants.LOG_RECV);
            }
            else
            {
                LogInformation(System.Text.Encoding.Default.GetString(data), AToolConstants.LOG_RECV);
            }
        }

        public void SendData(byte[] data, bool hex = false)
        {
            StringBuilder outputSb = new StringBuilder();

            string str = System.Text.Encoding.Default.GetString(data);
            outputSb.Append(str);
            LogInformation(outputSb.ToString(), AToolConstants.LOG_SEND);

            if (hex)
            {
                try
                {
                    SerialConnection.Instance.SendData(str.ToHexBytes());
                }
                catch (Exception ex)
                {
                    LogInformation($"无效的二进制字符串:{outputSb.ToString()}");
                }
            }
            else
            {
                SerialConnection.Instance.SendData(data);
            }
        }

        #endregion

        #region 菜单栏事件

        private void MenuRecvShowTime_Click(object sender, EventArgs e)
        {
            this.MenuRecvShowTime.Checked = !this.MenuRecvShowTime.Checked;
            configInfo.RecvShowTime = this.MenuRecvShowTime.Checked;
        }

        private void MenuRecvAutoLine_Click(object sender, EventArgs e)
        {
            this.MenuRecvAutoLine.Checked = !this.MenuRecvAutoLine.Checked;
            configInfo.RecvAutoLine = this.MenuRecvAutoLine.Checked;
        }

        private void MenuRecvShowHex_Click(object sender, EventArgs e)
        {
            this.MenuRecvShowHex.Checked = !this.MenuRecvShowHex.Checked;
            configInfo.RecvShowHex = this.MenuRecvShowHex.Checked;
        }

        private void MenuSendAppendRN_Click(object sender, EventArgs e)
        {
            this.MenuSendAppendRN.Checked = !this.MenuSendAppendRN.Checked;
            configInfo.SendAppendRN = this.MenuSendAppendRN.Checked;
        }
        private void MenuSendATString_Click(object sender, EventArgs e)
        {
            this.MenuSendATString.Checked = !this.MenuSendATString.Checked;
            configInfo.SendATString = this.MenuSendATString.Checked;
        }

        private void MenuSendHex_Click(object sender, EventArgs e)
        {
            this.MenuSendHex.Checked = !this.MenuSendHex.Checked;
            configInfo.SendHex = this.MenuSendHex.Checked;
        }

        private void MenuSendCycle_Click(object sender, EventArgs e)
        {
            this.MenuSendCycle.Checked = !this.MenuSendCycle.Checked;
            configInfo.SendCycle = this.MenuSendCycle.Checked;
            
            if (configInfo.SendCycle)
            {
                RunSendCycleTask();
            }
            else
            {
                CancelSendCycleTask();
            }
        }

        private void MenuRecvSaveLog_Click(object sender, EventArgs e)
        {
            this.MenuRecvSaveLog.Checked = !this.MenuRecvSaveLog.Checked;
            if (this.MenuRecvSaveLog.Checked)
            {
                configInfo.LogFile = $"接收日志-{this.toolStripCmbPort.Text}-{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}.txt";
                MessageBox.Show($"日志将保存到：{configInfo.LogFile}", this.Text, MessageBoxButtons.OK);
            }
            else
            {
                configInfo.LogFile = string.Empty;
            }
        }
        #endregion

        /// <summary>
        /// 发送按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (configInfo.SendATString)
                {
                    if (this.listView1.SelectedItems.Count == 1)
                    {
                        ListViewItem item = this.listView1.SelectedItems[0];
                        string str = ((CommandItem)item.Tag).CommandName;
                        StringBuilder sb = new StringBuilder(str);
                        if (configInfo.SendAppendRN)
                        {
                            sb.Append("\r\n");
                        }

                        SendData(System.Text.Encoding.Default.GetBytes(sb.ToString()), item.Checked);

                        Thread.Sleep(200);
                    }
                }

                if (!string.IsNullOrEmpty(this.richTextBox2.Text))
                {
                    StringBuilder sb = new StringBuilder(this.richTextBox2.Text);
                    if (configInfo.SendAppendRN)
                    {
                        sb.Append("\r\n");
                    }

                    SendData(System.Text.Encoding.Default.GetBytes(sb.ToString()), configInfo.SendHex);
                }
            }
            catch (Exception ex)
            {
                LogError(ex.ToString());
            }
            
        }

        /// <summary>
        /// 窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveCommandsJsonFile();
            SaveConfig();
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ((CommandItem)e.Item.Tag).Hex = e.Item.Checked;
        }

        #region 循环发送任务

        private void RunSendCycleTask()
        {
            CancelSendCycleTask();

            cancellationTokenSource = new CancellationTokenSource();
            token = cancellationTokenSource.Token;

            List<CommandItem> cmdItems = new List<CommandItem>();
            foreach (ListViewItem lvi in this.listView1.Items)
            {
                CommandItem ci = (CommandItem)lvi.Tag;
                if (ci.Order > 0)
                {
                    cmdItems.Add(ci);
                }
            }

            sendCycleTask = Task.Factory.StartNew(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    cmdItems = cmdItems.OrderBy(a => a.Order).ToList();
                    if (cmdItems.Count > 0)
                    {
                        foreach (var item in cmdItems)
                        {
                            BeginInvoke(new Action(() =>
                            {
                                string str = item.CommandName;
                                StringBuilder sb = new StringBuilder(str);
                                if (configInfo.SendAppendRN)
                                {
                                    sb.Append("\r\n");
                                }

                                SendData(System.Text.Encoding.Default.GetBytes(sb.ToString()), item.Hex);
                            }));

                            if (ManuCancel)
                            {
                                break;
                            }

                            Thread.Sleep(item.DelayMicroSeconds);
                        }
                    }

                    ManuCancel = false;
                }
            }, token);

            LogInformation("循环发送任务开始");
        }

        private void CancelSendCycleTask()
        {
            if (sendCycleTask != null)
            {
                ManuCancel = true;
                cancellationTokenSource.Cancel();
                sendCycleTask.Wait();

                sendCycleTask = null;
                cancellationTokenSource = null;
                LogInformation("循环发送任务停止");
            }
        }


        #endregion

        private void toolStripBtnDelete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0 && listView1.SelectedItems[0].Index != 0)
            {
                listView1.BeginUpdate();
                foreach (ListViewItem lvi in listView1.SelectedItems)
                {
                    ListViewItem item = lvi;
                    int index = lvi.Index;
                    listView1.Items.RemoveAt(index);
                }
                listView1.EndUpdate();
            }

            listView1.Focus();
        }
    }
}
