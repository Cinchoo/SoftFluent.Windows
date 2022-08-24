using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace SoftFluent.Windows
{
    public static class SplitterOnGridCellBehaviour
    {
        public static readonly DependencyProperty ChangeGridCellSizeOnDragProperty =
            DependencyProperty.RegisterAttached("ChangeGridCellSizeOnDrag", typeof(bool),
                                                typeof(SplitterOnGridCellBehaviour),
                                                new PropertyMetadata(false, OnChangeGridCellSizeOnDrag));

        private static void OnChangeGridCellSizeOnDrag(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            GridSplitter splitter = dependencyObject as GridSplitter;

            if (splitter == null)
            {
                throw new NotSupportedException("SplitterOnGridCellBehaviour can only be on a GridSplitter");
            }

            if ((bool)args.NewValue)
            {
                splitter.DragDelta += SplitterOnDragDelta;
            }
            else
            {
                splitter.DragDelta -= SplitterOnDragDelta;
            }
        }

        private static void SplitterOnDragDelta(object sender, DragDeltaEventArgs args)
        {
            GridSplitter splitter = (GridSplitter)sender;
            var containerCell = splitter.FindParent<DataGridCell>();
            containerCell.Column.Width = containerCell.Column.ActualWidth + args.HorizontalChange;
        }


        public static void SetChangeGridCellSizeOnDrag(UIElement element, bool value)
        {
            element.SetValue(ChangeGridCellSizeOnDragProperty, value);
        }

        public static bool GetChangeGridCellSizeOnDrag(UIElement element)
        {
            return (bool)element.GetValue(ChangeGridCellSizeOnDragProperty);
        }

        public static T FindParent<T>(this DependencyObject child)
           where T : DependencyObject
        {
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            if (parentObject == null) return null;

            var parent = parentObject as T;
            if (parent != null)
            {
                return parent;
            }
            return FindParent<T>(parentObject);
        }
    }
}
