using System;
using System.Collections;
using DevExpress.Web.ASPxGridView;

public partial class _Default : System.Web.UI.Page {
    protected void grid_CustomColumnGroup(object sender, CustomColumnSortEventArgs e) {
        if (e.Column != null && e.Column.FieldName == "ProductName") {
            int intervalValue1 = GetInterval(e.Value1.ToString());
            int intervalValue2 = GetInterval(e.Value2.ToString());
            e.Result = Comparer.Default.Compare(intervalValue1, intervalValue2);
            e.Handled = true;
        }
    }
    private int GetInterval(string str) {
        str = str.ToLower();
        char ch = str[0];
        if (ch >= 'a' && ch <= 'e') return 1;
        if (ch >= 'f' && ch <= 'j') return 2;
        if (ch >= 'k' && ch <= 'q') return 3;
        if (ch >= 'r' && ch <= 'v') return 4;
        if (ch >= 'w' && ch <= 'z') return 5;
        return -1;
    }
    protected void grid_CustomGroupDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e) {
        if (e.Column.FieldName != "ProductName") return;
        int interval = GetInterval(e.Value.ToString());
        switch (interval) {
            case 1: e.DisplayText = "A-E"; break;
            case 2: e.DisplayText = "F-J"; break;
            case 3: e.DisplayText = "K-Q"; break;
            case 4: e.DisplayText = "R-V"; break;
            case 5: e.DisplayText = "W-Z"; break;
        }
    }
}