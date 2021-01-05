using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace ajax_autocomplete
{
    public partial class Exibir : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string conexao = ConfigurationManager.ConnectionStrings["mydata"].ConnectionString;
            if (!Page.IsPostBack)
            {
                using (SqlConnection con = new SqlConnection(conexao))
                {
                    SqlCommand cmd = new SqlCommand("Select Nome from TbLoja", con);
                    con.Open();
                    DDLNome.DataSource = cmd.ExecuteReader();
                    DDLNome.DataBind();
                }
            }
        }

        protected void DDLNome_SelectedIndexChanged(object sender, EventArgs e)
        {
            string conexao = ConfigurationManager.ConnectionStrings["mydata"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexao))
            {
                SqlCommand cmd = new SqlCommand($"Select * from TbClientes where Nome={DDLNome.SelectedItem.Value}", con);
                con.Open();
                DDLNome.DataBind();
            }
        }
    }
}






//string term = Context.Request["term"] ?? "";
//string conexao = ConfigurationManager.ConnectionStrings["mydata"].ConnectionString;

//if (!Page.IsPostBack)
//{
//    using (SqlConnection con = new SqlConnection(conexao))
//    {
//        var cmd = new SqlCommand("spGetClientesNome", con);
//        cmd.CommandType = System.Data.CommandType.StoredProcedure;

//        SqlParameter parameter = new SqlParameter()
//        {
//            ParameterName = "@term",
//            Value = term
//        };
//        con.Open();
//        DDLNome.DataSource = cmd.ExecuteReader();
//        DDLNome.DataBind();
//    }
//}