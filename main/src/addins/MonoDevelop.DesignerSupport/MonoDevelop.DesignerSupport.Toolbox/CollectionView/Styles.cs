using AppKit;
using MonoDevelop.Ide;

namespace MonoDevelop.DesignerSupport.Toolbox
{
	static class Styles
	{
		static Styles ()
		{
			LoadStyles ();
			Ide.Gui.Styles.Changed += (o, e) => LoadStyles ();
		}

		public static int SearchTextFieldLineBorderWidth { get; private set; }
		public static NSColor SearchTextFieldLineBorderColor { get; private set; }
		public static NSColor SearchTextFieldLineBackgroundColor { get; private set; }

		public static NSColor ToggleButtonHoverBorderColor = NSColor.Black;
		public static NSColor ToggleButtonHoverClickedBackgroundColor = NSColor.FromRgba (red: 0.22f, green: 0.22f, blue: 0.22f, alpha: 1.0f);
		public static NSColor ToggleButtonHoverBackgroundColor = NSColor.FromRgba (red: 0.25f, green: 0.25f, blue: 0.25f, alpha: 1.0f);
		public static int ToggleButtonCornerRadius = 5;
		public static float ToggleButtonLineWidth = 0.5f;

		public static void LoadStyles ()
		{
			SearchTextFieldLineBorderWidth = 1;
			if (IdeApp.Preferences.UserInterfaceTheme == Theme.Light) {
				SearchTextFieldLineBorderColor = NSColor.Black;
				SearchTextFieldLineBackgroundColor = NSColor.FromRgba (red: 0.25f, green: 0.25f, blue: 0.25f, alpha: 1.0f);

				ToggleButtonHoverBorderColor = NSColor.Black;
				ToggleButtonHoverClickedBackgroundColor = NSColor.FromRgba (red: 0.22f, green: 0.22f, blue: 0.22f, alpha: 1.0f);
				ToggleButtonHoverBackgroundColor = NSColor.FromRgba (red: 0.25f, green: 0.25f, blue: 0.25f, alpha: 1.0f);
			} else {
				SearchTextFieldLineBorderColor = NSColor.Black;
				SearchTextFieldLineBackgroundColor = NSColor.FromRgba (red: 0.25f, green: 0.25f, blue: 0.25f, alpha: 1.0f);

				ToggleButtonHoverBorderColor = NSColor.Black;
				ToggleButtonHoverClickedBackgroundColor = NSColor.FromRgba (red: 0.22f, green: 0.22f, blue: 0.22f, alpha: 1.0f);
				ToggleButtonHoverBackgroundColor = NSColor.FromRgba (red: 0.25f, green: 0.25f, blue: 0.25f, alpha: 1.0f);
			}
		}
	}
}
