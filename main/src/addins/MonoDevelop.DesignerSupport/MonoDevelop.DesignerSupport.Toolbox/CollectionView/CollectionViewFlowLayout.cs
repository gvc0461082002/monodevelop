using System;
using AppKit;
using CoreGraphics;
using Foundation;
namespace MonoDevelop.DesignerSupport.Toolbox
{
	class CollectionViewFlowLayout : NSCollectionViewFlowLayout
	{

	}

	class CollectionViewDelegateFlowLayout : NSCollectionViewDelegateFlowLayout
	{
		public bool IsOnlyImage { get; set; }
		public bool IsShowCategories { get; set; }

		public override CGSize SizeForItem (NSCollectionView collectionView, NSCollectionViewLayout collectionViewLayout, NSIndexPath indexPath)
		{
			var delegateFlowLayout = (CollectionViewFlowLayout)collectionViewLayout;
			if (delegateFlowLayout.SectionAtIndexIsCollapsed ((nuint)indexPath.Section)) {
				return new CGSize (0, 0);
			}
			if (IsOnlyImage) {
				return ImageCollectionViewItem.Size;
			}
			var sectionInset = delegateFlowLayout.SectionInset;
			return new CGSize (collectionView.Frame.Width, LabelCollectionViewItem.ItemHeight);
		}

		public override NSEdgeInsets InsetForSection (NSCollectionView collectionView, NSCollectionViewLayout collectionViewLayout, nint section)
		{
			return new NSEdgeInsets (0, 0, 0, 0);
		}

		public override CGSize ReferenceSizeForHeader (NSCollectionView collectionView, NSCollectionViewLayout collectionViewLayout, nint section)
		{
			if (!IsShowCategories) {
				return CGSize.Empty;
			}
			var delegateFlowLayout = ((CollectionViewFlowLayout)collectionViewLayout);
			var sectionInset = delegateFlowLayout.SectionInset;
			return new CGSize (collectionView.Frame.Width, HeaderCollectionViewItem.SectionHeight);
		}

		public override CGSize ReferenceSizeForFooter (NSCollectionView collectionView, NSCollectionViewLayout collectionViewLayout, nint section)
		{
			return CGSize.Empty;
		}

		public override NSSet ShouldDeselectItems (NSCollectionView collectionView, NSSet indexPaths)
		{
			return indexPaths;
		}

		public override NSSet ShouldSelectItems (NSCollectionView collectionView, NSSet indexPaths)
		{
			return indexPaths;
		}
	}
}
