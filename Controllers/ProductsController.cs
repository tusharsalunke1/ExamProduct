using ExamProduct.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace ExamProduct.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            List<Product> lstProduct = new List<Product>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=ExamDatabase;Integrated Security=True";
            cn.Open();


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
          
            cmd.CommandText = "ProcedureForSelect";

            try
            {

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    lstProduct.Add(new Product {ProductId=(int)dr["ProductId"],ProductName=dr["ProductName"].ToString(),Rate=(Decimal)dr["Rate"],Description=dr["Description"].ToString(),CategoryName=dr["CategoryName"].ToString() });
                }
                dr.Close();

            }
            catch (Exception e)
            {

                ViewBag.IndexErr = e.Message;

            }

            finally {

                cn.Close();
            }



            return View(lstProduct);
        }

       

        // GET: Products/Edit/5
        public ActionResult Edit(int id=0)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=ExamDatabase;Integrated Security=True";
            cn.Open();


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Select * from Products where ProductId="+id;
            Product product = null;
            try
            {

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    product = new Product { ProductId = (int)dr["ProductId"], ProductName = dr["ProductName"].ToString(), Rate = (Decimal)dr["Rate"], Description = dr["Description"].ToString(), CategoryName = dr["CategoryName"].ToString() };

                }
                dr.Close();


            }
            catch (Exception e)
            {
                ViewBag.EditError = e.Message;

            }
            finally {
                cn.Close();
            
            }


            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(Product product, int id=0)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=ExamDatabase;Integrated Security=True";
            cn.Open();


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "ProcedureForUpdate";
           
            cmd.Parameters.AddWithValue("@ProductId",product.ProductId);
            cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
            cmd.Parameters.AddWithValue("@Rate", product.Rate);
            cmd.Parameters.AddWithValue("@Description", product.Description);
            cmd.Parameters.AddWithValue("@CategoryName", product.CategoryName);
            try
            {

                cmd.ExecuteNonQuery();

                RedirectToAction("Index");
               

            }
            catch (Exception e)
            {
                ViewBag.EditError = e.Message;

            }
            finally
            {
                cn.Close();

            }
            return View();
        }


      [ChildActionOnly]
        public ActionResult MyPartialView()
        {
            return View();
        }
    }
}
