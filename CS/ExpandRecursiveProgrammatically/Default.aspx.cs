using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace ExpandRecursiveProgrammatically {
    public partial class _Default : System.Web.UI.Page {
        protected void Page_Init(object sender, EventArgs e) {
            ASPxGridView1.DataSource = GetDataSource();
            ASPxGridView1.KeyFieldName = "ID";
            ASPxGridView1.DataBind();

            if(!IsPostBack && !IsCallback) {
                ASPxGridView1.GroupBy(ASPxGridView1.Columns["Group"]);
                ASPxGridView1.GroupBy(ASPxGridView1.Columns["Subgroup"]);                
            }
        }

        private DataTable GetDataSource() {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Group");
            table.Columns.Add("Subgroup");
            table.Columns.Add("ItemName");
            table.Rows.Add(1, "Group A", "Subgroup 1", "Data Item");
            return table;
        }

        protected void ASPxGridView1_CustomCallback(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventArgs e) {
            if(e.Parameters == null) return;
            string[] param = e.Parameters.Split(';');
            if(param.Length == 2 && param[0] == "customexpand") {
                ASPxGridView1.ExpandRow(Convert.ToInt32(param[1]), true);
            }
        }
    }
}
