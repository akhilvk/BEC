using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using BELayer;
using System.Data;


namespace DALayer
{
    
   
      public class DAL
      {
          
         #region CustMaster
          public SqlConnection con = new SqlConnection(System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory+"Connection.INI"));
        public SqlCommand cmd = new SqlCommand();
                 
        public SqlDataReader CustSelect()
        {
            
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "select * from tbl_CustMast where cust_del=0";
            SqlDataReader da;
            da=cmd.ExecuteReader();
            return da;
        }
        public SqlDataReader CustuniqSelect(BEL beobj)
        {
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "select * from tbl_CustMast where cust_id=@id and cust_del=0";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", beobj._id);
            SqlDataReader da;
            da = cmd.ExecuteReader();
            return da;
        }
        public SqlDataReader CusttypeSelect(BEL beobj)
        {
            cmd.Connection = con;
            con.Open();
            string strname;
            strname = beobj._name;
            cmd.CommandText = "select * from tbl_CustMast where cust_name like '" + strname + "%' and cust_del=0";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@name", beobj._name);
            SqlDataReader da;
            da = cmd.ExecuteReader();
            return da;
        }
        public bool CustInsert(BEL beobj)
        {
            cmd.Connection = con;
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.CommandText = "Insert into tbl_CustMast values(@name,@add1,@add2,@add3,@phone,@email,0)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@name", beobj._name);
            cmd.Parameters.AddWithValue("@add1", beobj._add1);
            cmd.Parameters.AddWithValue("@add2", beobj._add2);
            cmd.Parameters.AddWithValue("@add3", beobj._add3);
            cmd.Parameters.AddWithValue("@phone", beobj._phone);
            cmd.Parameters.AddWithValue("@email", beobj._email);
            try
           {
             cmd.ExecuteNonQuery();
              return true;
           }
           catch(Exception ex)
           {
              return false;
           }
         }
        public bool CustUpdate(BEL beobj)
        {
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.CommandText = "Update Tbl_CustMast set cust_name=@name,Address1=@add1,Address2=@add2,Address3=@add3,Phone=@phone,email=@email where cust_id=@custid";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@custid", beobj._id);
            cmd.Parameters.AddWithValue("@name", beobj._name);
            cmd.Parameters.AddWithValue("@add1", beobj._add1);
            cmd.Parameters.AddWithValue("@add2", beobj._add2);
            cmd.Parameters.AddWithValue("@add3", beobj._add3);
            cmd.Parameters.AddWithValue("@phone", beobj._phone);
            cmd.Parameters.AddWithValue("@email", beobj._email);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool CustDelete(BEL beobj)
        {
            cmd.Connection = con;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.CommandText = "update tbl_CustMast set cust_del=1 where cust_id=@custid";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@custid", beobj._id);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
         #endregion CustMaster
        
      }
      public class DALItem
      {
          #region ItemMaster
          public SqlConnection con = new SqlConnection(System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory + "Connection.INI"));
          public SqlCommand cmd = new SqlCommand();
      
          public SqlDataReader ItemSelect()
          {
              cmd.Connection = con;
              con.Open();
              cmd.CommandText = "select * from tbl_ItemMast where Item_del=0";
              SqlDataReader da;
              da = cmd.ExecuteReader();
              return da;
          }
          public DataTable ReturningDataByQ(string query)
          {
              cmd.CommandText = query;
              cmd.Connection = con;
              //cmd1.CommandTimeout = 0
              cmd.CommandTimeout = 0;
              SqlDataAdapter adp = new SqlDataAdapter(cmd);
              DataTable dt = new DataTable();
              //adp.SelectCommand.CommandTimeout = 0
              adp.Fill(dt);
              //dr.Close()
              return dt;
          }

          public SqlDataReader ItemuniqSelect(BELItem beobj)
          {
              cmd.Connection = con;
              con.Open();
              cmd.CommandText = "select * from tbl_ItemMast where Item_id=@id and Item_del=0";
              cmd.Parameters.Clear();
              cmd.Parameters.AddWithValue("@id", beobj._id);
              SqlDataReader da;
              da = cmd.ExecuteReader();
              return da;
          }
          public bool ItemExpEnabled(BELItem beobj)
          {
              cmd.Connection = con;
              if (con.State == ConnectionState.Closed)
              {
                  con.Open();
              }
              cmd.CommandText = "select exp from tbl_ItemMast where Item_id=@id and Item_del=0";
              cmd.Parameters.Clear();
              cmd.Parameters.AddWithValue("@id", beobj._id);
              int i = Convert.ToInt32(cmd.ExecuteScalar());
              if (i == 1)
              { return true;
              }
              else { return false; }
          }
          public Double ItemMrp(BELItem beobj)
          {
              cmd.Connection = con;
              if (con.State == ConnectionState.Closed)
              {
                  con.Open();
              }
              cmd.CommandText = "select MRP from tbl_ItemMast where Item_id=@id and Item_del=0";
              cmd.Parameters.Clear();
              cmd.Parameters.AddWithValue("@id", beobj._id);
              double i = Convert.ToDouble(cmd.ExecuteScalar());
              return i;
          }
          public Int32  ItemPacks(BELItem beobj)
          {
              cmd.Connection = con;
              if (con.State == ConnectionState.Closed)
              {
                  con.Open();
              }
              cmd.CommandText = "select Noofpacks from tbl_ItemMast where Item_id=@id and Item_del=0";
              cmd.Parameters.Clear();
              cmd.Parameters.AddWithValue("@id", beobj._id);
              Int32 i = 0;
              try
              { i = Convert.ToInt32(cmd.ExecuteScalar()); }
              catch { }
             
              return i;
          }
          public SqlDataReader ItemtypeSelect(BELItem beobj)
          {
              cmd.Connection = con;
              con.Open();
              string strname;
              strname = beobj._Itemname;
              cmd.CommandText = "select * from tbl_ItemMast where Item_name like '" + strname + "%' and Item_del=0";
              cmd.Parameters.Clear();
              cmd.Parameters.AddWithValue("@name", beobj._Itemname);
              SqlDataReader da;
              da = cmd.ExecuteReader();
              return da;
          }
          public bool ItemInsert(BELItem beobj)
          {
              cmd.Connection = con;
              if (con.State == ConnectionState.Closed)
              {
                  con.Open();
              }
              cmd.CommandText = "Insert into tbl_ItemMast values(@name,@code,@mrp,@exp,0,@catid,@noofpacks)";
              cmd.Parameters.Clear();
              cmd.Parameters.AddWithValue("@name", beobj._Itemname);
              cmd.Parameters.AddWithValue("@code", beobj._ItemCode);
              cmd.Parameters.AddWithValue("@mrp", beobj._Mrp);
              cmd.Parameters.AddWithValue("@exp", beobj._Expiry);
              cmd.Parameters.AddWithValue("@catid", beobj.catid);
              cmd.Parameters.AddWithValue("@noofpacks", beobj.NoofPacks);
             
              try
              {
                  cmd.ExecuteNonQuery();
                  return true;
              }
              catch (Exception ex)
              {
                  return false;
              }
          }
          public bool ItemUpdate(BELItem beobj)
          {
              cmd.Connection = con;
              if (con.State == ConnectionState.Closed)
              {
                  con.Open();
              }
              cmd.CommandText = "Update Tbl_ItemMast set Item_name=@name,Item_code=@code,Mrp=@mrp,exp=@exp,CatId=@CatId,NoofPacks=@NoofPacks where Item_id=@Itemid";
              cmd.Parameters.Clear();
              cmd.Parameters.AddWithValue("@Itemid", beobj._id);
              cmd.Parameters.AddWithValue("@name", beobj._Itemname);
              cmd.Parameters.AddWithValue("@code", beobj._ItemCode);
              cmd.Parameters.AddWithValue("@mrp", beobj._Mrp);
              cmd.Parameters.AddWithValue("@exp", beobj._Expiry);
              cmd.Parameters.AddWithValue("@CatId", beobj.catid);
              cmd.Parameters.AddWithValue("@NoofPacks", beobj.NoofPacks);
              try
              {
                  cmd.ExecuteNonQuery();
                  return true;
              }
              catch (Exception ex)
              {
                  return false;
              }
          }
          public bool ItemDelete(BELItem beobj)
          {
              cmd.Connection = con;
              if (con.State == ConnectionState.Closed)
              {
                  con.Open();
              }
              cmd.CommandText = "update tbl_ItemMast set Item_del=1 where Item_id=@Itemid";
              cmd.Parameters.Clear();
              cmd.Parameters.AddWithValue("@Itemid", beobj._id);
              try
              {
                  cmd.ExecuteNonQuery();
                  return true;
              }
              catch (Exception ex)
              {
                  return false;
              }
          }
          
          #endregion ItemMaster
      }

      public class DALSupp
      {
          #region SuppMaster
          public SqlConnection con = new SqlConnection(System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory + "Connection.INI"));
          public SqlCommand cmd = new SqlCommand();

          public SqlDataReader SuppSelect()
          {

              cmd.Connection = con;
              con.Open();
              cmd.CommandText = "select * from tbl_SuppMast where Supp_del=0";
              SqlDataReader da;
              da = cmd.ExecuteReader();
              return da;
          }
          public SqlDataReader SuppuniqSelect(BELSupp beobj)
          {
              cmd.Connection = con;
              con.Open();
              cmd.CommandText = "select * from tbl_SuppMast where Supp_id=@id and Supp_del=0";
              cmd.Parameters.Clear();
              cmd.Parameters.AddWithValue("@id", beobj._id);
              SqlDataReader da;
              da = cmd.ExecuteReader();
              return da;
          }
          public SqlDataReader SupptypeSelect(BELSupp beobj)
          {
              cmd.Connection = con;
              con.Open();
              string strname;
              strname = beobj._name;
              cmd.CommandText = "select * from tbl_SuppMast where Supp_name like '" + strname + "%' and Supp_del=0";
              cmd.Parameters.Clear();
              cmd.Parameters.AddWithValue("@name", beobj._name);
              SqlDataReader da;
              da = cmd.ExecuteReader();
              return da;
          }
          public bool SuppInsert(BELSupp beobj)
          {
              cmd.Connection = con;
              if (con.State == ConnectionState.Closed)
              {
                  con.Open();
              }
              cmd.CommandText = "Insert into tbl_SuppMast values(@name,@add1,@add2,@add3,@phone,@email,0)";
              cmd.Parameters.Clear();
              cmd.Parameters.AddWithValue("@name", beobj._name);
              cmd.Parameters.AddWithValue("@add1", beobj._add1);
              cmd.Parameters.AddWithValue("@add2", beobj._add2);
              cmd.Parameters.AddWithValue("@add3", beobj._add3);
              cmd.Parameters.AddWithValue("@phone", beobj._phone);
              cmd.Parameters.AddWithValue("@email", beobj._email);
              try
              {
                  cmd.ExecuteNonQuery();
                  return true;
              }
              catch (Exception ex)
              {
                  return false;
              }
          }
          public bool SuppUpdate(BELSupp beobj)
          {
              cmd.Connection = con;
              if (con.State == ConnectionState.Closed)
              {
                  con.Open();
              }
              cmd.CommandText = "Update Tbl_SuppMast set Supp_name=@name,Address1=@add1,Address2=@add2,Address3=@add3,Phone=@phone,email=@email where Supp_id=@Suppid";
              cmd.Parameters.Clear();
              cmd.Parameters.AddWithValue("@Suppid", beobj._id);
              cmd.Parameters.AddWithValue("@name", beobj._name);
              cmd.Parameters.AddWithValue("@add1", beobj._add1);
              cmd.Parameters.AddWithValue("@add2", beobj._add2);
              cmd.Parameters.AddWithValue("@add3", beobj._add3);
              cmd.Parameters.AddWithValue("@phone", beobj._phone);
              cmd.Parameters.AddWithValue("@email", beobj._email);
              try
              {
                  cmd.ExecuteNonQuery();
                  return true;
              }
              catch (Exception ex)
              {
                  return false;
              }
          }
          public bool SuppDelete(BELSupp beobj)
          {
              cmd.Connection = con;
              if (con.State == ConnectionState.Closed)
              {
                  con.Open();
              }
              cmd.CommandText = "update tbl_SuppMast set Supp_del=1 where Supp_id=@Suppid";
              cmd.Parameters.Clear();
              cmd.Parameters.AddWithValue("@Suppid", beobj._id);
              try
              {
                  cmd.ExecuteNonQuery();
                  return true;
              }
              catch (Exception ex)
              {
                  return false;
              }
          }
          #endregion SuppMaster

      }
      public class DALRec 
      {
          public SqlConnection con = new SqlConnection(System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory + "Connection.INI"));
          public SqlCommand cmd = new SqlCommand();
          public SqlTransaction mytran;
          
          public Int64 getSerial()
          {
              cmd.Connection = con;
              if (con.State == ConnectionState.Closed)
              {
                  con.Open();
              }
              cmd.CommandText = "select isnull(max(rec_no),0)+1 from tbl_RecDet";
              cmd.Parameters.Clear();
              return Convert.ToInt32(cmd.ExecuteScalar());
          }
          public bool updateRecDet(BELRec beobj)
          {
              Int32 recno;
              cmd.Connection = con;
              if (con.State == ConnectionState.Closed)
              {
                  con.Open();
              }
              mytran = con.BeginTransaction();
              cmd.Transaction = mytran;
              try
              {
                  cmd.CommandText = "Insert Into tbl_RecDet output inserted.Rec_no values(@date,@suppid,@compname,@refno)";
                  cmd.Parameters.Clear();
                  cmd.Parameters.AddWithValue("@date", beobj._RecDate);
                  cmd.Parameters.AddWithValue("@suppid", beobj._Supp);
                  cmd.Parameters.AddWithValue("@compname", beobj._Compname);
                  cmd.Parameters.AddWithValue("@refno", beobj._Refno);
                  recno = Convert.ToInt32(cmd.ExecuteScalar());
                  cmd.Parameters.Clear();
                  string[] str;
                  int barcode;
                  string strbarcode;
                  for (int i = 0; i <= beobj._lstItems.Count - 1; i++)
                  {
                      str = beobj._lstItems[i].Split('|');
                      cmd.CommandText = "Insert into tbl_Rec_Sub values(@recno,@itemcode,@batch,@exp,@mrp,@prate,@qty)";
                      cmd.Parameters.Clear();
                      cmd.Parameters.AddWithValue("@recno", recno);
                      cmd.Parameters.AddWithValue("@itemcode", str[0]);
                      cmd.Parameters.AddWithValue("@batch", str[2]);
                      cmd.Parameters.AddWithValue("@exp", DateTime.Parse(str[3]));
                      cmd.Parameters.AddWithValue("@mrp", String.Format("{0:0,0.00}", str[4]));
                      cmd.Parameters.AddWithValue("@prate", String.Format("{0:0,0.00}", str[5]));
                      cmd.Parameters.AddWithValue("@qty", String.Format("{0:0,0.00}", str[6]));
                      cmd.ExecuteNonQuery();
                  }
                  cmd.Parameters.Clear();
                  cmd.CommandText = "SELECT IsNULL( MAX( SUBSTRING( serial_no, 2, LEN( serial_no ) ) ) , 10000000 )  FROM Tbl_barcode";
                  barcode = Convert.ToInt32(cmd.ExecuteScalar());
                  for (int i = 0; i <= beobj._lstItems.Count - 1; i++)
                  {
                      
                      str = beobj._lstItems[i].Split('|');
                      for (int j = 0; j <= Convert.ToDouble(str[6]) - 1; j++)
                      {
                          barcode = barcode + 1;
                          if (beobj._Compname == "BIO")
                          {
                              strbarcode = 'C' + Convert.ToString(barcode);
                          }
                          else
                              strbarcode = 'B' + Convert.ToString(barcode);
                          cmd.CommandText = "Insert into tbl_barcode values(@serialno,@recdate,@comp,@recno,@itemcode,@batch,@exp,@mrp,@prate,'',0,'',@NoofPacks)";
                          cmd.Parameters.Clear();
                          cmd.Parameters.AddWithValue("@serialno", strbarcode);
                          cmd.Parameters.AddWithValue("@recno", recno);
                          cmd.Parameters.AddWithValue("@recdate", beobj._RecDate);
                          cmd.Parameters.AddWithValue("@itemcode", str[0]);
                          cmd.Parameters.AddWithValue("@batch", str[2]);
                          cmd.Parameters.AddWithValue("@NoofPacks", str[7]);
                          cmd.Parameters.AddWithValue("@exp", DateTime.Parse(str[3]));
                          cmd.Parameters.AddWithValue("@mrp", String.Format("{0:0,0.00}", str[4]));
                          cmd.Parameters.AddWithValue("@prate", String.Format("{0:0,0.00}", str[5]));
                          cmd.Parameters.AddWithValue("@comp", beobj._Compname);
                          cmd.ExecuteNonQuery();
                      }
                  }
                  barcode = 0;
                  strbarcode = "";
                  mytran.Commit();
                  return true;
                  
              }
              catch (Exception ex)
              {
                  mytran.Rollback();
                  return false;

              }

          }
          public SqlDataReader getbarcode(BELRec beobj)
          {
              cmd.Connection = con;
              if (con.State == ConnectionState.Closed)
              {
                  con.Open();
              }
              cmd.CommandText = "select * from tbl_barcode A inner join tbl_itemmast B on A.item_code=B.item_id where A.rec_no=@recno";
              cmd.Parameters.Clear();
              cmd.Parameters.AddWithValue("@recno", beobj._Recno);
              try
              {
                  SqlDataReader da;
                  da = cmd.ExecuteReader();
                  return da;
              }
              catch (Exception ex)
              {
                  return null;
              }
         
          }
          
      }
      public class DALUser
      {
          #region ItemMaster
          public SqlConnection con = new SqlConnection(System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory + "Connection.INI"));
          public SqlCommand cmd = new SqlCommand();

          public SqlDataReader UserSelect()
          {

              cmd.Connection = con;
              con.Open();
              cmd.CommandText = "select * from tbl_UserMast where User_del=0";
              SqlDataReader da;
              da = cmd.ExecuteReader();
              return da;
          }
          public SqlDataReader UseruniqSelect(BELUser beobj)
          {
              cmd.Connection = con;
              con.Open();
              cmd.CommandText = "select * from tbl_UserMast where User_id=@id and User_del=0";
              cmd.Parameters.Clear();
              cmd.Parameters.AddWithValue("@id", beobj._id);
              SqlDataReader da;
              da = cmd.ExecuteReader();
              return da;
          }
          public SqlDataReader UsertypeSelect(BELUser beobj)
          {
              cmd.Connection = con;
              con.Open();
              string strname;
              strname = beobj._name;
              cmd.CommandText = "select * from tbl_UserMast where User_name like '" + strname + "%' and User_del=0";
              cmd.Parameters.Clear();
              cmd.Parameters.AddWithValue("@name", beobj._name);
              SqlDataReader da;
              da = cmd.ExecuteReader();
              return da;
          }
          public bool UserInsert(BELUser beobj)
          {
              cmd.Connection = con;
              if (con.State == ConnectionState.Closed)
              {
                  con.Open();
              }
              cmd.CommandText = "Insert into tbl_UserMast values(@name,@pwd,0)";
              cmd.Parameters.Clear();
              cmd.Parameters.AddWithValue("@name", beobj._name);
              cmd.Parameters.AddWithValue("@pwd", beobj._pwd);
             

              try
              {
                  cmd.ExecuteNonQuery();
                  return true;
              }
              catch (Exception ex)
              {
                  return false;
              }
          }
          public bool UserUpdate(BELUser beobj)
          {
              cmd.Connection = con;
              if (con.State == ConnectionState.Closed)
              {
                  con.Open();
              }
              cmd.CommandText = "Update Tbl_UserMast set User_name=@name,User_pwd=@pwd where User_id=@id";
              cmd.Parameters.Clear();
              cmd.Parameters.AddWithValue("@id", beobj._id);
              cmd.Parameters.AddWithValue("@name", beobj._name);
              cmd.Parameters.AddWithValue("@pwd", beobj._pwd);
            
              try
              {
                  cmd.ExecuteNonQuery();
                  return true;
              }
              catch (Exception ex)
              {
                  return false;
              }
          }
          public bool UserDelete(BELUser beobj)
          {
              cmd.Connection = con;
              if (con.State == ConnectionState.Closed)
              {
                  con.Open();
              }
              cmd.CommandText = "update tbl_UserMast set User_del=1 where User_id=@Itemid";
              cmd.Parameters.Clear();
              cmd.Parameters.AddWithValue("@Itemid", beobj._id);
              try
              {
                  cmd.ExecuteNonQuery();
                  return true;
              }
              catch (Exception ex)
              {
                  return false;
              }
          }
          #endregion ItemMaster
      }
      public class DALDesp
           {
               public SqlConnection con = new SqlConnection(System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory + "Connection.INI"));
               public SqlCommand cmd = new SqlCommand();
               public SqlTransaction mytran;

               public Int64 getSerial()
               {
                   cmd.Connection = con;
                   if (con.State == ConnectionState.Closed)
                   {
                       con.Open();
                   }
                   cmd.CommandText = "select isnull(max(Desp_no),0)+1 from tbl_DespDet";
                   cmd.Parameters.Clear();
                   return Convert.ToInt32(cmd.ExecuteScalar());
               }
               public bool updateDespDet(BELDesp beobj)
               {
                   Int32 desno;
                   cmd.Connection = con;
                   if (con.State == ConnectionState.Closed)
                   {
                       con.Open();
                   }
                   mytran = con.BeginTransaction();
                   cmd.Transaction = mytran;
                   try
                   {
                       cmd.CommandText = "Insert Into tbl_DespDet output inserted.Desp_no values(@date,@Custid,@compname,@refno,0)";
                       cmd.Parameters.Clear();
                       cmd.Parameters.AddWithValue("@date", beobj._DesDate);
                       cmd.Parameters.AddWithValue("@Custid", beobj._Cust);
                       cmd.Parameters.AddWithValue("@compname", beobj._Compname);
                       cmd.Parameters.AddWithValue("@refno", beobj._Refno);
                       desno = Convert.ToInt32(cmd.ExecuteScalar());
                       cmd.Parameters.Clear();
                       string[] str;
                       
                       for (int i = 0; i <= beobj._lstItems.Count - 1; i++)
                       {
                           str = beobj._lstItems[i].Split('|');
                           cmd.CommandText = "Insert into tbl_Desp_Sub values(@desno,@itemcode,@pqty,0)";
                           cmd.Parameters.Clear();
                           cmd.Parameters.AddWithValue("@desno", desno);
                           cmd.Parameters.AddWithValue("@itemcode", str[0]);
                         
                           cmd.Parameters.AddWithValue("@pqty", String.Format("{0:0,0.00}", str[2]));
                           cmd.ExecuteNonQuery();
                       }
                       cmd.Parameters.Clear();
                       
                       //barcode = Convert.ToInt32(cmd.ExecuteScalar());
                       for (int i = 0; i <= beobj._lstItems.Count - 1; i++)
                       {
                           
                           str = beobj._lstItems[i].Split('|');
                           if (str[3] == "True")
                           {
                               cmd.CommandText = "SELECT  Top " + str[2] + " * FROM Tbl_barcode where compname=@compname and item_code=@itemcode and status=1  order by expiry asc";

                           }
                           else
                           {
                               cmd.CommandText = "SELECT  Top " + str[2] + " * FROM Tbl_barcode where compname=@compname and item_code=@itemcode and status=1  order by store_date asc";
                           } 
                           cmd.Parameters.Clear();
                           cmd.Parameters.AddWithValue("@itemcode", str[0]);
                           cmd.Parameters.AddWithValue("@compname", beobj._Compname);
                           SqlDataReader da;
                           da = cmd.ExecuteReader();
                           DataTable dt=new DataTable();
                           dt.Load(da);
                           
                           if (dt.Rows.Count > 0)
                           {
                               for (int j = 0; j <= dt.Rows.Count - 1; j++)
                               {

                                   DataRow dr = dt.Rows[j];
                                   cmd.CommandText = "Insert into tbl_desp_barcode values(@desno,@itemcode,@serialno,@batch,@expiry,0,0)";
                                   cmd.Parameters.Clear();
                                   cmd.Parameters.AddWithValue("@serialno",dr["Serial_no"] );
                                   cmd.Parameters.AddWithValue("@expiry", dr["expiry"]);
                                   cmd.Parameters.AddWithValue("@batch", dr["batchno"]);
                                   cmd.Parameters.AddWithValue("@desno", desno);
                                   cmd.Parameters.AddWithValue("@itemcode", str[0]);
                                   cmd.ExecuteNonQuery();

                               }
                           }
                       }
                      
                       mytran.Commit();
                       return true;

                   }
                   catch (Exception ex)
                   {
                       mytran.Rollback();
                       return false;

                   }

               }
               public double ItemStock(BELDesp beobj)
               {
                   double qty;
                   cmd.Connection = con;
                   if (con.State == ConnectionState.Closed)
                   {
                       con.Open();
                   }
                   cmd.CommandText = "select sum1-sum3 as qty from  (select Count(*) as sum1 from tbl_barcode  where Item_code=@itemcode and Compname=@compname and status=1) A,(Select COUNT(*) as sum3 from [tbl_desp_barcode] C inner join Tbl_DespDet D on C.desp_no=D.Desp_no where C.item_code= @itemcode and C.status=0 And D.comp_name=@compname)B ";
                   cmd.Parameters.Clear();
                   cmd.Parameters.AddWithValue("@itemcode", beobj._ItemCode);
                   cmd.Parameters.AddWithValue("@compname", beobj._Compname);
                   try
                   {
                       qty = Convert.ToDouble(cmd.ExecuteScalar());
                       return qty;
                   }
                   catch (Exception ex)
                   {
                       return 0.0;
                   }
               }
               public SqlDataReader picklistprint(BELDesp beobj)
               {
                   cmd.Connection = con;
                   if (con.State == ConnectionState.Closed)
                   {
                       con.Open();
                   }

                   cmd.CommandType = CommandType.Text;
                   cmd.CommandText = "EXEC dbo.Picklist @despno=@dno";
                   cmd.Parameters.AddWithValue("@dno", beobj._Desno);
                   SqlDataReader da;
                   
                   try 
                   {
                       da = cmd.ExecuteReader();
                       return da;
                   }
                   catch(Exception ex)
                   {
                       return null;
                   }
               }
      }
      public class DALLogin
      {
          public SqlConnection con = new SqlConnection(System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory + "Connection.INI"));
          public SqlCommand cmd = new SqlCommand();
          public SqlTransaction mytran;
          public bool checklogin(BELLogin beobj)
          {
              cmd.Connection = con;
              if (con.State == ConnectionState.Closed)
              {
                  con.Open();
              }
              cmd.CommandText = "select * from tbl_UserMast where user_name=@uname and user_pwd=@pwd and user_del=0 ";
              cmd.Parameters.Clear();
              cmd.Parameters.AddWithValue("@uname", beobj._name);
              cmd.Parameters.AddWithValue("@pwd", beobj._pwd);
              try
              {
                  SqlDataReader da;
                  da = cmd.ExecuteReader();
                      if (da.HasRows)
                      {
                          return true;
                      }
                      else
                      {
                    return false;
                      }

              }
              catch (Exception ex)
              {
                  return false;
              }
 
          }
      }
      public class DALRecRep 
      {
          public SqlConnection con = new SqlConnection(System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory + "Connection.INI"));
          public SqlCommand cmd = new SqlCommand();
          public SqlTransaction mytran;
          public SqlDataReader RecReport(BELRecRep beobj)
          {
              cmd.Connection = con;
              if (con.State == ConnectionState.Closed)
              {
                  con.Open();
              }

              cmd.CommandType = CommandType.Text;
              cmd.CommandText = "EXEC dbo.RecieptRep @Item=@item,@from=@fromdate,@to=@todate,@comp=@comp";
              cmd.Parameters.AddWithValue("@item", beobj._name);
              cmd.Parameters.AddWithValue("@fromdate", beobj._from.ToString("yyyy-MM-dd"));
              cmd.Parameters.AddWithValue("@todate", beobj._to.ToString("yyyy-MM-dd"));
              cmd.Parameters.AddWithValue("@comp", beobj.Comp);
              SqlDataReader da;

              try
              {
                  da = cmd.ExecuteReader();
                  return da;
              }
              catch (Exception ex)
              {
                  return null;
              }
          }
      }
      public class DALDespRep
      {
          public SqlConnection con = new SqlConnection(System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory + "Connection.INI"));
          public SqlCommand cmd = new SqlCommand();
          public SqlTransaction mytran;
          public SqlDataReader despReport(BELDespRep beobj)
          {
              cmd.Connection = con;
              if (con.State == ConnectionState.Closed)
              {
                  con.Open();
              }

              cmd.CommandType = CommandType.Text;
              cmd.CommandText = "EXEC dbo.DespRep @Item=@item,@from=@fromdate,@to=@todate,@Comp=@Comp";
              cmd.Parameters.AddWithValue("@item", beobj._name);
              cmd.Parameters.AddWithValue("@Comp", beobj.Comp);
              cmd.Parameters.AddWithValue("@fromdate", beobj._from.ToString("yyyy-MM-dd"));
              cmd.Parameters.AddWithValue("@todate", beobj._to.ToString("yyyy-MM-dd"));
              SqlDataReader da;

              try
              {
                  da = cmd.ExecuteReader();
                  return da;
              }
              catch (Exception ex)
              {
                  return null;
              }
          }
      }
      public class DALPhyRep
      {
          public SqlConnection con = new SqlConnection(System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory + "Connection.INI"));
          public SqlCommand cmd = new SqlCommand();
          public SqlTransaction mytran;
          public SqlDataReader PhyReport(BELPhyRep beobj)
          {
              cmd.Connection = con;
              if (con.State == ConnectionState.Closed)
              {
                  con.Open();
              }

              cmd.CommandType = CommandType.Text;
              cmd.CommandText = "EXEC dbo.PhyVerRep @from=@fromdate,@to=@todate";
              cmd.Parameters.AddWithValue("@fromdate", beobj._from.ToString("yyyy-MM-dd"));
              cmd.Parameters.AddWithValue("@todate", beobj._to.ToString("yyyy-MM-dd"));
              SqlDataReader da;

              try
              {
                  da = cmd.ExecuteReader();
                  return da;
              }
              catch (Exception ex)
              {
                  return null;
              }
          }
      }
  }

