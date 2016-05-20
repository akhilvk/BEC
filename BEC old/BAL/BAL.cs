using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BELayer;
using DALayer;
using System.Data.SqlClient;
using System.Data;

namespace BALayer
{
    public class BAL
    {
        BEL beobj = new BEL();
        DAL daobk = new DAL();

       


        public SqlDataReader custSelect()
        {
            return daobk.CustSelect();
        }
        public SqlDataReader custuniqSelect(BEL beobj)
        {
            return daobk.CustuniqSelect(beobj);
        }
        public SqlDataReader custTypeSelect(BEL beobj)
        {
            return daobk.CusttypeSelect(beobj);
        }
        public bool custinsert(BEL beobj)
        {
            return daobk.CustInsert(beobj);
        }
        public bool custupdate(BEL beobj)
        {
            return daobk.CustUpdate(beobj);
        }
        public bool custDelete(BEL beobj)
        {
            return daobk.CustDelete(beobj);
        }
    }
    public class BALSupp
    {
        BELSupp beobj = new BELSupp();
        DALSupp daobk = new DALSupp();

        public SqlDataReader SuppSelect()
        {
            return daobk.SuppSelect();
        }
        public SqlDataReader SuppuniqSelect(BELSupp beobj)
        {
            return daobk.SuppuniqSelect(beobj);
        }
        public SqlDataReader SuppTypeSelect(BELSupp beobj)
        {
            return daobk.SupptypeSelect(beobj);
        }
        public bool Suppinsert(BELSupp beobj)
        {
            return daobk.SuppInsert(beobj);
        }
        public bool Suppupdate(BELSupp beobj)
        {
            return daobk.SuppUpdate(beobj);
        }
        public bool SuppDelete(BELSupp beobj)
        {
            return daobk.SuppDelete(beobj);
        }
    }
    public class BALItem
    {
        BELItem beobj = new BELItem();
        DALItem daobk = new DALItem();
        public bool ItemExpEnabled(BELItem beobj)
        {
            return daobk.ItemExpEnabled(beobj);
        }
        public Double ItemMrp(BELItem beobj)
        {
            return daobk.ItemMrp(beobj);
        }
        public SqlDataReader ItemSelect()
        {
            return daobk.ItemSelect();
        }
        public SqlDataReader ItemSuniqSelect(BELItem beobj)
        {
            return daobk.ItemuniqSelect(beobj);
        }
        public SqlDataReader ItemSTypeSelect(BELItem beobj)
        {
            return daobk.ItemtypeSelect(beobj);
        }
        public bool ItemSinsert(BELItem beobj)
        {
            return daobk.ItemInsert(beobj);
        }
        public bool ItemSupdate(BELItem beobj)
        {
            return daobk.ItemUpdate(beobj);
        }
        public bool ItemSDelete(BELItem beobj)
        {
            return daobk.ItemDelete(beobj);
        }
    }
    public class BALRec
    {
        BELRec beobj = new BELRec();
        DALRec daobj = new DALRec();
        public Int64 Getserial()
        {
            return daobj.getSerial();
        }
        public bool InsertRec(BELRec beobj)
        {
            return daobj.updateRecDet(beobj);
        }
        public SqlDataReader getBarcode(BELRec beobj)
        {
            return daobj.getbarcode(beobj);
        }
    }
    public class BALUser 
    {
        BELUser beobj = new BELUser();
        DALUser daobk = new DALUser();

        public SqlDataReader UserSelect()
        {
            return daobk.UserSelect();
        }
        public SqlDataReader UseruniqSelect(BELUser beobj)
        {
            return daobk.UseruniqSelect(beobj);
        }
        public SqlDataReader UserTypeSelect(BELUser beobj)
        {
            return daobk.UsertypeSelect(beobj);
        }
        public bool UserInsert(BELUser beobj)
        {
            return daobk.UserInsert(beobj);
        }
        public bool Userupdate(BELUser beobj)
        {
            return daobk.UserUpdate(beobj);
        }
        public bool UserDelete(BELUser beobj)
        {
            return daobk.UserDelete(beobj);
        }
    }
    public class BALDesp
    {
        BELDesp beobj = new BELDesp();
        DALDesp daobj = new DALDesp();
        public Int64 Getserial()
        {
            return daobj.getSerial();

        }
        public bool Insertdesp(BELDesp beobj)
        {
            return daobj.updateDespDet(beobj);
        }
        public double Itemstock(BELDesp beobj)
        {
            return daobj.ItemStock(beobj);
        }
        public SqlDataReader picklistprint(BELDesp beobj)
        {
            return daobj.picklistprint(beobj);
        }
    }
    public class BALLogin
    {
        BELLogin beobj = new BELLogin();
        DALLogin daobj = new DALLogin();
        public bool checklogin(BELLogin beobj)
        {
            return daobj.checklogin(beobj);
        }
    }
    public class BALRecRep
    {
        BELRecRep beobj = new BELRecRep();
        DALRecRep daobj = new DALRecRep();
        public SqlDataReader RecRep(BELRecRep beobj)
        {
            return daobj.RecReport(beobj);
        }
    }
    public class BALDespRep
    {
        BELDespRep beobj = new BELDespRep();
        DALDespRep daobj = new DALDespRep();
        public SqlDataReader DespRep(BELDespRep beobj)
        {
            return daobj.despReport(beobj);
        }
    }
}
