using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BEC3
{
    class ClsBllRack
    {
        ClsDalRackMaster objdal = new ClsDalRackMaster();
            public int RackId { get; set; }
            public string RackNo { get; set; }
            public string  CategoryName { get; set; }
            public int CatId { get; set; }
            public string prodid { get; set; }
            public string  company { get; set; }
            public DateTime  Fdate { get; set; }
            public DateTime Tdate { get; set; }

            public DataTable gridfill(int flag)
            {
                return objdal.gridfill(this, flag);
            }
            public DataTable Report(int flag)
            {
                return objdal.Report(this, flag);
            }
            public DataTable ReturningDataByQ(string  flag)
            {
                return objdal.ReturningDataByQ(this, flag);
            }
            public bool SavetoDb(int flag)
            {
                return objdal.SavetoDb(this, flag);
            }
    }
}
