using Syncfusion.UI.Xaml.Grid;
using System;
using System.Data;
using System.Linq;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace DataTableDemo
{
    public class SfDataGridBehavior : Behavior<SfDataGrid>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            (AssociatedObject.ItemsSource as DataTable).RowChanged += SfDataGridBehavior_RowChanged;
        }

        private void SfDataGridBehavior_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            var dataTable = (DataTable)AssociatedObject.ItemsSource;
            var record = AssociatedObject.View.Records.FirstOrDefault(row => (row.Data as DataRowView).Row == e.Row);
            var rowIndex = AssociatedObject.ResolveToRowIndex(record);
            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.ApplicationIdle,
            new Action(() =>
            {
                if (e.Row.RowState == DataRowState.Modified)
                {
                    var currentRow = AssociatedObject.RowGenerator.Items.FirstOrDefault(r => r.RowIndex == rowIndex);
                    if (currentRow != null)
                    {
                        var element = currentRow.Element as VirtualizingCellsControl;
                        element.Background = new SolidColorBrush(Colors.LightYellow);
                    }
                }
            }));
        }
    }
}
