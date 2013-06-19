#region Using directives

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

#endregion

namespace Cyotek.Windows.Forms
{
    // Cyotek ImageBox
    // Copyright (c) 2010-2013 Cyotek. All Rights Reserved.
    // http://cyotek.com
    // http://cyotek.com/blog/tag/imagebox

    // If you use this control in your applications, attribution or donations are welcome.

    /// <summary>
    ///     Component for displaying images with support for scrolling and zooming.
    /// </summary>
    [DefaultProperty("Image"), ToolboxBitmap(typeof (ImageBox), "ImageBox.bmp"), ToolboxItem(true)]
    public class ImageBox : VirtualScrollableControl
    {
        #region Constants

        private const int MaxZoom = 3500;
        private const int MinZoom = 1;
        private const int SelectionDeadZone = 5;
        public const int PixelGridThreshold = 2;

        #endregion

        #region Instance Fields

        private bool _allowClickZoom;
        private bool _allowDoubleClick;
        private bool _allowZoom;
        private bool _autoCenter;
        private bool _autoPan;
        private int _dropShadowSize;
        private int _gridCellSize;
        private Color _gridColor;
        private Color _gridColorAlternate;
        private ImageBoxGridDisplayMode _gridDisplayMode;
        private ImageBoxGridScale _gridScale;
        private Bitmap _gridTile;
        private Image _image;
        private Image _backgroundTile;
        private Color _imageBorderColor;
        private ImageBoxBorderStyle _imageBorderStyle;
        private InterpolationMode _interpolationMode;
        private bool _invertMouse;
        private bool _isPanning;
        private bool _isSelecting;
        private bool _limitSelectionToImage;
        private Color _pixelGridColor;
        private Color _selectionColor;
        private ImageBoxSelectionMode _selectionMode;
        private RectangleF _selectionRegion;
        private bool _shortcutsEnabled;
        private bool _showPixelGrid;
        private bool _sizeToFit;
        private Point _startMousePosition;
        private Point _startScrollPosition;
        private TextureBrush _texture;
        private int _updateCount;
        private bool _virtualMode;
        private Size _virtualSize;
        private int _zoom;

        private ZoomLevelCollection _zoomLevels;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImageBox" /> class.
        /// </summary>
        public ImageBox()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.StandardDoubleClick, false);
            UpdateStyles();

            WheelScrollsControl = false;
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            AllowZoom = true;
            LimitSelectionToImage = true;
            DropShadowSize = 3;
            ImageBorderStyle = ImageBoxBorderStyle.None;
            BackColor = Color.White;
            AutoSize = false;
            AutoScroll = true;
            GridScale = ImageBoxGridScale.Small;
            GridDisplayMode = ImageBoxGridDisplayMode.Client;
            GridColor = Color.Gainsboro;
            GridColorAlternate = Color.White;
            GridCellSize = 8;
            AutoPan = true;
            InterpolationMode = InterpolationMode.NearestNeighbor;
            AutoCenter = true;
            SelectionColor = SystemColors.Highlight;
            ActualSize();
            ShortcutsEnabled = true;
            ZoomLevels = ZoomLevelCollection.Default;
            ImageBorderColor = SystemColors.ControlDark;
            PixelGridColor = Color.DimGray;
            // ReSharper restore DoNotCallOverridableMethodsInConstructor
        }

        #endregion

        #region Events

        /// <summary>
        ///     Occurs when the AllowClickZoom property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler AllowClickZoomChanged;

        /// <summary>
        ///     Occurs when the AllowDoubleClick property value changes
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler AllowDoubleClickChanged;

        /// <summary>
        ///     Occurs when the AllowZoom property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler AllowZoomChanged;

        /// <summary>
        ///     Occurs when the AutoCenter property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler AutoCenterChanged;

        /// <summary>
        ///     Occurs when the AutoPan property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler AutoPanChanged;

        /// <summary>
        ///     Occurs when the DropShadowSize property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler DropShadowSizeChanged;

        /// <summary>
        ///     Occurs when the GridSizeCell property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler GridCellSizeChanged;

        /// <summary>
        ///     Occurs when the GridColorAlternate property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler GridColorAlternateChanged;

        /// <summary>
        ///     Occurs when the GridColor property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler GridColorChanged;

        /// <summary>
        ///     Occurs when the GridDisplayMode property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler GridDisplayModeChanged;

        /// <summary>
        ///     Occurs when the GridScale property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler GridScaleChanged;

        /// <summary>
        ///     Occurs when the ImageBorderColor property value changes
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler ImageBorderColorChanged;

        /// <summary>
        ///     Occurs when the ImageBorderStyle property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler ImageBorderStyleChanged;

        /// <summary>
        ///     Occurs when the Image property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler ImageChanged;

        [Category("Property Changed")]
        public event EventHandler BackgroundTileChanged;

        /// <summary>
        ///     Occurs when the InterpolationMode property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler InterpolationModeChanged;

        /// <summary>
        ///     Occurs when the InvertMouse property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler InvertMouseChanged;

        /// <summary>
        ///     Occurs when the LimitSelectionToImage property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler LimitSelectionToImageChanged;

        /// <summary>
        ///     Occurs when panning the control completes.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler PanEnd;

        /// <summary>
        ///     Occurs when panning the control starts.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler PanStart;

        /// <summary>
        ///     Occurs when the PixelGridColor property value changes
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler PixelGridColorChanged;

        /// <summary>
        ///     Occurs when a selection region has been defined
        /// </summary>
        [Category("Action")]
        public event EventHandler<EventArgs> Selected;

        /// <summary>
        ///     Occurs when the user starts to define a selection region.
        /// </summary>
        [Category("Action")]
        public event EventHandler<CancelEventArgs> Selecting;

        /// <summary>
        ///     Occurs when the SelectionColor property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler SelectionColorChanged;

        /// <summary>
        ///     Occurs when the SelectionMode property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler SelectionModeChanged;

        /// <summary>
        ///     Occurs when the SelectionRegion property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler SelectionRegionChanged;

        /// <summary>
        ///     Occurs when the ShortcutsEnabled property value changes
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler ShortcutsEnabledChanged;

        /// <summary>
        ///     Occurs when the ShowPixelGrid property value changes
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler ShowPixelGridChanged;

        /// <summary>
        ///     Occurs when the SizeToFit property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler SizeToFitChanged;

        /// <summary>
        ///     Occurs when virtual painting should occur
        /// </summary>
        [Category("Appearance")]
        public event PaintEventHandler VirtualDraw;

        /// <summary>
        ///     Occurs when the VirtualMode property value changes
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler VirtualModeChanged;

        /// <summary>
        ///     Occurs when the VirtualSize property value changes
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler VirtualSizeChanged;

        /// <summary>
        ///     Occurs when the Zoom property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler ZoomChanged;

        /// <summary>
        ///     Occurs when the ZoomLevels property is changed
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler ZoomLevelsChanged;

        #endregion

        /// <summary>
        ///     Creates a bitmap image containing a 2x2 grid using the specified cell size and colors.
        /// </summary>
        /// <param name="cellSize">Size of the cell.</param>
        /// <param name="cellColor">Cell color.</param>
        /// <param name="alternateCellColor">Alternate cell color.</param>
        /// <returns></returns>
        public static Bitmap CreateCheckerBoxTile(int cellSize, Color cellColor, Color alternateCellColor)
        {
            Bitmap result;
            int width;
            int height;

            // draw the tile
            width = cellSize*2;
            height = cellSize*2;
            result = new Bitmap(width, height);

            using (var g = Graphics.FromImage(result))
            {
                using (Brush brush = new SolidBrush(cellColor))
                {
                    g.FillRectangle(brush, new Rectangle(cellSize, 0, cellSize, cellSize));
                    g.FillRectangle(brush, new Rectangle(0, cellSize, cellSize, cellSize));
                }

                using (Brush brush = new SolidBrush(alternateCellColor))
                {
                    g.FillRectangle(brush, new Rectangle(0, 0, cellSize, cellSize));
                    g.FillRectangle(brush, new Rectangle(cellSize, cellSize, cellSize, cellSize));
                }
            }

            return result;
        }

        /// <summary>
        ///     Creates a checked tile texture using default values.
        /// </summary>
        /// <returns></returns>
        public static Bitmap CreateCheckerBoxTile()
        {
            return CreateCheckerBoxTile(8, Color.Gainsboro, Color.WhiteSmoke);
        }

        #region Properties

        /// <summary>
        ///     Gets or sets a value indicating whether clicking the control with the mouse will automatically zoom in or out.
        /// </summary>
        /// <value>
        ///     <c>true</c> if clicking the control allows zooming; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(false), Category("Behavior")]
        public virtual bool AllowClickZoom
        {
            get { return _allowClickZoom; }
            set
            {
                if (_allowClickZoom != value)
                {
                    _allowClickZoom = value;
                    OnAllowClickZoomChanged(EventArgs.Empty);
                }
            }
        }

        [Category("Behavior"), DefaultValue(false)]
        public virtual bool AllowDoubleClick
        {
            get { return _allowDoubleClick; }
            set
            {
                if (AllowDoubleClick != value)
                {
                    _allowDoubleClick = value;

                    OnAllowDoubleClickChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether the user can change the zoom level.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the zoom level can be changed; otherwise, <c>false</c>.
        /// </value>
        [Category("Behavior"), DefaultValue(true)]
        public virtual bool AllowZoom
        {
            get { return _allowZoom; }
            set
            {
                if (AllowZoom != value)
                {
                    _allowZoom = value;

                    OnAllowZoomChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether the image is centered where possible.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the image should be centered where possible; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(true), Category("Appearance")]
        public virtual bool AutoCenter
        {
            get { return _autoCenter; }
            set
            {
                if (_autoCenter != value)
                {
                    _autoCenter = value;
                    OnAutoCenterChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///     Gets or sets if the mouse can be used to pan the control.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the control can be auto panned; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>If this property is set, the SizeToFit property cannot be used.</remarks>
        [DefaultValue(true), Category("Behavior")]
        public virtual bool AutoPan
        {
            get { return _autoPan; }
            set
            {
                if (_autoPan != value)
                {
                    _autoPan = value;
                    OnAutoPanChanged(EventArgs.Empty);

                    if (value)
                        SizeToFit = false;
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether the container enables the user to scroll to any content placed outside of its visible boundaries.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the container enables auto-scrolling; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(true)]
        public override bool AutoScroll
        {
            get { return base.AutoScroll; }
            set { base.AutoScroll = value; }
        }

        /// <summary>
        ///     Gets or sets the minimum size of the auto-scroll.
        /// </summary>
        /// <value></value>
        /// <returns>
        ///     A <see cref="T:System.Drawing.Size" /> that determines the minimum size of the virtual area through which the user can scroll.
        /// </returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Size AutoScrollMinSize
        {
            get { return base.AutoScrollMinSize; }
            set { base.AutoScrollMinSize = value; }
        }

        /// <summary>
        ///     Specifies if the control should auto size to fit the image contents.
        /// </summary>
        /// <value></value>
        /// <returns>
        ///     <c>true</c> if enabled; otherwise, <c>false</c>
        /// </returns>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), DefaultValue(false)]
        public override bool AutoSize
        {
            get { return base.AutoSize; }
            set
            {
                if (base.AutoSize != value)
                {
                    base.AutoSize = value;
                    AdjustLayout();
                }
            }
        }

        /// <summary>
        ///     Gets or sets the background color for the control.
        /// </summary>
        /// <value></value>
        /// <returns>
        ///     A <see cref="T:System.Drawing.Color" /> that represents the background color of the control. The default is the value of the
        ///     <see
        ///         cref="P:System.Windows.Forms.Control.DefaultBackColor" />
        ///     property.
        /// </returns>
        [DefaultValue(typeof (Color), "White")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        /// <summary>
        ///     Gets or sets the background image displayed in the control.
        /// </summary>
        /// <value></value>
        /// <returns>
        ///     An <see cref="T:System.Drawing.Image" /> that represents the image to display in the background of the control.
        /// </returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Image BackgroundImage
        {
            get { return base.BackgroundImage; }
            set { base.BackgroundImage = value; }
        }

        /// <summary>
        ///     Gets or sets the background image layout as defined in the <see cref="T:System.Windows.Forms.ImageLayout" /> enumeration.
        /// </summary>
        /// <value>The background image layout.</value>
        /// <returns>
        ///     One of the values of <see cref="T:System.Windows.Forms.ImageLayout" /> (
        ///     <see
        ///         cref="F:System.Windows.Forms.ImageLayout.Center" />
        ///     , <see cref="F:System.Windows.Forms.ImageLayout.None" />,
        ///     <see
        ///         cref="F:System.Windows.Forms.ImageLayout.Stretch" />
        ///     , <see cref="F:System.Windows.Forms.ImageLayout.Tile" />, or
        ///     <see
        ///         cref="F:System.Windows.Forms.ImageLayout.Zoom" />
        ///     ). <see cref="F:System.Windows.Forms.ImageLayout.Tile" /> is the default value.
        /// </returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ImageLayout BackgroundImageLayout
        {
            get { return base.BackgroundImageLayout; }
            set { base.BackgroundImageLayout = value; }
        }

        [Category("Appearance")]
        public virtual Image BackgroundTile
        {
            get { return _backgroundTile; }
            set
            {
                if (_backgroundTile != value)
                {
                    _backgroundTile = value;

                    OnBackgroundTileChanged();
                }
            }
        }

        /// <summary>
        ///     Gets or sets the size of the drop shadow.
        /// </summary>
        /// <value>The size of the drop shadow.</value>
        [Category("Appearance"), DefaultValue(3)]
        public virtual int DropShadowSize
        {
            get { return _dropShadowSize; }
            set
            {
                if (DropShadowSize != value)
                {
                    _dropShadowSize = value;

                    OnDropShadowSizeChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the font of the text displayed by the control.
        /// </summary>
        /// <value></value>
        /// <returns>
        ///     The <see cref="T:System.Drawing.Font" /> to apply to the text displayed by the control. The default is the value of the
        ///     <see
        ///         cref="P:System.Windows.Forms.Control.DefaultFont" />
        ///     property.
        /// </returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Font Font
        {
            get { return base.Font; }
            set { base.Font = value; }
        }

        /// <summary>
        ///     Gets or sets the size of the grid cells.
        /// </summary>
        /// <value>The size of the grid cells.</value>
        [Category("Appearance"), DefaultValue(8)]
        public virtual int GridCellSize
        {
            get { return _gridCellSize; }
            set
            {
                if (_gridCellSize != value)
                {
                    _gridCellSize = value;
                    OnGridCellSizeChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the color of primary cells in the grid.
        /// </summary>
        /// <value>The color of primary cells in the grid.</value>
        [Category("Appearance"), DefaultValue(typeof (Color), "Gainsboro")]
        public virtual Color GridColor
        {
            get { return _gridColor; }
            set
            {
                if (_gridColor != value)
                {
                    _gridColor = value;
                    OnGridColorChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the color of alternate cells in the grid.
        /// </summary>
        /// <value>The color of alternate cells in the grid.</value>
        [Category("Appearance"), DefaultValue(typeof (Color), "White")]
        public virtual Color GridColorAlternate
        {
            get { return _gridColorAlternate; }
            set
            {
                if (_gridColorAlternate != value)
                {
                    _gridColorAlternate = value;
                    OnGridColorAlternateChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the grid display mode.
        /// </summary>
        /// <value>The grid display mode.</value>
        [DefaultValue(ImageBoxGridDisplayMode.Client), Category("Appearance")]
        public virtual ImageBoxGridDisplayMode GridDisplayMode
        {
            get { return _gridDisplayMode; }
            set
            {
                if (_gridDisplayMode != value)
                {
                    _gridDisplayMode = value;
                    OnGridDisplayModeChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the grid scale.
        /// </summary>
        /// <value>The grid scale.</value>
        [DefaultValue(typeof (ImageBoxGridScale), "Small"), Category("Appearance")]
        public virtual ImageBoxGridScale GridScale
        {
            get { return _gridScale; }
            set
            {
                if (_gridScale != value)
                {
                    _gridScale = value;
                    OnGridScaleChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        [Category("Appearance"), DefaultValue(null)]
        public virtual Image Image
        {
            get { return _image; }
            set
            {
                if (_image != value)
                {
                    _image = value;
                    OnImageChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the color of the image border.
        /// </summary>
        /// <value>The color of the image border.</value>
        [Category("Appearance"), DefaultValue(typeof (Color), "ControlDark")]
        public virtual Color ImageBorderColor
        {
            get { return _imageBorderColor; }
            set
            {
                if (ImageBorderColor != value)
                {
                    _imageBorderColor = value;

                    OnImageBorderColorChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the image border style.
        /// </summary>
        /// <value>The image border style.</value>
        [Category("Appearance"), DefaultValue(typeof (ImageBoxBorderStyle), "None")]
        public virtual ImageBoxBorderStyle ImageBorderStyle
        {
            get { return _imageBorderStyle; }
            set
            {
                if (ImageBorderStyle != value)
                {
                    _imageBorderStyle = value;

                    OnImageBorderStyleChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the interpolation mode.
        /// </summary>
        /// <value>The interpolation mode.</value>
        [Category("Appearance"), DefaultValue(InterpolationMode.NearestNeighbor)]
        public virtual InterpolationMode InterpolationMode
        {
            get { return _interpolationMode; }
            set
            {
                if (value == InterpolationMode.Invalid)
                    value = InterpolationMode.Default;

                if (_interpolationMode != value)
                {
                    _interpolationMode = value;
                    OnInterpolationModeChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether the mouse should be inverted when panning the control.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the mouse should be inverted when panning the control; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(false), Category("Behavior")]
        public virtual bool InvertMouse
        {
            get { return _invertMouse; }
            set
            {
                if (_invertMouse != value)
                {
                    _invertMouse = value;
                    OnInvertMouseChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///     Gets a value indicating whether this control is panning.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this control is panning; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public virtual bool IsPanning
        {
            get { return _isPanning; }
            protected set
            {
                if (_isPanning != value)
                {
                    CancelEventArgs args;

                    args = new CancelEventArgs();

                    if (value)
                        OnPanStart(args);
                    else
                        OnPanEnd(EventArgs.Empty);

                    if (!args.Cancel)
                    {
                        _isPanning = value;

                        if (value)
                        {
                            _startScrollPosition = AutoScrollPosition;
                            Cursor = Cursors.SizeAll;
                        }
                        else
                            Cursor = Cursors.Default;
                    }
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this a selection region is currently being drawn.
        /// </summary>
        /// <value>
        ///     <c>true</c> if a selection region is currently being drawn; otherwise, <c>false</c>.
        /// </value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool IsSelecting
        {
            get { return _isSelecting; }
            protected set
            {
                if (_isSelecting != value)
                {
                    CancelEventArgs args;

                    args = new CancelEventArgs();

                    if (value)
                        OnSelecting(args);
                    else
                        OnSelected(EventArgs.Empty);

                    if (!args.Cancel)
                        _isSelecting = value;
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether selection regions should be limited to the image boundaries.
        /// </summary>
        /// <value>
        ///     <c>true</c> if selection regions should be limited to image boundaries; otherwise, <c>false</c>.
        /// </value>
        [Category("Behavior"), DefaultValue(true)]
        public virtual bool LimitSelectionToImage
        {
            get { return _limitSelectionToImage; }
            set
            {
                if (LimitSelectionToImage != value)
                {
                    _limitSelectionToImage = value;

                    OnLimitSelectionToImageChanged(EventArgs.Empty);
                }
            }
        }

        [Category("Appearance"), DefaultValue(typeof (Color), "DimGray")]
        public virtual Color PixelGridColor
        {
            get { return _pixelGridColor; }
            set
            {
                if (PixelGridColor != value)
                {
                    _pixelGridColor = value;

                    OnPixelGridColorChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the color of selection regions.
        /// </summary>
        /// <value>
        ///     The color of selection regions.
        /// </value>
        [Category("Appearance"), DefaultValue(typeof (Color), "Highlight")]
        public virtual Color SelectionColor
        {
            get { return _selectionColor; }
            set
            {
                if (SelectionColor != value)
                {
                    _selectionColor = value;

                    OnSelectionColorChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the selection mode.
        /// </summary>
        /// <value>
        ///     The selection mode.
        /// </value>
        [Category("Behavior"), DefaultValue(typeof (ImageBoxSelectionMode), "None")]
        public virtual ImageBoxSelectionMode SelectionMode
        {
            get { return _selectionMode; }
            set
            {
                if (SelectionMode != value)
                {
                    _selectionMode = value;

                    OnSelectionModeChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the selection region.
        /// </summary>
        /// <value>
        ///     The selection region.
        /// </value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual RectangleF SelectionRegion
        {
            get { return _selectionRegion; }
            set
            {
                if (SelectionRegion != value)
                {
                    _selectionRegion = value;

                    OnSelectionRegionChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether the defined shortcuts are enabled.
        /// </summary>
        /// <value>
        ///     <c>true</c> to enable the shortcuts; otherwise, <c>false</c>.
        /// </value>
        [Category("Behavior"), DefaultValue(true)]
        public virtual bool ShortcutsEnabled
        {
            get { return _shortcutsEnabled; }
            set
            {
                if (ShortcutsEnabled != value)
                {
                    _shortcutsEnabled = value;

                    OnShortcutsEnabledChanged(EventArgs.Empty);
                }
            }
        }

        [Category("Appearance"), DefaultValue(false)]
        public virtual bool ShowPixelGrid
        {
            get { return _showPixelGrid; }
            set
            {
                if (ShowPixelGrid != value)
                {
                    _showPixelGrid = value;

                    OnShowPixelGridChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether the control should automatically size to fit the image contents.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the control should size to fit the image contents; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(false), Category("Appearance")]
        public virtual bool SizeToFit
        {
            get { return _sizeToFit; }
            set
            {
                if (_sizeToFit != value)
                {
                    _sizeToFit = value;
                    OnSizeToFitChanged(EventArgs.Empty);

                    if (value)
                        AutoPan = false;
                    //else
                       // ActualSize();
                }
            }
        }

        /// <summary>
        ///     This property is not relevant for this class.
        /// </summary>
        /// <value></value>
        /// <returns>
        ///     The text associated with this control.
        /// </returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether the control acts as a virtual image box.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the control acts as a virtual image box; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        ///     When this property is set to <c>true</c>, the Image property is ignored in favor of the VirtualSize property. In addition, the VirtualDraw event is raised to allow custom painting of the image area.
        /// </remarks>
        [Category("Behavior"), DefaultValue(false)]
        public virtual bool VirtualMode
        {
            get { return _virtualMode; }
            set
            {
                if (VirtualMode != value)
                {
                    _virtualMode = value;

                    OnVirtualModeChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the size of the virtual image.
        /// </summary>
        /// <value>The size of the virtual image.</value>
        [Category("Appearance"), DefaultValue(typeof (Size), "0, 0")]
        public virtual Size VirtualSize
        {
            get { return _virtualSize; }
            set
            {
                if (VirtualSize != value)
                {
                    _virtualSize = value;

                    OnVirtualSizeChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the zoom.
        /// </summary>
        /// <value>The zoom.</value>
        [DefaultValue(100), Category("Appearance")]
        public virtual int Zoom
        {
            get { return _zoom; }
            set
            {
                if (value < MinZoom)
                    value = MinZoom;
                else if (value > MaxZoom)
                    value = MaxZoom;

                if (_zoom != value)
                {
                    _zoom = value;
                    OnZoomChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///     Gets the zoom factor.
        /// </summary>
        /// <value>The zoom factor.</value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual double ZoomFactor
        {
            get { return (double) Zoom/100; }
        }

        /// <summary>
        ///     Gets or sets the zoom levels.
        /// </summary>
        /// <value>The zoom levels.</value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
            /*Category("Behavior"), DefaultValue(typeof(ZoomLevelCollection), "7, 10, 15, 20, 25, 30, 50, 70, 100, 150, 200, 300, 400, 500, 600, 700, 800, 1200, 1600")*/
        ]
        public virtual ZoomLevelCollection ZoomLevels
        {
            get { return _zoomLevels; }
            set
            {
                if (ZoomLevels != value)
                {
                    _zoomLevels = value;

                    OnZoomLevelsChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///     Gets a value indicating whether painting of the control is allowed.
        /// </summary>
        /// <value>
        ///     <c>true</c> if painting of the control is allowed; otherwise, <c>false</c>.
        /// </value>
        protected virtual bool AllowPainting
        {
            get { return _updateCount == 0; }
        }

        /// <summary>
        ///     Gets the height of the scaled image.
        /// </summary>
        /// <value>The height of the scaled image.</value>
        protected virtual int ScaledImageHeight
        {
            get { return Convert.ToInt32(ViewSize.Height*ZoomFactor); }
        }

        /// <summary>
        ///     Gets the width of the scaled image.
        /// </summary>
        /// <value>The width of the scaled image.</value>
        protected virtual int ScaledImageWidth
        {
            get { return Convert.ToInt32(ViewSize.Width*ZoomFactor); }
        }

        protected virtual Size ViewSize
        {
            get { return VirtualMode ? VirtualSize : Image != null ? Image.Size : Size.Empty; }
        }

        #endregion

        #region Members

        /// <summary>
        ///     Resets the zoom to 100%.
        /// </summary>
        public virtual void ActualSize()
        {
            if (SizeToFit)
                SizeToFit = false;

            Zoom = 100;
        }

        /// <summary>
        ///     Disables any redrawing of the image box
        /// </summary>
        public virtual void BeginUpdate()
        {
            _updateCount++;
        }

        /// <summary>
        ///     Centers the given point in the image in the center of the control
        /// </summary>
        /// <param name="imageLocation">The point of the image to attempt to center.</param>
        public virtual void CenterAt(Point imageLocation)
        {
            ScrollTo(imageLocation, new Point(ClientSize.Width/2, ClientSize.Height/2));
        }

        /// <summary>
        ///     Enables the redrawing of the image box
        /// </summary>
        public virtual void EndUpdate()
        {
            if (_updateCount > 0)
                _updateCount--;

            if (AllowPainting)
                Invalidate();
        }

        /// <summary>
        ///     Fits a given <see cref="T:System.Drawing.Rectangle" /> to match image boundaries
        /// </summary>
        /// <param name="rectangle">The rectangle.</param>
        /// <returns>
        ///     A <see cref="T:System.Drawing.Rectangle" /> structure remapped to fit the image boundaries
        /// </returns>
        public Rectangle FitRectangle(Rectangle rectangle)
        {
            int x;
            int y;
            int w;
            int h;

            x = rectangle.X;
            y = rectangle.Y;
            w = rectangle.Width;
            h = rectangle.Height;

            if (x < 0)
                x = 0;

            if (y < 0)
                y = 0;

            if (x + w > ViewSize.Width)
                w = ViewSize.Width - x;

            if (y + h > ViewSize.Height)
                h = ViewSize.Height - y;

            return new Rectangle(x, y, w, h);
        }

        /// <summary>
        ///     Fits a given <see cref="T:System.Drawing.RectangleF" /> to match image boundaries
        /// </summary>
        /// <param name="rectangle">The rectangle.</param>
        /// <returns>
        ///     A <see cref="T:System.Drawing.RectangleF" /> structure remapped to fit the image boundaries
        /// </returns>
        public RectangleF FitRectangle(RectangleF rectangle)
        {
            float x;
            float y;
            float w;
            float h;

            x = rectangle.X;
            y = rectangle.Y;
            w = rectangle.Width;
            h = rectangle.Height;

            if (x < 0)
                x = 0;

            if (y < 0)
                y = 0;

            if (x + w > ViewSize.Width)
                w = ViewSize.Width - x;

            if (y + h > ViewSize.Height)
                h = ViewSize.Height - y;

            return new RectangleF(x, y, w, h);
        }

        /// <summary>
        ///     Gets the image view port.
        /// </summary>
        /// <returns></returns>
        public virtual Rectangle GetImageViewPort()
        {
            Rectangle viewPort;

            if (!ViewSize.IsEmpty)
            {
                Rectangle innerRectangle;
                Point offset;
                int width;
                int height;

                innerRectangle = GetInsideViewPort(true);

                if (!HScroll && !VScroll)
                    // if no scrolling is present, tinker the view port so that the image and any applicable borders all fit inside
                    innerRectangle.Inflate(-GetImageBorderOffset(), -GetImageBorderOffset());

                if (AutoCenter)
                {
                    int x;
                    int y;

                    x = !HScroll ? (innerRectangle.Width - (ScaledImageWidth + Padding.Horizontal))/2 : 0;
                    y = !VScroll ? (innerRectangle.Height - (ScaledImageHeight + Padding.Vertical))/2 : 0;

                    offset = new Point(x, y);
                }
                else
                    offset = Point.Empty;

                width = Math.Min(ScaledImageWidth - Math.Abs(AutoScrollPosition.X), innerRectangle.Width);
                height = Math.Min(ScaledImageHeight - Math.Abs(AutoScrollPosition.Y), innerRectangle.Height);

                viewPort = new Rectangle(offset.X + innerRectangle.Left, offset.Y + innerRectangle.Top, width, height);
            }
            else
                viewPort = Rectangle.Empty;

            return viewPort;
        }

        /// <summary>
        ///     Gets the inside view port, excluding any padding.
        /// </summary>
        /// <returns></returns>
        public Rectangle GetInsideViewPort()
        {
            return GetInsideViewPort(false);
        }

        /// <summary>
        ///     Gets the inside view port.
        /// </summary>
        /// <param name="includePadding">
        ///     if set to <c>true</c> [include padding].
        /// </param>
        /// <returns></returns>
        public virtual Rectangle GetInsideViewPort(bool includePadding)
        {
            int left;
            int top;
            int width;
            int height;

            left = 0;
            top = 0;
            width = ClientSize.Width;
            height = ClientSize.Height;

            if (includePadding)
            {
                left += Padding.Left;
                top += Padding.Top;
                width -= Padding.Horizontal;
                height -= Padding.Vertical;
            }

            return new Rectangle(left, top, width, height);
        }

        /// <summary>
        ///     Returns the source <see cref="T:System.Drawing.Point" /> repositioned to include the current image offset and scaled by the current zoom level
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>A Point which has been repositioned to match the current zoom level and image offset</returns>
        public virtual Point GetOffsetPoint(Point source)
        {
            PointF offset;

            offset = GetOffsetPoint(new PointF(source.X, source.Y));

            return new Point((int) offset.X, (int) offset.Y);
        }

        /// <summary>
        ///     Returns the source <see cref="T:System.Drawing.PointF" /> repositioned to include the current image offset and scaled by the current zoom level
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>A Point which has been repositioned to match the current zoom level and image offset</returns>
        public virtual PointF GetOffsetPoint(PointF source)
        {
            Rectangle viewport;
            PointF scaled;
            int offsetX;
            int offsetY;

            viewport = GetImageViewPort();
            scaled = GetScaledPoint(source);
            offsetX = viewport.Left + Padding.Left + AutoScrollPosition.X;
            offsetY = viewport.Top + Padding.Top + AutoScrollPosition.Y;

            return new PointF(scaled.X + offsetX, scaled.Y + offsetY);
        }

        /// <summary>
        ///     Returns the source <see cref="T:System.Drawing.RectangleF" /> scaled according to the current zoom level and repositioned to include the current image offset
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>A Rectangle which has been resized and repositioned to match the current zoom level and image offset</returns>
        public virtual RectangleF GetOffsetRectangle(RectangleF source)
        {
            RectangleF viewport;
            RectangleF scaled;
            float offsetX;
            float offsetY;

            viewport = GetImageViewPort();
            scaled = GetScaledRectangle(source);
            offsetX = viewport.Left + Padding.Left + AutoScrollPosition.X;
            offsetY = viewport.Top + Padding.Top + AutoScrollPosition.Y;

            return new RectangleF(new PointF(scaled.Left + offsetX, scaled.Top + offsetY), scaled.Size);
        }

        /// <summary>
        ///     Retrieves the size of a rectangular area into which a control can be fitted.
        /// </summary>
        /// <param name="proposedSize">The custom-sized area for a control.</param>
        /// <returns>
        ///     An ordered pair of type <see cref="T:System.Drawing.Size" /> representing the width and height of a rectangle.
        /// </returns>
        public override Size GetPreferredSize(Size proposedSize)
        {
            Size size;

            if (!ViewSize.IsEmpty)
            {
                int width;
                int height;

                // get the size of the image
                width = ScaledImageWidth;
                height = ScaledImageHeight;

                // add an offset based on padding
                width += Padding.Horizontal;
                height += Padding.Vertical;

                // add an offset based on the border style
                width += GetImageBorderOffset();
                height += GetImageBorderOffset();

                size = new Size(width, height);
            }
            else
                size = base.GetPreferredSize(proposedSize);

            return size;
        }

        /// <summary>
        ///     Returns the source <see cref="T:System.Drawing.Point" /> scaled according to the current zoom level
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>A Point which has been scaled to match the current zoom level</returns>
        public virtual Point GetScaledPoint(Point source)
        {
            return new Point((int) (source.X*ZoomFactor), (int) (source.Y*ZoomFactor));
        }

        /// <summary>
        ///     Returns the source <see cref="T:System.Drawing.PointF" /> scaled according to the current zoom level
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>A Point which has been scaled to match the current zoom level</returns>
        public virtual PointF GetScaledPoint(PointF source)
        {
            return new PointF((float) (source.X*ZoomFactor), (float) (source.Y*ZoomFactor));
        }

        /// <summary>
        ///     Returns the source <see cref="T:System.Drawing.Rectangle" /> scaled according to the current zoom level
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>A Rectangle which has been resized to match the current zoom level</returns>
        public virtual Rectangle GetScaledRectangle(Rectangle source)
        {
            return new Rectangle((int) (source.Left*ZoomFactor), (int) (source.Top*ZoomFactor),
                                 (int) (source.Width*ZoomFactor), (int) (source.Height*ZoomFactor));
        }

        /// <summary>
        ///     Returns the source <see cref="T:System.Drawing.RectangleF" /> scaled according to the current zoom level
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>A Rectangle which has been resized to match the current zoom level</returns>
        public virtual RectangleF GetScaledRectangle(RectangleF source)
        {
            return new RectangleF((float) (source.Left*ZoomFactor), (float) (source.Top*ZoomFactor),
                                  (float) (source.Width*ZoomFactor), (float) (source.Height*ZoomFactor));
        }

        /// <summary>
        ///     Returns the source <see cref="T:System.Drawing.SizeF" /> scaled according to the current zoom level
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>A Size which has been resized to match the current zoom level</returns>
        public virtual SizeF GetScaledSize(SizeF source)
        {
            return new SizeF((float) (source.Width*ZoomFactor), (float) (source.Height*ZoomFactor));
        }

        /// <summary>
        ///     Returns the source <see cref="T:System.Drawing.Size" /> scaled according to the current zoom level
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>A Size which has been resized to match the current zoom level</returns>
        public virtual Size GetScaledSize(Size source)
        {
            return new Size((int) (source.Width*ZoomFactor), (int) (source.Height*ZoomFactor));
        }

        /// <summary>
        ///     Creates an image based on the current selection region
        /// </summary>
        /// <returns>An image containing the selection contents if a selection if present, otherwise null</returns>
        /// <remarks>The caller is responsible for disposing of the returned image</remarks>
        public Image GetSelectedImage()
        {
            Image result;

            if (!SelectionRegion.IsEmpty)
            {
                Rectangle rect;

                rect =
                    FitRectangle(new Rectangle((int) SelectionRegion.X, (int) SelectionRegion.Y,
                                               (int) SelectionRegion.Width, (int) SelectionRegion.Height));

                result = new Bitmap(rect.Width, rect.Height);

                using (var g = Graphics.FromImage(result))
                    g.DrawImage(Image, new Rectangle(Point.Empty, rect.Size), rect, GraphicsUnit.Pixel);
            }
            else
                result = null;

            return result;
        }

        /// <summary>
        ///     Gets the source image region.
        /// </summary>
        /// <returns></returns>
        public virtual RectangleF GetSourceImageRegion()
        {
            RectangleF region;

            if (!ViewSize.IsEmpty)
            {
                float sourceLeft;
                float sourceTop;
                float sourceWidth;
                float sourceHeight;
                Rectangle viewPort;

                viewPort = GetImageViewPort();
                sourceLeft = (float) (-AutoScrollPosition.X/ZoomFactor);
                sourceTop = (float) (-AutoScrollPosition.Y/ZoomFactor);
                sourceWidth = (float) (viewPort.Width/ZoomFactor);
                sourceHeight = (float) (viewPort.Height/ZoomFactor);

                region = new RectangleF(sourceLeft, sourceTop, sourceWidth, sourceHeight);
            }
            else
                region = RectangleF.Empty;

            return region;
        }

        /// <summary>
        ///     Determines whether the specified point is located within the image view port
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns>
        ///     <c>true</c> if the specified point is located within the image view point; otherwise, <c>false</c>.
        /// </returns>
        public virtual bool IsPointInImage(Point point)
        {
            return GetImageViewPort().Contains(point);
        }

        /// <summary>
        ///     Converts the given client size point to represent a coordinate on the source image.
        /// </summary>
        /// <param name="point">The source point.</param>
        /// <returns>Point.Empty is the point could not be matched to the source image, otherwise the new translated point</returns>
        /// <remarks>If a match is made, the return will be offset by 1</remarks>
        public virtual Point PointToImage(Point point)
        {
            return PointToImage(point, false);
        }

        /// <summary>
        ///     Converts the given client size point to represent a coordinate on the source image.
        /// </summary>
        /// <param name="point">The source point.</param>
        /// <param name="fitToBounds">
        ///     if set to <c>true</c> and the point is outside the bounds of the source image, it will be mapped to the nearest edge.
        /// </param>
        /// <returns>Point.Empty is the point could not be matched to the source image, otherwise the new translated point</returns>
        /// <remarks>If a match is made, the return will be offset by 1</remarks>
        public virtual Point PointToImage(Point point, bool fitToBounds)
        {
            Rectangle viewport;
            int x;
            int y;

            viewport = GetImageViewPort();

            if (viewport.Contains(point) || fitToBounds)
            {
                if (AutoScrollPosition != Point.Empty)
                    point = new Point(point.X - AutoScrollPosition.X, point.Y - AutoScrollPosition.Y);

                x = (int) ((point.X - viewport.X)/ZoomFactor);
                y = (int) ((point.Y - viewport.Y)/ZoomFactor);

                if (x < 0)
                    x = 0;
                else if (x > ViewSize.Width)
                    x = ViewSize.Width;

                if (y < 0)
                    y = 0;
                else if (y > ViewSize.Height)
                    y = ViewSize.Height;
            }
            else
            {
                x = 0; // Return Point.Empty if we couldn't match
                y = 0;
            }

            return new Point(x, y);
        }

        /// <summary>
        ///     Scrolls the control to the given point in the image, offset at the specified display point
        /// </summary>
        /// <param name="imageLocation">The point of the image to attempt to scroll to.</param>
        /// <param name="relativeDisplayPoint">The relative display point to offset scrolling by.</param>
        public virtual void ScrollTo(Point imageLocation, Point relativeDisplayPoint)
        {
            int x;
            int y;

            x = (int) (imageLocation.X*ZoomFactor) - relativeDisplayPoint.X;
            y = (int) (imageLocation.Y*ZoomFactor) - relativeDisplayPoint.Y;

            AutoScrollPosition = new Point(x, y);
        }

        /// <summary>
        ///     Creates a selection region which encompasses the entire image
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown if no image is currently set</exception>
        public virtual void SelectAll()
        {
            if (Image == null)
                throw new InvalidOperationException("No image set");

            SelectionRegion = new RectangleF(PointF.Empty, Image.Size);
        }

        /// <summary>
        ///     Clears any existing selection region
        /// </summary>
        public virtual void SelectNone()
        {
            SelectionRegion = RectangleF.Empty;
        }

        /// <summary>
        ///     zooms into the image
        /// </summary>
        public virtual void ZoomIn()
        {
            if (SizeToFit)
            {
                int previousZoom;

                previousZoom = Zoom;
                SizeToFit = false;
                Zoom = previousZoom; // Stop the zoom getting reset to 100% before calculating the new zoom
            }

            Zoom = ZoomLevels.NextZoom(Zoom);
        }

        /// <summary>
        ///     Zooms out of the image
        /// </summary>
        public virtual void ZoomOut()
        {
            if (SizeToFit)
            {
                int previousZoom;

                previousZoom = Zoom;
                SizeToFit = false;
                Zoom = previousZoom; // Stop the zoom getting reset to 100% before calculating the new zoom
            }

            Zoom = ZoomLevels.PreviousZoom(Zoom);
        }

        /// <summary>
        ///     Zooms to the maximum size for displaying the entire image within the bounds of the control.
        /// </summary>
        public virtual void ZoomToFit()
        {
            if (!ViewSize.IsEmpty)
            {
                Rectangle innerRectangle;
                double zoom;
                double aspectRatio;

                AutoScrollMinSize = Size.Empty;

                innerRectangle = GetInsideViewPort(true);

                if (Image.Width > Image.Height)
                {
                    aspectRatio = (double) innerRectangle.Width/Image.Width;
                    zoom = aspectRatio*100.0;

                    if (innerRectangle.Height < ((Image.Height*zoom)/100.0))
                    {
                        aspectRatio = (double) innerRectangle.Height/Image.Height;
                        zoom = aspectRatio*100.0;
                    }
                }
                else
                {
                    aspectRatio = (double) innerRectangle.Height/Image.Height;
                    zoom = aspectRatio*100.0;

                    if (innerRectangle.Width < ((Image.Width*zoom)/100.0))
                    {
                        aspectRatio = (double) innerRectangle.Width/Image.Width;
                        zoom = aspectRatio*100.0;
                    }
                }

                Zoom = (int) Math.Round(Math.Floor(zoom));
            }
        }

        /// <summary>
        ///     Adjusts the view port to fit the  given region
        /// </summary>
        /// <param name="rectangle">The rectangle to fit the view port to.</param>
        public virtual void ZoomToRegion(RectangleF rectangle)
        {
            double ratioX;
            double ratioY;
            double zoomFactor;
            int cx;
            int cy;

            ratioX = ClientSize.Width/rectangle.Width;
            ratioY = ClientSize.Height/rectangle.Height;
            zoomFactor = Math.Min(ratioX, ratioY);
            cx = (int) (rectangle.X + (rectangle.Width/2));
            cy = (int) (rectangle.Y + (rectangle.Height/2));

            Zoom = (int) (zoomFactor*100);
            CenterAt(new Point(cx, cy));
        }

        /// <summary>
        ///     Adjusts the layout.
        /// </summary>
        protected virtual void AdjustLayout()
        {
            if (AutoSize)
                AdjustSize();
            else if (SizeToFit)
                ZoomToFit();
            else if (AutoScroll)
                AdjustViewPort();

            Invalidate();
        }

        /// <summary>
        ///     Adjusts the scroll.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        protected virtual void AdjustScroll(int x, int y)
        {
            Point scrollPosition;

            scrollPosition = new Point(HorizontalScroll.Value + x, VerticalScroll.Value + y);

            UpdateScrollPosition(scrollPosition);
        }

        /// <summary>
        ///     Adjusts the size.
        /// </summary>
        protected virtual void AdjustSize()
        {
            if (AutoSize && Dock == DockStyle.None)
                base.Size = base.PreferredSize;
        }

        /// <summary>
        ///     Adjusts the view port.
        /// </summary>
        protected virtual void AdjustViewPort()
        {
            if (AutoScroll && !ViewSize.IsEmpty)
                AutoScrollMinSize = new Size(ScaledImageWidth + Padding.Horizontal,
                                             ScaledImageHeight + Padding.Vertical);
        }

        /// <summary>
        ///     Creates the grid tile image.
        /// </summary>
        /// <param name="cellSize">Size of the cell.</param>
        /// <param name="firstColor">The first color.</param>
        /// <param name="secondColor">Color of the second.</param>
        /// <returns></returns>
        protected virtual Bitmap CreateGridTileImage(int cellSize, Color firstColor, Color secondColor)
        {
            float scale;

            // rescale the cell size
            switch (GridScale)
            {
                case ImageBoxGridScale.Medium:
                    scale = 1.5F;
                    break;

                case ImageBoxGridScale.Large:
                    scale = 2;
                    break;
                default:
                    scale = 1;
                    break;
            }

            cellSize = (int) (cellSize*scale);

            return CreateCheckerBoxTile(cellSize, firstColor, secondColor);
        }

        /// <summary>
        ///     Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_texture != null)
                {
                    _texture.Dispose();
                    _texture = null;
                }

                if (_gridTile != null)
                {
                    _gridTile.Dispose();
                    _gridTile = null;
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        ///     Draws a drop shadow.
        /// </summary>
        /// <param name="g">The graphics. </param>
        /// <param name="viewPort"> The view port. </param>
        protected virtual void DrawDropShadow(Graphics g, Rectangle viewPort)
        {
            Rectangle rightEdge;
            Rectangle bottomEdge;

            rightEdge = new Rectangle(viewPort.Right + 1, viewPort.Top + DropShadowSize, DropShadowSize,
                                      viewPort.Height);
            bottomEdge = new Rectangle(viewPort.Left + DropShadowSize, viewPort.Bottom + 1, viewPort.Width + 1,
                                       DropShadowSize);

            using (Brush brush = new SolidBrush(ImageBorderColor))
                g.FillRectangles(brush, new[] {rightEdge, bottomEdge});
        }

        /// <summary>
        ///     Draws a glow shadow.
        /// </summary>
        /// <param name="g">The graphics.</param>
        /// <param name="viewPort">The view port.</param>
        protected virtual void DrawGlowShadow(Graphics g, Rectangle viewPort)
        {
            // Glow code adapted from http://www.codeproject.com/Articles/372743/gGlowBox-Create-a-glow-effect-around-a-focused-con

            g.SetClip(viewPort, CombineMode.Exclude); // make sure the inside glow doesn't appear

            using (var path = new GraphicsPath())
            {
                int glowSize;
                int feather;

                path.AddRectangle(viewPort);
                glowSize = DropShadowSize*3;
                feather = 50;

                for (var i = 1; i <= glowSize; i += 2)
                {
                    int alpha;

                    alpha = feather - ((feather/glowSize)*i);

                    using (
                        var pen = new Pen(Color.FromArgb(alpha, ImageBorderColor), i) {LineJoin = LineJoin.Round})
                        g.DrawPath(pen, path);
                }
            }
        }

        /// <summary>
        ///     Draws the image.
        /// </summary>
        /// <param name="g">The g.</param>
        protected virtual void DrawImage(Graphics g)
        {
            InterpolationMode currentInterpolationMode;
            PixelOffsetMode currentPixelOffsetMode;

            currentInterpolationMode = g.InterpolationMode;
            currentPixelOffsetMode = g.PixelOffsetMode;

            g.InterpolationMode = InterpolationMode;

            // disable pixel offsets. Thanks to Rotem for the info.
            // http://stackoverflow.com/questions/14070311/why-is-graphics-drawimage-cropping-part-of-my-image/14070372#14070372
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            g.DrawImage(Image, GetImageViewPort(), GetSourceImageRegion(), GraphicsUnit.Pixel);

            g.PixelOffsetMode = currentPixelOffsetMode;
            g.InterpolationMode = currentInterpolationMode;
        }

        /// <summary>
        ///     Draws a border around the image.
        /// </summary>
        /// <param name="graphics"> The graphics. </param>
        protected virtual void DrawImageBorder(Graphics graphics)
        {
            if (ImageBorderStyle != ImageBoxBorderStyle.None)
            {
                Rectangle viewPort;

                graphics.SetClip(GetInsideViewPort());
                    // make sure the image border doesn't overwrite the control border

                viewPort = GetImageViewPort();
                viewPort = new Rectangle(viewPort.Left - 1, viewPort.Top - 1, viewPort.Width + 1, viewPort.Height + 1);

                using (var borderPen = new Pen(ImageBorderColor))
                    graphics.DrawRectangle(borderPen, viewPort);

                switch (ImageBorderStyle)
                {
                    case ImageBoxBorderStyle.FixedSingleDropShadow:
                        DrawDropShadow(graphics, viewPort);
                        break;
                    case ImageBoxBorderStyle.FixedSingleGlowShadow:
                        DrawGlowShadow(graphics, viewPort);
                        break;
                }

                graphics.ResetClip();
            }
        }

        /// <summary>
        ///     Draws a pixel grid.
        /// </summary>
        /// <param name="g">The graphics to draw the grid to.</param>
        protected virtual void DrawPixelGrid(Graphics g)
        {
            float pixelSize;

            pixelSize = (float) ZoomFactor;

            if (pixelSize > PixelGridThreshold)
            {
                Rectangle viewport;
                float offsetX;
                float offsetY;

                viewport = GetImageViewPort();
                offsetX = Math.Abs(AutoScrollPosition.X)%pixelSize;
                offsetY = Math.Abs(AutoScrollPosition.Y)%pixelSize;

                using (var pen = new Pen(PixelGridColor) {DashStyle = DashStyle.Dot})
                {
                    for (var x = viewport.Left + pixelSize - offsetX; x < viewport.Right; x += pixelSize)
                        g.DrawLine(pen, x, viewport.Top, x, viewport.Bottom);

                    for (var y = viewport.Top + pixelSize - offsetY; y < viewport.Bottom; y += pixelSize)
                        g.DrawLine(pen, viewport.Left, y, viewport.Right, y);

                    g.DrawRectangle(pen, viewport);
                }
            }
        }

        /// <summary>
        ///     Draws the selection region.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="System.Windows.Forms.PaintEventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void DrawSelection(PaintEventArgs e)
        {
            RectangleF rect;

            e.Graphics.SetClip(GetInsideViewPort(true));

            rect = GetOffsetRectangle(SelectionRegion);

            using (Brush brush = new SolidBrush(Color.FromArgb(128, SelectionColor)))
                e.Graphics.FillRectangle(brush, rect);

            using (var pen = new Pen(SelectionColor))
                e.Graphics.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);

            e.Graphics.ResetClip();
        }

        /// <summary>
        ///     Gets an offset based on the current image border style.
        /// </summary>
        /// <returns></returns>
        protected virtual int GetImageBorderOffset()
        {
            int offset;

            switch (ImageBorderStyle)
            {
                case ImageBoxBorderStyle.FixedSingle:
                    offset = 1;
                    break;

                case ImageBoxBorderStyle.FixedSingleDropShadow:
                    offset = (DropShadowSize + 1);
                    break;
                default:
                    offset = 0;
                    break;
            }

            return offset;
        }

        /// <summary>
        ///     Determines whether the specified key is a regular input key or a special key that requires preprocessing.
        /// </summary>
        /// <param name="keyData">
        ///     One of the <see cref="T:System.Windows.Forms.Keys" /> values.
        /// </param>
        /// <returns>
        ///     true if the specified key is a regular input key; otherwise, false.
        /// </returns>
        protected override bool IsInputKey(Keys keyData)
        {
            bool result;

            if ((keyData & Keys.Right) == Keys.Right | (keyData & Keys.Left) == Keys.Left |
                (keyData & Keys.Up) == Keys.Up | (keyData & Keys.Down) == Keys.Down)
                result = true;
            else
                result = base.IsInputKey(keyData);

            return result;
        }

        /// <summary>
        ///     Raises the <see cref="AllowClickZoomChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnAllowClickZoomChanged(EventArgs e)
        {
            EventHandler handler;

            handler = AllowClickZoomChanged;

            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="AllowDoubleClickChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnAllowDoubleClickChanged(EventArgs e)
        {
            EventHandler handler;

            SetStyle(ControlStyles.StandardDoubleClick, AllowDoubleClick);
            UpdateStyles();

            handler = AllowDoubleClickChanged;

            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="AllowZoomChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnAllowZoomChanged(EventArgs e)
        {
            EventHandler handler;

            handler = AllowZoomChanged;

            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="AutoCenterChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnAutoCenterChanged(EventArgs e)
        {
            EventHandler handler;

            Invalidate();

            handler = AutoCenterChanged;

            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="AutoPanChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnAutoPanChanged(EventArgs e)
        {
            EventHandler handler;

            handler = AutoPanChanged;

            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="System.Windows.Forms.Control.BackColorChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     An <see cref="T:System.EventArgs" /> that contains the event data.
        /// </param>
        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);

            Invalidate();
        }

        /// <summary>
        ///     Raises the <see cref="ScrollControl.BorderStyleChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="EventArgs" /> instance containing the event data.
        /// </param>
        protected override void OnBorderStyleChanged(EventArgs e)
        {
            base.OnBorderStyleChanged(e);

            AdjustLayout();
        }

        /// <summary>
        ///     Raises the <see cref="System.Windows.Forms.Control.DockChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     An <see cref="T:System.EventArgs" /> that contains the event data.
        /// </param>
        protected override void OnDockChanged(EventArgs e)
        {
            base.OnDockChanged(e);

            if (Dock != DockStyle.None)
                AutoSize = false;
        }

        /// <summary>
        ///     Raises the <see cref="DropShadowSizeChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnDropShadowSizeChanged(EventArgs e)
        {
            Invalidate();

            EventHandler handler;

            handler = DropShadowSizeChanged;

            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="GridCellSizeChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnGridCellSizeChanged(EventArgs e)
        {
            EventHandler handler;

            InitializeGridTile();

            handler = GridCellSizeChanged;

            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="GridColorAlternateChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnGridColorAlternateChanged(EventArgs e)
        {
            EventHandler handler;

            InitializeGridTile();

            handler = GridColorAlternateChanged;

            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="GridColorChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnGridColorChanged(EventArgs e)
        {
            EventHandler handler;

            InitializeGridTile();

            handler = GridColorChanged;

            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="GridDisplayModeChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnGridDisplayModeChanged(EventArgs e)
        {
            EventHandler handler;

            InitializeGridTile();
            Invalidate();

            handler = GridDisplayModeChanged;

            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="GridScaleChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnGridScaleChanged(EventArgs e)
        {
            EventHandler handler;

            InitializeGridTile();

            handler = GridScaleChanged;

            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="ImageBorderColorChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnImageBorderColorChanged(EventArgs e)
        {
            EventHandler handler;

            Invalidate();

            handler = ImageBorderColorChanged;

            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="ImageBorderStyleChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnImageBorderStyleChanged(EventArgs e)
        {
            EventHandler handler;

            Invalidate();

            handler = ImageBorderStyleChanged;

            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="ImageChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnImageChanged(EventArgs e)
        {
            EventHandler handler;

            AdjustLayout();

            handler = ImageChanged;

            if (handler != null)
                handler(this, e);
        }

        protected virtual void OnBackgroundTileChanged()
        {
            InitializeGridTile();
            Invalidate();
            EventHandler handler = BackgroundTileChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        /// <summary>
        ///     Raises the <see cref="InterpolationModeChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnInterpolationModeChanged(EventArgs e)
        {
            EventHandler handler;

            Invalidate();

            handler = InterpolationModeChanged;

            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="InvertMouseChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnInvertMouseChanged(EventArgs e)
        {
            EventHandler handler;

            handler = InvertMouseChanged;

            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="System.Windows.Forms.Control.KeyDown" /> event.
        /// </summary>
        /// <param name="e">
        ///     A <see cref="T:System.Windows.Forms.KeyEventArgs" /> that contains the event data.
        /// </param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            ProcessScrollingShortcuts(e);

            if (ShortcutsEnabled)
                ProcessImageShortcuts(e);
        }

        /// <summary>
        ///     Raises the <see cref="LimitSelectionToImageChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnLimitSelectionToImageChanged(EventArgs e)
        {
            EventHandler handler;

            handler = LimitSelectionToImageChanged;

            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">
        ///     A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.
        /// </param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (!Focused)
                Focus();

            if (e.Button == MouseButtons.Left && SelectionMode != ImageBoxSelectionMode.None)
                SelectionRegion = Rectangle.Empty;
        }

        /// <summary>
        ///     Raises the <see cref="System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">
        ///     A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.
        /// </param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.Button == MouseButtons.Left)
            {
                ProcessPanning(e);
                ProcessSelection(e);
            }
        }

        /// <summary>
        ///     Raises the <see cref="System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">
        ///     A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.
        /// </param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            bool doNotProcessClick;

            base.OnMouseUp(e);

            doNotProcessClick = IsPanning || IsSelecting;

            if (IsPanning)
                IsPanning = false;

            if (IsSelecting)
                IsSelecting = false;

            if (!doNotProcessClick && AllowZoom && AllowClickZoom && !IsPanning && !SizeToFit)
            {
                if (e.Button == MouseButtons.Left && ModifierKeys == Keys.None)
                    ProcessMouseZoom(true, e.Location);
                else if (e.Button == MouseButtons.Right ||
                         (e.Button == MouseButtons.Left && ModifierKeys != Keys.None))
                    ProcessMouseZoom(false, e.Location);
            }
        }

        /// <summary>
        ///     Raises the <see cref="System.Windows.Forms.Control.MouseWheel" /> event.
        /// </summary>
        /// <param name="e">
        ///     A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.
        /// </param>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if (AllowZoom && !SizeToFit)
                ProcessMouseZoom(e.Delta > 0, e.Location);
        }

        /// <summary>
        ///     Raises the <see cref="System.Windows.Forms.Control.PaddingChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     An <see cref="T:System.EventArgs" /> that contains the event data.
        /// </param>
        protected override void OnPaddingChanged(EventArgs e)
        {
            base.OnPaddingChanged(e);
            AdjustLayout();
        }

        /// <summary>
        ///     Raises the <see cref="System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">
        ///     A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.
        /// </param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (AllowPainting)
            {
                Rectangle innerRectangle;

                innerRectangle = GetInsideViewPort();

                // draw the background
                using (var brush = new SolidBrush(BackColor))
                    e.Graphics.FillRectangle(brush, innerRectangle);

                if (_texture != null && GridDisplayMode != ImageBoxGridDisplayMode.None)
                {
                    switch (GridDisplayMode)
                    {
                        case ImageBoxGridDisplayMode.Image:
                            Rectangle fillRectangle;

                            fillRectangle = GetImageViewPort();
                            e.Graphics.FillRectangle(_texture, fillRectangle);
                            break;

                        case ImageBoxGridDisplayMode.Client:
                            e.Graphics.FillRectangle(_texture, innerRectangle);
                            break;
                    }
                }

                // draw the image
                if (!ViewSize.IsEmpty)
                    DrawImageBorder(e.Graphics);
                if (VirtualMode)
                    OnVirtualDraw(e);
                else if (Image != null)
                    DrawImage(e.Graphics);

                // draw the grid
                if (ShowPixelGrid && !VirtualMode)
                    DrawPixelGrid(e.Graphics);

                // draw the selection
                if (SelectionRegion != Rectangle.Empty)
                    DrawSelection(e);

                base.OnPaint(e);
            }
        }

        /// <summary>
        ///     Raises the <see cref="PanEnd" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnPanEnd(EventArgs e)
        {
            EventHandler handler;

            handler = PanEnd;

            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="PanStart" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="System.ComponentModel.CancelEventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnPanStart(CancelEventArgs e)
        {
            EventHandler handler;

            handler = PanStart;

            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="System.Windows.Forms.Control.ParentChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     An <see cref="T:System.EventArgs" /> that contains the event data.
        /// </param>
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            AdjustLayout();
        }

        /// <summary>
        ///     Raises the <see cref="PixelGridColorChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnPixelGridColorChanged(EventArgs e)
        {
            EventHandler handler;

            Invalidate();

            handler = PixelGridColorChanged;

            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">
        ///     An <see cref="T:System.EventArgs" /> that contains the event data.
        /// </param>
        protected override void OnResize(EventArgs e)
        {
            AdjustLayout();

            base.OnResize(e);
        }

        /// <summary>
        ///     Raises the <see cref="System.Windows.Forms.ScrollableControl.Scroll" /> event.
        /// </summary>
        /// <param name="se">
        ///     A <see cref="T:System.Windows.Forms.ScrollEventArgs" /> that contains the event data.
        /// </param>
        protected override void OnScroll(ScrollEventArgs se)
        {
            Invalidate();

            base.OnScroll(se);
        }

        /// <summary>
        ///     Raises the <see cref="Selected" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnSelected(EventArgs e)
        {
            EventHandler<EventArgs> handler;

            switch (SelectionMode)
            {
                case ImageBoxSelectionMode.Zoom:
                    if (SelectionRegion.Width > SelectionDeadZone &&
                        SelectionRegion.Height > SelectionDeadZone)
                    {
                        ZoomToRegion(SelectionRegion);
                        SelectionRegion = RectangleF.Empty;
                    }
                    break;
            }

            handler = Selected;

            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="Selecting" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnSelecting(CancelEventArgs e)
        {
            EventHandler<CancelEventArgs> handler;

            handler = Selecting;

            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="SelectionColorChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnSelectionColorChanged(EventArgs e)
        {
            EventHandler handler;

            handler = SelectionColorChanged;

            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="SelectionModeChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnSelectionModeChanged(EventArgs e)
        {
            EventHandler handler;

            handler = SelectionModeChanged;

            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="SelectionRegionChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnSelectionRegionChanged(EventArgs e)
        {
            EventHandler handler;

            Invalidate();

            handler = SelectionRegionChanged;

            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="ShortcutsEnabledChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnShortcutsEnabledChanged(EventArgs e)
        {
            EventHandler handler;

            handler = ShortcutsEnabledChanged;

            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="ShowPixelGridChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnShowPixelGridChanged(EventArgs e)
        {
            EventHandler handler;

            Invalidate();

            handler = ShowPixelGridChanged;

            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="SizeToFitChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnSizeToFitChanged(EventArgs e)
        {
            EventHandler handler;

            AdjustLayout();

            handler = SizeToFitChanged;

            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="VirtualDraw" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="PaintEventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnVirtualDraw(PaintEventArgs e)
        {
            PaintEventHandler handler;

            handler = VirtualDraw;

            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="VirtualModeChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnVirtualModeChanged(EventArgs e)
        {
            EventHandler handler;

            AdjustLayout();

            handler = VirtualModeChanged;

            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="VirtualSizeChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnVirtualSizeChanged(EventArgs e)
        {
            EventHandler handler;

            AdjustLayout();

            handler = VirtualSizeChanged;

            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="ZoomChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnZoomChanged(EventArgs e)
        {
            EventHandler handler;

            AdjustLayout();

            handler = ZoomChanged;

            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="ZoomLevelsChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnZoomLevelsChanged(EventArgs e)
        {
            EventHandler handler;

            handler = ZoomLevelsChanged;

            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        ///     Processes shortcut keys for zooming and selection
        /// </summary>
        /// <param name="e">
        ///     The <see cref="KeyEventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void ProcessImageShortcuts(KeyEventArgs e)
        {
            int previousZoom;

            previousZoom = Zoom;

            switch (e.KeyCode)
            {
                case Keys.Home:
                    if (AllowZoom)
                        ActualSize();
                    break;

                case Keys.PageDown:
                case Keys.Oemplus:
                    if (AllowZoom)
                        ZoomIn();
                    break;

                case Keys.PageUp:
                case Keys.OemMinus:
                    if (AllowZoom)
                        ZoomOut();
                    break;
            }

            if (Zoom != previousZoom && AutoCenter && !AutoScrollMinSize.IsEmpty)
                AutoScrollPosition = new Point((AutoScrollMinSize.Width - ClientSize.Width)/2,
                                               (AutoScrollMinSize.Height - ClientSize.Height)/2);
        }

        /// <summary>
        ///     Processes zooming with the mouse. Attempts to keep the pre-zoom image pixel under the mouse after the zoom has completed.
        /// </summary>
        /// <param name="isZoomIn">
        ///     if set to <c>true</c> zoom in, otherwise zoom out.
        /// </param>
        /// <param name="cursorPosition">The cursor position.</param>
        protected virtual void ProcessMouseZoom(bool isZoomIn, Point cursorPosition)
        {
            Point currentPixel;
            int currentZoom;

            currentPixel = PointToImage(cursorPosition);
            currentZoom = Zoom;

            Zoom = isZoomIn ? ZoomLevels.NextZoom(Zoom) : ZoomLevels.PreviousZoom(Zoom);

            if (Zoom != currentZoom)
                ScrollTo(currentPixel, cursorPosition);
        }

        /// <summary>
        ///     Performs mouse based panning
        /// </summary>
        /// <param name="e">
        ///     The <see cref="MouseEventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void ProcessPanning(MouseEventArgs e)
        {
            if (AutoPan && !ViewSize.IsEmpty && SelectionMode == ImageBoxSelectionMode.None)
            {
                if (!IsPanning && (HScroll | VScroll))
                {
                    _startMousePosition = e.Location;
                    IsPanning = true;
                }

                if (IsPanning)
                {
                    int x;
                    int y;
                    Point position;

                    if (!InvertMouse)
                    {
                        x = -_startScrollPosition.X + (_startMousePosition.X - e.Location.X);
                        y = -_startScrollPosition.Y + (_startMousePosition.Y - e.Location.Y);
                    }
                    else
                    {
                        x = -(_startScrollPosition.X + (_startMousePosition.X - e.Location.X));
                        y = -(_startScrollPosition.Y + (_startMousePosition.Y - e.Location.Y));
                    }

                    position = new Point(x, y);

                    UpdateScrollPosition(position);
                }
            }
        }

        /// <summary>
        ///     Processes shortcut keys for scrolling
        /// </summary>
        /// <param name="e">
        ///     The <see cref="KeyEventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void ProcessScrollingShortcuts(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    AdjustScroll(
                        -(e.Modifiers == Keys.None
                              ? HorizontalScroll.SmallChange
                              : HorizontalScroll.LargeChange), 0);
                    break;

                case Keys.Right:
                    AdjustScroll(
                        e.Modifiers == Keys.None ? HorizontalScroll.SmallChange : HorizontalScroll.LargeChange,
                        0);
                    break;

                case Keys.Up:
                    AdjustScroll(0,
                                 -(e.Modifiers == Keys.None
                                       ? VerticalScroll.SmallChange
                                       : VerticalScroll.LargeChange));
                    break;

                case Keys.Down:
                    AdjustScroll(0,
                                 e.Modifiers == Keys.None
                                     ? VerticalScroll.SmallChange
                                     : VerticalScroll.LargeChange);
                    break;
            }
        }

        /// <summary>
        ///     Performs mouse based region selection
        /// </summary>
        /// <param name="e">
        ///     The <see cref="MouseEventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void ProcessSelection(MouseEventArgs e)
        {
            if (SelectionMode != ImageBoxSelectionMode.None)
            {
                if (!IsSelecting)
                {
                    _startMousePosition = e.Location;
                    IsSelecting = true;
                }

                if (IsSelecting)
                {
                    float x;
                    float y;
                    float w;
                    float h;
                    Point imageOffset;
                    RectangleF selection;

                    imageOffset = GetImageViewPort().Location;

                    if (e.X < _startMousePosition.X)
                    {
                        x = e.X;
                        w = _startMousePosition.X - e.X;
                    }
                    else
                    {
                        x = _startMousePosition.X;
                        w = e.X - _startMousePosition.X;
                    }

                    if (e.Y < _startMousePosition.Y)
                    {
                        y = e.Y;
                        h = _startMousePosition.Y - e.Y;
                    }
                    else
                    {
                        y = _startMousePosition.Y;
                        h = e.Y - _startMousePosition.Y;
                    }

                    x = x - imageOffset.X - AutoScrollPosition.X;
                    y = y - imageOffset.Y - AutoScrollPosition.Y;

                    x = x/(float) ZoomFactor;
                    y = y/(float) ZoomFactor;
                    w = w/(float) ZoomFactor;
                    h = h/(float) ZoomFactor;

                    selection = new RectangleF(x, y, w, h);
                    if (LimitSelectionToImage)
                        selection = FitRectangle(selection);

                    SelectionRegion = selection;
                }
            }
        }

        /// <summary>
        ///     Updates the scroll position.
        /// </summary>
        /// <param name="position">The position.</param>
        protected virtual void UpdateScrollPosition(Point position)
        {
            AutoScrollPosition = position;
            Invalidate();
            OnScroll(new ScrollEventArgs(ScrollEventType.EndScroll, 0));
        }

        /// <summary>
        ///     Initializes the grid tile.
        /// </summary>
        private void InitializeGridTile()
        {
            if (_texture != null)
                _texture.Dispose();

            if (_gridTile != null)
                _gridTile.Dispose();

            if (GridDisplayMode != ImageBoxGridDisplayMode.None && GridCellSize != 0)
            {
                _gridTile = CreateGridTileImage(GridCellSize, GridColor, GridColorAlternate);

                if (_backgroundTile != null)
                    _texture = new TextureBrush(_backgroundTile);
                else
                    _texture = new TextureBrush(_gridTile);
            }

            Invalidate();
        }

        public void Rotate()
        {
            var rotated = RotateImage((Bitmap) _image, 90);

            Image = rotated;
        }

        private Bitmap RotateImage(Bitmap bmpSrc, float theta)
        {
            var mRotate = new Matrix();
            mRotate.Translate(bmpSrc.Width/-2, bmpSrc.Height/-2, MatrixOrder.Append);
            mRotate.RotateAt(theta, new Point(0, 0), MatrixOrder.Append);

            using (var gp = new GraphicsPath())
            {

                // transform image points by rotation matrix
                gp.AddPolygon(new[] {new Point(0, 0), new Point(bmpSrc.Width, 0), new Point(0, bmpSrc.Height)});
                gp.Transform(mRotate);
                var pts = gp.PathPoints;

                // create destination bitmap sized to contain rotated source image
                var bbox = GetBoundingBox(bmpSrc, mRotate);

                var bmpDest = new Bitmap(bbox.Width, bbox.Height);

                using (var gDest = Graphics.FromImage(bmpDest))
                {
                    // draw source into dest
                    var mDest = new Matrix();
                    gDest.InterpolationMode = InterpolationMode.NearestNeighbor;
                    mDest.Translate(bmpDest.Width/2, bmpDest.Height/2, MatrixOrder.Append);
                    gDest.Transform = mDest;
                    gDest.DrawImage(bmpSrc, pts);
                    return bmpDest;
                }
            }
        }

        private Rectangle GetBoundingBox(Image img, Matrix matrix)
        {
            var gu = new GraphicsUnit();
            var rImg = Rectangle.Round(img.GetBounds(ref gu));

            // Transform the four points of the image, to get the resized bounding box.
            var topLeft = new Point(rImg.Left, rImg.Top);
            var topRight = new Point(rImg.Right, rImg.Top);
            var bottomRight = new Point(rImg.Right, rImg.Bottom);
            var bottomLeft = new Point(rImg.Left, rImg.Bottom);
            var points = new[] { topLeft, topRight, bottomRight, bottomLeft };
            var gp = new GraphicsPath(points,
                                      new[]
                                          {
                                              (byte) PathPointType.Start, (byte) PathPointType.Line,
                                              (byte) PathPointType.Line, (byte) PathPointType.Line
                                          });
            gp.Transform(matrix);
            return Rectangle.Round(gp.GetBounds());
        }
        #endregion
    }
}