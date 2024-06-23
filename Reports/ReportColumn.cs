using System.Collections.Generic;
using System.Drawing;

namespace Reports
{
    /// <summary>
    /// Колонки (заголовки) отчета
    /// </summary>
    public class ReportColumns : List<ReportColumn>
    {
        /// <summary>
        /// Добавить заголовки
        /// </summary>
        /// <param name="args"></param>
        public void Add(params ReportColumn[] args)
        {
            foreach (var item in args)
                base.Add(item);
        }
    }

    /// <summary>
    /// Ширины колонок (заголовков) отчета
    /// </summary>
    public class ReportColumn
    {
        public ReportColumn(string text = "", int width = 100, StringAlignment alignment = StringAlignment.Center)
        {
            Text = text;
            Width = width;
            Alignment = alignment;
        }

        /// <summary>
        /// Текст заголовка столбца
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Ширина столбца
        /// </summary>
        public int Width { get; set; } = 100;
        /// <summary>
        /// Выравнивание текста в столбце
        /// </summary>
        public StringAlignment Alignment { get; set; } = StringAlignment.Center;
    }
}
