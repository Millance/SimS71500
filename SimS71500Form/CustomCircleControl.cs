using System.Drawing.Drawing2D;

namespace SimS71500Form
{
    public partial class CustomCircleControl : UserControl
    {
        private Color statusColor = Color.Gray;

        public Color StatusColor
        {
            get { return statusColor; }
            set
            {
                statusColor = value;
                Invalidate(); // 强制重新绘制以显示新的颜色
            }
        }

        public CustomCircleControl()
        {
            InitializeComponent();
            DoubleBuffered = true;
            Size = new Size(50, 50); // 设置控件的大小
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Color darkerColor = ControlPaint.Dark(statusColor, 0.2f); // 调整 0.2f 以控制加深的程度

            int circleDiameter = Math.Min(Width, Height) - 10;
            int circleX = (Width - circleDiameter) / 2;
            int circleY = (Height - circleDiameter) / 2;

            // 创建一个线性渐变画刷
            LinearGradientBrush gradientBrush = new LinearGradientBrush(
                new Rectangle(circleX, circleY, circleDiameter, circleDiameter),
                statusColor,   // 渐变起始颜色
                darkerColor, // 渐变结束颜色
                LinearGradientMode.ForwardDiagonal); // 斜向45度的渐变
            e.Graphics.FillEllipse(gradientBrush, circleX, circleY, circleDiameter, circleDiameter);

            // 创建一个灰色边框的画笔
            Pen borderPen = new Pen(Color.Gray, circleDiameter / 15);
            e.Graphics.DrawEllipse(borderPen, circleX, circleY, circleDiameter, circleDiameter);
        }
    }
}