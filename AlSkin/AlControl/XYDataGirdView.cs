using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace YK.Controls
{
    /// <summary>
    /// 自定义DataGridView控件
    /// </summary>
    public class XYDataGridView : System.Windows.Forms.DataGridView
    {

        #region 重绘Column、Row

       // int _RowHeadWidth = 41;
       Color mLinearColor1 = Color.FromArgb(248, 250, 251);
        // Color mLinearColor1 = Color.FromArgb(215, 215, 215);
        Color mLinearColor2 = Color.FromArgb(196, 207, 224);
        Color mGridColor = Color.FromArgb(120, 147, 191);
        Color mBorderColor = Color.MediumBlue;
        Color mMouseInColor = Color.Orange;
        Color mHasFocusedColor = Color.DarkCyan;

        /// <summary>
        /// 重绘Column、Row
        /// </summary>
        /// <param name="e"></param>
        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
               // //如果是Column
               // if(e.RowIndex == -1) {
               //     drawColumnAndRow(e);
               //     e.Handled = true;
               //     //如果是Rowheader
               // } else if(e.ColumnIndex < 0 && e.RowIndex>=0) {
               //     drawColumnAndRow(e);
               //     _RowHeadWidth = e.CellBounds.Width;
               //     e.Handled = true;
               //}
            StringFormat StrFormat = new StringFormat();
            Rectangle Rect = new Rectangle(e.CellBounds.X - 1, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height - 1);
            System.Drawing.Drawing2D.LinearGradientBrush LinearGradientBrush = new System.Drawing.Drawing2D.LinearGradientBrush(Rect, mLinearColor1, mLinearColor2, System.Drawing.Drawing2D.LinearGradientMode.Vertical);
            //try
            //{
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                e.Graphics.FillRectangle(LinearGradientBrush, Rect);
                e.Graphics.DrawRectangle(new Pen(mGridColor), Rect);

                e.PaintContent(e.CellBounds);
                e.Handled = true;
            }
            //}
            //catch (Exception ex)
            //{
            //}
            //finally
            //{
            //    Rect = null;
            //    StrFormat.Dispose();
            //    if (LinearGradientBrush != null)
            //    {
            //        LinearGradientBrush.Dispose();
            //    }

            //}
        }

        /// <summary>
        /// Column和RowHeader绘制
        /// </summary>
        /// <param name="e"></param>
        void drawColumnAndRow(DataGridViewCellPaintingEventArgs e)
        {
            // 绘制背景色
            using (LinearGradientBrush backbrush =
                new LinearGradientBrush(e.CellBounds,
                    ProfessionalColors.MenuItemPressedGradientBegin,
                    ProfessionalColors.MenuItemPressedGradientMiddle 
                    , LinearGradientMode.Vertical)){
           
                Rectangle border = e.CellBounds;
                border.Width -= 1;
                //填充绘制效果
                e.Graphics.FillRectangle(backbrush, border);
                //绘制Column、Row的Text信息
                e.PaintContent(e.CellBounds);
                //绘制边框
                ControlPaint.DrawBorder3D(e.Graphics, e.CellBounds, Border3DStyle.Etched);

            }
        }

        #endregion


        #region 重绘选中状态

        #region Row重绘前处理

        /// <summary>
        /// Row重绘前处理
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRowPrePaint(DataGridViewRowPrePaintEventArgs e)
        {
            base.OnRowPrePaint(e);

            //是否是选中状态
            if ((e.State & DataGridViewElementStates.Selected) ==
                        DataGridViewElementStates.Selected)
            {
                // 计算选中区域Size
                int width = this.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);//+_RowHeadWidth;
 
                Rectangle rowBounds = new Rectangle(
                  0 , e.RowBounds.Top, width,
                    e.RowBounds.Height);

                // 绘制选中背景色
                using (LinearGradientBrush backbrush =
                    new LinearGradientBrush(rowBounds,
                        Color.SkyBlue, Color.LightSteelBlue, 90.0f)) 
                        //e.InheritedRowStyle.ForeColor, 90.0f))
                {
                    e.Graphics.FillRectangle(backbrush, rowBounds);
                    e.PaintCellsContent(rowBounds);
                    e.Handled = true;
                }

            }
        }

        #endregion

        #region Row重绘后处理

        /// <summary>
        /// Row重绘后处理
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
        {
            base.OnRowPostPaint(e);
            int width = this.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);// + _RowHeadWidth;
            Rectangle rowBounds = new Rectangle(
                   0, e.RowBounds.Top, width, e.RowBounds.Height);

            if (this.CurrentCellAddress.Y == e.RowIndex){
                //设置选中边框
                e.DrawFocus(rowBounds, true);
            }
        }

        #endregion

        #region Row刷新

        protected override void OnColumnWidthChanged(DataGridViewColumnEventArgs e)
        {
            base.OnColumnWidthChanged(e);
            if (this.CurrentRow != null)
                this.InvalidateRow(this.CurrentRow.Index);
        }

        protected override void OnScroll(ScrollEventArgs e)
        {
            base.OnScroll(e);
            if (this.CurrentRow != null)
                this.InvalidateRow(this.CurrentRow.Index);
        }

        #endregion

        #endregion

    }
}
