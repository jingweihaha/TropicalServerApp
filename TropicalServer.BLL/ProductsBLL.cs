using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TropicalServer.DAL;

namespace TropicalServer.BLL
{
    public class ProductsBLL
    {
        public DataSet GetProductByProductCategory_BLL(string description)
        {
            ProductsDAL p = new ProductsDAL();
            DataSet ds = p.GetProductByProductCategory_DAL(description);
            return ds;
        }
    }
}
