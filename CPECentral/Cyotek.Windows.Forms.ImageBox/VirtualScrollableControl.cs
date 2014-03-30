#region Using directives

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#endregion

// Original VirtualScrollableControl code by Scott Crawford (http://sukiware.com/)

namespace Cyotek.Windows.Forms
{
    [ToolboxItem(false)]
    public class VirtualScrollableControl : ScrollControl
    {
        #region Instance Fields

        private bool _autoScroll;

        private Size _autoScrollMargin;

        private Size _autoScrollMinSize;

        private Point _autoScrollPosition;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="VirtualScrollableControl" /> class.
        /// </summary>
        public VirtualScrollableControl()
        {
            AutoScrollMargin = Size.Empty;
            AutoScrollMinSize = Size.Empty;
            AutoScrollPosition = Point.Empty;
            AutoScroll = true;

            base.SetStyle(ControlStyles.ContainerControl, true);
        }

        #endregion

        #region Events

        /// <summary>
        ///     Occurs when the AutoScroll property value changes
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler AutoScrollChanged;

        /// <summary>
        ///     Occurs when the AutoScrollMargin property value changes
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler AutoScrollMarginChanged;

        /// <summary>
        ///     Occurs when the AutoScrollMinSize property value changes
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler AutoScrollMinSizeChanged;

        /// <summary>
        ///     Occurs when the AutoScrollPosition property value changes
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler AutoScrollPositionChanged;

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets a value indicating whether the container enables the user to scroll to any controls placed outside of
        ///     its visible boundaries.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the container enables auto-scrolling; otherwise, <c>false</c>.
        /// </value>
        [Category("Layout"), DefaultValue(true)]
        public virtual bool AutoScroll
        {
            get { return _autoScroll; }
            set
            {
                if (AutoScroll != value) {
                    _autoScroll = value;

                    OnAutoScrollChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the size of the auto-scroll margin.
        /// </summary>
        /// <value>
        ///     A <see cref="T:System.Drawing.Size" /> that represents the height and width of the auto-scroll margin in pixels.
        /// </value>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        [Category("Layout"), DefaultValue(typeof (Size), "0, 0")]
        public virtual Size AutoScrollMargin
        {
            get { return _autoScrollMargin; }
            set
            {
                if (value.Width < 0) {
                    throw new ArgumentOutOfRangeException("value", "Width must be a positive integer.");
                }
                if (value.Height < 0) {
                    throw new ArgumentOutOfRangeException("value", "Height must be a positive integer.");
                }

                if (AutoScrollMargin != value) {
                    _autoScrollMargin = value;

                    OnAutoScrollMarginChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the minimum size of the auto-scroll.
        /// </summary>
        /// <value>
        ///     A <see cref="T:System.Drawing.Size" /> that determines the minimum size of the virtual area through which the user
        ///     can scroll.
        /// </value>
        [Category("Layout"), DefaultValue(typeof (Size), "0, 0")]
        public virtual Size AutoScrollMinSize
        {
            get { return _autoScrollMinSize; }
            set
            {
                if (AutoScrollMinSize != value) {
                    _autoScrollMinSize = value;

                    OnAutoScrollMinSizeChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the location of the auto-scroll position.
        /// </summary>
        /// <value>
        ///     A <see cref="T:System.Drawing.Point" /> that represents the auto-scroll position in pixels.
        /// </value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual Point AutoScrollPosition
        {
            get { return _autoScrollPosition; }
            set
            {
                Point translated;

                translated = AdjustPositionToSize(new Point(-value.X, -value.Y));

                if (AutoScrollPosition != translated) {
                    ScrollByOffset(new Size(_autoScrollPosition.X - translated.X, _autoScrollPosition.Y - translated.Y));
                    _autoScrollPosition = translated;

                    OnAutoScrollPositionChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///     Total area of all visible controls which are scrolled with this container
        /// </summary>
        protected Rectangle ScrollArea
        {
            get
            {
                Rectangle area;

                area = Rectangle.Empty;

                foreach (Control child in Controls) {
                    if (child.Visible) {
                        area = Rectangle.Union(child.Bounds, area);
                    }
                }

                return Rectangle.Union(area, new Rectangle(_autoScrollPosition, _autoScrollMinSize));
            }
        }

        /// <summary>
        ///     Gets the view port rectangle.
        /// </summary>
        /// <value>The view port rectangle.</value>
        protected Rectangle ViewPortRectangle
        {
            get
            {
                return new Rectangle(-_autoScrollPosition.X, -_autoScrollPosition.Y, DisplayRectangle.Width,
                    DisplayRectangle.Height);
            }
        }

        #endregion

        #region Members

        /// <summary>
        ///     Scrolls the specified child control into view on an auto-scroll enabled control.
        /// </summary>
        /// <param name="activeControl">The child control to scroll into view.</param>
        public void ScrollControlIntoView(Control activeControl)
        {
            if (activeControl.Visible && AutoScroll && (HorizontalScroll.Visible || VerticalScroll.Visible)) {
                Point position;

                position =
                    AdjustPositionToSize(new Point(AutoScrollPosition.X + activeControl.Left,
                        AutoScrollPosition.Y + activeControl.Top));

                if (position.X != AutoScrollPosition.X || position.Y != AutoScrollPosition.Y) {
                    ScrollByOffset(new Size(AutoScrollPosition.X - position.X, AutoScrollPosition.Y - position.Y));
                }
            }
        }

        /// <summary>
        ///     Adjusts the given Point according to the scroll size
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns></returns>
        protected Point AdjustPositionToSize(Point position)
        {
            int x;
            int y;

            x = position.X;
            y = position.Y;

            if (x < -(AutoScrollMinSize.Width - ClientRectangle.Width)) {
                x = -(AutoScrollMinSize.Width - ClientRectangle.Width);
            }
            if (y < -(AutoScrollMinSize.Height - ClientRectangle.Height)) {
                y = -(AutoScrollMinSize.Height - base.ClientRectangle.Height);
            }
            if (x > 0) {
                x = 0;
            }
            if (y > 0) {
                y = 0;
            }

            return new Point(x, y);
        }

        /// <summary>
        ///     Raises the <see cref="AutoScrollChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnAutoScrollChanged(EventArgs e)
        {
            EventHandler handler;

            handler = AutoScrollChanged;

            if (handler != null) {
                handler(this, e);
            }
        }

        /// <summary>
        ///     Raises the <see cref="AutoScrollMarginChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnAutoScrollMarginChanged(EventArgs e)
        {
            EventHandler handler;

            handler = AutoScrollMarginChanged;

            if (handler != null) {
                handler(this, e);
            }
        }

        /// <summary>
        ///     Raises the <see cref="AutoScrollMinSizeChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnAutoScrollMinSizeChanged(EventArgs e)
        {
            EventHandler handler;

            AutoScrollPosition = AdjustPositionToSize(AutoScrollPosition);
            AdjustScrollbars();

            handler = AutoScrollMinSizeChanged;

            if (handler != null) {
                handler(this, e);
            }
        }

        /// <summary>
        ///     Raises the <see cref="AutoScrollPositionChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnAutoScrollPositionChanged(EventArgs e)
        {
            EventHandler handler;

            handler = AutoScrollPositionChanged;

            if (handler != null) {
                handler(this, e);
            }
        }

        /// <summary>
        ///     Raises the <see cref="System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">
        ///     An <see cref="T:System.EventArgs" /> that contains the event data.
        /// </param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            AdjustScrollbars();

            if (AutoScroll && !AutoScrollPosition.IsEmpty) {
                int xOffset;
                int yOffset;
                Rectangle scrollArea;

                scrollArea = ScrollArea;
                xOffset = scrollArea.Right - DisplayRectangle.Right;
                yOffset = scrollArea.Bottom - DisplayRectangle.Bottom;

                if (AutoScrollPosition.Y < 0 && yOffset < 0) {
                    yOffset = Math.Max(yOffset, AutoScrollPosition.Y);
                }
                else {
                    yOffset = 0;
                }

                if (AutoScrollPosition.X < 0 && xOffset < 0) {
                    xOffset = Math.Max(xOffset, AutoScrollPosition.X);
                }
                else {
                    xOffset = 0;
                }

                ScrollByOffset(new Size(xOffset, yOffset));
            }
        }

        /// <summary>
        ///     Raises the <see cref="Scroll" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="ScrollEventArgs" /> instance containing the event data.
        /// </param>
        protected override void OnScroll(ScrollEventArgs e)
        {
            if (e.Type != ScrollEventType.EndScroll) {
                if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll) {
                    ScrollByOffset(new Size(e.NewValue + AutoScrollPosition.X, 0));
                }
                else if (e.ScrollOrientation == ScrollOrientation.VerticalScroll) {
                    ScrollByOffset(new Size(0, e.NewValue + AutoScrollPosition.Y));
                }
            }

            base.OnScroll(e);
        }

        /// <summary>
        ///     Raises the <see cref="System.Windows.Forms.Control.VisibleChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     An <see cref="T:System.EventArgs" /> that contains the event data.
        /// </param>
        protected override void OnVisibleChanged(EventArgs e)
        {
            if (base.Visible) {
                base.PerformLayout();
            }

            base.OnVisibleChanged(e);
        }

        /// <summary>
        ///     Adjusts the scrollbars.
        /// </summary>
        private void AdjustScrollbars()
        {
            Rectangle clientRectangle;
            Size scrollSize;
            Size pageSize;
            int horzAddition;
            int vertAddition;
            bool horizontalScrollVisible;
            bool verticalScrollVisible;

            clientRectangle = ClientRectangle;
            scrollSize = new Size();
            pageSize = new Size();
            horzAddition = 0;
            vertAddition = 0;
            horizontalScrollVisible = false;
            verticalScrollVisible = false;

            if (AutoScroll &&
                (AutoScrollMinSize.Height > clientRectangle.Height || AutoScrollMinSize.Width > clientRectangle.Width)) {
                int i;

                for (i = 0; i < 2; i++) {
                    if (AutoScrollMinSize.Width > (clientRectangle.Width - vertAddition)) {
                        horizontalScrollVisible = true;
                        horzAddition = SystemInformation.VerticalScrollBarWidth;
                    }

                    if (AutoScrollMinSize.Height > (clientRectangle.Height - horzAddition)) {
                        verticalScrollVisible = true;
                        vertAddition = SystemInformation.HorizontalScrollBarHeight;
                    }
                }
            }

            if (verticalScrollVisible) {
                scrollSize.Height = AutoScrollMinSize.Height;
                if (clientRectangle.Height > horzAddition) {
                    pageSize.Height = clientRectangle.Height - horzAddition;
                }
            }

            if (horizontalScrollVisible) {
                scrollSize.Width = AutoScrollMinSize.Width;
                if (clientRectangle.Width > vertAddition) {
                    pageSize.Width = clientRectangle.Width - vertAddition;
                }
            }

            ScrollSize = scrollSize;
            PageSize = pageSize;
        }

        /// <summary>
        ///     Scrolls child controls by the given offset
        /// </summary>
        /// <param name="offset">The offset.</param>
        private void ScrollByOffset(Size offset)
        {
            if (!offset.IsEmpty) {
                SuspendLayout();
                foreach (Control child in Controls) {
                    child.Location -= offset;
                }

                _autoScrollPosition = new Point(_autoScrollPosition.X - offset.Width,
                    _autoScrollPosition.Y - offset.Height);
                ScrollTo(-_autoScrollPosition.X, -_autoScrollPosition.Y);

                ResumeLayout();

                Invalidate();
            }
        }

        #endregion
    };
} ;