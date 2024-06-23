using System.Drawing.Printing;
using System.Drawing;
using System;

namespace Reports
{
    /// <summary>
    /// Отчёт 
    /// </summary>
    public class Report
    {
        public string Caption { get; set; } = string.Empty; // заголовок отчета
        public ReportColumns ReportTopColumns { get; set; } = new ReportColumns(); // верхние колонки отчета
        public ReportColumns ReportMiddleColumns { get; set; } = new ReportColumns(); // средние колонки отчета
        public ReportColumns ReportBottomColumns { get; set; } = new ReportColumns(); // нижние колонки отчета
        public ReportRows ReportRows { get; set; } = new ReportRows(); // строки отчета
        public bool Landscape { get; set; } // расположение страницы (false - портрет; true - ландшафт)
        public Action<object, PrintPageEventArgs, RectangleF, PointF> PrintPage { get; set; }

        /// <summary>
        /// Инициализация
        /// </summary>
        public void Clear()
        {
            Caption = string.Empty;
            ReportTopColumns.Clear();
            ReportRows.Clear();
        }
    }
}
