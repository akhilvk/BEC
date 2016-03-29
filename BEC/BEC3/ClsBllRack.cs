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

            public DataTable gridfill(int flag)
            {
                return objdal.gridfill(this, flag);
            }
    }
}
