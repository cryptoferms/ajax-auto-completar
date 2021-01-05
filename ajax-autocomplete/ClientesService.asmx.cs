using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace ajax_autocomplete
{
    /// <summary>
    /// Summary description for ClientesService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ClientesService : System.Web.Services.WebService
    {

        //public static List<Clientes> PopularDropDownList()
        //{
        //    DataTable dt = new DataTable();
        //    var objtoCliente = new List<Clientes>();
        //    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["mydata"].ConnectionString))
        //    {
        //        using (var cmd = new SqlCommand("Select Id, Nome from TbLoja", con))
        //        {
        //            con.Open();
        //            var sqlData = new SqlDataAdapter(cmd);
        //            sqlData.Fill(dt);
        //            if (dt.Rows.Count > 0)
        //            {
        //                for (int i = 0; i < dt.Rows.Count; i++)
        //                {
        //                    objtoCliente.Add(new Clientes
        //                    {
        //                        //Id = Int32.Parse(dt.Rows[i]["Id"].ToString()),
        //                        Nome = dt.Rows[i]["Nome"].ToString()
        //                    });
        //                }
        //            }
        //        }
        //        return objtoCliente;
        //    }



        //}

        [WebMethod]
        //Função para buscar os dados no banco e converter e listar em JSON
        public void GetallClientes()
        {
            List<Clientes> listClientes = new List<Clientes>();
            string CS = ConfigurationManager.ConnectionStrings["mydata"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetClientesNome", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var cliente = new Clientes();
                    //cliente.id = rdr[0].ToString();
                    cliente.Nome = rdr["Nome"].ToString();

                    listClientes.Add(cliente);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(listClientes));
        }
    }
}
