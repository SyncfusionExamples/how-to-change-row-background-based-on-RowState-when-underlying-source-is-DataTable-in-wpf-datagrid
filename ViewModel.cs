using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTableDemo
{
    public class ViewModel : INotifyPropertyChanged
    {
        private DataTable sourceTable;

        public DataTable SourceTable
        {
            get { return sourceTable; }
            set
            {
                sourceTable = value;
                RaisePropertyChanged("SourceTable");
            }
        }
        public ViewModel()
        {
            sourceTable = new DataTable();

            System.Data.DataColumn column1 = new System.Data.DataColumn("ProductId", typeof(int));
            System.Data.DataColumn column2 = new System.Data.DataColumn("ProductName", typeof(string));
            System.Data.DataColumn column3 = new System.Data.DataColumn("NoOfOrders", typeof(double));
            System.Data.DataColumn column4 = new System.Data.DataColumn("OrderDate", typeof(DateTime));
            System.Data.DataColumn column5 = new System.Data.DataColumn("CountryName", typeof(string));
            System.Data.DataColumn column6 = new System.Data.DataColumn("ShipCity", typeof(string));
            System.Data.DataColumn column7 = new System.Data.DataColumn("CheckBox", typeof(bool));
            sourceTable.Columns.Add(column1);
            sourceTable.Columns.Add(column2);
            sourceTable.Columns.Add(column3);
            sourceTable.Columns.Add(column4);
            sourceTable.Columns.Add(column5);
            sourceTable.Columns.Add(column6);
            sourceTable.Columns.Add(column7);
            sourceTable.Rows.Add(1001, "Alice", 10, new DateTime(2015, 5, 2), "Argentina", "Boston Crab Meat");
            sourceTable.Rows.Add(1002, "NuNuCa Nuß-Nougat-Creme", 10, new DateTime(2015, 5, 2), "Argentina", "Buenos Aires");
            sourceTable.Rows.Add(1003, "Boston Crab Meat", 10, new DateTime(2015, 5, 2), "Argentina", "Buenos Aires");
            sourceTable.Rows.Add(1004, "Boston Crab Meat", 10, new DateTime(2015, 5, 2), "Argentina", "Buenos Aires");
            sourceTable.Rows.Add(1005, "Raclette Courdavault", 10, new DateTime(2015, 5, 2), "Argentina", "Buenos Aires");
            sourceTable.Rows.Add(1006, "Wimmers gute Semmelknödel", 10, new DateTime(2015, 5, 2), "Argentina", "Buenos Aires");
            sourceTable.Rows.Add(1008, "Gorgonzola Telino", 10, new DateTime(2015, 5, 2), "Argentina", "Buenos Aires");
            sourceTable.Rows.Add(1009, "Fløtemysost", 10, new DateTime(2015, 5, 2), "Argentina", "Buenos Aires");
            sourceTable.Rows.Add(1010, "Chartreuse verte", 10, new DateTime(2015, 5, 2), "Argentina", "Buenos Aires");
            sourceTable.AcceptChanges();
            sourceTable.Rows[0].SetModified();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
