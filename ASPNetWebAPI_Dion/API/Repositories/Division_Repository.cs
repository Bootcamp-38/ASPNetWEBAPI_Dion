﻿using API.Repositories.Interface;
using API.ViewModel;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace API.Repositories
{
    public class Division_Repository : Division_Interface
    {
        DynamicParameters parameters = new DynamicParameters();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConn"].ConnectionString);
        public int Create(DivisionVM divisionVM)
        {
            var sp = "SP_Insert_Division";
            parameters.Add("@Name", divisionVM.Name);
            parameters.Add("@Dept_Id", divisionVM.Dept_Id);
            var create = connection.Execute(sp, parameters, commandType: CommandType.StoredProcedure);
            return create;
        }

        public int Delete(int id)
        {
            var sp = "SP_Delete_Division";
            parameters.Add("@Id", id);
            var delete = connection.Execute(sp, parameters, commandType: CommandType.StoredProcedure);
            return delete;
        }

        public IEnumerable<DivisionVM> Get()
        {
            var sp = "SP_GetAll_Division";
            var getData = connection.Query<DivisionVM>(sp, commandType: CommandType.StoredProcedure);
            return getData;
        }

        public async Task<IEnumerable<DivisionVM>> Get(int id)
        {
            var sp = "SP_GetById_Division";
            parameters.Add("@Id", id);
            var getDataById = await connection.QueryAsync<DivisionVM>(sp, parameters, commandType: CommandType.StoredProcedure);
            return getDataById;
        }

        public int Update(int id, DivisionVM divisionVM)
        {
            var sp = "SP_Update_Division";
            parameters.Add("@Id", id);
            parameters.Add("@Name", divisionVM.Name);
            parameters.Add("@Dept_Id", divisionVM.Dept_Id);
            var update = connection.Execute(sp, parameters, commandType: CommandType.StoredProcedure);
            //throw new NotImplementedException();
            return update;
        }
    }
}