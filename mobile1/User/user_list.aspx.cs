using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mobile1.User
{
    public partial class user_list : System.Web.UI.Page
    {
        private SqlConnection DB = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
        DataSet DBSET2 = new DataSet();
        DataSet DBSET = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            TreeView1.Nodes.Clear();
            TreeView2.Nodes.Clear();

            string SQL2 = "select dept_name,dept_code,p_dept_code from dept_ba";
            SqlDataAdapter ADT2 = new SqlDataAdapter(SQL2, DB);
            ADT2.Fill(DBSET2, "BD");
            foreach (DataRow row in DBSET2.Tables["BD"].Select("p_dept_code=-1"))
            {
                //topnode = TreeView1.Nodes.Add(row["dept_name"].ToString());
                //PopulateTreeView(Convert.ToInt32(row["dept_code"]), topnode);
                TreeNode child = new TreeNode
                {
                    Text = row["dept_name"].ToString(),
                    Value = row["dept_code"].ToString()
                };
                TreeView1.Nodes.Add(child);
                child.NavigateUrl = "user_list.aspx?dept_code=" + child.Value;
                PopulateTreeView(Convert.ToInt32(row["dept_code"]), null);

            }
            
            if(Request.QueryString["dept_code"] != null)
            {
              
                string SQL3 = "select id,name,dept_code,duty_code,p_dept_code,duty_name from user_v order by duty_code asc ";
                SqlDataAdapter ADT3 = new SqlDataAdapter(SQL3, DB);
                ADT3.Fill(DBSET, "BD");
                int dept_code = Convert.ToInt32(Request["dept_code"]);
                if(dept_code == 0)
                {
                    foreach (DataRow row in DBSET.Tables["BD"].Rows)
                    {
                        TreeNode child = new TreeNode
                        {
                            Text = row["name"].ToString() + "  " + row["duty_name"].ToString(),
                            Value = row["id"].ToString()
                        };
                        TreeView2.Nodes.Add(child);
                        child.NavigateUrl = "user_detail.aspx?id=" + child.Value + "&dept_code=" + Request["dept_code"];
                        dept_code = Convert.ToInt32(row["dept_code"]);
                    }
                }
                else
                {
                    foreach (DataRow row in DBSET.Tables["BD"].Select("dept_code='" + Request["dept_code"].ToString() + "'"))
                    {
                        TreeNode child = new TreeNode
                        {
                            Text = row["name"].ToString() + "  " + row["duty_name"].ToString(),
                            Value = row["id"].ToString()
                        };
                        TreeView2.Nodes.Add(child);
                        child.NavigateUrl = "user_detail.aspx?id=" + child.Value + "&dept_code=" + Request["dept_code"];
                        dept_code = Convert.ToInt32(row["dept_code"]);
                    }

                    PopulateTreeView2(dept_code, null);
                }
                
              
            }
            
        }
        private void PopulateTreeView(int parentId, TreeNode treeNode)
        {
            try
            {
                foreach (DataRow row in DBSET2.Tables[0].Select(string.Format("p_dept_code='{0}'", parentId)))
                {
                    TreeNode child = new TreeNode
                    {
                        Text = row["dept_name"].ToString(),
                        Value = row["dept_code"].ToString()
                    };
                    if (parentId == 0)
                    {
                        TreeView1.Nodes.Add(child);
                        child.NavigateUrl = "user_list.aspx?dept_code="+ child.Value;
                        PopulateTreeView(Convert.ToInt32(row["dept_code"]), child);
                    }
                    else
                    {
                        treeNode.ChildNodes.Add(child);
                        child.NavigateUrl = "user_list.aspx?dept_code=" + child.Value;
                        PopulateTreeView(Convert.ToInt32(row["dept_code"]), child);
                    }
                }

            }
            catch
            {

            }
          



            TreeView1.CollapseAll();
        }
        private void PopulateTreeView2(int parentId, TreeNode treeNode)
        {
            try
            {
                foreach (DataRow row1 in DBSET.Tables[0].Select(string.Format("p_dept_code ='{0}'", parentId)))
                {
                    TreeNode child = new TreeNode
                    {
                        Text = row1["name"].ToString() + "  " + row1["duty_name"].ToString(),
                        Value = row1["id"].ToString()
                    };
                        TreeView2.Nodes.Add(child);
                    
                        child.NavigateUrl = "user_list.aspx?id=" + child.Value + "&dept_code=" + Request["dept_code"];
                        PopulateTreeView2(Convert.ToInt32(row1["dept_code"]), child);
                }

            }
            catch
            {

            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
                string SQL3 = "select id,name,dept_code,duty_code,p_dept_code,duty_name from user_v where name like  '%" + Search.Value + "%' order by duty_code asc ";
                SqlDataAdapter ADT3 = new SqlDataAdapter(SQL3, DB);
                ADT3.Fill(DBSET, "BD");
                int dept_code = 0;
                foreach (DataRow row in DBSET.Tables["BD"].Rows)
                {
                    TreeNode child = new TreeNode
                    {
                        Text = row["name"].ToString() + "  " + row["duty_name"].ToString(),
                        Value = row["id"].ToString()
                    };
                    TreeView2.Nodes.Add(child);
                    child.NavigateUrl = "user_detail.aspx?id=" + child.Value + "&dept_code=" + Request["dept_code"];
                    dept_code = Convert.ToInt32(row["dept_code"]);
                }
        }
    }
}