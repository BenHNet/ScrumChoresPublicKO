using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ScrumChoresPublicKO.Controllers
{
    public class ScrumChoresController : Controller
    {
        // GET: ScrumChores
        public ActionResult Home()
        {
            var returnValues = new List<KeyValuePair<string, string>>();

            var con = ConfigurationManager.ConnectionStrings["PerfomanceConnectionString"].ToString();

            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "SELECT [CustomerID],[TotalPurchaseYTD],[DateFirstPurchase],[BirthDate],[MaritalStatus],[YearlyIncome],[Gender],[TotalChildren],[NumberChildrenAtHome],[Education],[Occupation],[HomeOwnerFlag],[NumberCarsOwned]" +
                                    "FROM [AdventureWorks].[Sales].[vIndividualDemographics]";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    StringBuilder sb;

                    while (oReader.Read())
                    {
                        sb = new StringBuilder();
                        sb.Append(oReader["TotalPurchaseYTD"].ToString() + ", ");
                        sb.Append(oReader["DateFirstPurchase"].ToString() + ", ");
                        sb.Append(oReader["BirthDate"].ToString() + ", ");
                        sb.Append(oReader["MaritalStatus"].ToString() + ", ");
                        sb.Append(oReader["YearlyIncome"].ToString() + ", ");
                        sb.Append(oReader["Gender"].ToString() + ", ");
                        sb.Append(oReader["TotalChildren"].ToString() + ", ");
                        sb.Append(oReader["NumberChildrenAtHome"].ToString() + ", ");
                        sb.Append(oReader["Education"].ToString() + ", ");
                        sb.Append(oReader["Occupation"].ToString() + ", ");
                        sb.Append(oReader["HomeOwnerFlag"].ToString() + ", ");
                        sb.Append(oReader["NumberCarsOwned"].ToString());


                        returnValues.Add(new KeyValuePair<string, string>(oReader["CustomerID"].ToString(), sb.ToString()));
                    }

                    myConnection.Close();
                }
            }

            return View();
        }
        // GET: ChoreList
        public ActionResult ChoreList()
        {
            return View();
        }
        // GET: ChoreBoard
        public ActionResult ChoreBoard()
        {
            return View();
        }
    }
}