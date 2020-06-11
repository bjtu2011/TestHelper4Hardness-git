/************************************************************************
* Copyright (c) 2020 All Rights Reserved.
*命名空间：TestHelper4Hardness.Kernel
*文件名： ComDataManager
*创建人： XXX
*创建时间：2020/6/2 20:24:25
*描述:ComDataManager用来处理datagridview的数据进入，数据删除，数据更改等操作
*=======================================================================
*修改标记
*修改时间：2020/6/2 20:24:25
*修改人：XXX
*描述：
************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TestHelper4Hardness.Utils;

namespace TestHelper4Hardness.Kernel
{
    internal class ComDataManager
    {
        private DataGridView dataGridView;
        private DataTable dt = new DataTable();
        private int columnNo { get; set; }
        private int lastrow = -1;//记录最后一行
        private int lastcolumn = -1;//记录最后一列
        private MainForm mainForm;

        public ComDataManager(DataGridView dataGridView, MainForm mainForm)
        {
            this.mainForm = mainForm;
            this.dataGridView = dataGridView;
            dataGridView.DataSource = dt;
            dataGridView.Scroll += dataGridViewScroll;
            //绑定单元格编辑事件
            dataGridView.CellEndEdit += CellEndEdit;
            dataGridView.CellBeginEdit += CellBeginEdit;
            dataGridView.MouseClick += MouseClick;
            dataGridView.CellValueChanged += CellValueChanged;
        }

        public void CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    //如果rowindex==-1，则更新所有显示的行
                    if (dataGridView.FirstDisplayedCell != null)
                        for (int r = dataGridView.FirstDisplayedCell.RowIndex; r < dataGridView.FirstDisplayedCell.RowIndex + dataGridView.DisplayedRowCount(true); r++)
                        {
                            DataGridViewCellEventArgs en = new DataGridViewCellEventArgs(-1, r);
                            CellValueChanged(sender, en);
                        }
                }
                else
                {
                    if (e.RowIndex < dt.Rows.Count)
                        if (e.ColumnIndex == -1)//整行
                        {
                            for (int i = 0; i < columnNo; i++)

                                if (dt.Rows[e.RowIndex][i].ToString() != "" && (Decimal.Parse(dt.Rows[e.RowIndex][i].ToString()) < mainForm.stdMinValue || Decimal.Parse(dt.Rows[e.RowIndex][i].ToString()) > mainForm.stdMaxValue))
                                {
                                    ((DataGridView)sender).Rows[e.RowIndex].Cells[i].Style.BackColor = Color.FromName("Red");
                                }
                                else
                                {
                                    ((DataGridView)sender).Rows[e.RowIndex].Cells[i].Style.BackColor = Color.FromName("White");
                                }
                        }
                        else
                        {
                            if (dt.Rows[e.RowIndex][e.ColumnIndex].ToString() != "" && (Decimal.Parse(dt.Rows[e.RowIndex][e.ColumnIndex].ToString()) < mainForm.stdMinValue || Decimal.Parse(dt.Rows[e.RowIndex][e.ColumnIndex].ToString()) > mainForm.stdMaxValue))
                            {
                                ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.FromName("Red");
                            }
                            else
                            {
                                ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.FromName("White");
                            }
                        }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(e.RowIndex + "-" + e.ColumnIndex + "\n\r" + err.ToString());
            }
        }

        private void MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
                contextMenuStrip.Items.Add("删除", null, delData);
                contextMenuStrip.Items.Add("设置正常值范围", null, setStdValue);
                contextMenuStrip.Items.Add("联系我们", null, null);
                contextMenuStrip.Show(dataGridView, e.X, e.Y);
            }
        }

        private void setStdValue(object sender, EventArgs e)
        {
            Settings settings = new Settings(mainForm, "record");
            settings.ShowDialog();
        }

        //删除数据
        private void delData(object sender, EventArgs e)
        {
            List<Dictionary<String, int>> deletes = new List<Dictionary<string, int>>();
            DataGridViewSelectedCellCollection cells = dataGridView.SelectedCells;
            if (cells.Count <= 0)
            {
                MessageBox.Show("请先选择要删除的单元格", "提示");
            }
            else
            {
                foreach (DataGridViewCell cell in cells)
                {
                    if (cell.ColumnIndex >= columnNo)
                    {
                        MessageBox.Show(cell.RowIndex + "-" + cell.ColumnIndex + "单元格不允许删除！", "警告");
                    }
                    else
                    {
                        if (cell.RowIndex * columnNo + cell.ColumnIndex >= lastrow * columnNo + lastcolumn)
                        {
                            MessageBox.Show(cell.RowIndex + "-" + cell.ColumnIndex + "单元格不允许删除！", "警告");
                        }
                        else
                        {
                            //可以删除
                            Dictionary<String, int> dict = new Dictionary<string, int>();
                            dict.Add("RowIndex", cell.RowIndex);
                            dict.Add("ColumnIndex", cell.ColumnIndex);
                            dict.Add("OrderNum", cell.RowIndex * columnNo + cell.ColumnIndex);
                            deletes.Add(dict);
                        }
                    }
                }
                if (deletes.Count > 0)//如果存在允许删除的单元格
                {
                    Dictionary<String, int> startIndex = new Dictionary<string, int>();
                    Dictionary<String, int>[] deletesArray = deletes.ToArray();
                    //对delete排序
                    Array.Sort(deletesArray, delegate (Dictionary<String, int> x, Dictionary<String, int> y) { return x["OrderNum"].CompareTo(y["OrderNum"]); });
                    int steps = 0;
                    startIndex["RowIndex"] = deletesArray[steps]["RowIndex"];
                    startIndex["ColumnIndex"] = deletesArray[steps]["ColumnIndex"];
                    startIndex["OrderNum"] = deletesArray[steps]["OrderNum"];
                    while (startIndex["OrderNum"] < lastrow * columnNo + lastcolumn)
                    {
                        if (deletes.Count == steps)//如果删除的数量等于步长
                        {
                            Dictionary<String, int> temp = huigun(startIndex["RowIndex"], startIndex["ColumnIndex"], steps);
                            dt.Rows[temp["RowIndex"]][temp["ColumnIndex"]] = dt.Rows[startIndex["RowIndex"]][startIndex["ColumnIndex"]];
                            if (columnNo - 1 == temp["ColumnIndex"])
                            {
                                float sum = 0;
                                for (int col = 0; col < columnNo; col++)
                                {
                                    sum += float.Parse((String)dt.Rows[temp["RowIndex"]][col].ToString());
                                }
                                dt.Rows[temp["RowIndex"]][temp["ColumnIndex"] + 1] = (sum / columnNo).ToString("0.0");//平均值
                            }
                            dt.Rows[startIndex["RowIndex"]][startIndex["ColumnIndex"]] = "{delete}";
                        }
                        if (deletes.Count > steps)//如果删除的数量大于步长
                        {
                            if (startIndex["OrderNum"] == deletesArray[steps]["OrderNum"])
                            {
                                dt.Rows[startIndex["RowIndex"]][startIndex["ColumnIndex"]] = "{delete}";
                                steps++;
                            }
                            else
                            {
                                Dictionary<String, int> temp = huigun(startIndex["RowIndex"], startIndex["ColumnIndex"], steps);
                                dt.Rows[temp["RowIndex"]][temp["ColumnIndex"]] = dt.Rows[startIndex["RowIndex"]][startIndex["ColumnIndex"]];
                                if (columnNo - 1 == temp["ColumnIndex"])
                                {
                                    float sum = 0;
                                    for (int col = 0; col < columnNo; col++)
                                    {
                                        sum += float.Parse((String)dt.Rows[temp["RowIndex"]][col].ToString());
                                    }
                                    dt.Rows[temp["RowIndex"]][temp["ColumnIndex"] + 1] = (sum / columnNo).ToString("0.0");//平均值
                                }
                                dt.Rows[startIndex["RowIndex"]][startIndex["ColumnIndex"]] = "{delete}";
                            }
                        }

                        if (columnNo - 1 == startIndex["ColumnIndex"])
                        {
                            startIndex["RowIndex"] = startIndex["RowIndex"] + 1;
                            startIndex["ColumnIndex"] = 0;
                        }
                        else
                        {
                            startIndex["ColumnIndex"] = startIndex["ColumnIndex"] + 1;
                        }

                        startIndex["OrderNum"] = startIndex["RowIndex"] * columnNo + startIndex["ColumnIndex"];
                    }
                    Dictionary<String, int> temp1 = huigun(startIndex["RowIndex"], startIndex["ColumnIndex"], steps);
                    lastcolumn = temp1["ColumnIndex"];
                    lastrow = temp1["RowIndex"];
                }

                //数据清理,清除{delete数据}
                for (int rowsNum = dt.Rows.Count - 1; rowsNum >= 0; rowsNum--)
                {
                    if (dt.Rows[rowsNum][0].ToString() != "{delete}" && dt.Rows[rowsNum][0].ToString() != "")
                    {
                        for (int k = 0; k < columnNo; k++)
                        {
                            dt.Rows[rowsNum][k] = dt.Rows[rowsNum][k].ToString().Replace("{delete}", "");
                        }
                        break;
                    }
                    else
                    {
                        dt.Rows.RemoveAt(rowsNum);
                    }
                }
                mainForm.setCountText((lastrow * columnNo + lastcolumn).ToString());
                //更新delete之后的存储
                mainForm.jsonDataDelete(deletes);
                //重绘，标红异常值
                DataGridViewCellEventArgs en = new DataGridViewCellEventArgs(-1, -1);
                CellValueChanged(dataGridView, en);
                //getNewDataTable(dt);
            }
        }

        private Dictionary<String, int> huigun(int rowindex, int colindex, int steps)
        {
            //如果当前为第一列
            if (colindex == 0)
            {
                colindex = columnNo - 1;
                rowindex--;
                steps--;
                if (steps > 0)
                    return huigun(rowindex, colindex, steps);
                else
                {
                    Dictionary<String, int> result = new Dictionary<string, int>();
                    result.Add("RowIndex", rowindex);
                    result.Add("ColumnIndex", colindex);
                    result.Add("OrderNum", rowindex * columnNo + colindex);
                    return result;
                }
            }
            else
            {
                colindex--;
                steps--;
                if (steps > 0)
                    return huigun(rowindex, colindex, steps);
                else
                {
                    Dictionary<String, int> result = new Dictionary<string, int>();
                    result.Add("RowIndex", rowindex);
                    result.Add("ColumnIndex", colindex);
                    result.Add("OrderNum", rowindex * columnNo + colindex);
                    return result;
                }
            }
        }

        private void getNewDataTable(DataTable dt)
        {
            DataTable temp = new DataTable();
            if (columnNo > 0)
            {
                for (int i = 0; i < columnNo; i++)
                {
                    DataColumn columnTemp = new DataColumn("数据" + i);
                    temp.Columns.Add(columnTemp);
                }
                DataColumn columnTemp1 = new DataColumn("平均值");
                temp.Columns.Add(columnTemp1);
            }
            int newColumn = columnNo;
            int newRow = -1;
            for (int row = 0; row < dt.Rows.Count; row++)
            {
                for (int column = 0; column < columnNo; column++)
                {
                    if (dt.Rows[row][column].ToString() != "-1")
                    {
                        if (columnNo == newColumn)
                        {
                            if (newRow >= 0)
                            {
                                float sum = 0;
                                for (int col = 0; col < columnNo; col++)
                                {
                                    sum += float.Parse((String)temp.Rows[newRow][col].ToString());
                                }
                                temp.Rows[newRow][newColumn] = (sum / columnNo).ToString("0.0");//平均值
                            }
                            //增加行，lastcolumn=0
                            temp.Rows.Add();
                            newRow++;
                            newColumn = 0;
                        }
                        temp.Rows[newRow][newColumn] = dt.Rows[row][column];
                        newColumn++;
                    }
                }
            }

            dt = temp;
        }

        private void CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //平均值点击
            if (e.ColumnIndex >= columnNo)
            {
                e.Cancel = true;
                dataGridView.CancelEdit();
                MessageBox.Show("该单元格不可编辑", "警告");
            }
            else
            {
                if (e.RowIndex * columnNo + e.ColumnIndex >= lastrow * columnNo + lastcolumn)
                {
                    e.Cancel = true;
                    dataGridView.CancelEdit();
                    MessageBox.Show("该单元格不可编辑", "警告");
                }
            }
        }

        //单元格编辑事件
        private void CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex * columnNo + e.ColumnIndex < lastrow * columnNo + lastcolumn)
            {
                dt.Rows[e.RowIndex][e.ColumnIndex] = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                String dataJson = Util.read2File("data/" + mainForm.sampleModel.sampleNo + ".json", FileMode.Open, FileAccess.Read);
                if (JsonSplit.IsJson(dataJson))
                {
                    mainForm.sampleModel = Util.JsonToObj<SampleModel>(dataJson);
                    int index = Int32.Parse(mainForm.sampleModel.samplePointNum) * e.RowIndex + e.ColumnIndex;
                    if (index < mainForm.sampleModel.data.Count)
                    {
                        mainForm.sampleModel.data[index] = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        Util.write2File("data/" + mainForm.sampleModel.sampleNo + ".json", Util.ObjToJson<SampleModel>(mainForm.sampleModel), System.IO.FileMode.Create, System.IO.FileAccess.Write);
                        mainForm.sampleModel.data.Clear();
                    }
                }
            }
            else
            {
                dataGridView.CancelEdit();
                MessageBox.Show("该单元格不可编辑", "警告");
            }
        }

        //解决双缓冲黑行
        public void solveDoubleBufferdBlack()
        {
        }

        public void initDataGridView(int columnNo, List<String> data = null)
        {
            this.columnNo = columnNo;
            lastrow = 0;
            lastcolumn = 0;
            if (columnNo > 0)
            {
                for (int i = 0; i < columnNo; i++)
                {
                    DataColumn columnTemp = new DataColumn("数据" + i);
                    dt.Columns.Add(columnTemp);
                }
                DataColumn columnTemp1 = new DataColumn("平均值");
                dt.Columns.Add(columnTemp1);
            }
            //设置不允许排序
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                this.dataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            if (data != null)
            {
                addData(data);
            }
        }

        public void addData(List<String> data)
        {
            if (data.Count > 0)
            {
                //当前行数不能满足数据数量时，增加一行

                for (int count = 0; count < data.Count; count++)
                {
                    if (dt.Rows.Count * columnNo < lastrow * columnNo + lastcolumn + data.Count - count)
                        dt.Rows.Add();
                    dt.Rows[lastrow][lastcolumn] = data[count];
                    if (columnNo - 1 == lastcolumn)
                    {
                        if (lastrow >= 0)
                        {
                            float sum = 0;
                            for (int col = columnNo-3; col < columnNo; col++)
                            {
                                sum += float.Parse((String)dt.Rows[lastrow][col].ToString());
                            }
                            dt.Rows[lastrow][columnNo] = (sum / 3).ToString("0.0");//平均值
                        }
                        //lastcolumn=0
                        lastrow++;
                        lastcolumn = 0;
                    }
                    else
                        lastcolumn++;
                }
                showDataGridView();
            }
        }

        public void showDataGridView()
        {
            if (dataGridView.Rows.Count == dataGridView.DisplayedRowCount(true))
            {
                AddRowNum(0, dataGridView.Rows.Count);
            }
            this.dataGridView.FirstDisplayedScrollingRowIndex = this.dataGridView.Rows.Count - 1;
        }

        public void updateData()
        {
        }

        public void resetData(int columnNo, List<String> data)
        {
            this.columnNo = columnNo;
            clear();
            initDataGridView(columnNo, data);
        }

        //更换样本点的时候用
        public void clear()
        {
            dt.Columns.Clear();
            dt.Rows.Clear();
        }

        //从index行开始添加行号
        private delegate void AddRowNumDelegate(int index, int count);

        private void AddRowNum(int index, int count)
        {
            if (dataGridView.InvokeRequired)
            {
                dataGridView.BeginInvoke(new AddRowNumDelegate(AddRowNum), new object[] { index, count });
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    dataGridView.Rows[index + i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView.Rows[index + i].HeaderCell.Value = (index + i + 1).ToString();
                }
            }
        }

        private System.Timers.Timer t;

        private void dataGridViewScroll(object sender, ScrollEventArgs e)
        {
            if (t != null) { t.Stop(); t.Close(); t = null; }
            t = new System.Timers.Timer(500);

            t.AutoReset = false;
            t.Enabled = true;
            t.Elapsed += timer_Elapsed;
        }

        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            AddRowNum(dataGridView.FirstDisplayedCell.RowIndex, dataGridView.DisplayedRowCount(true));
        }

        public void modifyAllData()
        {
            decimal temp = 0;
            Random r = new Random();
            //修改数据
            List<String> tempData = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < columnNo; j++)
                {
                    if (dt.Rows[i][j].ToString() != "" && Util.IsNumeric(dt.Rows[i][j].ToString()))
                    {
                        temp = Decimal.Parse(dt.Rows[i][j].ToString());
                        if (temp < mainForm.stdMinValue || temp > mainForm.stdMaxValue)
                        {
                            dt.Rows[i][j] = (Decimal.Parse(r.NextDouble().ToString()) * (mainForm.stdMaxValue - mainForm.stdMinValue) + mainForm.stdMinValue).ToString("0.0");
                        }

                        tempData.Add(dt.Rows[i][j].ToString());
                    }
                }
            }
            if (mainForm.sampleModel.sampleNo != "")
            {
                mainForm.sampleModel.data = tempData;

                Util.write2File("data/" + mainForm.sampleModel.sampleNo + ".json", Util.ObjToJson<SampleModel>(mainForm.sampleModel), System.IO.FileMode.Create, System.IO.FileAccess.Write);
                mainForm.sampleModel.data.Clear();
            }
            CellValueChanged(dataGridView, new DataGridViewCellEventArgs(-1, -1));
        }
    }
}