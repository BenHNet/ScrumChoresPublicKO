using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ScrumChores.Business.Repositories;
using ScrumChores.Model.Entities;
using ScrumChores.Model.Interfaces;
using ScrumChoresPublicKO.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace ScrumChoresPublicKO.API
{
    public class PerformanceController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<KeyValuePair<string, string>> Get()
        {
            var con = ConfigurationManager.ConnectionStrings["PerfomanceConnectionString"].ToString();

            var returnValues = new List<KeyValuePair<string, string>>();

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

            return returnValues;
        }

    }
}