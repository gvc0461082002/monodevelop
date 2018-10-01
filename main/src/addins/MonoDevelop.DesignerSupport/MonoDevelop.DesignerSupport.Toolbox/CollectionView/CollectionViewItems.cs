using System;
using AppKit;
using CoreGraphics;
using Foundation;
using MonoDevelop.Ide;
using Xwt;
using System.Linq;

namespace MonoDevelop.DesignerSupport.Toolbox
{
	[Register ("LabelCollectionViewItem")]
	public class LabelCollectionViewItem : NSCollectionViewItem
	{
		public const int ItemHeight = 32;
		internal const string Name = "LabelViewItem";

		public override string Description => TextField.StringValue;

		public override bool Selected {
			get => base.Selected;
			set {
				base.Selected = value;
				if (frameBox != null) {
					if (value) {
						frameBox.BackgroundColor = new Xwt.Drawing.Color (red: 0.33f, green: 0.55f, blue: 0.92f, alpha: 1.0f);
					} else {
						frameBox.BackgroundColor = new Xwt.Drawing.Color (red: 0.25f, green: 0.25f, blue: 0.25f, alpha: 1.0f);
					}
				}
			}
		}

		public static NSColor CellBackgroundSelectedColor = NSColor.FromRgba (red: 0.33f, green: 0.55f, blue: 0.92f, alpha: 1.0f);
		public static NSColor CellBorderSelectedColor = NSColor.Black;
		public static NSColor CellBackgroundColor = NSColor.FromRgba (red: 0.25f, green: 0.25f, blue: 0.25f, alpha: 1.0f);

		public Xwt.Drawing.Image Image {
			get => imageView.Image;
			set => imageView.Image = value;
		}

		Xwt.FrameBox frameBox;
		Xwt.HBox contentBox;
		Xwt.Label label;
		Xwt.ImageView imageView;

		public override void LoadView ()
		{
			Toolkit.NativeEngine.Invoke (() => {

				frameBox = new Xwt.FrameBox ();
				View = Toolkit.NativeEngine.GetNativeWidget (frameBox) as NSView;

				contentBox = new Xwt.HBox ();

				imageView = new Xwt.ImageView ();
				var imageViewNativeBorderContainer = Toolkit.NativeEngine.GetNativeWidget (imageView) as NSView;
				ImageView = imageViewNativeBorderContainer.Subviews.FirstOrDefault () as NSImageView;

				label = new Xwt.Label ("");
				var labelNativeBorderContainer = Toolkit.NativeEngine.GetNativeWidget (label) as NSView;
				TextField = labelNativeBorderContainer.Subviews.FirstOrDefault () as NSTextField;
			});

			frameBox.Content = contentBox;
			contentBox.PackStart (imageView);
			contentBox.PackStart (label);
			frameBox.Show ();
		}

		public LabelCollectionViewItem (IntPtr handle) : base (handle)
		{

		}
	}

	[Register ("HeaderCollectionViewItem")]
	public class HeaderCollectionViewItem : NSCollectionViewItem
	{
		public static NSColor HeaderCellBackgroundSelectedColor = NSColor.FromRgb (0.29f, green: 0.29f, blue: 0.29f);// NSColor.ControlBackground;
		public static NSColor HeaderCellBackgroundColor = HeaderCellBackgroundSelectedColor;

		public static Xwt.Drawing.Image ExpandedImage = ImageService.GetIcon ("md-disclose-arrow-down", Gtk.IconSize.Menu);
		public static Xwt.Drawing.Image CollapsedImage = ImageService.GetIcon ("md-disclose-arrow-up", Gtk.IconSize.Menu);

		public const int ExpandButtonSize = 20;
		public const int SectionHeight = 25;

		internal const string Name = "HeaderViewItem";

		bool isCollapsed;
		public bool IsCollapsed {
			get => isCollapsed;
			internal set {
				isCollapsed = value;
				ExpandButton.Image = value ? CollapsedImage : ExpandedImage;
			}
		}

		Xwt.HBox contentBox;
		Xwt.Label label;
		public Xwt.Button ExpandButton { get; private set; }

		public override void LoadView ()
		{
			Toolkit.NativeEngine.Invoke (() => {

				contentBox = new Xwt.HBox ();
				View = Toolkit.NativeEngine.GetNativeWidget (contentBox) as NSView;
			
				label = new Xwt.Label ("");
				var labelNativeBorderContainer = Toolkit.NativeEngine.GetNativeWidget (label) as NSView;
				TextField = labelNativeBorderContainer.Subviews.FirstOrDefault () as NSTextField;

				ExpandButton = new Xwt.Button ();
			});

			contentBox.PackStart (label, true);
			contentBox.PackEnd (ExpandButton);
			contentBox.Show ();

			View.WantsLayer = true;
		}

		public HeaderCollectionViewItem (IntPtr handle) : base (handle)
		{

		}
	}

	[Register ("ImageCollectionViewItem")]
	public class ImageCollectionViewItem : NSCollectionViewItem
	{
		public static NSColor ImageCellBackgroundSelectedColor = NSColor.FromRgba (red: 0.33f, green: 0.55f, blue: 0.92f, alpha: 1.0f);
		public static NSColor ImageCellBorderSelectedColor = NSColor.Black;
		public static NSColor ImageCellBackgroundColor = NSColor.FromRgba (red: 0.25f, green: 0.25f, blue: 0.25f, alpha: 1.0f);

		public static CGSize Size = new CGSize (25, 25);

		internal const string Name = "ImageViewItem";
		const int margin = 5;

		public Xwt.Drawing.Image Image {
			get => imageView.Image;
			set => imageView.Image = value;
		}

		public string ToolTip {
			get => ImageView.ToolTip;
			set => ImageView.ToolTip = value;
		}

		public string AccessibilityTitle {
			get => ImageView.AccessibilityLabel;
			set => ImageView.AccessibilityTitle = value;
		}

		public override bool Selected {
			get => base.Selected;
			set {
				base.Selected = value;
				if (frameBox != null) {
					if (value) {
						frameBox.BackgroundColor = new Xwt.Drawing.Color (red: 0.33f, green: 0.55f, blue: 0.92f, alpha: 1.0f);
					} else {
						frameBox.BackgroundColor = new Xwt.Drawing.Color (red: 0.25f, green: 0.25f, blue: 0.25f, alpha: 1.0f);
					}
				}
			}
		}

		Xwt.FrameBox frameBox;
		Xwt.ImageView imageView;

		public override void LoadView ()
		{
			Toolkit.NativeEngine.Invoke (() => {
				frameBox = new Xwt.FrameBox ();
				View = Toolkit.NativeEngine.GetNativeWidget (frameBox) as NSView;

				imageView = new Xwt.ImageView ();
				var imageViewNativeBorderContainer = Toolkit.NativeEngine.GetNativeWidget (imageView) as NSView;
				ImageView = imageViewNativeBorderContainer.Subviews.FirstOrDefault () as NSImageView;
			});

			frameBox.Content = imageView;
			frameBox.Show ();
		}

		public ImageCollectionViewItem (IntPtr handle) : base (handle)
		{

		}
	}

	class ContentCollectionViewItem : NSStackView
	{
		public NSColor BackgroundColor { get; set; } = NSColor.Control;
		public NSColor BackgroundSelectedColor { get; set; } = NSColor.SelectedTextBackground;
		public NSColor BorderSelectedColor { get; internal set; }

		bool isSelected;
		public bool IsSelected {
			get => isSelected;
			set {
				if (isSelected == value) {
					return;
				}
				isSelected = value;
				NeedsDisplay = true;
			}
		}

		NSTrackingArea trackingArea;
		public override void UpdateTrackingAreas ()
		{
			base.UpdateTrackingAreas ();
			if (trackingArea != null) {
				RemoveTrackingArea (trackingArea);
				trackingArea.Dispose ();
			}
			var viewBounds = Bounds;
			var options = NSTrackingAreaOptions.MouseMoved | NSTrackingAreaOptions.ActiveInKeyWindow | NSTrackingAreaOptions.MouseEnteredAndExited;
			trackingArea = new NSTrackingArea (viewBounds, options, this, null);
			AddTrackingArea (trackingArea);
		}

		bool isMouseHover;
		public override void MouseEntered (NSEvent theEvent)
		{
			base.MouseEntered (theEvent);
			isMouseHover = true;
			NeedsDisplay = true;
		}

		public override void MouseExited (NSEvent theEvent)
		{
			base.MouseExited (theEvent);
			isMouseHover = false;
			NeedsDisplay = true;
		}

		public override void DrawRect (CGRect dirtyRect)
		{
			base.DrawRect (dirtyRect);

			if (IsSelected) {
				BackgroundSelectedColor.Set ();
			} else {
				BackgroundColor.Set ();
			}
			NSBezierPath.FillRect (dirtyRect);

			if (!IsSelected && isMouseHover && BorderSelectedColor != null) {
				BorderSelectedColor.Set ();
				var rect = NSBezierPath.FromRect (new CGRect (dirtyRect.X + 2, dirtyRect.Y + 2, dirtyRect.Width - 4, dirtyRect.Height - 4));
				rect.LineWidth = 0.5f;
				rect.ClosePath ();
				rect.Stroke ();
			}
		}

		public ContentCollectionViewItem ()
		{
			Orientation = NSUserInterfaceLayoutOrientation.Horizontal;
			WantsLayer = true;
		}
	}
}
