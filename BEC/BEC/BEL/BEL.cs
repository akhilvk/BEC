using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BELayer
{
    public class BEL
    {
        public string _id;
        public string id { get { return _id; } set { _id = value; } }
        
        public string _name;
        public string name { get { return _name; } set { _name = value; } }

        public string _add1;
        public string add1 { get { return _add1; } set { _add1 = value; } }

        public string _add2;
        public string add2 { get { return _add2; } set { _add2 = value; } }

        public string _add3;
        public string add3 { get { return _add3; } set { _add3 = value; } }

        public string _phone;
        public string phone { get { return _phone; } set { _phone = value; } }

        public string _email;
        public string email { get { return _email; } set { _email = value; } }


    }
    public class BELSupp
    {
        public string _id;
        public string id { get { return _id; } set { _id = value; } }

        public string _name;
        public string name { get { return _name; } set { _name = value; } }

        public string _add1;
        public string add1 { get { return _add1; } set { _add1 = value; } }

        public string _add2;
        public string add2 { get { return _add2; } set { _add2 = value; } }

        public string _add3;
        public string add3 { get { return _add3; } set { _add3 = value; } }

        public string _phone;
        public string phone { get { return _phone; } set { _phone = value; } }

        public string _email;
        public string email { get { return _email; } set { _email = value; } }


    }
    public class BELItem
    {
        public string _id;
        public string id { get { return _id; } set { _id = value; } }

        public string _Itemname;
        public string name { get { return _Itemname; } set { _Itemname = value; } }

        public string _ItemCode;
        public string add1 { get { return _ItemCode; } set { _ItemCode = value; } }

        public string _Mrp;
        public string add2 { get { return _Mrp; } set { _Mrp = value; } }

        public int _Expiry;
        public int add3 { get { return _Expiry; } set { _Expiry = value; } }
        public int catid { get; set; }
        public int NoofPacks { get; set; }
    }
    public class BELRec
    {
        public string _Recno;
        public string Recno { get { return _Recno; } set { _Recno = value; } }

        public string _RecDate;
        public string RecDate { get { return _RecDate; } set { _RecDate = value; } }

        public string _Compname;
        public string Compname { get { return _Compname; } set { _Compname = value; } }

        public int _Supp;
        public int Supp { get { return _Supp; } set { _Supp = value; } }

        public string _Refno;
        public string Refno { get { return _Refno; } set { _Refno = value; } }

        public int _ItemCode;
        public int ItemCode { get { return _ItemCode; } set { _ItemCode = value; } }

        public DateTime _Expiry;
        public DateTime Expiry { get { return _Expiry; } set { _Expiry = value; } }

        public string _Mrp;
        public string Mrp { get { return _Mrp; } set { _Mrp = value; } }

        public string _Prate;
        public string Prate { get { return _Prate; } set { _Prate = value; } }

        public string _Qty;
        public string Qty { get { return _Qty; } set { _Qty = value; } }

        public List<string> _lstItems;
        public List<string> lstItems { get { return _lstItems; } set { _lstItems = value; } }

    }
    public class BELUser
    {
        public string _id;
        public string id { get { return _id; } set { _id = value; } }

        public string _name;
        public string name { get { return _name; } set { _name = value; } }

        public string _pwd;
        public string pwd { get { return _pwd; } set { _pwd = value; } }

    }
    public class BELLogin
    {
        
        public string _name;
        public string name { get { return _name; } set { _name = value; } }

        public string _pwd;
        public string pwd { get { return _pwd; } set { _pwd = value; } }

    }
    public class BELRecRep
    {
        public DateTime _from;
        public DateTime from { get { return _from; } set { _from = value; } }

        public DateTime _to;
        public DateTime to { get { return _to; } set { _to = value; } }

        public string _name;
        public string name { get { return _name; } set { _name = value; } }

        public string  Comp { get; set; }

    }
    public class BELDespRep
    {
        public DateTime _from;
        public DateTime from { get { return _from; } set { _from = value; } }

        public DateTime _to;
        public DateTime to { get { return _to; } set { _to = value; } }

        public string _name;
        public string name { get { return _name; } set { _name = value; } }

        public string  Comp { get; set; }

    }
    public class BELDesp
    {
        public string _Desno;
        public string Desno { get { return _Desno; } set { _Desno = value; } }

        public string _DesDate;
        public string DesDate { get { return _DesDate; } set { _DesDate = value; } }

        public string _Compname;
        public string Compname { get { return _Compname; } set { _Compname = value; } }

        public int _Cust;
        public int Cust { get { return _Cust; } set { _Cust = value; } }

        public string _Refno;
        public string Refno { get { return _Refno; } set { _Refno = value; } }

        public int _ItemCode;
        public int ItemCode { get { return _ItemCode; } set { _ItemCode = value; } }

        public int _Exp;
        public int Exp { get { return _Exp; } set { _Exp = value; } }


        public List<string> _lstItems;
        public List<string> lstItems { get { return _lstItems; } set { _lstItems = value; } }


    }
    public class BELPhyRep
    {
        public DateTime _from;
        public DateTime from { get { return _from; } set { _from = value; } }

        public DateTime _to;
        public DateTime to { get { return _to; } set { _to = value; } }

    }
}
