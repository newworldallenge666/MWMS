﻿using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using DTcms.DBUtility;
namespace DTcms.DAL
{
	 	//AllotOrder
		public partial class AllotOrder
	{
   		     
		public bool Exists(int Id,int SourceStoreId,int PurposeStoreId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from AllotOrder");
			strSql.Append(" where ");
			                                       strSql.Append(" Id = @Id and  ");
                                                                   strSql.Append(" SourceStoreId = @SourceStoreId and  ");
                                                                   strSql.Append(" PurposeStoreId = @PurposeStoreId  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@SourceStoreId", SqlDbType.Int,4),
					new SqlParameter("@PurposeStoreId", SqlDbType.Int,4)			};
			parameters[0].Value = Id;
			parameters[1].Value = SourceStoreId;
			parameters[2].Value = PurposeStoreId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DTcms.Model.AllotOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into AllotOrder(");			
            strSql.Append("SourceStoreId,PurposeStoreId,Remark,CreateTime,Admin");
			strSql.Append(") values (");
            strSql.Append("@SourceStoreId,@PurposeStoreId,@Remark,@CreateTime,@Admin");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@SourceStoreId", SqlDbType.Int,4) ,            
                        new SqlParameter("@PurposeStoreId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Admin", SqlDbType.VarChar,254)             
              
            };
			            
            parameters[0].Value = model.SourceStoreId;                        
            parameters[1].Value = model.PurposeStoreId;                        
            parameters[2].Value = model.Remark;                        
            parameters[3].Value = model.CreateTime;                        
            parameters[4].Value = model.Admin;                        
			   
			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);			
			if (obj == null)
			{
				return 0;
			}
			else
			{
				                    
            	return Convert.ToInt32(obj);
                                                                  
			}			   
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DTcms.Model.AllotOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update AllotOrder set ");
			                                                
            strSql.Append(" SourceStoreId = @SourceStoreId , ");                                    
            strSql.Append(" PurposeStoreId = @PurposeStoreId , ");                                    
            strSql.Append(" Remark = @Remark , ");                                    
            strSql.Append(" CreateTime = @CreateTime , ");                                    
            strSql.Append(" Admin = @Admin  ");            			
			strSql.Append(" where Id=@Id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@SourceStoreId", SqlDbType.Int,4) ,            
                        new SqlParameter("@PurposeStoreId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Admin", SqlDbType.VarChar,254)             
              
            };
						            
            parameters[0].Value = model.Id;                        
            parameters[1].Value = model.SourceStoreId;                        
            parameters[2].Value = model.PurposeStoreId;                        
            parameters[3].Value = model.Remark;                        
            parameters[4].Value = model.CreateTime;                        
            parameters[5].Value = model.Admin;                        
            int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AllotOrder ");
			strSql.Append(" where Id=@Id");
						SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;


			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
				/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AllotOrder ");
			strSql.Append(" where ID in ("+Idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
				
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DTcms.Model.AllotOrder GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id, SourceStoreId, PurposeStoreId, Remark, CreateTime, Admin  ");			
			strSql.Append("  from AllotOrder ");
			strSql.Append(" where Id=@Id");
						SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			
			DTcms.Model.AllotOrder model=new DTcms.Model.AllotOrder();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["SourceStoreId"].ToString()!="")
				{
					model.SourceStoreId=int.Parse(ds.Tables[0].Rows[0]["SourceStoreId"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["PurposeStoreId"].ToString()!="")
				{
					model.PurposeStoreId=int.Parse(ds.Tables[0].Rows[0]["PurposeStoreId"].ToString());
				}
																																				model.Remark= ds.Tables[0].Rows[0]["Remark"].ToString();
																												if(ds.Tables[0].Rows[0]["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
				}
																																				model.Admin= ds.Tables[0].Rows[0]["Admin"].ToString();
																										
				return model;
			}
			else
			{
				return null;
			}
		}
		
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM AllotOrder ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" * ");
			strSql.Append(" FROM AllotOrder ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

   
	}
}

