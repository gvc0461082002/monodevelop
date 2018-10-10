using AppKit;
using CoreGraphics;
using Foundation;
using System;
namespace MonoDevelop.DesignerSupport.Toolbox
{
	class ColleccionViewDelegate : NSCollectionViewDelegate
	{
		public event EventHandler<NSSet> SelectionChanged;
		public event EventHandler<NSIndexSet> DragBegin;
		public override void ItemsSelected (NSCollectionView collectionView, NSSet indexPaths)
		{
			SelectionChanged?.Invoke (this, indexPaths);
		}

		public override bool CanDragItems (NSCollectionView collectionView, NSSet indexPaths, NSEvent theEvent)
		{
			DragBegin?.Invoke (this, null);
			return false;
		}
	}
}
