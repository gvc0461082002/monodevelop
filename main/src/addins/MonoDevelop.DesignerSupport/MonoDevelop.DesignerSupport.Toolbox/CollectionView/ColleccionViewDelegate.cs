using AppKit;
using Foundation;
using System;
namespace MonoDevelop.DesignerSupport.Toolbox
{
	class ColleccionViewDelegate : NSCollectionViewDelegate
	{
		public event EventHandler<NSSet> SelectionChanged;
		public override void ItemsSelected (NSCollectionView collectionView, NSSet indexPaths)
		{
			SelectionChanged?.Invoke (this, indexPaths);
		}
	}
}
