using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaDashStyleBug
{
        public class ListBoxHierachyLine : Panel
    {
        public static readonly StyledProperty<bool> IsLastChildProperty =
            AvaloniaProperty.Register<ListBoxHierachyLine, bool>(nameof(IsLastChild));

        public bool IsLastChild
        {
            get => GetValue(IsLastChildProperty);
            set => SetValue(IsLastChildProperty, value);
        }

        public static readonly StyledProperty<double> LineThicknessProperty =
            AvaloniaProperty.Register<ListBoxHierachyLine, double>(nameof(LineThickness));

        public double LineThickness
        {
            get => GetValue(LineThicknessProperty);
            set => SetValue(LineThicknessProperty, value);
        }

        public static readonly StyledProperty<DashStyle> LineDashStyleProperty =
            AvaloniaProperty.Register<ListBoxHierachyLine, DashStyle>(nameof(LineDashStyle));

        public DashStyle LineDashStyle
        {
            get => GetValue(LineDashStyleProperty);
            set => SetValue(LineDashStyleProperty, value);
        }

        public static readonly StyledProperty<IBrush> ForegroundProperty =
            AvaloniaProperty.Register<ListBoxHierachyLine, IBrush>(nameof(Foreground));

        public IBrush Foreground
        {
            get => GetValue(ForegroundProperty);
            set => SetValue(ForegroundProperty, value);
        }

        public static readonly StyledProperty<double> TopOffsetProperty =
            AvaloniaProperty.Register<ListBoxHierachyLine, double>(nameof(TopOffset));

        public double TopOffset
        {
            get => GetValue(TopOffsetProperty);
            set => SetValue(TopOffsetProperty, value);
        }

        static ListBoxHierachyLine()
        {
            AffectsRender<ListBoxHierachyLine>(
                IsLastChildProperty,
                TopOffsetProperty,
                LineThicknessProperty,
                LineDashStyleProperty,
                ForegroundProperty,
                TopOffsetProperty);
        }

        public override void Render(DrawingContext context)
        {
            base.Render(context);

            Pen pen = new Pen(Foreground, LineThickness, LineDashStyle, PenLineCap.Round, PenLineJoin.Round);

            context.DrawLine(pen, new Point(Bounds.Width / 2, TopOffset), new Point(Bounds.Width / 2, Bounds.Height / 2));
            context.DrawLine(pen, new Point(Bounds.Width / 2, Bounds.Height / 2), new Point(Bounds.Width, Bounds.Height / 2));

            if (IsLastChild)
                return;

            context.DrawLine(pen, new Point(Bounds.Width / 2, Bounds.Height / 2), new Point(Bounds.Width / 2, Bounds.Height));
        }
    }
}